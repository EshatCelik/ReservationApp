using System.Collections.Generic;

namespace Reservation.Api.ErrorDetails
{
    public abstract class BaseApiResponse
    {
        public bool  Success { get; set; }
        public string Message { get; set; }
    }
    public class ApiResponse<T> : BaseApiResponse
    {
        public T Data { get; set; }
    }

    public class ErrorResponse : BaseApiResponse
    {
        public List<ErrorDetail> Errors { get; set; } = new List<ErrorDetail>();
    }

    public class ErrorDetail
    {
        public string Message { get; set; }
        public string Field { get; set; }
    }
}
