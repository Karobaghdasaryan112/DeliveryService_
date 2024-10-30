using DeliveryService.User.UserProtocolService;
namespace DeliveryService.User
{
    public class UserProtocol
    {
        private FilterParamsProtocol _filterParamsProtocol;
        private UpdatingProtocol _updatProtocol;
        private CreatingProtocol _creatingProtocol;
        public UserProtocol(
            FilterParamsProtocol filterParamsProtocol,
            UpdatingProtocol updatProtocol,
            CreatingProtocol creatingProtocol
            )
        {
            _filterParamsProtocol = filterParamsProtocol;
            _updatProtocol = updatProtocol;
            _creatingProtocol = creatingProtocol;
        }
        public void StartInteraction()
        {
                Console.WriteLine("Что вы хотите сделать? (1 - Фильтрация, 2 - Создание, 3 - Обновление, 0 - Выход)");
            while (true)
            {
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _filterParamsProtocol.FilterChoice();
                        break;
                    case "2":
                        _creatingProtocol.CreatingChoise();
                        break;
                    case "3":
                        _updatProtocol.UpdateChoise();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
