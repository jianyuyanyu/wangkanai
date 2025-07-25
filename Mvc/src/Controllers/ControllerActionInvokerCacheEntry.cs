﻿// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Wangkanai.Extensions.Internal;
using Wangkanai.Mvc.Infrastructure;

namespace Wangkanai.Routing.Controllers;

internal sealed class ControllerActionInvokerCacheEntry
{
	internal ControllerActionInvokerCacheEntry(
		FilterItem[] cachedFilters,
		Func<ControllerContext, object> controllerFactory,
		Func<ControllerContext, object, ValueTask>? controllerReleaser,
		ControllerBinderDelegate? controllerBinderDelegate,
		ObjectMethodExecutor objectMethodExecutor,
		ActionMethodExecutor actionMethodExecutor,
		ActionMethodExecutor innerActionMethodExecutor)
	{
		ControllerFactory = controllerFactory;
		ControllerReleaser = controllerReleaser;
		ControllerBinderDelegate = controllerBinderDelegate;
		CachedFilters = cachedFilters;
		ObjectMethodExecutor = objectMethodExecutor;
		ActionMethodExecutor = actionMethodExecutor;
		InnerActionMethodExecutor = innerActionMethodExecutor;
	}

	public FilterItem[] CachedFilters { get; }

	public Func<ControllerContext, object> ControllerFactory { get; }

	public Func<ControllerContext, object, ValueTask>? ControllerReleaser { get; }

	public ControllerBinderDelegate? ControllerBinderDelegate { get; }

	internal ObjectMethodExecutor ObjectMethodExecutor { get; }

	// This includes the execution of the filter delegate (if there's a filter)
	internal ActionMethodExecutor ActionMethodExecutor { get; }

	// This is called inside of the filter delegate
	internal ActionMethodExecutor InnerActionMethodExecutor { get; }
}
