﻿// Copyright (c) 2014-2023 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Domain.Messages;

namespace Wangkanai.Domain.Events;

public interface IEvent : IKeyIntEntity, IEvent<int>;

public interface IGuidEvent : IKeyGuidEntity, IEvent<Guid>;

public interface IEvent<T> : IEntity<T>, IMessage
{
	int            Version   { get; set; }
	DateTimeOffset TimeStamp { get; set; }
}