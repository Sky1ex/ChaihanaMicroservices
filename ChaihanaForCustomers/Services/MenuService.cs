using AspireForChaihana.ServiceDefaults.Models.Cafe;
using AspireForChaihana.ServiceDefaults.Repository.Default;

namespace WebApplication1.Services
{
    public class MenuService
    {
        private readonly ILogger<CartService> _logger;
        private readonly IUnitOfWorkCafe _unitOfWorkCafe;

        public MenuService(ILogger<CartService> logger, IUnitOfWorkCafe unitOfWorkCafe)
        {
            _logger = logger;
            _unitOfWorkCafe = unitOfWorkCafe;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await _unitOfWorkCafe.Categories.GetAllAsync();
            return categories.ToList();
        }

		public async Task<List<Product>> GetProducts()
		{
			var products = await _unitOfWorkCafe.Products.GetAllAsync();
			return products.ToList();
		}
	}
}
