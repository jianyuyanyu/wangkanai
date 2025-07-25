// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Wangkanai.Detection.Models;
using Wangkanai.Responsive.Mocks;

using Xunit;

namespace Wangkanai.Responsive.Hosting;

public class ResponsiveMiddlewareTest
{
	private static Task Next(HttpContext d)
	{
		return Task.Factory.StartNew(() => d);
	}

	[Fact]
	public void Ctor_RequestDelegate_Null_ThrowsArgumentNullException()
	{
		Assert.Throws<ArgumentNullException>(
			() => new ResponsiveMiddleware(null!)
		);
	}

	[Fact]
	public async ValueTask Invoke_HttpContext_Null_ResponsiveService_Null_ThrowsArgumentNullException()
	{
		var middleware = new ResponsiveMiddleware(Next);

		await Assert.ThrowsAsync<ArgumentNullException>(
			async () => await middleware.InvokeAsync(null!, null!)
		);
	}

	[Fact]
	public async ValueTask Invoke_HttpContext_ResponsiveService_Null_ThrowsNullReferenceException()
	{
		var service = MockService.HttpContextService(null!);
		var middleware = new ResponsiveMiddleware(Next);

		await Assert.ThrowsAsync<NullReferenceException>(
			async () => await middleware.InvokeAsync(service.Context, null!)
		);
	}

	[Fact]
	public async ValueTask Invoke_HttpContext_ResponsiveService_Success()
	{
		using var server = MockServer.Server();
		var request = MockClient.CreateRequest(Device.Desktop);
		var client = server.CreateClient();
		var response = await client.SendAsync(request, TestContext.Current.CancellationToken);
		response.EnsureSuccessStatusCode();
		Assert.Contains(
			"desktop",
			await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken),
			StringComparison.OrdinalIgnoreCase);
	}
}
