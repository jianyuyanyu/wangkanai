﻿// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.AspNetCore.Identity;

namespace Wangkanai.Federation;

/// <summary>
///     Provides programmatic configuration for the <see cref="FederationMiddleware" />.
/// </summary>
public sealed class FederationOptions
{
	public DiscoveryOptions Discovery { get; set; } = new();
	public EndpointsOptions Endpoints { get; set; } = new();
	public StoreOptions     Stores    { get; set; } = new();
}