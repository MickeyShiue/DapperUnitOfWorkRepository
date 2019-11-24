using Dapper.Service.OrderDetailServices;
using Dapper.Service.OrderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Service
{
    interface IUnitOfWork : IDisposable
    {
        IOrderService OrderService { get; }

        IOrderDetailService OrderDetailService { get; }

        void Complete();
    }
}
