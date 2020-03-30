using GACore.Architecture;

namespace GACore.DemoApp
{
	public class FooKingpin : IKingpinStateReporter
	{
		private IKingpinState kingpinState = null;

		public IKingpinState KingpinState
		{
			get { return kingpinState; }
			set 
			{ 
				kingpinState = value; 
			}
		}

		public void Randomize()
		{
			KingpinState = new FooKingpinState();
			//GACore.Controls.ViewModel.ViewModelFactory.KingpinStateReporterViewModel.
		}


		public void SetGood()
		{
			KingpinState = FooKingpinState.FromGood();
		}

		public FooKingpin()
		{
		}
	}
}