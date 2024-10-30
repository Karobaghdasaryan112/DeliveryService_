using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Logger.Interface.InLogger
{
    public interface IInFilterModel
    {
        double Weight { get; }
        string CityDistrict { get;  }
        DateTime DeliveryDataTime { get; }
        DateTime StartDeliveryDataTime { get; }
        DateTime EndDeliveryDataTime { get;  }
        void LoggingFilter(string CityDistrict, double Weight);
        void LoggingFilter(string CityDistrict, DateTime DeliveryDateTime);
        void LoggingFilter(DateTime StartDeliveryDateTime, DateTime EndDeliveryDateTime);
        void LoggingFilter(string CityDistrict);
        void LoggingFilter(double Weight);

    }
}
