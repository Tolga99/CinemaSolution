using System.Net;

namespace WebServerAPI
{
    public class NotFoundError : ApiErrors
    {
        public NotFoundError() : base(404, HttpStatusCode.NotFound.ToString())
        {

        }


        public NotFoundError(string message) : base(404, HttpStatusCode.NotFound.ToString(), message)
        {
        }
    }
}