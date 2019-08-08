using System.Collections.Generic;
using System.Windows.Media;

namespace GACore
{
    public static class ExtensionMethods
    {
        public static Color ToColor(this LightState? lightState)
        {
            switch (lightState)
            {
                case LightState.Green: return Colors.Green;

                case LightState.Amber: return Colors.Orange;

                case LightState.Red: return Colors.Red;

                case LightState.Off:
                default:
                    return Colors.Beige;
            }
        }

        public static BrushCollection GetBrushCollection<T>(this Dictionary<T, BrushCollection> dictionary, T key)
        {
            if (dictionary.ContainsKey(key)) return dictionary[key];

            return new BrushCollection("Unknown", Brushes.Crimson, Brushes.White);
        }

        private readonly static HashSet<DynamicLimiterStatus> dynamicFaultStates = new HashSet<DynamicLimiterStatus>()
            {
                DynamicLimiterStatus.MotorFault
            };

        private readonly static HashSet<NavigationStatus> navigationFaultStates = new HashSet<NavigationStatus>()
            {
                NavigationStatus.AssociationFailure,
                NavigationStatus.HighUncertainty,
                NavigationStatus.Lost
            };

        private readonly static HashSet<PositionControlStatus> pcsFaultStates = new HashSet<PositionControlStatus>()
            {
                PositionControlStatus.OutOfPosition,
                PositionControlStatus.WaypointDiscontinuity
            };

        public static HashSet<DynamicLimiterStatus> DynamicFaultStates => dynamicFaultStates;

        public static HashSet<NavigationStatus> NavigationFaultStates => navigationFaultStates;

        public static HashSet<PositionControlStatus> PCSFaultStates => pcsFaultStates;

        public static bool IsFault(this PositionControlStatus positionControlStatus) => PCSFaultStates.Contains(positionControlStatus);

        public static bool IsFault(this NavigationStatus navigationStatus) => NavigationFaultStates.Contains(navigationStatus);

        public static bool IsFault(this DynamicLimiterStatus dynamicLimiterStatus) => DynamicFaultStates.Contains(dynamicLimiterStatus);
    }
}