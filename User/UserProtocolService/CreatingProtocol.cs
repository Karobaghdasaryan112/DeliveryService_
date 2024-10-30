using DeliveryService.InputDatas.Interfaces;
using DeliveryService.Logger.Interface.InLogger;
using DeliveryService.Validation.Interfaces;


namespace DeliveryService.User.UserProtocolService
{
    public class CreatingProtocol
    {
        private IOrderCreate _orderService { get; set; }
        private ICreatingValidator _userInputValidator { get; set; }
        private IInCreateModel _inCreate {  get; set; }
        public CreatingProtocol(IOrderCreate orderService, ICreatingValidator userInputValidator)
        {
            _orderService = orderService;
            _userInputValidator = userInputValidator;
        }
        public void CreatingChoise()
        {
            Console.WriteLine("Введите район:");
            string cityDistrict = Console.ReadLine();
            Console.WriteLine("Введите вес заказа:");
            double.TryParse(Console.ReadLine(), out double weight);
            CreateOrder(cityDistrict, weight);
        }
        private void CreateOrder(string CityDistrict,double Weight)
        {
            if (_userInputValidator.CreateValidator(CityDistrict, Weight))
            {
                _orderService.Create(CityDistrict, Weight);
                Console.WriteLine($"Заказ успешно создан с районом: {CityDistrict} и весом: {Weight}.");
            }
        }
    }
}
