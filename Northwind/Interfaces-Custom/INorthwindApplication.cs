using EasyLOB;
using System;

namespace Northwind
{
    public interface INorthwindApplication : IDisposable
    {
        #region Properties

        IDIManager DIManager { get; }

        #endregion Properties
    }
}