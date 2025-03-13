namespace ECommerceApp.Application.Dtos
{
    public class RestDto<T>
    {
        public RestDto(int statusCode, T? data = default, string? message = null, List<string>? details = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageBasedOnStatusCode(statusCode);
            Data = data;
            Details = details ?? new List<string>();
        }

        public int StatusCode { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; }
        public List<string> Details { get; set; } = new List<string>();
        private string? GetMessageBasedOnStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _ => null
            };
        }
    }
}
