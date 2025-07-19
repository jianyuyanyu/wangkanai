// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved. Apache License, Version 2.0

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Wangkanai.Detection.Mocks;

internal static class MockServer
{
	private static readonly RequestDelegate ContextHandler
		= context => context.Response.WriteAsync("DetectionMvc:");

	internal static WebApplicationBuilder WebApplicationBuilder()
		=> WebApplication.CreateBuilder();

	internal static TestServer Server(IWebHostBuilder builder)
		=> new(builder);

	internal static TestServer Server(Action<DetectionOptions> options)
		=> Server(WebHostBuilderDetection(options));

	internal static IWebHostBuilder WebHostBuilder()
		=> WebHostBuilder(ContextHandler);

	internal static IWebHostBuilder WebHostBuilder(RequestDelegate contextHandler)
		=> new WebHostBuilder()
		   .ConfigureServices(services => { })
		   .Configure(app => { app.Run(contextHandler); });

	internal static IWebHostBuilder WebHostBuilderDetection()
		=> WebHostBuilderDetection(options => { });

	internal static IWebHostBuilder WebHostBuilderDetection(Action<DetectionOptions> options)
		=> WebHostBuilderDetection(ContextHandler, options);

	internal static IWebHostBuilder WebHostBuilderDetection(RequestDelegate contextHandler)
		=> WebHostBuilderDetection(contextHandler, options => { });

	private static IWebHostBuilder WebHostBuilderDetection(RequestDelegate contextHandler, Action<DetectionOptions> options)
		=> new WebHostBuilder()
		   .ConfigureServices(services =>
		   {
			   // var accessor = MockService.MockHttpContextAccessor(agent);
			   // services.TryAddSingleton<IHttpContextAccessor, accessor>();
			   services.AddScoped(sp => sp.GetService<IHttpContextAccessor>().HttpContext.Session);
			   services.AddDetection(options);
		   })
		   .Configure(app =>
		   {
			   app.UseSession();
			   app.UseDetection();
			   app.Run(contextHandler);
		   });
}
