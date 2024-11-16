namespace S_BLL.Model.DTO
{
    public struct RequestToJoinDto
    {
        public bool AcceptPolitics { get; set; }

        public string Login { get; set; }

        public string Username { get; set; }

        public string UserPassword { get; set; }

        public string ServerPassword { get; set; }
    }
}
