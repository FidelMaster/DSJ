//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSJ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblTicketDocumento
    {
        public int Id { get; set; }
        public Nullable<int> IdTicket { get; set; }
        public string documento { get; set; }
        public byte[] FechaRegistro { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    
        public virtual TblTicket TblTicket { get; set; }
    }
}
