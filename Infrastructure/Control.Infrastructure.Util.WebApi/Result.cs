using Control.Infrastructure.Util.WebApi.Messages;

namespace Control.Infrastructure.Util.WebApi
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsForbidden { get; }
        public ErrorType? Error { get; }
        public string ErrorMessage { get; }
        public bool IsFailure => !IsSuccess;
        private object[] Parameters { get; }

        protected Result(bool isSuccess, ErrorType? error, params object[] values)
        {
            if (isSuccess && error.HasValue)
                throw new InvalidOperationException();
            if (!isSuccess && !error.HasValue)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            if (IsFailure)
            {
                Error = error;
                ErrorMessage = string.Format(ErrorMessages.ResourceManager.GetString(error.ToString()), values);
                Parameters = values;
            }
        }

        protected Result(bool isSuccess, bool isForbidden, ErrorType? error, params object[] values)
        {
            if (isSuccess && error.HasValue)
                throw new InvalidOperationException();
            if (!isSuccess && !error.HasValue)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            IsForbidden = isForbidden;
            if (IsFailure)
            {
                Error = error;
                ErrorMessage = string.Format(ErrorMessages.ResourceManager.GetString(error.ToString()), values);
                Parameters = values;
            }
        }

        public static Result Fail(ErrorType error, params object[] values)
        {
            return new Result(false, false, error, values);
        }

        public static Result Fail(Result result)
        {
            return new Result(false, result.Error, result.Parameters);
        }

        public static Result Forbidden(ErrorType error, params object[] values)
        {
            return new Result(false, true, error, values);
        }

        public static Result<T> Forbidden<T>(Result result)
        {
            return new Result<T>(default, false, true, result.Error, result.Parameters);

        }

        public static Result<T> Fail<T>(Result result)
        {
            return new Result<T>(default, false, result.Error, result.Parameters);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null);
        }

        public static Result Combine(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                {
                    return result;
                }
            }
            return Ok();
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (IsFailure)
                    throw new InvalidOperationException();
                return _value;
            }
        }

        protected internal Result(T value, bool isSuccess, ErrorType? error, params object[] values)
            : base(isSuccess, error, values)
        {
            _value = value;
        }

        protected internal Result(T value, bool isSuccess, bool isForbidden, ErrorType? error, params object[] values)
            : base(isSuccess, isForbidden, error, values)
        {
            _value = value;
        }
    }

    public enum ErrorType
    {
        #region Users
        #endregion
    }
}
