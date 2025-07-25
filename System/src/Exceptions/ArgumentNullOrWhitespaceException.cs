﻿// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Wangkanai.Resources;

namespace Wangkanai.Exceptions;

[Serializable]
public sealed class ArgumentNullOrWhitespaceException : ArgumentException
{
	private ArgumentNullOrWhitespaceException(SerializationInfo info, StreamingContext context) { }
	public ArgumentNullOrWhitespaceException() : base(SystemResources.ArgumentNullOrEmptyGeneric) { }
	public ArgumentNullOrWhitespaceException(string paramName) : base(paramName, SystemResources.ArgumentNullOrEmptyGeneric) { }
	public ArgumentNullOrWhitespaceException(string paramName, string message) : base(paramName, message) { }
	public ArgumentNullOrWhitespaceException(string message, Exception innerException) : base(message, innerException) { }
}
