using System.Net;

namespace ZAMY.Application.Common.Helper
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public List<string> ErrorMessage { get; set; }
        public object Result { get; set; }

        public ApiResponse(object result = null)
        {
                StatusCode = result is null ? HttpStatusCode.NotFound : HttpStatusCode.OK;
                Result = result;
                ErrorMessage = result is null  ? new List<string>() { "مفيش داتا اعرضها" } : default!; 
            
        }


        //private void GetDefaultErrorMessage(int statusCode) 
        //{
        //    switch (statusCode) {

        //        case 400:
        //            ErrorMessage = new List<string>() { "الريكويست مش كويس" };
        //            break;
        //        case 401:
        //            ErrorMessage = new List<string>() { "ملكش صلاحية وصول" };
        //            break;
        //        case 404:
        //            ErrorMessage = 
        //            break;
        //        case 500:
        //            ErrorMessage = new List<string>() { "السرفر واقع" };
        //            break;
        //        default:
        //          IsSuccess = true;
        //            break;

        //    }
        //}


    }
}
