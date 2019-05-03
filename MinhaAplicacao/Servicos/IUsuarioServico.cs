using MinhaAplicacao.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAplicacao.Servicos
{
    public interface IUsuarioServico
    {
        Task<IList<UsuarioModelo>> RecuperarTodos();
    }
}
