using GACore.Architecture;
using System.Collections.Generic;
using System.Windows.Media;
using GAAPICommon.Core.Dtos;
using System;

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
			if (dictionary.ContainsKey(key)) return dictionary[key];

			return new BrushCollection("Unknown", Brushes.Crimson, Brushes.White);
		}

		public static bool IsInFault(this IKingpinState kingpinState)
		{
			if (kingpinState.PositionControlStatus.IsFault()) return true;

			if (kingpinState.NavigationStatus.IsFault()) return true;

			if (kingpinState.DynamicLimiterStatus.IsFault()) return true;

			if (kingpinState.ExtendedDataFaultStatus.IsFault()) return true;

			return false;
		}

		public static bool IsFault(this ExtendedDataFaultStatus exFaultStatus) => ExDataFaultStates.Contains(exFaultStatus);

		public static HashSet<ExtendedDataFaultStatus> ExDataFaultStates { get; } = new HashSet<ExtendedDataFaultStatus>()
		{
			ExtendedDataFaultStatus.Fault
		};

		public static HashSet<DynamicLimiterStatus> DynamicFaultStates { get; } = new HashSet<DynamicLimiterStatus>()
			{
				DynamicLimiterStatus.MotorFault
			};

		public static HashSet<NavigationStatus> NavigationFaultStates { get; } = new HashSet<NavigationStatus>()
			{
				NavigationStatus.AssociationFailure,
				NavigationStatus.HighUncertainty,
				NavigationStatus.Lost
			};

		public static HashSet<PositionControlStatus> PCSFaultStates { get; } = new HashSet<PositionControlStatus>()
			{
				PositionControlStatus.OutOfPosition,
				PositionControlStatus.WaypointDiscontinuity
			};

		public static bool IsFault(this PositionControlStatus positionControlStatus) => PCSFaultStates.Contains(positionControlStatus);

		public static bool IsFault(this NavigationStatus navigationStatus) => NavigationFaultStates.Contains(navigationStatus);

		public static bool IsFault(this DynamicLimiterStatus dynamicLimiterStatus) => DynamicFaultStates.Contains(dynamicLimiterStatus);
	}
}