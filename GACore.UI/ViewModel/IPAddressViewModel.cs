using GACore.Architecture;
using System.Net;

namespace GACore.UI.ViewModel
{
	public class IPAddressViewModel : AbstractViewModel<IIPAddressable>
	{
		private byte[] ipAddressBytes = new byte[4] { 0, 0, 0, 0 };

		public int ByteA
		{
			get { return ipAddressBytes[0]; }
			set
			{
				if (ipAddressBytes[0] != value)
				{
					ipAddressBytes[0] = (byte)value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public int ByteB
		{
			get { return ipAddressBytes[1]; }
			set
			{
				if (ipAddressBytes[1] != value)
				{
					ipAddressBytes[1] = (byte)value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public int ByteC
		{
			get { return ipAddressBytes[2]; }
			set
			{
				if (ipAddressBytes[2] != value)
				{
					ipAddressBytes[2] = (byte)value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public int ByteD
		{
			get { return ipAddressBytes[3]; }
			set
			{
				if (ipAddressBytes[3] != value)
				{
					ipAddressBytes[3] = (byte)value;
					OnNotifyPropertyChanged();
				}
			}
		}

		private void NotifyByteUpdates()
		{
			OnNotifyPropertyChanged("ByteA");
			OnNotifyPropertyChanged("ByteB");
			OnNotifyPropertyChanged("ByteC");
			OnNotifyPropertyChanged("ByteD");
		}

		public void ApplyChanges()
		{
			Logger.Trace("[IPAddressViewModel] ApplyChanges()");
			if (Model != null) Model.IPAddress = IPAddress;
		}

		public IPAddress IPAddress
		{
			get { return new IPAddress(ipAddressBytes); }
			set
			{
				byte[] ipV4ByteValue = value.MapToIPv4().GetAddressBytes();

				if (ipAddressBytes != ipV4ByteValue)
				{
					ipAddressBytes = ipV4ByteValue;
					OnNotifyPropertyChanged();
					NotifyByteUpdates();
				}
			}
		}


		internal IPAddressViewModel()
		{
		}

		protected override void HandleModelUpdate(IIPAddressable oldValue, IIPAddressable newValue)
		{
			IPAddress = newValue.IPAddress ?? null;
			base.HandleModelUpdate(oldValue, newValue);
		}
	}
}
