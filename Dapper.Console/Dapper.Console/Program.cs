using Dapper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var Orders = unitOfWork.OrderService.GetOrderLsitAll();  
                var OrderDetails = unitOfWork.OrderDetailService.GetOrderDetailLsitAll();
                var OrderAndDetail = unitOfWork.OrderService.GetOrderAndDetailAll(); //也可以自幹SQL Query
            }
        }
    }
}
