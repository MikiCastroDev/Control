namespace Control.Infrastructure.Util.WebApi
{
    public class ApiResponse<T>
    {
        public T Result { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }

        protected internal ApiResponse(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ff"));
        }
    }

    public class ApiResponse : ApiResponse<string>
    {
        protected ApiResponse(string errorMessage)
            : base(null, errorMessage)
        {
        }

        public static ApiResponse<T> Ok<T>(T result)
        {
            return new ApiResponse<T>(result, null);
        }

        public static ApiResponse Ok()
        {
            return new ApiResponse(null);
        }

        public static ApiResponse Error(string errorMessage)
        {
            return new ApiResponse(errorMessage);
        }
    }
}
