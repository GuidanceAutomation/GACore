using GACore.Architecture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GACore.DemoApp
{
    public class FooKingpin : INotifyPropertyChanged
    {
        private IKingpinState kingpinState = new FooKingpinState();

        public IKingpinState KingpinState
        {
            get { return kingpinState; }
            set
            {
                kingpinState = value;
                OnNotifyPropertyChanged();
            }
        }

        public void Randomize()
        {
            KingpinState = new FooKingpinState();
        }

        public void SetGood()
        {
            KingpinState = FooKingpinState.FromGood();
        }

        public FooKingpin()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
