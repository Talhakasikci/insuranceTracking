namespace InsuranceTrancking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class driving_license
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LicenseID { get; set; }

        public int? CustomerID { get; set; }

        [StringLength(50)]
        public string LicenseNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ClaimDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        public virtual customers customers { get; set; }
    }
}
