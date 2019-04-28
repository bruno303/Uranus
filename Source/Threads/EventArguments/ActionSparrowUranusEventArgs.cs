using System;
using Uranus.Source.Interfaces;

namespace Uranus.Source.Threads.EventArguments
{
    public class ActionUranusThreadEventArgs : IUranusThreadEventArgs
    {
        public bool HasError { get; set; }
        public Exception Error { get; set; }
    }
}