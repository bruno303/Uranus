using System;
using Uranus.Source.Interfaces;

namespace Uranus.Source.Threads.EventArguments
{
    public class FuncUranusThreadEventArgs<TResult> : IUranusThreadEventArgs
    {
        public TResult Result { get; set; }
        public bool HasError { get; set; }
        public Exception Error { get; set; }
    }
}