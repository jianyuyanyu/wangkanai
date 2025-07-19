﻿// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Microsoft.AspNetCore.Mvc.Filters;

namespace Wangkanai.Mvc.Filters;

internal sealed class FilterDescriptorOrderComparer : IComparer<FilterDescriptor>
{
	public static FilterDescriptorOrderComparer Comparer { get; } = new FilterDescriptorOrderComparer();

	public int Compare(FilterDescriptor? x, FilterDescriptor? y)
	{
		x.ThrowIfNull();
		y.ThrowIfNull();

		return x.Order == y.Order
				   ? x.Scope.CompareTo(y.Scope)
				   : x.Order.CompareTo(y.Order);
	}
}
