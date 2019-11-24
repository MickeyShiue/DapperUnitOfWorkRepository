using Dapper.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dapper.DataAccess.Repositorys
{
    public abstract class GenericRepository<TEntity> where TEntity : BaseModel
    {
        protected IDbTransaction Transaction { get; }

        protected IDbConnection Connection => Transaction.Connection;


        public GenericRepository(IDbTransaction transaction)
        {
            Transaction = transaction;
        }

        protected TEntity GetById(int id)
        {
            return Connection.Get<TEntity>(id, Transaction);
        }

        protected IEnumerable<TEntity> GetAll()
        {
            return Connection.GetList<TEntity>(String.Empty, transaction: Transaction).ToList();
        }

        protected IEnumerable<TEntity> GetAll(string conditions, object parameters = null, int? commandTimeout = null)
        {
            return Connection.GetList<TEntity>(conditions: conditions,
                parameters: parameters,
                transaction: Transaction,
                commandTimeout: commandTimeout).ToList();
        }

        protected IEnumerable<TEntity> GetAll(object whereConditions, int? commandTimeout = null)
        {
            return Connection.GetList<TEntity>(whereConditions: whereConditions,
                transaction: Transaction,
                commandTimeout: commandTimeout).ToList();
        }

        protected IEnumerable<TEntity> Query(string SQL, object parameters = null)
        {
            return Connection.Query<TEntity>(SQL, parameters, Transaction);
        }

        protected void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entity.Id = default(int);
            entity.Id = Connection.Insert(entity, Transaction) ?? default(int);
        }

        protected void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        protected void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Connection.Update(entity, Transaction);
        }

        protected void RemoveById(int id)
        {
            Connection.Delete<TEntity>(id, Transaction);
        }

        protected string GetTableNameMapper()
        {
            dynamic attributeTable = typeof(TEntity).GetCustomAttributes(false)
                .SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");

            return attributeTable != null ? attributeTable.Name : typeof(TEntity).Name;
        }
    }
}
