using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Reservation.Shared.Dto.Response
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public ErrorDto Error { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public static ResponseDto<T> Succes(T data, int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static ResponseDto<T> Succes(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode, IsSuccessful = true };
        }
        public static ResponseDto<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
        public static ResponseDto<T> Fail(string error, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(error, isShow);

            return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
    }


    public class ErrorDto
    {
        public List<string> Errors { get; private set; } = new List<string>();
        public bool IsShow { get; private set; }

        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }
        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}
