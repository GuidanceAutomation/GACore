using GACore.Generics;
using NUnit.Framework;

namespace GACore.Test.Generics
{
	[TestFixture]
	[Category("Generics")]
	public class TQuandary
	{
		[Test]
		[TestCase(0, 1)]
		public void Quandary_Init(int initial, int final)
		{
			Quandary<int> quandary = new Quandary<int>(initial, final);

			Assert.AreEqual(initial, quandary.Initial);
			Assert.AreEqual(final, quandary.Final);
		}

		[Test]
		public void Quandary_Set_Final()
		{
			int final = 0;
			Quandary<int> quandary = new Quandary<int>(int.MinValue, final);
			Assert.AreEqual(int.MinValue, quandary.Initial);
			Assert.AreEqual(final, quandary.Final);

			final = int.MaxValue;
			quandary.Final = final;
			Assert.AreEqual(int.MinValue, quandary.Initial);
			Assert.AreEqual(final, quandary.Final);
		}

		[Test]
		public void Quandary_Set_Initial()
		{
			int initial = int.MinValue;
			Quandary<int> quandary = new Quandary<int>(initial, int.MaxValue);
			Assert.AreEqual(initial, quandary.Initial);
			Assert.AreEqual(int.MaxValue, quandary.Final);

			initial = 0;
			quandary.Initial = initial;
			Assert.AreEqual(initial, quandary.Initial);
			Assert.AreEqual(int.MaxValue, quandary.Final);
		}
	}
}
