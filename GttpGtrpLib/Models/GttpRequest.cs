namespace GttpGtrpLib.Models
{
    public struct GttpRequest
    {
        public string UserIdentity { get; set; }

        public string ChatIdentity { get; set; }

        public string ReplyToIdentity { get; set; }

        public string TextModificators { get; set; }

        public string MessageText { get; set; }
    }
}
