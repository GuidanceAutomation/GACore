using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace GACore
{
	public struct IPAddressRange
	{
		private readonly AddressFamily addressFamily;

		private readonly byte[] lowerBytes;

		private readonly byte[] upperBytes;

		public IPAddressRange(string lowerIPV4string, string upperIPV4string)
			: this(IPAddress.Parse(lowerIPV4string), IPAddress.Parse(upperIPV4string))
		{
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + addressFamily.GetHashCode();
				hash = hash * 23 + lowerBytes.GetHashCode();
				hash = hash * 23 + upperBytes.GetHashCode();
				return hash;
			}
		}

		public static bool operator !=(IPAddressRange rangeA, IPAddressRange rangeB) => !rangeA.Equals(rangeB);

		public static bool operator ==(IPAddressRange rangeA, IPAddressRange rangeB) => rangeA.Equals(rangeB);

		public override bool Equals(object obj)
		{
			if (!(obj is IPAddressRange)) return false;

			IPAddressRange other = (IPAddressRange)obj;

			return addressFamily == other.addressFamily
				&& lowerBytes.SequenceEqual(other.lowerBytes)
				&& upperBytes.SequenceEqual(other.upperBytes);
		}

		public IPAddressRange(IPAddress lower, IPAddress upper)
		{
			if (lower == null) throw new ArgumentOutOfRangeException("lower");
			if (upper == null) throw new ArgumentOutOfRangeException("upper");

			if (lower.AddressFamily != upper.AddressFamily) throw new ArgumentOutOfRangeException("Inconsistent address families");

			this.addressFamily = lower.AddressFamily;
			this.lowerBytes = lower.GetAddressBytes();
			this.upperBytes = upper.GetAddressBytes();
		}

		public IPAddress Lower => new IPAddress(lowerBytes);

		public IPAddress Upper => new IPAddress(upperBytes);

		public string ToSummaryString() => string.Format("IPAddressRange lower:{0}, upper:{1}", Lower, Upper);

		public override string ToString() => ToSummaryString();

		public bool IsInRange(IPAddress ipaddress)
		{
			if (ipaddress == null) throw new ArgumentNullException();

			if (ipaddress.AddressFamily != addressFamily) return false;

			byte[] addressBytes = ipaddress.GetAddressBytes();

			bool lowerBoundary = true;
			bool upperBoundary = true;

			for (int i = 0; i < this.lowerBytes.Length && (lowerBoundary || upperBoundary); i++)
			{
				if ((lowerBoundary && addressBytes[i] < lowerBytes[i]) || (upperBoundary && addressBytes[i] > upperBytes[i])) return false;

				lowerBoundary &= (addressBytes[i] == lowerBytes[i]);
				upperBoundary &= (addressBytes[i] == upperBytes[i]);
			}

			return true;
		}
	}
}