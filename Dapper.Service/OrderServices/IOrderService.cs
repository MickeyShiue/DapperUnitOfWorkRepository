using Dapper.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Service.OrderServices
{
    public interface IOrderService
    {
        IEnumerable<Orders> GetOrderLsitAll();

        Orders GetOrderByID(int Id);

        IEnumerable<dynamic> GetOrderAndDetailAll();
    }
}
