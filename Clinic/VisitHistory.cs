//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinic
{
    using System;
    using System.Collections.Generic;
    
    public partial class VisitHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VisitHistory()
        {
            this.DiseaseVisit = new HashSet<DiseaseVisit>();
        }
    
        public int Id { get; set; }
        public System.DateTime VisitTime { get; set; }
        public int StaffId { get; set; }
        public bool Attendance { get; set; }
        public string VisitCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiseaseVisit> DiseaseVisit { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
