using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Domain.Model
{
    /// <summary>
    /// classe que representa a tabela mensagem 
    /// </summary>
    [ActiveRecord("Mensagem")]
    public class Mensagem : EntidadeBase<Mensagem>
    {
        [Property("Usuario", Length = 70, NotNull = true)]
        public string Usuario { get; set; }

        [Property("Detalhe", Length = 2000, NotNull = true)]
        public string Detalhe { get; set; }

        [HasMany(typeof(MensagensDosUsuarios), Cascade = ManyRelationCascadeEnum.None, ColumnKey = "MensagemId", Inverse = true)]
        public IList<MensagensDosUsuarios> Mensagens { get; set; }



    }
}