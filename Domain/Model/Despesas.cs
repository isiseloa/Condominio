using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;


namespace Domain.Model
{
    /// <summary>
    /// classe que representa a tabela despesa no banco de dados
    /// </summary>
    [ActiveRecord("Despesas")]
    public class Despesas : EntidadeBase<Despesas>
    {
        [Property("Descricao", Length=2000, NotNull = true)]
        public string Descricao { get; set; }

        [Property("Valor", NotNull = true)]
        public decimal Valor { get; set; }

        [Property("Data", NotNull = true)]
        public DateTime Data { get; set; }
    }
}
