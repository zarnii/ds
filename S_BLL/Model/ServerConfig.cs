using S_BLL.Model.DTO;
using System.Configuration;
using System.Text.Json;

namespace S_BLL.Model
{
    public class ServerConfig
    {
        private readonly Configuration Config;

        private const string IsOpenLiteral = "IsOpen";

        private const string HasPoliticsLiteral = "HasPolitics";

        private const string PathToPoliticsFileLiteral = "PathToPoliticsFile";

        private const string AccessTypeLiteral = "AccessType";

        private const string PasswordLiteral = "Password";

        private const string PathToEndpointsConfigLiteral = "PathToEndpointsConfig";

        private const string MaxConnectedClientAtOnceLiteral = "MaxConnectedClientAtOnce";

        private const string ConnectionStringLiteral = "ConnectionString";

        public ServerConfig(string pathToConfig)
        {
            if (String.IsNullOrEmpty(pathToConfig))
            {
                throw new ArgumentNullException(nameof(pathToConfig));
            }

            var configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = pathToConfig;
            Config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        public AccessType GetAccessType()
        {
            return ParseServerAccessType(TryGetConfigValue(AccessTypeLiteral));
        }

        public bool GetIsOpen()
        {
            return Boolean.Parse(TryGetConfigValue(IsOpenLiteral));
        }

        public bool GetHasPolitics()
        {
            return Boolean.Parse(TryGetConfigValue(HasPoliticsLiteral));
        }

        public string GetPassword()
        {
            return TryGetConfigValue(PasswordLiteral);
        }

        public async Task<string> GetPolitics()
        {
            var pathToFile = TryGetConfigValue(PathToPoliticsFileLiteral);
            return await File.ReadAllTextAsync(pathToFile);
        }

        public uint GetMaxConnectedClientAtOnce()
        {
            return uint.Parse(TryGetConfigValue(MaxConnectedClientAtOnceLiteral));
        }

        public async Task<ServerEndpointsDto> GetServerEndpoints()
        {
            var endpointsStr = await File.ReadAllTextAsync(
                TryGetConfigValue(PathToEndpointsConfigLiteral));

            return JsonSerializer.Deserialize<ServerEndpointsDto>(endpointsStr);
        }

        public string GetConnectionString()
        {
            return TryGetConfigValue(ConnectionStringLiteral);
        }

        private string TryGetConfigValue(string key)
        {
            try
            {
                return Config.AppSettings.Settings[key].Value;
            }
            catch (NullReferenceException)
            {
                throw new KeyNotFoundException($"В файле концигурации отсутсвует параметр с ключем \"{key}\"");
            }
        }

        private AccessType ParseServerAccessType(string accessType)
        {
            var accessTypeLower = accessType.ToLower();

            if (accessTypeLower == "open")
            {
                return AccessType.Open;
            }
            else if (accessTypeLower == "request")
            {
                return AccessType.Request;
            }
            else if (accessTypeLower == "password")
            {
                return AccessType.Password;
            }
            else
            {
                throw new ArgumentException("Переданная строка не соответствует ни одному типу доступа.");
            }
        }
    }
}
