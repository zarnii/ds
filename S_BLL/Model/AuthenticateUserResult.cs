using S_BLL.Model.StatusCodes;
using System.Security.Claims;

namespace S_BLL.Model
{
    public struct AuthenticateUserResult
    {
        public ClaimsPrincipal? ClaimsPrincipal { get; set; }

        public UserIdentity? UserIdentity { get; set; }

        public AuthenticateUserResult(
            ClaimsPrincipal claimsPrincipal,
            UserIdentity? userIdentity)
        {
            ClaimsPrincipal = claimsPrincipal;
            UserIdentity = userIdentity;
        }
    }
}
