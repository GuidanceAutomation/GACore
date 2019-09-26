using NUnit.Framework;
using System;

namespace GACore.Test
{
	[TestFixture]
	[Category("Trigonometry")]
	public class TTrigonometry
	{
		[Test]
		[TestCase(0, 0)]
		[TestCase(Math.PI, Math.PI)]
		[TestCase(3 * Math.PI, Math.PI)]
		public void PiWrap(double value, double expected)
		{
			Assert.AreEqual(expected, Trigonometry.PiWrap(value));
		}
	}
}
