//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhanSu_HoDangTai_63135354.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CALAMVIEC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CALAMVIEC()
        {
            this.CHAMCONGs = new HashSet<CHAMCONG>();
            this.PHANCONGs = new HashSet<PHANCONG>();
        }
    
        public string MACA { get; set; }
        public string MOTACALAMVIEC { get; set; }
        public Nullable<System.TimeSpan> TGBATDAU { get; set; }
        public Nullable<System.TimeSpan> TGKETTHUC { get; set; }
        public Nullable<System.DateTime> NGAYLAMVIEC { get; set; }
        public Nullable<int> SLNHANVIEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHAMCONG> CHAMCONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONG> PHANCONGs { get; set; }
    }
}