using S_BLL.Model;
using S_DAL.Models;
using System.Linq.Expressions;

namespace S_BLL.Specifications
{
    public class UserByIdentitySpec : Specification<User>
    {
        private readonly UserIdentity UserIdentity;
        public UserByIdentitySpec(UserIdentity userIdentity)
        {
            UserIdentity = userIdentity;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return (user) => 
                new UserIdentity(BitConverter.GetBytes(user.Identity)) 
                == UserIdentity;
        }
    }
}
