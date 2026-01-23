using explore_pattern.Api.Utilities.Constants;
using System.Text.Json.Serialization;

namespace explore_pattern.Api.Models.BaseModels
{
    public class ApiResponse<T>
    {
        public ApiStatus Status { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        public static ApiResponse<T> Success(T data, string message = StatusMessage.SuccessString)
        {
            return new ApiResponse<T>
            {
                Status = new ApiStatus
                {
                    Code = StatusCodes.Status200OK,
                    Message = message
                },
                Data = data
            };
        }

        public static ApiResponse<T> Fail(int code, string message)
        {
            return new ApiResponse<T>
            {
                Status = new ApiStatus
                {
                    Code = code,
                    Message = message
                },
                Data = default
            };
        }
    }

    public class ApiStatus
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
    }

}
