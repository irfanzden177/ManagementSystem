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

    public partial class tb_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_user()
        {
            this.tb_class = new HashSet<tb_class>();
            this.tb_salary = new HashSet<tb_salary>();
        }
    
        public int ID { get; set; }
        [DisplayName("Nombor Kad Pengenalan")]
        [Range(0, int.MaxValue, ErrorMessage = "Sila masukkan nombor kad pengenalan yang betul")]
        public string IC { get; set; }
        [DisplayName("Nama Penuh")]
        public string Name { get; set; }
        [DisplayName("Pengguna")]
        public Nullable<int> Role { get; set; }
        [DisplayName("Kata Laluan")]
        public string Password { get; set; }
        [DisplayName("Emel")]
        public string Email { get; set; }
        [DisplayName("Nombor Telefon")]
        [Range(0, int.MaxValue, ErrorMessage = "Sila masukkan nombor telefon yang betul")]
        public string Contact { get; set; }
        [DisplayName("Status")]
        public Nullable<int> Status { get; set; }
        [DisplayName("Nombor Batch")]
        public Nullable<int> BatchID { get; set; }
        public string LoginErrorMessage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_class> tb_class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_salary> tb_salary { get; set; }
        public virtual tb_status tb_status { get; set; }
    }
}
