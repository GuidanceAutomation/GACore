using GAAPICommon.Architecture;
using System;

namespace GACore.Architecture
{
	/// <summary>
	/// SemVer interpretation
	/// </summary>
	public interface ISemVer : IComparable
	{
		int Major { get; }

		int Minor { get; }

		int Patch { get; }

		ReleaseFlag ReleaseFlag { get; }
	}
}
