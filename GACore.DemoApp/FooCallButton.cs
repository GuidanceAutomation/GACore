using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GACore.DemoApp
{
    public class FooCallButton : INotifyPropertyChanged
    {
        private LightState? lightState = null;

        private bool? isPressed = null;

        public void Randomize()
        {
            LightState = Tools.RandomEnumValue<LightState>();
            IsPressed = Tools.Random.Next(0, 2) < 1;
        }

        public LightState? LightState
        {
            get { return lightState; }
            set
            {
                if (lightState != value)
                {
                    lightState = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public bool? IsPressed
        {
            get { return isPressed; }
            set
            {
                if (isPressed != value)
                {
                    isPressed = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}