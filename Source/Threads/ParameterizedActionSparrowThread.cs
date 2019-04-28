using System;
using Uranus.Source.Abstracts;
using Uranus.Source.Threads.EventArguments;

namespace Uranus.Source.Threads
{
    public class ParameterizedActionUranusThread<TParameter> :
        ParameterizedUranusThreadAbstract<Action<TParameter>, TParameter, ActionUranusThreadEventArgs, ActionUranusThreadEventArgs>
    {
        protected override ActionUranusThreadEventArgs ArgumentsAfterExecution()
        {
            return new ActionUranusThreadEventArgs()
            {
                HasError = this.HasError,
                Error = this.Error
            };
        }

        protected override ActionUranusThreadEventArgs ArgumentsBeforeExecution()
        {
            return new ActionUranusThreadEventArgs()
            {
                HasError = this.HasError,
                Error = this.Error
            };
        }

        protected override void MethodExecute(TParameter parameter)
        {
            ThreadMethod(parameter);
        }
    }
}