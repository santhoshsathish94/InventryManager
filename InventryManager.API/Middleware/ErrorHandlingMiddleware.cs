using Newtonsoft.Json;

namespace InventryManager.API.Middleware
{
    /// <summary></summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        /// <summary></summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
        }

        /// <summary></summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Adding Trace here for debugging purpose
            logger.LogError(exception.Message + ". Trace: " + exception.StackTrace);
            var code = StatusCodes.Status500InternalServerError; // 500 if unexpected

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}
