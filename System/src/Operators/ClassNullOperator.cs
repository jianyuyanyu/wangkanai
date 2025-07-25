﻿// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

namespace Wangkanai.Operators;

public sealed class ClassNullOperator<T> : INullOperator<T>
	where T : class
{
	public bool HasValue(T value) => value.FalseIfNull();

	public bool AddIfNotNull(ref T accumulator, T value)
	{
		if (value.TrueIfNull())
			return false;

		accumulator = Operator<T>.Add(accumulator, value);
		return true;
	}
}
