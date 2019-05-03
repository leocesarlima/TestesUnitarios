using MinhaAplicacao.Modelos;
using MinhaAplicacao.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAplicacao.Dominios
{
    public class ComercioDominio
    {
        private readonly IUsuarioServico _usuarioServico;

        public ComercioDominio(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public async Task<IList<UsuarioModelo>> ListarClientes()
        {
            var clientes = await _usuarioServico.RecuperarTodos();

            if (clientes == null)
                throw new Exception("Nenhum cliente encontrado");

            return clientes;
        }

        public float CalcularLucro(int qntCompra)
        {
            float valorBase = 1.1F;

            return qntCompra * valorBase;
        }
    }
}
