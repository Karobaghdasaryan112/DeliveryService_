using DeliveryService.InputDatas.Interfaces;
using DeliveryService.Models;
using Microsoft.Extensions.Logging;
using DeliveryService.Logger.Implementation;
using DeliveryService.Logger.Interface.InLogger;
using DeliveryService.Logger.Interface.OutLogger;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DeliveryService.Service.Implementations
{
    public class OrderService : IFilterParams, IOrderCreate, IOrderUpdate
    {

        private readonly string _loggerPath = "C:\\Users\\Samsung\\source\\repos\\DeliveryService\\Data\\Orders.json";
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true, AllowTrailingCommas = true };
        private IInCreateModel _inCreate { get; set; }
        private IInFilterModel _inFilter { get; set; }
        private IInUpdateModel _inUpdate { get; set; }
        private IOutCreateModel _outCreate { get; set; }
        private IOutFilterModel _outFilter { get; set; }
        private IOutUpdateModel _outUpdate { get; set; }
        private Logger.Implementation.Logger _logger { get; set; }
        
        public OrderService(Logger.Implementation.Logger logger)
        {
            _logger = logger;

        }
        public OrderService(IInCreateModel inCreate, IOutCreateModel outCreate, Logger.Implementation.Logger logger) : this(logger)
        {
            _inCreate = inCreate;
            _outCreate = outCreate;
        }
        public OrderService(IInFilterModel inFilter, IOutFilterModel outFilter, Logger.Implementation.Logger logger) : this(logger)
        {
            _inFilter = inFilter;
            _outFilter = outFilter;
        }
        public OrderService(IInUpdateModel inUpdate, IOutUpdateModel outUpdate, Logger.Implementation.Logger logger) : this(logger)
        {
            _inUpdate = inUpdate;
            _outUpdate = outUpdate;
        }
        public Order Create(string CityDistrict, double Weight)
        {
            List<Order> Orders = GetAllOrders();
            Order order = new Order(CityDistrict,DateTime.Now,Weight)
            {
            };
            Orders.Add(order);
            string jsonString = JsonSerializer.Serialize(Orders, _options);
            File.WriteAllText(_loggerPath, jsonString);
            _inCreate.LoggingCreate(CityDistrict, Weight);
            _outCreate.LoggingCreate(order);
            _logger.Log(_inCreate, _outCreate);
            Console.WriteLine(order.GetOrder());
            return order;
        }

        public IEnumerable<Order> FilterOrder(string CityDistrict, double weight)
        {
            IEnumerable<Order> orders = GetAllOrders().Where(Order => (Order.CityDistrict == CityDistrict 
            && Order.Weight == weight));
            _outFilter.LoggingFilter(orders);
            _inFilter.LoggingFilter(CityDistrict,weight);
            _logger.Log(_inFilter, _outFilter);
            return orders;
        }

        public IEnumerable<Order> FilterOrders(string CityDistrict, DateTime DeliveryDataTime)
        {
            IEnumerable<Order> orders = GetAllOrders().Where(Order =>  Order.CityDistrict == CityDistrict 
            && Order.DeliveryDateTime == DeliveryDataTime);
            _outFilter.LoggingFilter(orders);
            _inFilter.LoggingFilter(CityDistrict, DeliveryDataTime);
            _logger.Log(_inFilter, _outFilter);
            return orders;
        }

        public IEnumerable<Order> FilterOrdersWithCityDistrict(string CityDistrict)
        {
            IEnumerable<Order> orders = GetAllOrders().Where(Order => Order.CityDistrict == CityDistrict);
            _outFilter.LoggingFilter(orders);
            _inFilter.LoggingFilter(CityDistrict);
            _logger.Log(_inFilter, _outFilter);
            return orders;
        }

        public IEnumerable<Order> FilterOrdersWithTimeInterval(DateTime startDeliveryDataTime, DateTime EndDeliveryDataTime)
        {
            IEnumerable<Order> orders = GetAllOrders().Where(Order => (Order.DeliveryDateTime > startDeliveryDataTime
            && Order.DeliveryDateTime < EndDeliveryDataTime));
            _outFilter.LoggingFilter(orders);
            _inFilter.LoggingFilter(startDeliveryDataTime, EndDeliveryDataTime);
            _logger.Log(_inFilter, _outFilter);
            return orders;
        }

        public IEnumerable<Order> FilterOrdersWithWeight(double Weight)
        {
            IEnumerable<Order> orders = GetAllOrders().Where(Order => Order.Weight == Weight);
            _outFilter.LoggingFilter(orders);
            _inFilter.LoggingFilter(Weight);
            _logger.Log(_inFilter, _outFilter);
            return orders;
        }



        public bool Update(Order OldOrder, Order NewOrder)
        {
            List<Order> Orders = GetAllOrders();
            Order FindOrder = Orders.FirstOrDefault(Order => Order.OrderNumber == OldOrder.OrderNumber);
            if (FindOrder != null)
            {
                List<Order> NewAndOldOrders = new List<Order>()
                {
                    OldOrder,
                    NewOrder
                };
                _outUpdate.UpdatingOrders(NewAndOldOrders);
                _inUpdate.LoggerUpdate(OldOrder);
                _logger.Log(_inUpdate, _outUpdate);
                FindOrder.Weight = NewOrder.Weight;
                FindOrder.CityDistrict = NewOrder.CityDistrict;
                string jsonString = JsonSerializer.Serialize(Orders, _options);
                File.WriteAllText(_loggerPath, jsonString);
                return true;
            }
            return false;
        }
        private List<Order> GetAllOrders()
        {
            var ordersJson = File.ReadAllText(_loggerPath);
            
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(ordersJson);
            return orders;
        } 
    }
}
