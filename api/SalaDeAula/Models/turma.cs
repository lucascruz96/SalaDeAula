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
    
    public partial class turma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public turma()
        {
            this.atividade = new HashSet<atividade>();
            this.mensagem = new HashSet<mensagem>();
            this.usuario_turma = new HashSet<usuario_turma>();
        }
    
        public long codigo_turma { get; set; }
        public string nome_turma { get; set; }
        public string token_acesso { get; set; }
        public System.DateTime data_criacao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atividade> atividade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mensagem> mensagem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_turma> usuario_turma { get; set; }
    }
}
