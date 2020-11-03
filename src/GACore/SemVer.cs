using GAAPICommon.Architecture;
using GACore.Architecture;
using System;

namespace GACore
{
	public class SemVer : ISemVer
	{
		public SemVer(Version version)
		{
			if (version == null) throw new ArgumentNullException("version");

			Major = version.Major;
			Minor = version.Minor;
			Patch = version.Build;
			ReleaseFlag = (ReleaseFlag)version.Revision;
		}

		public SemVer(int major, int minor, int patch, ReleaseFlag releaseFlag)
		{
			Major = major;
			Minor = minor;
			Patch = patch;
			ReleaseFlag = releaseFlag;
		}

		public int Major { get; } = -1;

		public int Minor { get; } = -1;

		public int Patch { get; } = -1;

		public ReleaseFlag ReleaseFlag { get; } = ReleaseFlag.Alpha;

		public override string ToString() => this.ToSemVerVersionString();

		public int CompareTo(object obj)
		{
			if (obj == null) return 1;

			if (!(obj is ISemVer other)) throw new ArgumentOutOfRangeException("object is not ISemVer");

			int majorResult = Major.CompareTo(other.Major);

			if (majorResult != 0) return majorResult;

			int minorResult = Minor.CompareTo(other.Minor);

			if (minorResult != 0) return minorResult;

			int patchResult =  Patch.CompareTo(other.Patch);

			if (patchResult != 0) return patchResult;

			return ReleaseFlag.CompareTo(other.ReleaseFlag);
		}
	}
}
