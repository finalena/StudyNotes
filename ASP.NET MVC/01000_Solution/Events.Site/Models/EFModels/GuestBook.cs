namespace Events.Site.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GuestBook
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        [StringLength(10)]
        public string CellPhone { get; set; }

        [Required]
        [StringLength(200)]
        public string Message { get; set; }

		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:ss:mm}", ApplyFormatInEditMode = true)]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime CreateTime { get; set; }
    }
}
