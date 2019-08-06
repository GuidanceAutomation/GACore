using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GACore.DemoApp
{
    public class FooKingpinStatusReporter : IKingpinStatusReporter, INotifyPropertyChanged
    {
        private PositionControlStatus positionControlStatus = Tools.RandomEnumValue<PositionControlStatus>();

        public PositionControlStatus PositionControlStatus
        {
            get { return positionControlStatus; }
            set
            {
                if (positionControlStatus != value)
                {
                    positionControlStatus = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public NavigationStatus navigationStatus = Tools.RandomEnumValue<NavigationStatus>();

        public NavigationStatus NavigationStatus
        {
            get { return navigationStatus; }
            set
            {
                if (navigationStatus != value)
                {
                    navigationStatus = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public DynamicLimiterStatus dynamicLimiterStatus = Tools.RandomEnumValue<DynamicLimiterStatus>();

        public DynamicLimiterStatus DynamicLimiterStatus
        {
            get { return dynamicLimiterStatus; }
            set
            {
                if (dynamicLimiterStatus != value)
                {
                    dynamicLimiterStatus = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public void Randomize()
        {
            PositionControlStatus = Tools.RandomEnumValue<PositionControlStatus>();
            NavigationStatus = Tools.RandomEnumValue<NavigationStatus>();
            DynamicLimiterStatus = Tools.RandomEnumValue<DynamicLimiterStatus>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}