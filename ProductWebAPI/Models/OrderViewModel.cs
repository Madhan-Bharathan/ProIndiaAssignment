namespace ProductWebAPI.Models
{
    public class OrderViewModel
    {
        public Int64 OrderId { get; set; }
        public String OrderName { get; set; }
        public int Quantity { get; set; }
        public Int64 Price { get; set; }
        public Int64 ProductRefId { get; set; }

    }
}
