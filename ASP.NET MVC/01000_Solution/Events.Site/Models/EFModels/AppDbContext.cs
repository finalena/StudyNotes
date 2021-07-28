namespace Events.Site.Models.EFModels
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=EventConnectionString")
		{
		}

		public virtual DbSet<Register> Registers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
