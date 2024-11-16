namespace S_BLL.Model.DTO
{
    public struct ServerPolitics
    {
        public bool HasPolitics { get; set; }

        public string? Politics { get; set; }

        public AccessType AccessType { get; set; }
    }
}
