
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
    
public partial class FormTB
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public FormTB()
    {

        this.ResumeEmployeeTB = new HashSet<ResumeEmployeeTB>();

    }


    public int FormID { get; set; }

    public string Region { get; set; }

    public string City { get; set; }

    public string Benefits { get; set; }

    public string WorkingDays { get; set; }

    public string Gender { get; set; }

    public System.DateTime RequestDtae { get; set; }

    public string FormText { get; set; }

    public string JobDescRiption { get; set; }

    public int JobID { get; set; }



    public virtual JobCategoryTB JobCategoryTB { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ResumeEmployeeTB> ResumeEmployeeTB { get; set; }

}

}
