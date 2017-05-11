using CqrsOrm.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsOrm.Core.Connection
{ 
   public class DapperConnection : IConnection
    {
        private readonly IRepository _context;

        public DapperConnection(string connectionString)
        {
            _context = new DapperRepository(connectionString);
        }

        public DapperConnection(DapperRepository context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            return _context.Transaction(transaction =>
            {
                var result = _context.Connection.Query<T>(query, param, transaction);
                return result;
            });
        }

        public void Execute(string sql, object param)
        {
            _context.Transaction(transaction => _context.Connection.Execute(sql, param, transaction));
        }
    }
}
