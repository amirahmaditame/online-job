
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
    
public partial class JobCategoryTB
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public JobCategoryTB()
    {

        this.CommentTB = new HashSet<CommentTB>();

        this.SelectedJobTB = new HashSet<SelectedJobTB>();

    }


    public int JobID { get; set; }

    public string JobCategory { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CommentTB> CommentTB { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SelectedJobTB> SelectedJobTB { get; set; }

}

}
