using GACore.Architecture;
using System.Collections.Generic;
using System.Windows.Media;
using GAAPICommon.Core.Dtos;
using System;
using GAAPICommon.Architecture;

namespace GACore
{
	public static class ExtensionMethods
	{
		private static readonly Dictionary<ReleaseFlag, string> releaseFlagDictionary = new Dictionary<ReleaseFlag, string>()
		{
			{ReleaseFlag.Alpha, "Alpha" },
			{ReleaseFlag.Beta, "Beta" },
			{ReleaseFlag.ReleaseCandidate, "Release candidate" },
			{ReleaseFlag.Release, "Release" }
		};

		public static SemVerDto ToSemVerDto(this ISemVer semVer)
		{
			if (semVer == null) throw new ArgumentNullException("semVer");

			return new SemVerDto()
			{
				Major = semVer.Major,
				Minor = semVer.Minor,
				Patch = semVer.Patch,
				ReleaseFlag = releaseFlagDictionary[semVer.ReleaseFlag]
			};
		}

		public static Color ToColor(this LightState? lightState)
		{
			switch (lightState)
			{
				case LightState.Green: return Colors.Green;

				case LightState.Amber: return Colors.Orange;

				case LightState.Red: return Colors.Red;

				case LightState.Off:
				default:
					return Colors.White;
			}
		}

		public static KingpinFaultDiagnosis Diagnose(this IKingpinState kingpinState) => new KingpinFaultDiagnosis(kingpinState);

		public static BrushCollection GetBrushCollection<T>(this Dictionary<T, BrushCollection> dictionary, T key)
		{
			if (dictionary.ContainsKey(key))
				return dictionary[key];

			return new BrushCollection("Unknown", Brushes.Crimson, Brushes.White);
		}
	}
}