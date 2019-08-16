using GACore.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACore
{
    /// <summary>
    /// An an object to capture the current fault state of a Kingpin
    /// </summary>
    public class KingpinFaultDiagnosis
    {
        private readonly PositionControlStatus? pcsFault;

        private readonly ExtendedDataFaultStatus? extendedDataFault;

        private readonly NavigationStatus? navigationFault;

        private readonly DynamicLimiterStatus? dynamicLimiterFault;

        public KingpinFaultDiagnosis(IKingpinState kingpinState)
        {
            if (kingpinState == null)
            {
                throw new ArgumentNullException("kingpinState");
            }

            dynamicLimiterFault = kingpinState.DynamicLimiterStatus.IsFault() ?
                (DynamicLimiterStatus?)kingpinState.DynamicLimiterStatus : null;

            extendedDataFault = kingpinState.ExtendedDataFaultStatus.IsFault() ?
                (ExtendedDataFaultStatus?)kingpinState.ExtendedDataFaultStatus : null;

            navigationFault = kingpinState.NavigationStatus.IsFault() ?
                (NavigationStatus?)kingpinState.NavigationStatus : null;

            pcsFault = kingpinState.PositionControlStatus.IsFault() ?
                (PositionControlStatus?)kingpinState.PositionControlStatus : null;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + dynamicLimiterFault.GetHashCode();
                hash = hash * 23 + extendedDataFault.GetHashCode();
                hash = hash * 23 + navigationFault.GetHashCode();
                hash = hash * 23 + pcsFault.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            KingpinFaultDiagnosis other = obj as KingpinFaultDiagnosis;

            if (other == null) return false;

            return this.dynamicLimiterFault.Equals(other.dynamicLimiterFault)
                && this.extendedDataFault.Equals(other.extendedDataFault)
                && this.navigationFault.Equals(other.navigationFault)
                && this.pcsFault.Equals(other.pcsFault);
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

        public PositionControlStatus? PCSFault => pcsFault;

        public ExtendedDataFaultStatus? ExtendedDataFault => extendedDataFault;

        public NavigationStatus? NavigationFault => navigationFault;

        public DynamicLimiterStatus? DynamicLimiterFault => dynamicLimiterFault;
    }
}
