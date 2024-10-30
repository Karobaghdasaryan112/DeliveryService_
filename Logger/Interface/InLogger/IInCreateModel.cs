using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Logger.Interface.InLogger
{
    public interface IInCreateModel
    {
        string CityDistrict { get; }
        double Weight { get; }
        void LoggingCreate(string CityDistraict, double Weight);
    }
}
