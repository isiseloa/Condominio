using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Domain.Model
{
    /// <summary>
    /// classe que representa a tabela ocorrencia
    /// </summary>
    [ActiveRecord("Ocorrencia")]
    public class Ocorrencia : EntidadeBase<Ocorrencia>
    {

        [BelongsTo("UsuarioId", Cascade = CascadeEnum.None)]
        public Usuario Usuario { get; set; }

        [Property("TipoOcorrencia", Length = 50, NotNull = true)]
        public string TipoOcorrencia { get; set; }

        [Property("Detalhes", Length = 2000, NotNull = true)]
        public string Detalhes { get; set; }


        [Property("StatusOcorrencia", NotNull = true)]
        public StatusOcorrencia Status { get; set; }

        public enum StatusOcorrencia
        {
            Aberta = 0,
            EmAndamento = 1,
            Resolvida = 2
        }

    }
}
