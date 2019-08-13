using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GACore
{
    [DataContract]
    public class SemVerData : IComparable
    {
        [DataMember]
        public int Major { get; set; }

        [DataMember]
        public int Minor { get; set; }

        [DataMember]
        public int Patch { get; set; }

        public SemVerData(int major, int minor, int patch)
        {
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
        }

        public string ToSummaryString => string.Format("{0}.{1}.{2}", Major, Minor, Patch);

        public override string ToString() => ToSummaryString;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            SemVerData other = obj as SemVerData;

            if (other == null) throw new ArgumentOutOfRangeException("object is not SemVerData");

            int majorResult = Major.CompareTo(other.Major);

            if (majorResult != 0) return majorResult;

            int minorResult = Minor.CompareTo(other.Minor);

            if (minorResult != 0) return minorResult;

            return Patch.CompareTo(other.Patch);
        }
    }
}
