namespace InsuranceTrancking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class payments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentID { get; set; }

        public int? PolicyID { get; set; }

        public double? AmountPaid { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public virtual insurance_policies insurance_policies { get; set; }
    }
}
