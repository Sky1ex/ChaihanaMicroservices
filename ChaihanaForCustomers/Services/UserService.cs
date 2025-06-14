﻿using SharedLibrary.Models.Customers;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SharedLibrary.DataBase_and_more;
using WebApplication1.DTO;
using SharedLibrary.Repository.Default;

namespace WebApplication1.OtherClasses
{
    public class UserService
    {
        private readonly IUnitOfWorkCustomers _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly string role = "userId";

        public UserService(IHttpContextAccessor httpContextAccessor, IUnitOfWorkCustomers unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUser(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            return _mapper.Map<UserDto>(user);

        }

        public async Task<bool> CheckPhone(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            return user.Phone != string.Empty;
        }

        public async Task<Guid> GetLogin()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new InvalidOperationException("HttpContext is not available.");
            }

            // Проверяем JWT токен
            var jwtToken = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            Guid userId;

            if (string.IsNullOrEmpty(jwtToken) || !AuthOptions.ValidateToken(jwtToken, role, out userId))
            {
                // Создаем нового пользователя
                userId = Guid.NewGuid();
                var cart = new Cart() { CartId = Guid.NewGuid() };
                var user = new User { UserId = userId, Cart = cart };
                cart.User = user;

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.SaveChangesAsync();

                AuthOptions.SetJwtCookie(httpContext, userId, role);

                // Генерируем новый токен
                var newToken = AuthOptions.GenerateJwtToken(userId, role);
                httpContext.Response.Headers.Append("Authorization", $"Bearer {newToken}");
            }

            return userId;
        }

        public bool SetLogin(Guid login)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new InvalidOperationException("HttpContext is not available.");
            }

            AuthOptions.SetJwtCookie(httpContext, login, role);

            return true;
        }
    }
}
