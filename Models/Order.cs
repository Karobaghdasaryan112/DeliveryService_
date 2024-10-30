using System;

namespace DeliveryService.Models
{
    public class Order
    {
        public string OrderNumber { get;  set; }
        public string CityDistrict { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public double Weight { get; set; }
        public Order(string city, DateTime deliveryDateTime, double weight)
        {
            OrderNumber = (OrderNumber == null) ? GenerateOrderNumber() : OrderNumber;
            CityDistrict = city;
            DeliveryDateTime = deliveryDateTime;
            Weight = weight;
        }
        public Order() { }
        private string GenerateOrderNumber()
        {
            return $"{Guid.NewGuid()}/{DeliveryDateTime:yyyy-MM-ddTHH:mm:ss}/{CityDistrict}";
        }
        public string GetOrder()
        {
            return $"Order Number: {OrderNumber}, City District: {CityDistrict}, Delivery Date: {DeliveryDateTime}, Weight: {Weight} kg";
        }
    }    
}
