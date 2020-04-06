using GACore.Architecture;
using NUnit.Framework;
using System;

namespace GACore.Test
{
	[TestFixture]
	[Description("Result object")]
	public class TGenericResult
	{
		[Test]
		public void Success()
		{
			IResult<int> result = new Result<int>(true, 69);

			Assert.IsTrue(result.IsSuccessful);
			Assert.AreEqual(69, result.Value);
			StringAssert.AreEqualIgnoringCase(string.Empty, result.FailureReason);
		}

		[Test]
		public void Succces_ArgumentOutOfRangeException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new Result<object>(true, null));
		}
	}
}