
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
    
public partial class EmployeeTB
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public EmployeeTB()
    {

        this.FormDetailTB = new HashSet<FormDetailTB>();

    }


    public int EmployeeID { get; set; }

    public int UserID { get; set; }

    public Nullable<int> PhoneNumber { get; set; }

    public string Site { get; set; }

    public string Adress { get; set; }

    public string CompanyName { get; set; }



    public virtual UserTB UserTB { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<FormDetailTB> FormDetailTB { get; set; }

}

}
