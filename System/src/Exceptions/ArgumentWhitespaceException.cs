﻿// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Wangkanai.Resources;

namespace Wangkanai.Exceptions;

[Serializable]
public sealed class ArgumentWhitespaceException : ArgumentException
{
   private ArgumentWhitespaceException(SerializationInfo info, StreamingContext context) { }
   public ArgumentWhitespaceException() : base(SystemResources.ArgumentEmptyGeneric) { }
   public ArgumentWhitespaceException(string paramName) : base(SystemResources.ArgumentEmptyGeneric, paramName) { }
   public ArgumentWhitespaceException(string message,   Exception innerException) : base(message, innerException) { }
   public ArgumentWhitespaceException(string paramName, string    message) : base(message, paramName) { }
}