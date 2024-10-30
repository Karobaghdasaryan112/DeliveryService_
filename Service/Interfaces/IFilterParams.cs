using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.InputDatas.Interfaces
{
    public interface IFilterParams
    {
        IEnumerable<Order> FilterOrders(string CityDistrict, DateTime DeliveryDataTime);
        IEnumerable<Order> FilterOrdersWithTimeInterval(DateTime startDeliveryDataTime, DateTime EndDeliveryDataTime);
        IEnumerable<Order> FilterOrdersWithCityDistrict(string CityDistrict);
        IEnumerable<Order> FilterOrdersWithWeight(double Weight);
        IEnumerable<Order> FilterOrder(string CityDistrict,double weight);
    }
}
