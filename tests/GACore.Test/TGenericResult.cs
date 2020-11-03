using GACore.Architecture;
using NUnit.Framework;
using System;

namespace GACore.Test
{
	[TestFixture]
	[Description("Result object")]
	public class TGenericResult
	{
		[TestCase(69)]
		public void Success<T>(T instance)
		{
			IResult<T> result = Result<T>.FromSuccess(instance);

			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(instance, result.Value);
			StringAssert.AreEqualIgnoringCase(string.Empty, result.FailureReason);
		}

		[TestCase(66)]
		[TestCase("Horse")]
		public void FromException<T>(T instance)
		{
			string message = "OHES NOES";
			Exception ex = new Exception(message);

			IResult<T> result = Result<T>.FromException(ex);

			Assert.IsFalse(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase(message, result.FailureReason);

			Assert.AreEqual(default(T), result.Value);
		}
	}
}