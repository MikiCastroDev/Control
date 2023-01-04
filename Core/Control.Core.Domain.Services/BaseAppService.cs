using Control.Infrastructure.Util.WebApi;
using Microsoft.Extensions.Logging;

namespace Control.Core.Domain
{
    public class BaseAppService
    {
        protected IServiceProvider _serviceProvider;
        protected ILogger<BaseAppService> _logger;

        public BaseAppService(IServiceProvider serviceProvider, ILogger<BaseAppService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected Result<T> ProcessOk<T>(T dto, bool loguearResponse = false)
        {
            if (loguearResponse)
                _logger.LogReturn(dto);

            return Result.Ok<T>(dto);
        }

        protected Result<T> ProcessFail<T>(Result result)
        {
            _logger.LogWarning(" [{DomainError}] - " + result.ErrorMessage, result.Error.ToString());
            return Result.Fail<T>(result);
        }

        protected Result<T> ProcessException<T>(Result result, Exception ex)
        {
            _logger.LogError(ex, $"{result.ErrorMessage} : {ex.Message}");
            return Result.Fail<T>(result);
        }

        protected Result<T> ProcessForbidden<T>(Result result)
        {
            _logger.LogWarning(" [{DomainError}] - " + result.ErrorMessage, result.Error.ToString());
            return Result.Forbidden<T>(result);
        }
    }
}
