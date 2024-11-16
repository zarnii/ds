using S_BLL.Model;
using S_BLL.Specifications;
using S_DAL.Models;
using S_DAL.Contexts;
using S_BLL.Model.DTO;
using S_BLL.Model.StatusCodes;

namespace S_BLL.BL
{
    public class JoinToServerBl
    {
        private readonly ServerConfig ServerConfig;

        private readonly UserContext UserContext;

        private readonly RequestToConnectContext RequestToConnectContext;

        public JoinToServerBl(
            ServerConfig serverConfig, 
            UserContext userContext,
            RequestToConnectContext requestToConnectContext)
        {
            ArgumentNullException.ThrowIfNull(serverConfig, nameof(serverConfig));
            ArgumentNullException.ThrowIfNull(userContext, nameof(userContext));
            ArgumentNullException.ThrowIfNull(requestToConnectContext, nameof(requestToConnectContext));

            ServerConfig = serverConfig;
            UserContext = userContext;
            RequestToConnectContext = requestToConnectContext;
        }

        public bool CheckServerIsOpen()
        {
            return ServerConfig.GetIsOpen();
        }

        public async Task<ServerPolitics> GetServerPolitics()
        {
            var accessType = ServerConfig.GetAccessType();
            var hasPolitics = ServerConfig.GetHasPolitics();
            var politics = await ServerConfig.GetPolitics();

            return new ServerPolitics()
            {
                HasPolitics = hasPolitics,
                Politics = politics,
                AccessType = accessType
            };
        }

        public async Task<ResponseToJoin> AcceptJoinRequest(RequestToJoinDto request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var loginSpecification = new UserByLoginSpec(request.Login);
            var userCount = UserContext.Users
                .Where(loginSpecification.ToExpression())
                .Count();
            
            if (userCount != 0)
            {
                return new ResponseToJoin() 
                { 
                    ValidateDataStatusCode = ValidateUserDataStatusCode.InvalidLogin,
                    Message = "Пользователь с таким логином уже существует"
                };
            }

            return await CreateResponse(request);
        }

        private async Task<ResponseToJoin> CreateResponse(RequestToJoinDto request)
        {
            var serverAcceptType = ServerConfig.GetAccessType();

            if (serverAcceptType == AccessType.Password)
            {
                if (request.ServerPassword == ServerConfig.GetPassword())
                {
                    await CreateUser(request.Username, request.Login, request.UserPassword);

                    return new ResponseToJoin(
                        ValidateUserDataStatusCode.Success, 
                        String.Empty
                    );
                }
                else
                {
                    return new ResponseToJoin(
                        ValidateUserDataStatusCode.InvalidPassword,
                        "Неверный пароль"
                    );
                }
            }
            else if (serverAcceptType == AccessType.Open)
            {
                await CreateUser(request.Username, request.Login, request.UserPassword);

                return new ResponseToJoin(
                        ValidateUserDataStatusCode.Success,
                        String.Empty
                );
            }
            else
            {
                await CreateRequest(request.Username, request.Login, request.UserPassword);

                return new ResponseToJoin(
                    ValidateUserDataStatusCode.Success,
                    String.Empty
                );
            }
        }

        private async Task CreateUser(string username, string login, string password)
        {
            UserContext.Users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Login = login,
                Username = username,
                Password = password
            });

            await UserContext.SaveChangesAsync();
        }

        private async Task CreateRequest(string username, string login, string password)
        {
            RequestToConnectContext.RequestToConnects.Add(new RequestToConnect()
            {
                Id = Guid.NewGuid(),
                Login = login,
                Username = username,
                Password = password
            });

            await RequestToConnectContext.SaveChangesAsync();
        }
    }
}
