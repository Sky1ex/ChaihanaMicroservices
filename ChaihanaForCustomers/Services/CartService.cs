using DefaultLibrary.Models.Customers;
using DefaultLibrary.Repository.Default;
using FluentAssertions;
using MapsterMapper;
using WebApplication1.DTO;

namespace WebApplication1.Services
{
    public class CartService : ICartService
    {
        private readonly ILogger<CartService> _logger;
        private readonly IUnitOfWorkCustomers _unitOfWorkCustomers;
		private readonly IUnitOfWorkCafe _unitOfWorkCafe;
		private readonly IMapper _mapper;

		public CartService(ILogger<CartService> logger, IUnitOfWorkCustomers unitOfWorkCustomers, IUnitOfWorkCafe unitOfWorkCafe, IMapper mapper)
        {
            _logger = logger;
            _unitOfWorkCustomers = unitOfWorkCustomers;
            _unitOfWorkCafe = unitOfWorkCafe;
            _mapper = mapper;
        }

        public async Task<CartDto> GetCartAsync(Guid userId)
        {
            var cart = await _unitOfWorkCustomers.Carts.GetByUserIdFull(userId);

			if (cart == null)
			{
				_logger.LogWarning("Корзина для пользователя {UserId} не найдена.", userId);
				throw new InvalidOperationException("Корзина не найдена.");
			}

			var productIds = cart.CartElement.Select(ce => ce.ProductId).Distinct().ToList();
			var products = _unitOfWorkCafe.Products.GetProducts(productIds);
			var productDict = products.ToDictionary(p => p.ProductId);

			var cartDto = _mapper.Map<CartDto>(cart);

			foreach (var element in cartDto.CartElement)
			{
				if (productDict.TryGetValue(element.ProductId, out var product))
				{
					element.product = _mapper.Map<ProductDto>(product);
				}
			}
            /*return _mapper.Map<CartDto>(cart);*/
            return cartDto;
        }
        public async Task RemoveFromCartAsync(Guid userId, Guid productId)
        {
            var cart = await _unitOfWorkCustomers.Carts.GetByUserIdWithCartElements(userId);

            if (cart == null)
            {
                _logger.LogWarning("Корзина для пользователя {UserId} не найдена.", userId);
                throw new InvalidOperationException("Корзина не найдена.");
            }

            var cartElement = cart.CartElement.FirstOrDefault(ce => ce.ProductId == productId);
            if (cartElement == null)
            {
                _logger.LogWarning("Элемент коризны {UserId} не найдена.", userId);
                throw new InvalidOperationException("Элемент корзины не найден.");
            }
            else
            {
                cart.CartElement.Remove(cartElement);
                _unitOfWorkCustomers.CartElements.Delete(cartElement);
                await _unitOfWorkCustomers.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(Guid userId)
        {
            var cart = await _unitOfWorkCustomers.Carts.GetByUserIdWithCartElements(userId);

            if (cart == null)
            {
                _logger.LogWarning("Корзина для пользователя {UserId} не найдена.", userId);
                throw new InvalidOperationException("Корзина не найдена.");
            }

            cart.CartElement.Clear();
            await _unitOfWorkCustomers.SaveChangesAsync();
        }

        // Обновление количества товара в корзине
        public async Task UpdateCartItemQuantityAsync(Guid userId, Guid productId, int change)
        {
            var cart = await _unitOfWorkCustomers.Carts.GetByUserIdFull(userId);

            if (cart == null)
            {
                _logger.LogWarning("Корзина для пользователя {UserId} не найдена.", userId);
                throw new InvalidOperationException("Корзина не найдена.");
            }

            var cartElement = cart.CartElement.FirstOrDefault(ce => ce.ProductId == productId);

            if (cartElement != null)
            {
                cartElement.Count += change;

                if (cartElement.Count <= 0)
                {
                    cart.CartElement.Remove(cartElement);
                    _unitOfWorkCustomers.CartElements.Delete(cartElement);
                }
            }
            else
            {
                var product = await _unitOfWorkCafe.Products.GetByIdAsync(productId);

                if(product == null)
                {
                    _logger.LogWarning("Продукт {productId} не найден.", productId);
                    throw new InvalidOperationException("Продукт не найден.");
                }

                CartElement newCartElem = new CartElement
                {
                    CartElementId = Guid.NewGuid(),
                    ProductId = product.ProductId,
                    Count = change
                };
                cart.CartElement.Add(newCartElem);

                await _unitOfWorkCustomers.CartElements.AddAsync(newCartElem);
            }

            await _unitOfWorkCustomers.SaveChangesAsync();
        }

        // Оформление выбранных товаров
        public async Task<OrderDto> CheckoutSelectedAsync(Guid userId, List<Guid> productIds, Guid addressId)
        {
            var cart = await _unitOfWorkCustomers.Carts.GetByUserIdFull(userId);

            var user = await _unitOfWorkCustomers.Users.GetByIdWithOrders(userId);

            if (cart == null || !cart.CartElement.Any())
            {
                _logger.LogWarning("Корзина для пользователя {UserId} пуста.", userId);
                throw new InvalidOperationException("Корзина пуста.");
            }

            var address = await _unitOfWorkCustomers.Addresses.GetByIdAsync(addressId);
            if (address == null)
            {
                _logger.LogWarning("Адрес {AddressId} не найден.", addressId);
                throw new InvalidOperationException("Адрес не найден.");
            }

            var selectedCartElements = cart.CartElement
                .Where(ce => productIds.Contains(ce.ProductId))
                .ToList();

            if (!selectedCartElements.Any())
            {
                _logger.LogWarning("Выбранные товары не найдены в корзине.");
                throw new InvalidOperationException("Товары не найдены.");
            }

            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                dateTime = DateTimeOffset.UtcNow,
                Adress = new AddressElement
                {
                    AddressElementId = Guid.NewGuid(),
                    City = address.City,
                    Street = address.Street,
                    House = address.House,
                    Apartment = address.Apartment
                },
                OrderElement = selectedCartElements.Select(ce => new OrderElement
                {
                    OrderElementId = Guid.NewGuid(),
                    ProductId = ce.ProductId,
                    Count = ce.Count
                }).ToList()
            };

            await _unitOfWorkCustomers.Orders.AddAsync(order);
            user.Orders.Add(order);

            // Удаляем выбранные товары из корзины
            foreach (var cartElement in selectedCartElements)
            {
                cart.CartElement.Remove(cartElement);
                _unitOfWorkCustomers.CartElements.Delete(cartElement);
            }

            await _unitOfWorkCustomers.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }
    }
}
