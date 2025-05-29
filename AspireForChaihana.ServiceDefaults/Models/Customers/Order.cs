using System.Net;

namespace AspireForChaihana.ServiceDefaults.Models.Customers
{
    public class Order
    {
        public DateTimeOffset dateTime { get; set; } = DateTimeOffset.Now;

        public Guid OrderId { get; set; } = Guid.NewGuid();

        public List<OrderElement>? OrderElement { get; set; } = new List<OrderElement>();

        public required AddressElement Adress { get; set; }

        public int Sum { get; set; } = 0;

    }
}
