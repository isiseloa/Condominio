using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Domain.Model
{
    /// <summary>
    /// tabela de relacionamento N:N entre usuario e mensagem
    /// </summary>
    [ActiveRecord("MensagensDosUsuarios")]
    public class MensagensDosUsuarios : EntidadeBase<MensagensDosUsuarios>
    {
        [BelongsTo("MensagemId", Cascade = CascadeEnum.None)]
        public Mensagem Mensagem { get; set; }

        [BelongsTo("UsuarioId", Cascade = CascadeEnum.None)]
        public Usuario Usuario { get; set; }
    }
}
