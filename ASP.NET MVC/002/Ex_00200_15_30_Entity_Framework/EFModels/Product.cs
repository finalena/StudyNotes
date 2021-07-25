using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Ex_00200_15_30_Entity_Framework.EFModels
{
	public partial class Product
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string ProductName { get; set; }

		public int CategoryId { get; set; }

		public int UnitPrice { get; set; }

		public bool Enabled { get; set; }

		public virtual Category Category { get; set; }
	}
}
