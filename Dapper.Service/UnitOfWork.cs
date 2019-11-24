using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.DataAccess.Infrastructure;
using Dapper.Service.OrderDetailServices;
using Dapper.Service.OrderServices;

namespace Dapper.Service
{
    public class UnitOfWork: IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;


        private IOrderService _OrderService;
        private IOrderDetailService _OrderDetailService;

        public UnitOfWork()
        {
            var factory = new ConnectionFactory();

            _connection = factory.CreateDbConn();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }


        public IOrderService OrderService => _OrderService ?? (_OrderService = new OrderService(_transaction));

        public IOrderDetailService OrderDetailService => _OrderDetailService ?? (_OrderDetailService = new OrderDetailService(_transaction));

        public void Complete()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _OrderService = null;
            _OrderDetailService = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
    }
}
