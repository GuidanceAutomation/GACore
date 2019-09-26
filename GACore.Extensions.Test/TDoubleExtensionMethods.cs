using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACore.Extensions.Test
{
	[TestFixture]
	[Category("ExtensionMethods")]
	public class TDouble_ExtensionMethods
	{
		[Test]
		[TestCase(0, 1, 0)]
		[TestCase(0, 0.5, 0)]
		[TestCase(0.4, 0.5, 0.5)]
		[TestCase(1.2, 2, 2)]
		[TestCase(12, 5, 10)]
		[TestCase(14, 3, 15)]
		public void Quantize(double value, double quantizeStep, double expected)
		{
			double actual = value.Quantize(quantizeStep);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(Math.PI, Math.PI)]
		[TestCase(3 * Math.PI, Math.PI)]
		public void PiWrap(double value, double expected)
		{
			Assert.AreEqual(expected, value.PiWrap());
		}
	}
}
