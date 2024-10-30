using DeliveryService.InputDatas.Interfaces;
using DeliveryService.Models;
using DeliveryService.Validation.Interfaces;

namespace DeliveryService.User.UserProtocolService
{
    public class UpdatingProtocol
    {
        private IOrderUpdate _orderService { get; set; }
        private IFilterParams _filterParams { get; set; }
        private IUpdatValidator _userInputValidator { get; set; }
        public UpdatingProtocol(IOrderUpdate orderUpdate, IUpdatValidator userInputValidator, IFilterParams filterParams)
        {
            _orderService = orderUpdate;
            _userInputValidator = userInputValidator;
            _filterParams = filterParams;
        }
        public void UpdateChoise()
        {
            Console.WriteLine("Обновление с указанием района и веса");
            Console.WriteLine("Введите старый район:");
            string oldcityDistrict = Console.ReadLine();
            Console.WriteLine("Введите старый вес:");
            string oldSweight = Console.ReadLine();
            Console.WriteLine("Введите новый район:");
            string newcityDistrict = Console.ReadLine();
            Console.WriteLine("Введите новый вес:");
            string newSweight = Console.ReadLine();
            string SnewSweight = Console.ReadLine();
            double.TryParse(SnewSweight, out double newweight);
            double.TryParse(oldSweight, out double oldweight);
            UpdateOrder(oldcityDistrict, oldweight, newcityDistrict, newweight);
        }
        private void UpdateOrder(string OldCityDistrict, double OldWeight, string NewCityDistrict, double NewWeght)
        {
            Order oldOrder = _filterParams.FilterOrder(OldCityDistrict, OldWeight).FirstOrDefault();
            if (_userInputValidator.Update(oldOrder, NewCityDistrict, NewWeght))
            {
                Order ordernew = new Order()
                {
                    CityDistrict = NewCityDistrict,
                    Weight = NewWeght,
                    DeliveryDateTime = DateTime.Now,
                    OrderNumber = oldOrder.OrderNumber,
                };
                if (!_orderService.Update(oldOrder, ordernew))
                {
                    Console.WriteLine("Ошибка: Не удалось обновить заказ.");
                }
                else
                {
                    Console.WriteLine($"Заказ успешно обновлен. Новый район: {NewCityDistrict}, новый вес: {NewWeght}.");
                }
            }
        }
    }
}
