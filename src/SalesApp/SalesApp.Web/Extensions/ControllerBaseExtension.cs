using Microsoft.AspNetCore.Mvc;
using SalesApp.Application.Models;

namespace SalesApp.Web.Extensions
{
    public static class ControllerBaseExtension
    {
        public static IActionResult HandleResult<T>(this ControllerBase controller, Result<T> result)
        {
            if(result.IsSuccess)
            {
                return controller.Ok(result.Content);
            }

            if(result.Error.type == ResultError.InternalServerError)
            {
                return controller.StatusCode(500, result.Error);
            }

            if(result.Error.type == ResultError.ResourceNotFound)
            {
                return controller.NotFound(result.Error);
            }

            return controller.BadRequest(result.Error);
        }
    }
}
