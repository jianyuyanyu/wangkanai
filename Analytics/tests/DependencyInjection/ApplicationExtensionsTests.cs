// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using System;

using Castle.Core.Logging;

using Microsoft.AspNetCore.Builder;

using Moq;

using Xunit;

namespace Microsoft.Extensions.DependencyInjection;

public class ApplicationExtensionsTests
{
	[Fact]
	public void UseAnalytics_ThrowsInvalidOptionException_IfMakerServiceIsNotRegister()
	{
		// Arrange
		var provider = new Mock<IServiceProvider>();
		provider.Setup(s => s.GetService(typeof(ILoggerFactory)))
				.Returns(Mock.Of<NullLogFactory>());
		var app = new Mock<IApplicationBuilder>();
		app.Setup(x => x.ApplicationServices)
		   .Returns(provider.Object);

		// Act
		var exception = Assert.Throws<InvalidOperationException>(() => app.Object.UseAnalytics());

		// Assert
		Assert.Equal("AnalyticsMarkerService is not added to ConfigureServices(...)", exception.Message);
	}
}
