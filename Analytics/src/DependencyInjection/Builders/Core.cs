// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using Wangkanai.Analytics.Services;

namespace Microsoft.Extensions.DependencyInjection;

internal static class AnalyticsCoreBuilderExtensions
{
   public static IAnalyticsBuilder AddRequiredServices(this IAnalyticsBuilder builder)
   {
      builder.ThrowIfNull();

      builder.Services.AddHttpContextAccessor();
      builder.Services.AddOptions();
      builder.Services.TryAddSingleton(provider => provider.GetRequiredService<IOptions<AnalyticsOptions>>().Value);

      return builder;
   }

   public static IAnalyticsBuilder AddCoreServices(this IAnalyticsBuilder builder)
   {
      // Add basic core to services
      builder.Services.TryAddScoped<IAnalyticsService, AnalyticsService>();

      return builder;
   }

   public static IAnalyticsBuilder AddMarkerService(this IAnalyticsBuilder builder)
   {
      builder.Services.TryAddSingleton<AnalyticsMarkerService, AnalyticsMarkerService>();

      return builder;
   }
}