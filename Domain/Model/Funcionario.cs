using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Domain.Model
{
    /// <summary>
    /// classe que representa a tabela funcionario
    /// </summary>
    [ActiveRecord("Funcionario")]
    public class Funcionario : EntidadeBase<Funcionario>
    {
        [Property("Nome", Length = 100, NotNull = true)]
        public string Nome { get; set; }

        [Property("Endereco", Length = 200, NotNull = true)]
        public string Endereco { get; set; }

        [Property("CPF", Length = 20, NotNull = true)]
        public string CPF { get; set; }

        [Property("RG", Length = 20, NotNull = false)]
        public string RG { get; set; }

        [Property("Telefone", Length = 20, NotNull = true)]
        public string Telefone { get; set; }

        [Property("DataNascimento", NotNull = true)]
        public DateTime DataNascimento { get; set; }

        [Property("DataAdmissao", NotNull = true)]
        public DateTime DataAdmissao { get; set; }

        [Property("NumeroCarteiraTrabalho", Length = 25, NotNull = true)]
        public string NumeroCarteiraTrabalho { get; set; }

        [Property("Cargo", Length = 25, NotNull = true)]
        public string Cargo { get; set; }

        [HasMany(typeof(Salario), Cascade = ManyRelationCascadeEnum.None, ColumnKey = "SalarioId", Inverse = true)]
        public IList<Salario> Salarios { get; set; }

        private Salario salarioVigente = null;

        /// <summary>
        /// obtém o salário atual do funcionário
        /// </summary>
        public Salario SalarioVigente
        {
            get
            {
                if (salarioVigente == null && Salarios != null && Salarios.Count > 0)
                {
                    salarioVigente = Salarios.FirstOrDefault(s => s.Vigente);
                }
                return salarioVigente;
            }
        }


    }
}
