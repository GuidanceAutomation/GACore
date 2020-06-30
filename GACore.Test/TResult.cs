using GACore.Architecture;
using NUnit.Framework;
using System;

namespace GACore.Test
{
	[TestFixture]
	[Description("Result object")]
	public class TResult
	{
		[Test]
		public void Success()
		{
			IResult result = new Result(true);

			Assert.IsTrue(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase(string.Empty, result.FailureReason);
		}

		[Test]
		public void Failure_Unspecified()
		{
			IResult result = new Result(false);

			Assert.IsFalse(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase("Unknown", result.FailureReason);
		}

		[Test]
		public void Throws_ArgumentOutOfRangeException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new Result(true, "Metal Gear???"));
		}

		[Test]
		public void FromException()
		{
			string message = "OHES NOES";
			Exception ex = new Exception(message);

			IResult result = new Result(ex);

			Assert.IsFalse(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase(message, result.FailureReason);
		}
	}
}