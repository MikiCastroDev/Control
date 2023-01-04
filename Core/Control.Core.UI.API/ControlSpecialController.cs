using Control.Infrastructure.Util.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace Control.Core.UI.API
{
    public class ControlSpecialController : ControllerBase
    {
        #region Metodos para envolver la respuesta a través de la clase ApiResponse
        protected new IActionResult Ok()
        {
            return base.Ok(ApiResponse.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(ApiResponse.Ok(result));
        }

        protected ActionResult<T> TypedOk<T>(T result)
        {
            return base.Ok(ApiResponse.Ok(result));
        }

        protected IActionResult Created<T>(string url, T result)
        {
            return base.Created(url, ApiResponse.Ok(result));
        }

        protected ActionResult<T> BadRequest<T>(string errorMessage)
        {
            return BadRequest(ApiResponse.Error(errorMessage));
        }

        protected ActionResult<T> Forbidden<T>(string errorMessage)
        {
            return StatusCode(403, ApiResponse.Error(errorMessage));
        }

        protected IActionResult NotFound(string errorMessage)
        {
            return NotFound(ApiResponse.Error(errorMessage));
        }
        #endregion

        #region Metodos para el procesamiento del resultado commands
        protected ActionResult<T> ProcessResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return TypedOk(result.Value);
            else if (result.IsForbidden)
                return Forbidden<T>(result.ErrorMessage);
            else
                return BadRequest(ApiResponse.Error(result.ErrorMessage));
        }

        protected ActionResult ProcessFileResult(Result<FileStreamResult> result)
        {
            if (result.IsSuccess)
                return result.Value;
            else if (result.IsFailure)
                return BadRequest(ApiResponse.Error(result.ErrorMessage));

            return NotFound(ApiResponse.Error(result.ErrorMessage));
        }

        protected UnauthorizedObjectResult ProcessUnauthorized(Result result)
        {
            return Unauthorized(ApiResponse.Error(result.ErrorMessage));
        }

        protected IActionResult ProcessResult<T>(Result<T> result, string createdUrl)
        {
            if (result.IsSuccess)
                return Created(createdUrl, result.Value);
            else
                return BadRequest(ApiResponse.Error(result.ErrorMessage));
        }
        #endregion
    }
}
