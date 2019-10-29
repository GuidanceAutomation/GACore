using GACore.Architecture;

namespace GACore.Controls.ViewModel
{
	public class KingpinStatusReporterViewModel : AbstractViewModel<IKingpinStateReporter>, IRefresh
	{
		private DynamicLimiterStatus dynamicLimiterStatus = DynamicLimiterStatus.Unknown;

		private NavigationStatus navigationStatus = NavigationStatus.Unknown;

		private PositionControlStatus positionControlStatus = PositionControlStatus.Unknown;

		protected override void HandleModelUpdate() => Refresh();

		public NavigationStatus NavigationStatus
		{
			get { return navigationStatus; }
			private set
			{
				if (navigationStatus != value)
				{
					navigationStatus = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public PositionControlStatus PositionControlStatus
		{
			get { return positionControlStatus; }
			private set
			{
				if (positionControlStatus != value)
				{
					positionControlStatus = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public DynamicLimiterStatus DynamicLimiterStatus
		{
			get { return dynamicLimiterStatus; }
			private set
			{
				if (dynamicLimiterStatus != value)
				{
					dynamicLimiterStatus = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public void Refresh()
		{
			DynamicLimiterStatus = Model != null ? Model.KingpinState.DynamicLimiterStatus : DynamicLimiterStatus.Unknown;
			NavigationStatus = Model != null ? Model.KingpinState.NavigationStatus : NavigationStatus.Unknown;
			PositionControlStatus = Model != null ? Model.KingpinState.PositionControlStatus : PositionControlStatus.Unknown;
		}
	}
}
