// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System;

namespace Wangkanai.Domain;

public interface IAuditable
{
	DateTime  Created { get; set; }
	DateTime? Updated { get; set; }
}