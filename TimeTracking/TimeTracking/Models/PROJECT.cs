//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeTracking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROJECT
    {
        public PROJECT()
        {
            this.WORKTIMEs = new HashSet<WORKTIME>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime dateStarted { get; set; }
        public Nullable<System.DateTime> dateEnded { get; set; }
    
        public virtual ICollection<WORKTIME> WORKTIMEs { get; set; }
    }
}