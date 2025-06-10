using System.ComponentModel;

namespace SharedLibrary.DTO
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int Apartment {  get; set; }
    }
}
