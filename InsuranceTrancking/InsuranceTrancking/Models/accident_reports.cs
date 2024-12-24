namespace InsuranceTrancking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class accident_reports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReportID { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        public int? VehicleID { get; set; }

        public int? PolicyID { get; set; }

        public int? RepairShopID { get; set; }

        public virtual insurance_policies insurance_policies { get; set; }

        public virtual repair_shops repair_shops { get; set; }

        public virtual vehicles vehicles { get; set; }
    }
}
