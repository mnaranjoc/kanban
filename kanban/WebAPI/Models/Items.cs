//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Items
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int ColumnID { get; set; }
    
        public virtual Columns Columns { get; set; }
    }
}
