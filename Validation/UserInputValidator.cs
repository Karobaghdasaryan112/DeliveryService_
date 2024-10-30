using DeliveryService.Models;
using DeliveryService.Validation.Interfaces;

namespace DeliveryService.Validation
{
    public class UserInputValidator : IFilteringValidator, ICreatingValidator, IUpdatValidator
    {
        bool IFilteringValidator.FilterOrdersWithCityDistrictValidator(string CityDistrict)
        {
            if (string.IsNullOrEmpty(CityDistrict))
            {
                Console.WriteLine("Ошибка: Городской округ не может быть пустым.");
                return false;
            }
            if (CityDistrict.Length > 20)
            {
                Console.WriteLine("Ошибка: Городской округ должен быть короче 20 символов.");
                return false;
            }
            return true;
        }

        bool IFilteringValidator.FilterOrdersWithTimeIntervalValidator(DateTime startDeliveryDataTime, DateTime EndDeliveryDataTime)
        {
            if (startDeliveryDataTime == DateTime.MinValue || EndDeliveryDataTime == DateTime.MinValue)
            {
                Console.WriteLine("Ошибка: Дата не должна быть пустой.");
                return false;
            }
            if (startDeliveryDataTime >= EndDeliveryDataTime)
            {
                Console.WriteLine("Ошибка: Начальная дата должна быть раньше конечной.");
                return false;
            }
            if (startDeliveryDataTime >= DateTime.Now || EndDeliveryDataTime >= DateTime.Now)
            {
                Console.WriteLine("Ошибка: Даты должны быть в прошлом.");
                return false;
            }
            return true;
        }

        bool IFilteringValidator.FilterOrdersWithWeightValidator(double Weight)
        {
            if (Weight <= 0)
            {
                Console.WriteLine("Ошибка: Вес должен быть положительным числом.");
                return false;
            }
            return true;
        }

        bool IFilteringValidator.FilterParamsValidator(string CityDistrict, DateTime DeliveryDateTime)
        {
            if (DeliveryDateTime == DateTime.MinValue)
            {
                Console.WriteLine("Ошибка: Дата доставки не может быть пустой.");
                return false;
            }
            if (DeliveryDateTime >= DateTime.Now)
            {
                Console.WriteLine("Ошибка: Дата доставки должна быть в прошлом.");
                return false;
            }
            if (string.IsNullOrEmpty(CityDistrict))
            {
                Console.WriteLine("Ошибка: Городской округ не может быть пустым.");
                return false;
            }
            return true;
        }


        bool ICreatingValidator.CreateValidator(string CityDistrict, double Weight)
        {
            if (string.IsNullOrEmpty(CityDistrict))
            {
                Console.WriteLine("Ошибка: Городской округ не может быть пустым.");
                return false;
            }
            if (Weight <= 0)
            {
                Console.WriteLine("Ошибка: Вес должен быть положительным числом.");
                return false;
            }
            return true;
        }

        bool ICreatingValidator.CreateValidator(Order order)
        {
            if (order == null)
            {
                Console.WriteLine("Ошибка: Заказ не может быть пустым.");
                return false;
            }
            if (order.DeliveryDateTime == DateTime.MinValue)
            {
                Console.WriteLine("Ошибка: Дата доставки не может быть пустой.");
                return false;
            }
            if (order.DeliveryDateTime >= DateTime.Now)
            {
                Console.WriteLine("Ошибка: Дата доставки должна быть в прошлом.");
                return false;
            }
            if (string.IsNullOrEmpty(order.CityDistrict))
            {
                Console.WriteLine("Ошибка: Городской округ не может быть пустым.");
                return false;
            }
            if (order.Weight <= 0)
            {
                Console.WriteLine("Ошибка: Вес должен быть положительным числом.");
                return false;
            }
            return true;
        }


        bool IUpdatValidator.Update(Order OldOrder, string CityDistrict, double Weight)
        {
            if (OldOrder == null)
            {
                Console.WriteLine("Ошибка: Старый заказ не может быть пустым.");
                return false;
            }
            if (string.IsNullOrEmpty(CityDistrict))
            {
                Console.WriteLine("Ошибка: Городской округ не может быть пустым.");
                return false;
            }
            if (Weight <= 0)
            {
                Console.WriteLine("Ошибка: Вес должен быть положительным числом.");
                return false;
            }
            return true;
        }

        bool IUpdatValidator.Update(Order OldOrder, Order NewOrder)
        {
            if (OldOrder == null)
            {
                Console.WriteLine("Ошибка: Старый заказ не может быть пустым.");
                return false;
            }
            if (NewOrder == null)
            {
                Console.WriteLine("Ошибка: Новый заказ не может быть пустым.");
                return false;
            }
            if (string.IsNullOrEmpty(NewOrder.CityDistrict))
            {
                Console.WriteLine("Ошибка: Городской округ не может быть пустым.");
                return false;
            }
            if (NewOrder.Weight <= 0)
            {
                Console.WriteLine("Ошибка: Вес должен быть положительным числом.");
                return false;
            }
            if (NewOrder.DeliveryDateTime != OldOrder.DeliveryDateTime)
            {
                Console.WriteLine("Ошибка: Дата доставки не совпадает со старым заказом.");
                return false;
            }
            return true;
        }
    }
}
