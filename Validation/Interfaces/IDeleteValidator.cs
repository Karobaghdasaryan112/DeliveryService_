using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Validation.Interfaces
{
    public interface IDeleteValidator
    {
        bool Delete(Order order);
        bool Delete(string OrderNumber);
    }
}
