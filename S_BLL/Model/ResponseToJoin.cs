using S_BLL.Model.DTO;
using S_BLL.Model.StatusCodes;

namespace S_BLL.Model
{
    public struct ResponseToJoin
    {
        public ValidateUserDataStatusCode ValidateDataStatusCode {  get; set; }

        public string Message { get; set; }

        public ResponseToJoin(
            ValidateUserDataStatusCode statusCode, 
            string message)
        {
            ValidateDataStatusCode = statusCode;
            Message = message;
        }
    }
}
