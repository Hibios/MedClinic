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
    
    public partial class MedCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedCard()
        {
            this.User = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public int PolyclinicId { get; set; }
        public Nullable<int> DiseaseListId { get; set; }
    
        public virtual DiseaseList DiseaseList { get; set; }
        public virtual Polyclinic Polyclinic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}
