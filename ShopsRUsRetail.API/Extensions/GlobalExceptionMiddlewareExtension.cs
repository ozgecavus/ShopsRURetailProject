﻿using System.Net;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ShopsRUsRetail.Core.Entities;

namespace ShopsRUs.Extensions
{
    public static class GlobalExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(
            this IApplicationBuilder app,
            ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Error: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error." + contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
