using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CatalogAPI.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"Model State: {context.ModelState.IsValid}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogError($"Errors: {context.ModelState.ErrorCount}");
        }
    }
}