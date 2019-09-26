using NUnit.Framework;
using System.Windows;

namespace GACore.Extensions.Test
{
	[TestFixture]
	[Category("ExtensionMethods")]
	public class TPoint_ExtensionMethods
	{
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