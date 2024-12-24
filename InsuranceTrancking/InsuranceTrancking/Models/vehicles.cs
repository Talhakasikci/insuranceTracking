namespace InsuranceTrancking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vehicles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vehicles()
        {
            accident_reports = new HashSet<accident_reports>();
            insurance_policies = new HashSet<insurance_policies>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VehicleID { get; set; }

        [StringLength(100)]
        public string Brand { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        public int? Year { get; set; }

        public int? CustomerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CustomerClaimDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<accident_reports> accident_reports { get; set; }

        public virtual customers customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<insurance_policies> insurance_policies { get; set; }
    }
}
