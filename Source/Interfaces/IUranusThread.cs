using System;

namespace Uranus.Source.Interfaces
{
    public interface IUranusThread<TMethod, TBeforeExecutionEventArgs, TAfterExecutionEventArgs>
            : IUranusBaseThread<TMethod, TBeforeExecutionEventArgs, TAfterExecutionEventArgs>
        where TBeforeExecutionEventArgs : IUranusThreadEventArgs
        where TAfterExecutionEventArgs : IUranusThreadEventArgs
    {
        void Execute();
    }
}