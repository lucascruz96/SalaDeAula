//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalaDeAula.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class resposta
    {
        public long codigo_resposta { get; set; }
        public long codigo_usuario { get; set; }
        public long codigo_questao { get; set; }
        public long codigo_alternativa { get; set; }
        public System.DateTime data_envio { get; set; }
    
        public virtual alternativa alternativa { get; set; }
        public virtual questao questao { get; set; }
        public virtual usuario usuario { get; set; }
    }
}