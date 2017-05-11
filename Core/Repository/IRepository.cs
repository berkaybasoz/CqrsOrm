using System;
using System.Data;

namespace CqrsOrm.Core.Repository
{
    public interface IRepository : IDisposable
    {
        IDbConnection Connection { get; }
        T Transaction<T>(Func<IDbTransaction, T> query);
        IDbTransaction BeginTransaction();
        void Commit();
        void Rollback();
    }
}
