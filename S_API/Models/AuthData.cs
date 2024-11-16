namespace S_API.Models
{
    public struct AuthData
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public AuthData(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
