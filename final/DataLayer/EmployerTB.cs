
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DataLayer
{

using System;
    using System.Collections.Generic;
    
public partial class EmployerTB
{

    public int EmployerID { get; set; }

    public Nullable<int> ResumeID { get; set; }

    public int UserID { get; set; }



    public virtual ResumeTB ResumeTB { get; set; }

    public virtual UserTB UserTB { get; set; }

}

}
