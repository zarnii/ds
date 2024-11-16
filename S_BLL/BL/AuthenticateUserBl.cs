using Microsoft.EntityFrameworkCore;
using S_BLL.Model;
using S_BLL.Specifications;
using S_DAL.Contexts;
using System.Security.Claims;
using ValidationLib;

namespace S_BLL.BL
{
    public class AuthenticateUserBl
    {
        private readonly UserContext UserContext;

        private readonly string AuthenticationScheme = "Cookie";

        public AuthenticateUserBl(UserContext userContext)
        {
            ArgumentNullException.ThrowIfNull(userContext, nameof(userContext));

            UserContext = userContext;
        }

        public async Task<(ClaimsPrincipal, UserIdentity)> AuthenticateUser(string login, string password)
        {
            ValidatorOfString.CheckStringIsNotNull(login, nameof(login));
            ValidatorOfString.CheckStringIsNotNull(password, nameof(password));

            var userByLoginSpec = new UserByLoginSpec(login);
            var user = await UserContext.Users.
                Where(userByLoginSpec.ToExpression())
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Пользователь с переданными логином не найден", nameof(login));
            }

            if (password != user.Password)
            {
                throw new ArgumentException("Неверный пароль", nameof(password));
            }

            var claims = new List<Claim>()
            {
                new Claim("Identity", user.Identity.ToString())
            };

            return new(
                new ClaimsPrincipal(new ClaimsIdentity(claims, AuthenticationScheme)),
                new UserIdentity(BitConverter.GetBytes(user.Identity)));
        }


    }
}
