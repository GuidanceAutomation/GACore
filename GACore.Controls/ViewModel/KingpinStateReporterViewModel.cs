﻿using GACore.Architecture;

namespace GACore.Controls.ViewModel
{
	public class KingpinStateReporterViewModel : AbstractViewModel<IKingpinStateReporter>, IRefresh
	{
		private IKingpinState kingpinState = null;

		protected override void HandleModelUpdate(IKingpinStateReporter oldValue, IKingpinStateReporter newValue)
		{
			base.HandleModelUpdate(oldValue, newValue);
			Refresh();
		}

		public IKingpinState KingpinState
		{
			get { return kingpinState; }
			private set
			{
				if (kingpinState != value)
				{
					kingpinState = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public void Refresh()
		{
			KingpinState = Model?.KingpinState;
		}
	}
}
