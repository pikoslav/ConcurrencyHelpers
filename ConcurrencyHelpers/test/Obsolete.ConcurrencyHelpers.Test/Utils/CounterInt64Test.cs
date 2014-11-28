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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcurrencyHelpers.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConcurrencyHelpers.Test
{
	[TestClass]
	public class CounterInt64Test
	{
		[TestMethod]
		public void CounterInt64CompareExchangeOk()
		{
			var c = new CounterInt64(1);
			var res = c.CompareExchange(1, 2);
			Assert.AreEqual(1, res);
		}

		[TestMethod]
		public void CounterInt64CompareExchangeFail()
		{
			var c = new CounterInt64(1);
			var res = c.CompareExchange(2, 2);
			Assert.AreEqual(1, res);
		}

		[TestMethod]
		public void CounterInt64Constructor()
		{
			var c = new CounterInt64(22);
			Assert.AreEqual(22, (Int64)c);
		}

		[TestMethod]
		public void CounterInt64DecrementIncrement()
		{
			var c = new CounterInt64(22);
			c.Decrement();
			Assert.AreEqual(21, (Int64)c);
			c.Increment();
			Assert.AreEqual(22, (Int64)c);
		}

		[TestMethod]
		public void CounterInt64Int64Conversion()
		{
			const long int64Value = 28;
			const int int32Value = 28;
			var c = new CounterInt64();
			c = int64Value;
			Assert.AreEqual(int64Value, (Int64)c);
			c = int32Value;
			Assert.AreEqual(int32Value, (Int32)c);
		}

		[TestMethod]
		public void CounterInt64GetAndReset()
		{
			var c = new CounterInt64(22);
			var result = c.GetAndReset();
			Assert.AreEqual(result, 22);
			Assert.AreEqual(0, (Int64)c);
		}

		[TestMethod]
		public void CounterInt64GetAndSet()
		{
			var c = new CounterInt64(22);
			var result = c.GetAndSet(38);
			Assert.AreEqual(result, 22);
			Assert.AreEqual(38, (Int64)c);
		}

		[TestMethod]
		public void CounterInt64PlusMinusOperators()
		{
			var c = new CounterInt64(22);
			c++;
			Assert.AreEqual(23, (Int64)c);
			c--;
			Assert.AreEqual(22, (Int64)c);
			c += 1;
			Assert.AreEqual(23, (Int64)c);
		}

		[TestMethod]
		public void CounterInt64SumBetweenCounters()
		{
			var c = new CounterInt64(22);
			var d = new CounterInt64(23);
			var e = c + d;
			Assert.AreEqual(45, (Int64)e);
		}

		[TestMethod]
		public void CounterInt64ToStringOperator()
		{
			var c = new CounterInt64(22);
			Assert.AreEqual("22", c.ToString());
		}
	}
}