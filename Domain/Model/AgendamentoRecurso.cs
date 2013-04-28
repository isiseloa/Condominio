using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Domain.Model
{
    /// <summary>
    /// Classe que corresponde a tabela agendamento recurso no banco de dados
    /// </summary>
    [ActiveRecord("AgendamentoRecurso")]
    public class AgendamentoRecurso : EntidadeBase<AgendamentoRecurso>
    {

        [Property("Recurso", Length = 100, NotNull = true)]
        public string Recurso { get; set; }

        [Property("Data", NotNull = true)]
        public DateTime Data { get; set; }

        [BelongsTo("UsuarioId", Cascade = CascadeEnum.None)]
        public Usuario Usuario { get; set; }        

    }
}
