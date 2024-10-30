using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Logger.Interface.OutLogger
{
    public interface IOutUpdateModel
    {
        public List<Order> OldAndNewOrders { get; }
        public void UpdatingOrders(List<Order> orders);
    }
}
