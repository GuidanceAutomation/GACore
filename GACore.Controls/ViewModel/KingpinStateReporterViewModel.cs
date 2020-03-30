using GACore.Architecture;
using System.Net;
using System.Windows.Media;

namespace GACore.Controls.ViewModel
{
	public class KingpinStateReporterViewModel : AbstractViewModel<IKingpinStateReporter>, IRefresh
	{
		protected override void HandleModelUpdate(IKingpinStateReporter oldValue, IKingpinStateReporter newValue)
		{
			base.HandleModelUpdate(oldValue, newValue);
			Refresh();
		}

		private string alias = string.Empty;

		public string Alias
		{
			get { return alias; }
			private set
			{
				if (alias != value)
				{
					alias = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		private IPAddress ipAddress = null;

		public IPAddress IPAddress
		{
			get { return ipAddress; }
			private set
			{
				if (ipAddress != value)
				{
					ipAddress = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		private MovementType movementType = MovementType.Stationary;

		public MovementType MovementType
		{
			get { return movementType; }
			private set
			{
				if (movementType != value)
				{
					movementType = value;
					OnNotifyPropertyChanged();
				}
			}
		}


		private float x = float.NaN;

		public float X
		{
			get { return x; }
			private set
			{
				if (x != value)
				{
					x = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		private float y = float.NaN;

		public float Y
		{
			get { return x; }
			private set
			{
				if (y != value)
				{
					y = value;
					OnNotifyPropertyChanged();
				}
			}
		}


		private float heading = float.NaN;

		public float Heading
		{
			get { return heading; }
			private set
			{
				if (heading != value)
				{
					heading = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		private bool isInFault = false;
		
		public bool IsInFault
		{
			get { return isInFault; }
			private set
			{
				if (isInFault != value)
				{
					isInFault = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public void Refresh()
		{
			IKingpinState toProcess = Model?.KingpinState;

			if (toProcess != null)
			{
				Alias = toProcess.Alias;
				ipAddress = toProcess.IPAddress;
				IsVirtual = toProcess.IsVirtual;

				MovementType = toProcess.CurrentMovementType;

				X = toProcess.X;
				Y = toProcess.Y;
				Heading = toProcess.Heading;

				DynamicLimiterStatus = toProcess.DynamicLimiterStatus;
				NavigationStatus = toProcess.NavigationStatus;
				PositionControlStatus = toProcess.PositionControlStatus;
				IsInFault = toProcess.IsInFault();
			}
			else
			{
				Alias = string.Empty;
				IPAddress = null;
				IsVirtual = false;

				MovementType = MovementType.Stationary;

				X = float.NaN;
				Y = float.NaN;
				Heading = float.NaN;

				DynamicLimiterStatus = DynamicLimiterStatus.Unknown;
				NavigationStatus = NavigationStatus.Unknown;
				PositionControlStatus = PositionControlStatus.Unknown;
				IsInFault = false;
			}


		}

		private DynamicLimiterStatus dynamicLimiterStatus = DynamicLimiterStatus.Unknown;

		private NavigationStatus navigationStatus = NavigationStatus.Unknown;

		private PositionControlStatus positionControlStatus = PositionControlStatus.Unknown;

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

		private bool isVirtual = false;

		public bool IsVirtual
		{
			get { return isVirtual; }
			private set
			{
				if (isVirtual != value)
				{
					isVirtual = value;
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
	}
}
