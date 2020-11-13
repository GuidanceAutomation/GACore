using System;

namespace GACore.Architecture
{
    public interface IRestartRequestable
    {
        event Action RestartRequested;

        void RequestRestart();
    }
}
