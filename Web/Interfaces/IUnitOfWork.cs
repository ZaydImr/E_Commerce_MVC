using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        void Save();
    }
}
