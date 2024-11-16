namespace S_BLL.Model.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserIdentity Identity { get; set; }

        public IList<MessageDto> Messages { get; set; }

        public IList<RoleDto> Roles { get; set; }
    }
}
