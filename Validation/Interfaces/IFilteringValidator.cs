using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Validation.Interfaces
{
    public interface IFilteringValidator
    {
        bool FilterParamsValidator(string CityDistrict, DateTime DeliveryDateTime);

        bool FilterOrdersWithTimeIntervalValidator(DateTime startDeliveryDataTime, DateTime EndDeliveryDataTime);

        bool FilterOrdersWithCityDistrictValidator(string CityDistrict);

        bool FilterOrdersWithWeightValidator(double Weight);

    }
}
