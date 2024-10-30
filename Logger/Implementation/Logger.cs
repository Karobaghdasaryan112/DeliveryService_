using DeliveryService.Logger.Implementation.LoggerModel;
using DeliveryService.Logger.Interface.InLogger;
using DeliveryService.Logger.Interface.OutLogger;
using DeliveryService.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeliveryService.Logger.Implementation
{
    public class Logger
    {
        private OrderInOutModel<IInFilterModel,IOutFilterModel> _orderInOutModelFilter;
        private OrderInOutModel<IInCreateModel, IOutCreateModel> _orderInOutModelCreate;
        private OrderInOutModel<IInUpdateModel, IOutUpdateModel> _orderInOutModelUpdate;
        private string _jsonString {  get; set; }
        private readonly string _ordersPath = "C:\\Users\\Samsung\\source\\repos\\DeliveryService\\Logs\\Log.json";
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { 
            WriteIndented = true, 
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        public Logger() { }
        public void Log(IInFilterModel filterModel, IOutFilterModel outFilter)
        {
            _orderInOutModelFilter = new OrderInOutModel<IInFilterModel,IOutFilterModel>(filterModel,outFilter);
            _jsonString = JsonSerializer.Serialize(_orderInOutModelFilter, _options);
            SaveToFile(_jsonString);
        }

        public void Log(IInCreateModel createModel, IOutCreateModel outCreate)
        {
            _orderInOutModelCreate = new OrderInOutModel<IInCreateModel, IOutCreateModel>(createModel, outCreate);
            _jsonString = JsonSerializer.Serialize(_orderInOutModelCreate, _options);
            SaveToFile(_jsonString);
        }

        public void Log(IInUpdateModel updateModel, IOutUpdateModel outUpdate)
        {
            _orderInOutModelUpdate = new OrderInOutModel<IInUpdateModel, IOutUpdateModel>(updateModel,outUpdate);
            _jsonString = JsonSerializer.Serialize(_orderInOutModelUpdate, _options);
            SaveToFile(_jsonString);
        }


        private void SaveToFile(string JsonStringInOut)
        {
            string ExistData = File.Exists(_ordersPath) ? File.ReadAllText(_ordersPath) : string.Empty;

            if (string.IsNullOrEmpty(ExistData))
            {
                ExistData = "[" + Environment.NewLine + JsonStringInOut + Environment.NewLine + "]";
            }
            else
            {
                ExistData = ExistData.TrimEnd(']', '\n', '\r') + "," + Environment.NewLine + JsonStringInOut + Environment.NewLine + "]";
            }
            File.WriteAllText(_ordersPath, ExistData);
        }
    }
}
