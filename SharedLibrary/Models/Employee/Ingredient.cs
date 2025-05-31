using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Employee
{
	[PrimaryKey("IngredientId")]
	public class Ingredient
	{
		public Guid IngredientId { get; set; }

		public string Name { get; set; } 

		public int Unit { get; set; }
		
		// Навигационное свойство (один WorkSchedule принадлежит одному Employee)
		public Employee Employee { get; set; }
	}
}
