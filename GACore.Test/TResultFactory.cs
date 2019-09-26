using GACore.Architecture;
using NUnit.Framework;

namespace GACore.Test
{
	[TestFixture]
	[Description("Result factory")]
	public class TResultFactory
	{
		[Test]
		public void StringFormatting()
		{
			int[] args = { 1, 2, 3 };
			string expected = string.Format("ohes noes: {0}, {1}, {2}", args[0], args[1], args[2]);

			IGenericResult<int> result = ResultFactory.FromFailure<int>("ohes noes: {0}, {1}, {2}", args[0], args[1], args[2]);

			StringAssert.AreEqualIgnoringCase(expected, result.FailureReason);
		}

		[Test]
		public void ResultFactoryUnkownFailure()
		{
			IResult result = ResultFactory.FromUnknownFailure();

			Assert.IsFalse(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase("unknown", result.FailureReason);
		}

		[Test]
		public void ResultFactoryGenericUnkownFailure()
		{
			IGenericResult<int> result = ResultFactory.FromUnknownFailure<int>();

			Assert.IsFalse(result.IsSuccessful);
			Assert.AreEqual(default(int), result.Value);
			StringAssert.AreEqualIgnoringCase("unknown", result.FailureReason);
		}

		[Test]
		[TestCase("epic fails")]
		public void ResultFactoryFailure(string failureReason)
		{
			IResult result = ResultFactory.FromFailure(failureReason);

			Assert.IsFalse(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase(failureReason, result.FailureReason);
		}

		[Test]
		[TestCase("epic fails")]
		public void ResultFactoryGenericFailure(string failureReason)
		{
			IGenericResult<int> result = ResultFactory.FromFailure<int>(failureReason);

			Assert.IsFalse(result.IsSuccessful);
			Assert.AreEqual(default(int), result.Value);
			StringAssert.AreEqualIgnoringCase(failureReason, result.FailureReason);
		}

		[Test]
		public void ResultFactorySuccess()
		{
			IResult result = ResultFactory.FromSuccess();

			Assert.IsTrue(result.IsSuccessful);
			StringAssert.AreEqualIgnoringCase(string.Empty, result.FailureReason);
		}

		[Test]
		public void ResultFactoryGenericSuccess()
		{
			IGenericResult<int> result = ResultFactory.FromSuccess<int>(69);

			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(69, result.Value);
			StringAssert.AreEqualIgnoringCase(string.Empty, result.FailureReason);
		}
	}
}