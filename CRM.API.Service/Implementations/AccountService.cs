using CRM.API.Interfaces;
using CRM.API.Models;
using CRM.API.Response;
using CRM.DAL;
using CRM.Domain.Helpers;
using CRM.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace CRM.API.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<Author> _userRepository;

        public AccountService(IBaseRepository<Author> userRepository)
        {
            _userRepository = userRepository;
        }

        private ClaimsIdentity Authenticate(Author user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }

                if (user.Password != HashPassword.HashPas(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль или логин"
                    };
                }
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }

    }
}
