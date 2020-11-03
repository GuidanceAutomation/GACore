using GAAPICommon.Architecture;
using GAAPICommon.Core.Dtos;
using GACore.Architecture;
using NUnit.Framework;

namespace GACore.Test
{
	[TestFixture]
	public class TExtensionMethods
	{
		[Test]
		public void ToSemVerDto()
		{
			ISemVer semVer = new SemVer(1, 2, 3, ReleaseFlag.Beta);

			SemVerDto semVerDto = semVer.ToSemVerDto();

			Assert.IsNotNull(semVerDto);

			Assert.AreEqual(1, semVerDto.Major);
			Assert.AreEqual(2, semVerDto.Minor);
			Assert.AreEqual(3, semVerDto.Patch);
			StringAssert.AreEqualIgnoringCase("Beta", semVerDto.ReleaseFlag);
		}
	}
}
