using GttpGtrpLib.Models;
using GttpGtrpLib.Exceptions;
using ValidationLib;

namespace GttpGtrpLib.Utils
{
    public class GttpRequestParser
    {
        private const string UserIdentityLiteral = "UserIdentity";

        private const string ChatIdentityLiteral = "ChatIdentity";

        private const string ReplyToIdentityLiteral = "ReplyToIdentity";

        private const string TextModificatorsLiteral = "TextModificators";

        private const string MessageTextLiteral = "MessageText";

        private const char SeparatorLiteral = ':';

        private const char EndStringLabelLiteral = ';';

        private const int UserIdentityLiteralLength = 12;

        private const int ChatIdentityLiteralLength = 12;

        private const int ReplyToIdentityLiteralLength = 15;

        private const int TextModificatorsLiteralLength = 16;

        private const int MessageTextLiteralLength = 11;

        private const int SeparatorLiteralLength = 1;

        private const int SeparatorCountInRequest = 4;

        private const int EndStringLabelCountInRequest = 4;

        public GttpRequest Parse(string request)
        {
            ValidatorOfString.CheckStringIsNotNull(request);

            var requestField = request.Replace(" ", "").Split(EndStringLabelLiteral);
            var map = new Dictionary<string, string>();

            foreach (var field in requestField) 
            { 
                var keyValue = field.Split(SeparatorLiteral);
                map.Add(keyValue[0], keyValue[1]);
            }

            try
            {
                var gttpRequest = new GttpRequest();
                gttpRequest.UserIdentity = map[UserIdentityLiteral];
                gttpRequest.ChatIdentity = map[ChatIdentityLiteral];
                gttpRequest.ReplyToIdentity = map[ReplyToIdentityLiteral];
                gttpRequest.TextModificators = map[TextModificatorsLiteral];
                gttpRequest.MessageText = map[MessageTextLiteral];

                return gttpRequest;
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidGttpRequestException(ex.Message);
            }
            
        }
    }
}
