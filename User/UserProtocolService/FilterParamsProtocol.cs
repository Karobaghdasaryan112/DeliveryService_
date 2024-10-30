using DeliveryService.InputDatas.Interfaces;
using DeliveryService.Models;
using DeliveryService.Validation.Interfaces;

namespace DeliveryService.User.UserProtocolService
{
    public class FilterParamsProtocol
    {
        private IFilterParams _orderService { get; set; }
        private IFilteringValidator _userFilterValidator { get; set; }
        public FilterParamsProtocol(IFilterParams orderService, IFilteringValidator userInputValidator)
        {
            _orderService = orderService;
            _userFilterValidator = userInputValidator;
        }
        public void FilterChoice()
        {
            Console.WriteLine("Выберите тип фильтрации:");
            Console.WriteLine("1 - Фильтрация по району и времени доставки");
            Console.WriteLine("2 - Фильтрация по интервалу времени доставки");
            Console.WriteLine("3 - Фильтрация по району");
            Console.WriteLine("4 - Фильтрация по весу");

            var filterChoice = Console.ReadLine();

            switch (filterChoice)
            {
                case "1":
                    Console.WriteLine("Введите район:");
                    string cityDistrict = Console.ReadLine();
                    Console.WriteLine("Введите дату:");
                    string deliveryDateTime = Console.ReadLine();
                    DateTime.TryParse(cityDistrict, out DateTime dateTime);
                    FilterParams(cityDistrict, dateTime);
                    break;
                case "2":
                    Console.WriteLine("Введите начальное время доставки:");
                    string startDeliveryDateTime = Console.ReadLine();
                    Console.WriteLine("Введите конечное время доставки:");
                    string endDeliveryDateTime = Console.ReadLine();
                    DateTime.TryParse(startDeliveryDateTime, out DateTime startdateTime);
                    DateTime.TryParse(endDeliveryDateTime, out DateTime enddateTime);
                    FilterParams(startdateTime, enddateTime);
                    break;
                case "3":
                    Console.WriteLine("Введите район:");
                    cityDistrict = Console.ReadLine();
                    FilterParams(cityDistrict);
                    break;
                case "4":
                    Console.WriteLine("Введите вес:");
                    double.TryParse(Console.ReadLine(), out double weight);
                    FilterParams(weight);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
        private void FilterParams(string CityDistrict, DateTime DeliveryDateTime)
        {
            if (_userFilterValidator.FilterParamsValidator(CityDistrict, DeliveryDateTime))
            {
                IEnumerable<Order> Orders = _orderService.FilterOrders(CityDistrict, DeliveryDateTime);
                if (Orders == null)
                {
                    Console.WriteLine("Заказы с указанным городским округом и датой доставки не найдены.");
                }
                else
                {
                    foreach (var order in Orders)
                    {
                        Console.WriteLine($"Заказ номер: {order.OrderNumber}, Район: {order.CityDistrict}, Дата доставки: {order.DeliveryDateTime}");
                    }
                }
            }
        }

        private void FilterParams(DateTime StartDeliveryDataTime, DateTime EndDeliveryDataTime)
        {
            if (_userFilterValidator.FilterOrdersWithTimeIntervalValidator(StartDeliveryDataTime, EndDeliveryDataTime))
            {
                IEnumerable<Order> Orders = _orderService.FilterOrdersWithTimeInterval(StartDeliveryDataTime, EndDeliveryDataTime);
                if (Orders == null)
                {
                    Console.WriteLine("Заказы в указанном временном интервале не найдены.");
                }
                else
                {
                    foreach (var order in Orders)
                    {
                        Console.WriteLine($"Заказ номер: {order.OrderNumber}, Дата доставки: {order.DeliveryDateTime}");
                    }
                }
            }
        }

        private void FilterParams(string CityDistrict)
        {
            if (_userFilterValidator.FilterOrdersWithCityDistrictValidator(CityDistrict))
            {
                IEnumerable<Order> Orders = _orderService.FilterOrdersWithCityDistrict(CityDistrict);
                if (Orders == null)
                {
                    Console.WriteLine("Заказы с указанным городским округом не найдены.");
                }
                else
                {
                    foreach (var order in Orders)
                    {
                        Console.WriteLine($"Заказ номер: {order.OrderNumber}, Район: {order.CityDistrict}, Вес: {order.Weight}");
                    }
                }
            }
        }

        private void FilterParams(double Weight)
        {
            if (_userFilterValidator.FilterOrdersWithWeightValidator(Weight))
            {
                IEnumerable<Order> Orders = _orderService.FilterOrdersWithWeight(Weight);
                if (Orders == null)
                {
                    Console.WriteLine("Заказы с указанным весом не найдены.");
                }
                else
                {
                    foreach (var order in Orders)
                    {
                        Console.WriteLine($"Заказ номер: {order.OrderNumber}, Вес: {order.Weight}, Район: {order.CityDistrict}, Дата доставки: {order.DeliveryDateTime}");
                    }
                }
            }
        }

    }
}
