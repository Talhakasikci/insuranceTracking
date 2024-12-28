namespace InsuranceTrancking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class insurance_policies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public insurance_policies()
        {
            accident_reports = new HashSet<accident_reports>();
            payments = new HashSet<payments>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolicyID { get; set; }

        [StringLength(50)]
        public string PolicyNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [StringLength(100)]
        public string CoverageType { get; set; }

        public int? VehicleID { get; set; }

        public int? CustomerID { get; set; }

        public int? InsuranceCompanyID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<accident_reports> accident_reports { get; set; }

        public virtual customers customers { get; set; }

        public virtual insurance_companies insurance_companies { get; set; }

        public virtual vehicles vehicles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payments> payments { get; set; }
    }
}
