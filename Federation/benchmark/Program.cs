﻿// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

global using BenchmarkDotNet.Attributes;
global using BenchmarkDotNet.Running;

using Wangkanai.Federation;

BenchmarkRunner.Run<FederationBenchmark>();
