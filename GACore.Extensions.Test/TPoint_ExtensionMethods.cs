using NUnit.Framework;
using System;
using System.Windows;

namespace GACore.Extensions.Test
{
	[TestFixture]
	[Category("ExtensionMethods")]
	public class TPoint_ExtensionMethods
	{
		[Test]
		public void Quantize_NaN()
		{
			Point point = new Point(double.NaN, 2.5);
			Point quantized = point.Quantize(2);

			Assert.AreEqual(double.NaN, quantized.X);
			Assert.AreEqual(2, quantized.Y);
		}

		[Test]
		public void QuantizePI()
		{
			Point point = new Point(Math.PI, Math.PI);

			Point quantized = point.Quantize(0.001);

			Assert.AreEqual(3.142, quantized.X);
			Assert.AreEqual(3.142, quantized.Y);
		}

		[Test]
		public void Quantize()
		{
			Point point = new Point(1.6, 2.7);
			Point quantized = point.Quantize(2);

			Assert.AreEqual(2, quantized.X);
			Assert.AreEqual(2, quantized.Y);
		}

		[Test]
		[TestCase(0, 0, 1, 1)]
		public void GetVectorTo(double x1, double y1, double x2, double y2)
		{
			Point source = new Point(x1, y1);
			Point destination = new Point(x2, y2);

			Vector expected = new Vector(x2 - x1, y2 - y1);
			Vector actual = source.GetVectorTo(destination);

			Assert.AreEqual(expected, actual);
		}
	}
}