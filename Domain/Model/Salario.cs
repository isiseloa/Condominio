using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Domain.Model
{
    /// <summary>
    /// classe que representa a tabela salário
    /// </summary>
    [ActiveRecord("Salario")]
    public class Salario : EntidadeBase<Comunicado>
    {
        [Property("Valor", NotNull = true)]
        public decimal Valor { get; set; }

        [Property("InicioVigencia", NotNull = true)]
        public DateTime InicioVigencia { get; set; }

        [Property("FinalVigencia")]
        public DateTime? FinalVigencia { get; set; }

        [Property("Vigente", NotNull = true)]
        public bool Vigente { get; set; }

        [BelongsTo("SalarioId", Cascade = CascadeEnum.None)]
        public Funcionario FuncionarioDoSalario { get; set; }

        public override string ToString()
        {
            return Valor.ToString("F2");
        }
        

    }
}
