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
			IResult result = Result.FromSuccess();

			Assert.IsTrue(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase(string.Empty, result.FailureReason);
		}

		[Test]
		public void Failure_Unspecified()
		{
			IResult result = Result.FromFailure();

			Assert.IsFalse(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase("Unknown", result.FailureReason);
		}
		
		[Test]
		public void FromException()
		{
			string message = "OHES NOES";
			Exception ex = new Exception(message);

			IResult result = Result.FromException(ex);

			Assert.IsFalse(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase(message, result.FailureReason);
		}
	}
}