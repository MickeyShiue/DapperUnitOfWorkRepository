using Dapper.DataAccess.DataModel;
using Dapper.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Service.OrderServices
{
    public class OrderService : GenericRepository<Orders>, IOrderService
    {     
        public OrderService(IDbTransaction transaction) : base(transaction)
        {

        }

        public IEnumerable<Orders> GetOrderLsitAll()
        {
            return GetAll();
        }

        public Orders GetOrderByID(int Id)
        {
            return GetById(Id);
        }

        public IEnumerable<dynamic> GetOrderAndDetailAll()
        {
            string sql = @"SELECT * FROM Orders O
                          INNER JOIN OrderDetails D ON O.ID = D.OrderID";

            return Query(sql);
        }
    }
}
