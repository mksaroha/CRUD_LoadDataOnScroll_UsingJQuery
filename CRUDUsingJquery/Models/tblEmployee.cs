//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDUsingJquery.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> DepartmentID { get; set; }
    
        public virtual tblDepartment tblDepartment { get; set; }
    }
}
