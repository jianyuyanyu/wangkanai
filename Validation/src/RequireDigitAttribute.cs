// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

namespace System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class RequireDigitAttribute : ValidationAttribute
{
	public RequireDigitAttribute()
		: base(() => "Digit is required") { }

	public override bool IsValid(object? value)
		=> value switch
		{
			null => true,
			string actual => actual.Any(char.IsDigit),
			_ => false
		};
}
