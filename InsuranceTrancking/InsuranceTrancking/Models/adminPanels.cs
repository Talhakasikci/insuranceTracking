namespace InsuranceTrancking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class adminPanels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int adminID { get; set; }

        [StringLength(255)]
        public string Adminname { get; set; }


        [StringLength(255)]
        public string mail { get; set; }


        [StringLength(255)]
        public string adminpassword { get; set; }
    }
}
        