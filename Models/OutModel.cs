using DeliveryService.Logger.Interface.OutLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class OutModel : IOutCreateModel, IOutFilterModel, IOutUpdateModel
    {
        private Order _creatingOrder {  get; set; }
        private IEnumerable<Order> _orders { get; set; }
        private List<Order> _updateingOrders { get; set; }
        Order IOutCreateModel.CreatingOrder => _creatingOrder;

        IEnumerable<Order> IOutFilterModel.GetOrders => _orders;

        List<Order> IOutUpdateModel.OldAndNewOrders => _updateingOrders;

        void IOutCreateModel.LoggingCreate(Order CreateOrder)
        {
            _creatingOrder = CreateOrder;
        }

        void IOutFilterModel.LoggingFilter(IEnumerable<Order> orders)
        {
            _orders = orders;
        }

        void IOutUpdateModel.UpdatingOrders(List<Order> orders)
        {
                _updateingOrders = orders;
        }
    }
}
