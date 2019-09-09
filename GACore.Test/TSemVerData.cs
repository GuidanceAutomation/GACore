using NUnit.Framework;

namespace GACore.Test
{
	[TestFixture]
	public class TSemVerData
	{
		[TestCase(1, 2, 3, 1, 2, 3, 0)]
		[TestCase(2, 2, 3, 1, 2, 3, 1)]
		[TestCase(1, 2, 4, 1, 2, 3, 1)]
		[TestCase(1, 3, 3, 1, 2, 3, 1)]
		[TestCase(1, 2, 3, 2, 2, 3, -1)]
		[TestCase(1, 2, 3, 1, 3, 3, -1)]
		[TestCase(1, 2, 3, 1, 2, 4, -1)]
		public void CompareTo(int majorA, int minorA, int patchA, int majorB, int minorB, int patchB, int expected)
		{
			SemVerData semVerDataA = new SemVerData(majorA, minorA, patchA);

			SemVerData semVerDataB = new SemVerData(majorB, minorB, patchB);

			Assert.AreEqual(expected, semVerDataA.CompareTo(semVerDataB));
		}
	}
}