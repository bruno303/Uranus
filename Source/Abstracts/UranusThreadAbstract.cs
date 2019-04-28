using System;
using System.Threading;
using Uranus.Source.Interfaces;

namespace Uranus.Source.Abstracts
{
    public abstract class UranusThreadAbstract<TMethod,
                                                TBeforeExecutionEventArgs,
                                                TAfterExecutionEventArgs> :
                          IUranusThread<TMethod,
                                         TBeforeExecutionEventArgs,
                                         TAfterExecutionEventArgs>
        where TBeforeExecutionEventArgs : IUranusThreadEventArgs
        where TAfterExecutionEventArgs : IUranusThreadEventArgs
    {
        public TMethod ThreadMethod { get; set; }
        public bool HasError { get; set; }
        public Exception Error { get; set; }

        protected Thread executionThread;

        public event EventHandler<TBeforeExecutionEventArgs> BeforeExecution;
        public event EventHandler<TAfterExecutionEventArgs> AfterExecution;

        public UranusThreadAbstract()
        {
            executionThread = new Thread(InternalThreadMethod);
        }

        protected void InternalThreadMethod()
        {
            try
            {
                Clean();
                OnBeforeExecution();
                MethodExecute();
            }
            catch(Exception ex)
            {
                HasError = true;
                Error = ex;
            }
            finally
            {
                OnAfterExecution();
            }
        }

        protected abstract void MethodExecute();

        protected virtual void Clean()
        {
            Error = null;
            HasError = false;
        }

        public void Execute()
        {
            if (!Executing())
            {
                executionThread.Start();
            }
        }

        protected abstract TAfterExecutionEventArgs ArgumentsAfterExecution();

        protected abstract TBeforeExecutionEventArgs ArgumentsBeforeExecution();

        protected bool Executing() => executionThread.ThreadState == ThreadState.Running;

        private void OnBeforeExecution()
        {
            BeforeExecution?.Invoke(this, ArgumentsBeforeExecution());
        }

        private void OnAfterExecution()
        {
            AfterExecution?.Invoke(this, ArgumentsAfterExecution());
        }
    }
}