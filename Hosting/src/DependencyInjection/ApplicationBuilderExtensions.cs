// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Microsoft.AspNetCore.Builder;

using Wangkanai;
using Wangkanai.Hosting.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationBuilderExtensions
{
   public static void ValidateOption<T>(this IApplicationBuilder app, T option)
      where T : class
   {
      app.ThrowIfNull();
      option.ThrowIfNull();
   }

   public static void VerifyMarkerIsRegistered(this IApplicationBuilder app)
      => app.VerifyServiceIsRegistered<MarkerService>();

   public static void VerifyMarkerIsRegistered<T>(this IApplicationBuilder app)
      where T : MarkerService
      => app.VerifyServiceIsRegistered<T>();

   public static void VerifyServiceIsRegistered<T>(this IApplicationBuilder app)
      where T : class
   {
      app.ThrowIfNull();
      var type = typeof(T);
      if (app.ApplicationServices.GetService(type) is null)
      {
         throw new InvalidOperationException($"{type.Name} is not added to ConfigureServices(...)");
      }
   }

   public static void VerifyEndpointRoutingMiddlewareIsNotRegistered(this IApplicationBuilder                       app,
                                                                     Func<IApplicationBuilder, IApplicationBuilder> middleware)
   {
      middleware.ThrowIfNull();
      const string endpointRouteBuilder = "__EndpointRouteBuilder";
      if (app.Properties.TryGetValue(endpointRouteBuilder, out var obj))
      {
         throw new
            InvalidOperationException($"{nameof(middleware)} must be in execution pipeline before {nameof(EndpointRoutingApplicationBuilderExtensions.UseRouting)} to 'Configure(...)' in the application startup code.");
      }
   }
}