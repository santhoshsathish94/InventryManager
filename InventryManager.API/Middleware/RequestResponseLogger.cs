using System.Diagnostics;
using System.Text;

namespace InventryManager.API.Middleware
{
    /// <summary>API logging.</summary>
    public class RequestResponseLogger
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        /// <summary>Initializes the API logging.</summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public RequestResponseLogger(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<RequestResponseLogger>();
        }

        /// <summary>Invokes API logging.</summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            // only log API calls
            bool isApiPath = context.Request.Path.ToString().ToLower().StartsWith("/api/");
            Stopwatch perfWatch = Stopwatch.StartNew();

            context.Request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
            await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            var requestBody = Encoding.UTF8.GetString(buffer);
            context.Request.Body.Seek(0, SeekOrigin.Begin);

            if (isApiPath)
            {
                logger.LogInformation("Request: " + requestBody);
            }

            var originalBodyStream = context.Response.Body;

            using var responseBody = new MemoryStream(); context.Response.Body = responseBody;

            await next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            if (isApiPath)
            {
                if (response.Length < 1000)
                {
                    logger.LogInformation($"Response ({perfWatch.ElapsedMilliseconds} ms): {response}.");
                }
                else
                {
                    logger.LogInformation($"Response ({perfWatch.ElapsedMilliseconds} ms): {response.Length} bytes");
                }
            }

            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
