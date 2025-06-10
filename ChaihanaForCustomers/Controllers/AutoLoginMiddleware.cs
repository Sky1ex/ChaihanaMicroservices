using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SharedLibrary.DataBase_and_more;
using SharedLibrary.Repository.Default;
using SharedLibrary.Models.Customers;
using Twilio.Rest.PreviewIam.Organizations;

namespace WebApplication1.Controllers
{
    public class AutoLoginMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly string role = "userId";

        public AutoLoginMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(
        HttpContext context,
        IConfiguration config, IUnitOfWorkCustomers _unitOfWork)
        {
            // Проверяем куку
            var jwtToken = context.Request.Cookies["jwt_token"];
            Guid userId;

            if (string.IsNullOrEmpty(jwtToken) || !AuthOptions.ValidateToken(jwtToken, role, out userId))
            {
                // Создаем нового пользователя
                userId = Guid.NewGuid();
                var cart = new Cart { CartId = Guid.NewGuid() };
                var user = new User { UserId = userId, Cart = cart };

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

                // Устанавливаем новую куку с токеном
                AuthOptions.SetJwtCookie(context, userId, role);

                // Добавляем токен в заголовки текущего запроса
                context.Request.Headers.Append("Authorization", $"Bearer {AuthOptions.GenerateJwtToken(userId, role)}");
            }
            else
            {
                // Если токен валиден, добавляем его в заголовки
                context.Request.Headers.Append("Authorization", $"Bearer {jwtToken}");
            }

            await _next(context);
        }

    }
}
