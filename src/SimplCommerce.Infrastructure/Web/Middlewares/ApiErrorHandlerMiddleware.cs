namespace SimplCommerce.Infrastructure.Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ApiErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiErrorHandlerMiddleware> _logger;
        private readonly ApiErrorHandlerOptions _options;

        public ApiErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory _loggerFactory, IOptions<ApiErrorHandlerOptions> options = null)
        {
            this._next = next;
            this._logger = _loggerFactory.CreateLogger<ApiErrorHandlerMiddleware>();
            this._options = options.Value ?? new ApiErrorHandlerOptions();
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            if (!context.Response.HasStarted && context.Request.Path.HasValue 
                && _options.HandledPaths.Any(x=> context.Request.Path.Value.Contains(x)))
            {
                context.Response.ContentType = "application/json";

                var response = new SimplResponse
                {
                    Success = false,
                    Payload = null,
                    Error = new SimplResponseError { ErrorCode = context.Response.StatusCode, ErrorMessage = "An error occurred while processing your request" }
                };
                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
