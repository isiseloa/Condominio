using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Domain.Model
{
    /// <summary>
    /// classe que representa a tabela unidade
    /// </summary>
    [ActiveRecord("Unidade")]
    public class Unidade : EntidadeBase<Unidade>
    {
        [Property("Numero", Length = 10, NotNull = true)]
        public string Numero { get; set; }

        [Property("Piso", NotNull = true)]
        public int Piso { get; set; }

        [Property("Torre", Length = 10, NotNull = true)]
        public string Torre { get; set; }

        [HasMany(typeof(Usuario), Cascade = ManyRelationCascadeEnum.None, ColumnKey = "UnidadeId", Inverse = true)]
        public IList<Usuario> Usuarios { get; set; }

        public override string ToString()
        {
            return Numero;
        }
    }
}
