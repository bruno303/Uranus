using System;

namespace Uranus.Source.Interfaces
{
    public interface IParameterizedUranusThread<TMethod, TParameter, TBeforeExecutionEventArgs, TAfterExecutionEventArgs>
             : IUranusBaseThread<TMethod, TBeforeExecutionEventArgs, TAfterExecutionEventArgs>
        where TBeforeExecutionEventArgs : IUranusThreadEventArgs
        where TAfterExecutionEventArgs : IUranusThreadEventArgs
    {
        void Execute(TParameter parameter);
    }
}