using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Logger.Interface.OutLogger
{
    public interface IOutCreateModel
    {
        public Order CreatingOrder {  get;}
        public void LoggingCreate(Order CreateOrder);
    }
}
