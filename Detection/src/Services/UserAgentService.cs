// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Wangkanai.Detection.Models;

namespace Wangkanai.Detection.Services;

public sealed class UserAgentService : IUserAgentService
{
	public UserAgentService(IHttpContextService context)
	{
		UserAgent = new UserAgent(context.Request.Headers["User-Agent"].FirstOrDefault() ?? "");
	}

	public UserAgent UserAgent { get; }
}
