using NUnit.Framework;
using System.Net;

namespace GACore.Test
{
	[TestFixture]
	[Category("GACore")]
	[Description("IPAddressRange")]
	public class TIPAddressRange
	{
		[Test]
		[TestCase("192.168.4.9", false)]
		[TestCase("192.168.4.10", true)]
		[TestCase("192.168.4.15", true)]
		[TestCase("192.168.4.20", true)]
		[TestCase("192.168.4.21", false)]
		public void InRange(string ipV4string, bool isExpectedInRange)
		{
			IPAddress lower = IPAddress.Parse("192.168.4.10");
			IPAddress upper = IPAddress.Parse("192.168.4.20");

			IPAddressRange range = new IPAddressRange(lower, upper);

			IPAddress testCase = IPAddress.Parse(ipV4string);

			Assert.AreEqual(isExpectedInRange, range.IsInRange(testCase));
		}

		[Test]
		public void AreNotEqual()
		{
			IPAddress lowerA = IPAddress.Parse("192.168.4.10");
			IPAddress upperA = IPAddress.Parse("192.168.4.20");

			IPAddress lowerB = IPAddress.Parse("192.168.5.10");
			IPAddress upperB = IPAddress.Parse("192.168.5.20");

			IPAddressRange rangeA = new IPAddressRange(lowerA, upperA);
			IPAddressRange rangeB = new IPAddressRange(lowerB, upperB);

			Assert.AreNotEqual(rangeA, rangeB);
		}

		[Test]
		public void AreEqual()
		{
			IPAddress lower = IPAddress.Parse("192.168.4.10");
			IPAddress upper = IPAddress.Parse("192.168.4.20");

			IPAddressRange range = new IPAddressRange(lower, upper);
			IPAddressRange rangeCopy = new IPAddressRange(lower, upper);

			Assert.AreEqual(range, rangeCopy);
		}
	}
}
