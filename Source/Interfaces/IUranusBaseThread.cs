using System;

namespace Uranus.Source.Interfaces
{
    public interface IUranusBaseThread<TMethod, TBeforeExecutionEventArgs, TAfterExecutionEventArgs>
        where TBeforeExecutionEventArgs : IUranusThreadEventArgs
        where TAfterExecutionEventArgs : IUranusThreadEventArgs
    {
        event EventHandler<TBeforeExecutionEventArgs> BeforeExecution;
        event EventHandler<TAfterExecutionEventArgs> AfterExecution;
        TMethod ThreadMethod { get; set; }
        bool HasError { get; set; }
        Exception Error { get; set; }         
    }
}