using GttpGtrpLib.Models;

namespace S_TextChannels.Models
{
    public class GttpContext
    {
        public GttpRequest Request { get; set; }

        public AuthenticateResult AuthenticateResult { get; set; }

        /*
            Здесь должно быть какие-нибудь поле,
            в которое будет помещаться результат обработки
            конечной точки по обработке сообщений.
        */
    }
}
