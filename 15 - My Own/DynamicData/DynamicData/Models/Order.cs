namespace DynamicData.Models
{
    public class Order
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public OrderStatus Status { get; set; }
        public OrderStatus[] PossibleStatuses { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Approved,
        Cancelled,
    }
}