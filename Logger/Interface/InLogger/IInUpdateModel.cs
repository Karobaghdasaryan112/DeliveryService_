using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Logger.Interface.InLogger
{
    public interface IInUpdateModel
    {
        string CityDistrict { get; }
        double Weight { get; }
        Order NewOrder { get; }
        Order OldOrder { get; }
        void LoggerUpdate(string CityDistrict, double Weight);
        void LoggerUpdate(Order OldOrder);
    }
}
