using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Ex_00200_15_30_Entity_Framework.EFModels
{
	public partial class Category
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Category()
		{
			Products = new HashSet<Product>();
		}

		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string CategoryName { get; set; }

		public int DisplayOrder { get; set; }

		public bool Enabled { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Product> Products { get; set; }
	}
}
