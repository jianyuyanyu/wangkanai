// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

public class ForeachBenchmark
{
	private readonly int[] _array = new int[1000];

	[Benchmark]
	public int ForLoop()
	{
		int sum = 0;
		for (int i = 0; i < _array.Length; i++)
		{
			sum += _array[i];
		}
		return sum;
	}

	[Benchmark]
	public int ForeachLoop()
	{
		int sum = 0;
		foreach (int i in _array)
		{
			sum += i;
		}
		return sum;
	}
}
