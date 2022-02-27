//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MAM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssignedUser
    {
        public int Id { get; set; }
        public string CardNo { get; set; }
        public string Name { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> SectionId { get; set; }
        public string Designation { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    
        public virtual AssignedUser AssignedUser1 { get; set; }
        public virtual AssignedUser AssignedUser2 { get; set; }
        public virtual Company Company { get; set; }
        public virtual Division Division { get; set; }
        public virtual Section Section { get; set; }
    }
}
