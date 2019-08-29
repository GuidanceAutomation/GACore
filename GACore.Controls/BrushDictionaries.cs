using GACore.Architecture;
using System.Collections.Generic;
using System.Windows.Media;

namespace GACore.Controls
{
    public static class BrushDictionaries
    {
        private static readonly Dictionary<DynamicLimiterStatus, BrushCollection> dynamicLimiterStatusBrushCollectionDictionary = new Dictionary<DynamicLimiterStatus, BrushCollection>
        {
            { DynamicLimiterStatus.OK, new BrushCollection(Properties.Resources.UI_DynamicLimiterStatus_OK, Brushes.Black, Brushes.Green) },
            { DynamicLimiterStatus.SafetySensor, new BrushCollection(Properties.Resources.UI_DynamicLimiterStatus_SafetySensor, Brushes.Black, Brushes.Yellow) },
            { DynamicLimiterStatus.Warning_1, new BrushCollection(Properties.Resources.UI_DynamicLimiterStatus_Warning1, Brushes.Black, Brushes.Yellow) },
            { DynamicLimiterStatus.Warning_2, new BrushCollection(Properties.Resources.UI_DynamicLimiterStatus_Warning2, Brushes.Black, Brushes.Yellow) },
            { DynamicLimiterStatus.MotorFault, new BrushCollection(Properties.Resources.UI_DynamicLimiterStatus_MotorFault, Brushes.Black, Brushes.Crimson) },
            { DynamicLimiterStatus.FastStop, new BrushCollection(Properties.Resources.UI_DynamicLimiterStatus_FastStop, Brushes.Black, Brushes.Yellow) },
            { DynamicLimiterStatus.GoSlow, new BrushCollection(Properties.Resources.UI_DynamicLimiterStatus_GoSlow, Brushes.Black, Brushes.Yellow) }
        };

        private static readonly Dictionary<NavigationStatus, BrushCollection> navigationStatusBrushCollectionDictionary = new Dictionary<NavigationStatus, BrushCollection>
        {
            { NavigationStatus.OK, new BrushCollection(Properties.Resources.UI_NavigationStatus_OK, Brushes.Black, Brushes.Green) },
            { NavigationStatus.Lost, new BrushCollection(Properties.Resources.UI_NavigationStatus_Lost, Brushes.Black, Brushes.Crimson) },
            { NavigationStatus.AssociationFailure, new BrushCollection(Properties.Resources.UI_NavigationStatus_AssociationFailure, Brushes.Black, Brushes.Crimson) },
            { NavigationStatus.HighUncertainty, new BrushCollection(Properties.Resources.UI_NavigationStatus_HighUncertainty, Brushes.Black, Brushes.Orange) },
            { NavigationStatus.PoorAssociaton, new BrushCollection(Properties.Resources.UI_NavigationStatus_PoorAssociation, Brushes.Black, Brushes.Yellow) },
            { NavigationStatus.NoResponse, new BrushCollection(Properties.Resources.UI_NavigationStatus_NoResponse, Brushes.Black, Brushes.Crimson) }
        };

        private static readonly Dictionary<PositionControlStatus, BrushCollection> positionControlStatusBrushCollectionDictionary = new Dictionary<PositionControlStatus, BrushCollection>
        {
            {PositionControlStatus.OK, new BrushCollection(Properties.Resources.UI_PositionControlStatus_OK, Brushes.Black, Brushes.Green) },
            {PositionControlStatus.Disabled, new BrushCollection(Properties.Resources.UI_PositionControlStatus_Disabled, Brushes.Silver, Brushes.Black) },
            {PositionControlStatus.Disabling, new BrushCollection(Properties.Resources.UI_PositionControlStatus_Disabling, Brushes.Silver, Brushes.Black) },
            {PositionControlStatus.NoWaypoints, new BrushCollection(Properties.Resources.UI_PositionControlStatus_NoWaypoints, Brushes.Silver, Brushes.Yellow) },
            {PositionControlStatus.OutOfPosition, new BrushCollection(Properties.Resources.UI_PositionControlStatus_OutOfPosition, Brushes.Black, Brushes.Orange) },
            {PositionControlStatus.WaypointDiscontinuity, new BrushCollection(Properties.Resources.UI_PositionControlStatus_WaypointDiscontinuity, Brushes.Black, Brushes.Crimson) }
        };

        public static Dictionary<PositionControlStatus, BrushCollection> PositionControlStatusBackgroundBrushCollectionDictionary => positionControlStatusBrushCollectionDictionary;
        public static Dictionary<DynamicLimiterStatus, BrushCollection> DynamicLimiterStatusBrushCollectionDictionary => dynamicLimiterStatusBrushCollectionDictionary;
        public static Dictionary<NavigationStatus, BrushCollection> NavigationStatusBackgroundBrushCollectionDictionary => navigationStatusBrushCollectionDictionary;
    }
}