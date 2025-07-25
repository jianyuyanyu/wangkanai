// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Microsoft.AspNetCore.Http;

using Wangkanai.Responsive.Extensions;
using Wangkanai.Responsive.Services;

namespace Wangkanai.Responsive.Hosting;

public sealed class ResponsiveMiddleware
{
	private readonly RequestDelegate _next;

	public ResponsiveMiddleware(RequestDelegate next)
	{
		_next = next.ThrowIfNull();
	}

	public async Task InvokeAsync(HttpContext context, IResponsiveService responsive)
	{
		context.ThrowIfNull();

		context.SetDevice(responsive.View);

		await _next(context);
	}
}
