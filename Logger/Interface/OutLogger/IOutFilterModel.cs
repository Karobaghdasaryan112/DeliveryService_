using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Logger.Interface.OutLogger
{
    public interface IOutFilterModel
    {
        public void LoggingFilter(IEnumerable<Order> orders);
        IEnumerable<Order> GetOrders {  get; }

    }
}
