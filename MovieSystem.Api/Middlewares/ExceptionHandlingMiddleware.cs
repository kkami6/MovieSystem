using System.Net;
using System.Text.Json;


namespace MovieSystem.Api.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await WriteErrorResponse(context, ex.Message, ex.Errors.Select(e => e.ErrorMessage));
            }
            catch (KeyNotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await WriteErrorResponse(context, ex.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await WriteErrorResponse(context, "Internal server error.", new[] { ex.Message });
            }
        }

        private static async Task WriteErrorResponse(HttpContext context,
                                                     string message,
                                                     IEnumerable<string>? errors = null)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                message,
                errors = errors?.ToList()
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
}
}
