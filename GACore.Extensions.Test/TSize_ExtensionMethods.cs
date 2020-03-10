using NUnit.Framework;
using System;
using System.Windows;

namespace GACore.Extensions.Test
{
	[TestFixture]
	public class TSize_ExtensionMethods
	{
		[Test]
		public void Subtract()
		{
			Size tenTwenty = new Size(10, 20);
			Size threeSix = new Size(3, 6);

			Size result = tenTwenty.Subtract(threeSix);

			Assert.AreEqual(10 - 3, result.Width);
			Assert.AreEqual(20 - 6, result.Height);
		}

		[Test]
		public void Max()
		{
			Size threeFive = new Size(3, 5);
			Size fourTwo = new Size(4, 2);

			Size max = threeFive.Max(fourTwo);

			Assert.AreEqual(4, max.Width);
			Assert.AreEqual(5, max.Height);
		}

		[Test]
		public void Scale()
		{
			Size tenTwenty = new Size(10, 20);
			Size scaled = tenTwenty.Scale(0.5);

			Assert.AreEqual(5, scaled.Width);
			Assert.AreEqual(10, scaled.Height);
		}

		[Test]
		public void SubtractNegative()
		{
			Size threeFour = new Size(3, 4);
			Size tenTwenty = new Size(10, 20);

			Assert.Throws<System.ArgumentException>(() =>
				{
					threeFour.Subtract(tenTwenty);
				});
		}
	}
}
