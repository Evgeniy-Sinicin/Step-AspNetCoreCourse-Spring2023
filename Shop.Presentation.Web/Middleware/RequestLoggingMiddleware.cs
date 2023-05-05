using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Presentation.Web.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate nextMiddleware, ILogger<RequestLoggingMiddleware> logger)
        {
            _nextMiddleware = nextMiddleware;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _nextMiddleware(context);
            }
            catch (Exception)
            {
                _logger.LogWarning("Request {method} {url} => {statusCode}", context.Request?.Method, context.Request?.Path.Value, context.Response?.StatusCode);
            }
        }
    }
}
