//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _04_Data.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cliente_foto
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_foto { get; set; }
        public Nullable<System.DateTime> fecha_visionado { get; set; }
        public Nullable<bool> me_gusta { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual foto foto { get; set; }
    }
}
