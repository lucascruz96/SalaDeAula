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
    
    public partial class atividade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public atividade()
        {
            this.questao = new HashSet<questao>();
        }
    
        public long codigo_atividade { get; set; }
        public long codigo_turma { get; set; }
        public string nome_atividade { get; set; }
        public System.DateTime data_limite { get; set; }
        public System.DateTime data_criacao { get; set; }
    
        public virtual turma turma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<questao> questao { get; set; }
    }
}
