//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheList.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblListTipo
    {
        public tblListTipo()
        {
            this.tblList = new HashSet<tblList>();
        }
    
        public int listTipoID { get; set; }
        public string listTipoNome { get; set; }
    
        public virtual ICollection<tblList> tblList { get; set; }
    }
}
