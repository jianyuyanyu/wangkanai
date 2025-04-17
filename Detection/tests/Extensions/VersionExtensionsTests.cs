// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved. Apache License, Version 2.0

namespace Wangkanai.Detection.Extensions;

public class VersionExtensionsTests
{
	[Fact]
	public void RemoveWhitespaceTest()
	{
		var temp = "1.0.0 ";
		var version = temp.ToVersion();
		var result = version.ToString();
		Assert.Equal("1.0.0", result);
	}

	[Theory]
	[InlineData("1.1")]
	[InlineData("1.1.0")]
	[InlineData("1.1.1.1")]
	public void StringToVersion(string value)
	{
		var version = value.ToVersion();
		Assert.Equal(value, version.ToString());
	}

	[Fact]
	public void MajorOnly()
	{
		Assert.Equal("1.0", "1".ToVersion().ToString());
	}
}
