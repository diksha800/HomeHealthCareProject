//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeHealthCareModelClass.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class doctorName
    {
        public int ID { get; set; }
        public int DID { get; set; }
        public string DoctorName1 { get; set; }
    
        public virtual Specialist Specialist { get; set; }
    }
}
