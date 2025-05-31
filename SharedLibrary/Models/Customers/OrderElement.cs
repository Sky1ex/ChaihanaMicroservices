namespace SharedLibrary.Models.Customers
{
    public class OrderElement
    {
        public Guid OrderElementId { get; set; } = Guid.NewGuid();
        public required Guid ProductId { get; set; }
        public int Count { get; set; } = 1;
    }
}
