using System;
using Uranus.Source.Abstracts;
using Uranus.Source.Threads.EventArguments;

namespace Uranus.Source.Threads
{
    public class ActionUranusThread : UranusThreadAbstract<Action, ActionUranusThreadEventArgs, ActionUranusThreadEventArgs>
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

        protected override void MethodExecute()
        {
            ThreadMethod();
        }
    }
}