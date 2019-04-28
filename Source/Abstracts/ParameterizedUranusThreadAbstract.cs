using System;
using System.Threading;
using Uranus.Source.Interfaces;

namespace Uranus.Source.Abstracts
{
    public abstract class ParameterizedUranusThreadAbstract<TMethod,
                                                TParameter,
                                                TBeforeExecutionEventArgs,
                                                TAfterExecutionEventArgs> :
                          IParameterizedUranusThread<TMethod,
                                         TParameter,
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

        public ParameterizedUranusThreadAbstract()
        {
            executionThread = new Thread(InternalThreadMethod);
        }

        protected void InternalThreadMethod(object parameter)
        {
            try
            {
                Clean();
                OnBeforeExecution();
                MethodExecute((TParameter)parameter);
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

        protected abstract void MethodExecute(TParameter parameter);

        protected virtual void Clean()
        {
            Error = null;
            HasError = false;
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

        public void Execute(TParameter parameter)
        {
            if (!Executing())
            {
                executionThread.Start(parameter);
            }
        }
    }
}