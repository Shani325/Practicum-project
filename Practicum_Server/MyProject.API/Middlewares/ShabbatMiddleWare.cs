using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace MyProject.WebAPI.Middlewares
{
    public class ShabbatMiddleWare
    {
        private readonly RequestDelegate _next;

        public ShabbatMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            else
            {
                await _next(context);
            }
        }
    }
    public static class ShabbatMiddleWareExtentions
    {
        public static IApplicationBuilder UseShabbat(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleWare>();
        }
    }
}

