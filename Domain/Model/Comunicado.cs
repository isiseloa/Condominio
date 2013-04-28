using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using System.Data;


namespace Domain.Model
{
    /// <summary>
    /// classe que corresponde a tabela comunicado no banco de dados - é usada para comunicados e atas de reunião
    /// </summary>
    [ActiveRecord("Comunicado")]
    public class Comunicado : EntidadeBase<Comunicado>
    {
        [BelongsTo("UsuarioId", Cascade = CascadeEnum.None)]
        public Usuario Usuario { get; set; }

        [Property("Titulo", Length = 100, NotNull = true)]
        public string Titulo { get; set; }

        [Property("Texto", SqlType = "Text", Length=2000000000,  NotNull = true)]
        public string Texto { get; set; }

        [Property("TipoRegistro", NotNull = true)]
        public TipoRegistro Tipo { get; set; }

        /// <summary>
        /// identifica o tipo do registro (comunicado/ata de reunião)
        /// </summary>
        public enum TipoRegistro
        {
            Comunicado = 0,
            AtaReuniao = 1
        }


        /// <summary>
        /// Lista todos os registros do tipo comunicado, filtrados pela data de início e pela data final
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public static IList<Comunicado> ObterComunicados(DateTime dataInicial, DateTime dataFinal)
        {
            return Comunicado.Todos.Where(c => c.dataCriacao.Date >= dataInicial.Date && c.dataCriacao.Date <= dataFinal.Date && c.Tipo == TipoRegistro.Comunicado).ToList();
        }

        /// <summary>
        /// Lista todos os registros do tipo ata de reunião, filtrados pela data de início e pela data final
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public static IList<Comunicado> ObterAtas(DateTime dataInicial, DateTime dataFinal)
        {
            return Comunicado.Todos.Where(c => c.dataCriacao.Date >= dataInicial.Date && c.dataCriacao.Date <= dataFinal.Date && c.Tipo == TipoRegistro.AtaReuniao).ToList();
        }
    }
}
