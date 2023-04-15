using WebAPI.Utils.Constants;

namespace WebAPI.Utils.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string message = "Not Found")
        {
            this.message = message;
            this.statuscode = StatusCode.NOT_FOUND;
            this.errorcode = StatusCode.NOT_FOUND;
        }
    }
}
