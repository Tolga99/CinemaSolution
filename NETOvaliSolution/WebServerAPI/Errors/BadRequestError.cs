using System.Net;

namespace WebServerAPI
{
    public class BadRequestError : ApiErrors
    {
       public BadRequestError() : base(400, HttpStatusCode.BadRequest.ToString())
    {

    }


    public BadRequestError(string message) : base(400, HttpStatusCode.BadRequest.ToString(), message)
    {
    }
}
}