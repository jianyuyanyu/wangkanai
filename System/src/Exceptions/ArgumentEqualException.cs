// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Resources;

namespace Wangkanai.Exceptions;

[Serializable]
public sealed class ArgumentEqualException : ArgumentException
{
	private ArgumentEqualException(SerializationInfo info, StreamingContext context) { }
	public ArgumentEqualException() : base(SystemResources.ArgumentEqualGeneric) { }
	public ArgumentEqualException(string paramName) : base(SystemResources.ArgumentEqualGeneric, paramName) { }
	public ArgumentEqualException(string message, Exception innerException) : base(message, innerException) { }
	public ArgumentEqualException(string message, string paramName, Exception innerException) : base(message, paramName, innerException) { }
	public ArgumentEqualException(string paramName, string message) : base(message, paramName) { }
}
