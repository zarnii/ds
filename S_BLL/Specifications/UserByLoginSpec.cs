using S_DAL.Models;
using System.Linq.Expressions;

namespace S_BLL.Specifications
{
    internal class UserByLoginSpec : Specification<User>
    {
        private readonly string Login;

        public UserByLoginSpec(string login)
        {
            Login = login;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return (user) => user.Login == Login;
        }
    }
}
