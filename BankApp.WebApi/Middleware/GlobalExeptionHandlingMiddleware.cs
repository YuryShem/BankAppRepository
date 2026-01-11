using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text.Json;
using BankApp.Shared.Exeptions;

namespace WebApplication1.Middleware
{
    public class GlobalExeptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public GlobalExeptionHandlingMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var problem = new ProblemDetails { Instance = context.Request.Path };
                int status = StatusCodes.Status500InternalServerError;

                switch (ex)
                {
                    case LoginException le:
                        status = StatusCodes.Status422UnprocessableEntity;
                        problem.Title = "Incorrect data";
                        problem.Detail = _env.IsDevelopment() ? ex.ToString() : ex.Message;
                        problem.Extensions["login"] = "incorrect";
                        problem.Extensions["password"] = "incorrect";
                        break;
                    default:
                        status = StatusCodes.Status500InternalServerError;
                        problem.Title = "An unexpected error occured";
                        problem.Detail = _env.IsDevelopment() ? ex.ToString() : "An internal error occured";
                        break;
                }

                context.Response.StatusCode = status;
                context.Response.ContentType = "application/problem+json";

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                await context.Response.WriteAsync(JsonSerializer.Serialize(problem, options));
            }
        }
    }
}
