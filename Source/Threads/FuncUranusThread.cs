using System;
using Uranus.Source.Abstracts;
using Uranus.Source.Threads.EventArguments;

namespace Uranus.Source.Threads
{
    public class FuncUranusThread<TResult> : UranusThreadAbstract<Func<TResult>,
                                                FuncUranusThreadEventArgs<TResult>,
                                                FuncUranusThreadEventArgs<TResult>>
    {
        private TResult result;

        protected override FuncUranusThreadEventArgs<TResult> ArgumentsAfterExecution()
        {
            return new FuncUranusThreadEventArgs<TResult>()
            {
                HasError = this.HasError,
                Error = this.Error,
                Result = result
            };
        }

        protected override FuncUranusThreadEventArgs<TResult> ArgumentsBeforeExecution()
        {
            return new FuncUranusThreadEventArgs<TResult>()
            {
                HasError = this.HasError,
                Error = this.Error,
                Result = result
            };
        }

        protected override void Clean()
        {
            base.Clean();
            result = default(TResult);
        }

        protected override void MethodExecute()
        {
            result = ThreadMethod();
        }
    }
}