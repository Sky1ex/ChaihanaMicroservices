using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaihanaForEmplyee.Models
{
	public class Cart
    {
        public Cart() { }

        [Key]
        [ForeignKey("User")]
        public Guid CartId { get; set; } = Guid.NewGuid();

        public User User { get; set; }
		[DeleteBehavior(DeleteBehavior.Cascade)]
		public List<CartElement>? CartElement { get; set; } = new List<CartElement>();

    }
}

// Добавить такой же для Order для сохранения корзины.
