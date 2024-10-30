using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Logger.Implementation.LoggerModel
{
    public class OrderInOutModel<T1,T2>
    {
        public T1 _inModel {  get; set; }
        public T2 _outModel {  get; set; }
        public OrderInOutModel(T1 inModel, T2 outModel)
        {
            _inModel = inModel;
            _outModel = outModel;
        }
        public OrderInOutModel() { }
    }
}
