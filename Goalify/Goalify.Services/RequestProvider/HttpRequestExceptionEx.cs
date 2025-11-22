using System.Net;

namespace Goalify.Services.RequestProvider
{
    public class HttpRequestExceptionEx : HttpRequestException
    {
        public HttpRequestExceptionEx(HttpStatusCode code, string? message = null, Exception? inner = null)
            : base(message, inner)
        {
            HttpCode = code;
        }

        public HttpStatusCode HttpCode { get; }
    }

    public class ServiceAuthenticationException : Exception
    {
        public ServiceAuthenticationException(string content)
            : base($"Authentication failed: {content}")
        {
        }
    }
}
