using System;
using System.Runtime.InteropServices;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Infrastructure.Domain.Models;
using Microsoft.Win32.SafeHandles;

namespace HvCommerce.Core.Infrastructure.EntityFramework
{
    public class Repository<T> : RepositoryWithTypedId<T, long>, IRepository<T>
        where T : class, IEntityWithTypedId<long>
    {
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private bool disposed;

        public Repository(HvDbContext context) : base(context)
        {
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.handle.Dispose();
            }

            this.disposed = true;
        }
    }
}