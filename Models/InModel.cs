using DeliveryService.Logger.Interface.InLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class InModel : IInCreateModel, IInFilterModel, IInUpdateModel
    {
        private string _sityDistrict { get; set; }
        private double _weight { get; set; }
        private Order _newOrder { get; set; }
        private Order _oldOrder { get; set; }
        private DateTime _deliveryDateTime { get; set; }
        private DateTime _endDeliveryDateTime { get; set; }
        private DateTime _startDeliveryDateTime { get; set; }


        string IInCreateModel.CityDistrict => _sityDistrict;
        double IInCreateModel.Weight => _weight;
        void IInCreateModel.LoggingCreate(string CityDistraict, double Weight)
        {
            _sityDistrict = CityDistraict;
            _weight = Weight;
        }








        Order IInUpdateModel.NewOrder => _newOrder;

        Order IInUpdateModel.OldOrder => _oldOrder;

        string IInUpdateModel.CityDistrict => _sityDistrict;
        double IInUpdateModel.Weight => _weight;
        void IInUpdateModel.LoggerUpdate(string CityDistrict, double Weight)
        {
            _sityDistrict = CityDistrict;
            _weight = Weight;
        }

        void IInUpdateModel.LoggerUpdate( Order OldOrder)
        {
            _oldOrder = OldOrder;
        }






        string IInFilterModel.CityDistrict => _sityDistrict;
        double IInFilterModel.Weight => _weight;

        DateTime IInFilterModel.DeliveryDataTime => _deliveryDateTime;

        DateTime IInFilterModel.StartDeliveryDataTime => _startDeliveryDateTime;

        DateTime IInFilterModel.EndDeliveryDataTime => _endDeliveryDateTime;


        void IInFilterModel.LoggingFilter(double Weight)
        {
            this._weight = Weight;
        }


        void IInFilterModel.LoggingFilter(string CityDistrict, double Weight)
        {
            _sityDistrict = CityDistrict;
            _weight = Weight;
        }

        void IInFilterModel.LoggingFilter(string CityDistrict, DateTime DeliveryDateTime)
        {
            _sityDistrict = CityDistrict;
            _deliveryDateTime = DeliveryDateTime;
        }

        void IInFilterModel.LoggingFilter(DateTime StartDeliveryDateTime, DateTime EndDeliveryDateTime)
        {
            this._startDeliveryDateTime = StartDeliveryDateTime;
            this._endDeliveryDateTime = EndDeliveryDateTime;
        }

        void IInFilterModel.LoggingFilter(string CityDistrict)
        {
            this._sityDistrict = CityDistrict;
        }


    }
}
