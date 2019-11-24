using Dapper.DataAccess.DataModel;
using System.Collections.Generic;

namespace Dapper.Service.OrderDetailServices
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetails> GetOrderDetailLsitAll();

        OrderDetails GetOrderDetailByID(int Id);
    }
}
