using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Validation.Interfaces
{
    public interface IUpdatValidator
    {
        bool Update(Order OldOrder, string CityDistrict, double Weight);
        bool Update(Order OldOrder, Order NewOrder);
    }
}
