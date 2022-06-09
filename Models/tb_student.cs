//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tb_student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_student()
        {
            this.tb_class = new HashSet<tb_class>();
            this.tb_performance = new HashSet<tb_performance>();
        }
    
        public int ID { get; set; }
        [DisplayName("Nama Penuh")]
        public string Name { get; set; }
        [DisplayName("No Kad Pengenalan")]
        public string IC { get; set; }
        [DisplayName("Alamat")]
        public string Address { get; set; }
        [DisplayName("Tarikh")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public Nullable<System.DateTime> Date { get; set; }
        [DisplayName("Nama Pakej")]
        public Nullable<int> Package { get; set; }
        [DisplayName("Nombor Batch")]
        public int BatchID { get; set; }
        [DisplayName("Kod Pelajar")]
        public string RefNo { get; set; }
        public string LoginErrorMessage { get; set; }


        public virtual tb_batches tb_batches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_class> tb_class { get; set; }
        public virtual tb_package tb_package { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_performance> tb_performance { get; set; }
    }
}
