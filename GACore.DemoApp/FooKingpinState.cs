using GACore.Architecture;
using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace GACore.DemoApp
{
	/// <summary>
	/// Just makes a random kingpin state
	/// </summary>
	public class FooKingpinState : IKingpinState
	{
		private PositionControlStatus positionControlStatus = Tools.RandomEnumValue<PositionControlStatus>();

		public PositionControlStatus PositionControlStatus
		{
			get { return positionControlStatus; }
			set
			{
				if (positionControlStatus != value)
				{
					positionControlStatus = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public NavigationStatus navigationStatus = Tools.RandomEnumValue<NavigationStatus>();

		public NavigationStatus NavigationStatus
		{
			get { return navigationStatus; }
			set
			{
				if (navigationStatus != value)
				{
					navigationStatus = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public DynamicLimiterStatus dynamicLimiterStatus = Tools.RandomEnumValue<DynamicLimiterStatus>();

		public DynamicLimiterStatus DynamicLimiterStatus
		{
			get { return dynamicLimiterStatus; }
			set
			{
				if (dynamicLimiterStatus != value)
				{
					dynamicLimiterStatus = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public string Alias => "Foo Kingpin";

		private bool isVirtual = Tools.Random.Next(0, 2) > 0;

		public bool IsVirtual
		{
			get { return isVirtual; }
		}

		public byte Tick => throw new NotImplementedException();

		private float x = Tools.Random.Next(-10, 10);

		public float X
		{
			get { return x; }
			set
			{
				if (x != value)
				{
					x = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		private float y = Tools.Random.Next(-10, 10);

		public float Y
		{
			get { return y; }
			set
			{
				if (y != value)
				{
					y = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		private float heading = Tools.Random.Next(-3, 3);

		public float Heading
		{
			get { return heading; }
			set
			{
				if (heading != value)
				{
					heading = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public MovementType currentMovementType = Tools.RandomEnumValue<MovementType>();

		public MovementType CurrentMovementType
		{
			get { return currentMovementType; }
			set
			{
				if (currentMovementType != value)
				{
					currentMovementType = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public IPAddress IPAddress => IPAddress.Loopback;

		public byte[] StateCastExtendedData => throw new NotImplementedException();

		public double Speed => throw new NotImplementedException();

		public int WaypointLastId => throw new NotImplementedException();

		public int WaypointNextId => throw new NotImplementedException();

		public AgvMode AgvMode => throw new NotImplementedException();

		public double BatteryChargePercentage => throw new NotImplementedException();

		public ExtendedDataFaultStatus ExtendedDataFaultStatus => ExtendedDataFaultStatus.OK;

		public FrozenState FrozenState => throw new NotImplementedException();

		public bool IsCharging => throw new NotImplementedException();

		public static IKingpinState FromGood()
		{
			return new FooKingpinState()
			{
				PositionControlStatus = PositionControlStatus.OK,
				NavigationStatus = NavigationStatus.OK,
				DynamicLimiterStatus = DynamicLimiterStatus.OK
			};
		}

		public int LastCompletedInstructionId => throw new NotImplementedException();

		public TimeSpan Stationary => throw new NotImplementedException();

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}