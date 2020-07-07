namespace FashionShop.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("doan.khuyenmai")]
    public partial class khuyenmai
    {
        [Key]
        public int MAKM { get; set; }

        public int PHANTRAMKM { get; set; }

        [Column(TypeName = "date")]
        public DateTime TGBD { get; set; }

        [Column(TypeName = "date")]
        public DateTime TGKT { get; set; }
    }
}
