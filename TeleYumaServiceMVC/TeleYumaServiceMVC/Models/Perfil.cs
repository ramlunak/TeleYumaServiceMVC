//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeleYumaServiceMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public partial class Perfil
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string IdCuenta { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
    }
}
