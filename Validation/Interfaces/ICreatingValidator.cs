using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Validation.Interfaces
{
    public interface ICreatingValidator
    {
        bool CreateValidator(string CityDistrict, double Weight);
        bool CreateValidator(Order order);
    }
}
