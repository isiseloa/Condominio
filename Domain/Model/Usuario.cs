using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using System.Collections;


namespace Domain.Model
{
    /// <summary>
    /// Classe que representa a tabela Usuario
    /// </summary>
    [ActiveRecord("Usuario")]
    public class Usuario : EntidadeBase<Usuario>
    {
        #region Property

        [Property("Usuario", Length = 20, NotNull = true)]
        public string NomeUsuario { get; set; }

        [Property("Nome", Length = 20, NotNull = true)]
        public string Nome { get; set; }

        [Property("Sobrenome", Length = 50, NotNull = false)]
        public string Sobrenome { get; set; }

        [Property("Senha", Length = 100, NotNull = true)]
        public string Senha { get; set; }

        [Property("Email", Length = 100, NotNull = true)]
        public string Email { get; set; }

        [BelongsTo("UnidadeId", Cascade = CascadeEnum.None)]
        public Unidade Unidade { get; set; }

        [Property("TipoDoUsuario", ColumnType = "int", NotNull = true)]
        public TipoUsuario TipoDoUsuario { get; set; }

        [Property("Status", ColumnType = "int", NotNull = true)]
        public Status StatusDoUsuario { get; set; }

        /// <summary>
        /// retorna um texto amigável de acordo com o perfil do usuário
        /// </summary>
        public string DescricaoTipoUsuario
        {
            get
            {
                if (this.TipoDoUsuario == TipoUsuario.AdministradorCondominio)
                    return "Administrador do Condominio";
                else if (this.TipoDoUsuario == TipoUsuario.ResponsavelUnidade)
                    return "Responsável pela Unidade";
                else
                    return "Usuário Comum";
            }
        }

        [HasMany(typeof(AgendamentoRecurso), Cascade = ManyRelationCascadeEnum.None, ColumnKey = "UsuarioId", Inverse = true)]
        public IList<AgendamentoRecurso> RecursosAgendados { get; set; }

        [HasMany(typeof(MensagensDosUsuarios), Cascade = ManyRelationCascadeEnum.None, ColumnKey = "UsuarioId", Inverse = true)]
        public IList<MensagensDosUsuarios> Mensagens { get; set; }

        [HasMany(typeof(Ocorrencia), Cascade = ManyRelationCascadeEnum.None, ColumnKey = "UsuarioId", Inverse = true)]
        public IList<Ocorrencia> Ocorrencias { get; set; }

        public enum TipoUsuario
        {
            AdministradorCondominio = 0,
            ResponsavelUnidade = 1,
            UsuarioComum = 2
        }

        public enum Status
        {
            Ativo = 0,
            PendenteAlterarSenha = 1,
            Inativo = 2
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Nome, this.Sobrenome);
        }

    }
}
