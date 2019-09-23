using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GACore;
using GACore.Architecture;

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
	}
}
