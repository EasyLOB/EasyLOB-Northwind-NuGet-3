﻿using EasyLOB;
using Northwind.Persistence;
using System;

namespace Northwind.Application
{
    public partial class NorthwindApplication : INorthwindApplication
    {
        #region Properties

        public INorthwindUnitOfWork UnitOfWork { get; }

        public IDIManager DIManager { get; }

        #endregion Properties

        #region Methods

        public NorthwindApplication(INorthwindUnitOfWork unitOfWork, IDIManager diManager)
        {
            UnitOfWork = unitOfWork;
            DIManager = diManager;
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose
    }
}