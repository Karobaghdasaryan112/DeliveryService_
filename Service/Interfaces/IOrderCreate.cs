using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.InputDatas.Interfaces
{
    public interface IOrderCreate
    {
        Order Create(string CityDistrict,double Weight);
    }
}
