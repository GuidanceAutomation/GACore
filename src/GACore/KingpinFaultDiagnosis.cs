using GAAPICommon.Architecture;
using GACore.Architecture;
using System;
using System.Text;

namespace GACore
{
	/// <summary>
	/// An an object to capture the current fault state of a Kingpin
	/// </summary>
	public class KingpinFaultDiagnosis
	{
        public KingpinFaultDiagnosis(IKingpinState kingpinState)
		{
			if (kingpinState == null)
				throw new ArgumentNullException("kingpinState");

			DynamicLimiterFault = kingpinState.DynamicLimiterStatus.IsFault() ?
				(DynamicLimiterStatus?)kingpinState.DynamicLimiterStatus : null;

			ExtendedDataFault = kingpinState.ExtendedDataFaultStatus.IsFault() ?
				(ExtendedDataFaultStatus?)kingpinState.ExtendedDataFaultStatus : null;

			NavigationFault = kingpinState.NavigationStatus.IsFault() ?
				(NavigationStatus?)kingpinState.NavigationStatus : null;

			PCSFault = kingpinState.PositionControlStatus.IsFault() ?
				(PositionControlStatus?)kingpinState.PositionControlStatus : null;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + DynamicLimiterFault.GetHashCode();
				hash = hash * 23 + ExtendedDataFault.GetHashCode();
				hash = hash * 23 + NavigationFault.GetHashCode();
				hash = hash * 23 + PCSFault.GetHashCode();
				return hash;
			}
		}

		public override bool Equals(object obj)
		{
			KingpinFaultDiagnosis other = obj as KingpinFaultDiagnosis;

			if (other == null) return false;

			return DynamicLimiterFault.Equals(other.DynamicLimiterFault)
				&& ExtendedDataFault.Equals(other.ExtendedDataFault)
				&& NavigationFault.Equals(other.NavigationFault)
				&& PCSFault.Equals(other.PCSFault);
		}

		public string ToDiagnosticString()
		{
			if (IsInFault())
			{
				StringBuilder builder = new StringBuilder();
				builder.Append("Kingpin faults detected:");

				if (DynamicLimiterFault != null) builder.AppendFormat(" {0}", DynamicLimiterFault);
				if (ExtendedDataFault != null) builder.AppendFormat(" {0}", ExtendedDataFault);
				if (NavigationFault != null) builder.AppendFormat(" {0}", NavigationFault);
				if (PCSFault != null) builder.AppendFormat(" {0}", PCSFault);

				return builder.ToString();
			}
			else
			{
				return "No kingpin fault detected";
			}
		}

		public override string ToString() => ToDiagnosticString();

		public bool IsInFault() => (PCSFault != null || ExtendedDataFault != null
			|| NavigationFault != null || DynamicLimiterFault != null);

        public PositionControlStatus? PCSFault { get; }

        public ExtendedDataFaultStatus? ExtendedDataFault { get; }

        public NavigationStatus? NavigationFault { get; }

        public DynamicLimiterStatus? DynamicLimiterFault { get; }
    }
}