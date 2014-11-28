// ===========================================================
// Copyright (C) 2014-2015 Kendar.org
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
// files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
// modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
// is furnished to do so, subject to the following conditions:
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
// BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF 
// OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ===========================================================


using System;
using System.Collections.Generic;
using ConcurrencyHelpers.Coroutines;

namespace ConcurrencyHelpers.Test.Mocks
{
	class WaitCoroutine : Coroutine
	{
		private readonly int _timerMs;

		public WaitCoroutine(int timerMs = 100)
		{
			ThrowsException = false;
			Cycles = 0;
			_timerMs = timerMs;
		}

		public override IEnumerable<Step> Run()
		{
			while (Thread.Status != CoroutineThreadStatus.Stopped)
			{
				yield return InvokeAsTaskAndWait(() =>
				{
					System.Threading.Thread.Sleep(_timerMs);
					Cycles++;
				});
				if (ThrowsException) throw new Exception();
				yield return Step.Current;
			}
		}

		public override void OnError(Exception ex)
		{
			Exceptions++;
		}

		public int Cycles { get; private set; }
		public int Exceptions { get; private set; }
		public bool ThrowsException { get; set; }
	}
}