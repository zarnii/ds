using S_TextChannels.Middleware.Interfaces;
using S_TextChannels.Models;
using S_BLL.Model;
using S_BLL.Specifications;
using S_DAL.Contexts;

namespace S_TextChannels.Middleware
{
    public class AuthenticationMw : IMiddlaware
    {
        private readonly UserContext UserContext;

        public AuthenticationMw(UserContext userContext) 
        { 
            ArgumentNullException.ThrowIfNull(userContext, nameof(userContext));

            UserContext = userContext;
        }

        public async Task<GttpContext> HandleGttpContext(GttpContext context, IMiddlewareIterator iterator)
        {
            var userByIdentitySpec = 
                new UserByIdentitySpec(new UserIdentity(context.Request.UserIdentity));

            var user = UserContext.Users
                .Where(userByIdentitySpec.ToExpression())
                .FirstOrDefault();

            context.AuthenticateResult = user == null
                ? AuthenticateResult.Ivalid
                : AuthenticateResult.Success;

            if (!iterator.IsDone())
            {
                var next = iterator.GetNext();

                return await next.HandleGttpContext(context, iterator);
            }

            return context;
        }
    }
}
