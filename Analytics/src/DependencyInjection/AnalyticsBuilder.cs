// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Helper functions for configuring analytics services.</summary>
public sealed class AnalyticsBuilder : IAnalyticsBuilder
{
	/// <summary>Creates a new instance of <see cref="IAnalyticsBuilder" /></summary>
	/// <param name="services">The <see cref="IServiceCollection" /> to attach to.</param>
	public AnalyticsBuilder(IServiceCollection services)
		=> Services = services.ThrowIfNull();

	/// <summary>Gets the <see cref="IServiceCollection" /> services are attached to</summary>
	/// <value>The <see cref="IServiceCollection" /> services are attached to</value>
	public IServiceCollection Services { get; }
}
