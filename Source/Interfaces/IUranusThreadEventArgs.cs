using System;

namespace Uranus.Source.Interfaces
{
    public interface IUranusThreadEventArgs
    {
        bool HasError { get; set; }
        Exception Error { get; set; }
    }
}