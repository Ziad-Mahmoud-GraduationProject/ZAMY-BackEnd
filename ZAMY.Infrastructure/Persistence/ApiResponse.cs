using System.Net;

namespace ZAMY.Infrastructure.Persistence
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public List<string> ErrorMessage { get; set; } = new List<string>();
        public object Result { get; set; }
    }
}
