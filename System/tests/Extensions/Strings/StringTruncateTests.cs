﻿// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Wangkanai.Exceptions;

namespace Wangkanai.Extensions.Strings;

public class StringTruncateTests
{
	string? _null = null;
	string _empty = string.Empty;
	string _space = " ";
	string _tab = "\t";
	string _text = "Well, she turned me into a newt. Burn her! We want a shrubbery!! Well, I got better. Listen. Strange women lying in ponds distributing swords is no basis for a system of government.";

	[Fact]
	public void Normal()
	{
		var value = "abcdefghijklmnopqrstuvwxyz";
		var actual = value.Truncate(10);
		var expected = "abcdefghij";
		Assert.Equal(expected, actual);
	}

	[Fact] public void Null() => Assert.Throws<ArgumentNullException>(() => _null!.Truncate(10));
	[Fact] public void NullWithEllipsis() => Assert.Throws<ArgumentNullException>(() => _null!.TruncateWithPostfix(10, "..."));
	[Fact] public void Empty() => Assert.Throws<ArgumentEmptyException>(() => _empty.Truncate(10));
	[Fact] public void EmptyWithEllipsis() => Assert.Throws<ArgumentEmptyException>(() => _empty.TruncateWithPostfix(10, "..."));
	[Fact] public void Zero() => Assert.Empty("abc".Truncate(0));
	[Fact] public void Negative() => Assert.Throws<ArgumentLessThanException>(() => "abc".Truncate(-1));
	[Fact] public void NegativeWithEllipsis() => Assert.Throws<ArgumentLessThanException>(() => "abc".TruncateWithPostfix(-1, "..."));

	[Fact]
	public void Space()
	{
		Assert.Equal(_space, _space.Truncate(1));
		Assert.Empty(_space.Truncate(0));
	}

	[Fact]
	public void SpaceWithEllipsis()
	{
		Assert.Throws<ArgumentLessThanException>(() => _space.TruncateWithPostfix(1, "..."));
		Assert.Throws<ArgumentLessThanException>(() => _space.TruncateWithPostfix(0, "..."));
	}

	[Fact]
	public void Tab()
	{
		Assert.Equal(_tab, _tab.Truncate(1));
		Assert.Empty(_tab.Truncate(0));
	}

	[Fact]
	public void Text()
	{
		var actual = _text.Truncate(10);
		var expected = "Well, she ";
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void TextWithEllipsis()
	{
		var actual = _text.TruncateWithPostfix(10, "...");
		var expected = "Well, s...";
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void TextWithEllipsisAndSpace()
	{
		var actual = _text.TruncateWithPostfix(10, "... ");
		var expected = "Well, ... ";
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void TextWithEllipsisAndTab()
	{
		var actual = _text.TruncateWithPostfix(10, "... \t");
		var expected = "Well,... \t";
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void TextWithEllipsisAndTabAndSpace()
	{
		var actual = _text.TruncateWithPostfix(10, "... \t ");
		var expected = "Well... \t ";
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void TextWithEllipsisAndTabAndSpaceAndNewLine()
	{
		var actual = _text.TruncateWithPostfix(10, "... \t \n");
		var expected = "Wel... \t \n";
		Assert.Equal(expected, actual);
	}
}
