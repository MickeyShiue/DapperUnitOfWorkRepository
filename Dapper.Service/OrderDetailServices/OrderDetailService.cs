using Dapper.DataAccess.DataModel;
using Dapper.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Service.OrderDetailServices
{
    public class OrderDetailService : GenericRepository<OrderDetails>, IOrderDetailService
    {
        public OrderDetailService(IDbTransaction transaction) : base(transaction)
        {

        }

        public IEnumerable<OrderDetails> GetOrderDetailLsitAll()
        {
            return GetAll();
        }
        public OrderDetails GetOrderDetailByID(int Id)
        {
            return GetById(Id);
        }
    }
}
