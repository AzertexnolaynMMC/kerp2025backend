using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Extensions
{
    public static class ResponseExtensions
    {
        public static IActionResult Success<T>(this ControllerBase c, T data, string title = "Uğurlu əməliyyat")
        {
            return c.Ok(new CustomerResponseModel<T>
            {
                StatusCode = 0,
                title = title,
                AccessToken = null,
                Data = data
            });
        }
    }
}
