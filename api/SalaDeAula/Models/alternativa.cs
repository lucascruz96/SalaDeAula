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
    
    public partial class alternativa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public alternativa()
        {
            this.resposta = new HashSet<resposta>();
        }
    
        public long codigo_alternativa { get; set; }
        public long codigo_questao { get; set; }
        public string texto_alternativa { get; set; }
        public bool correta { get; set; }
    
        public virtual questao questao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resposta> resposta { get; set; }
    }
}
