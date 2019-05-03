using MinhaAplicacao.Dominios;
using MinhaAplicacao.Modelos;
using MinhaAplicacao.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MinhaAplicacao.Teste
{
    public class ComercioTeste
    {
        private readonly Mock<IUsuarioServico> usuarioServico;

        private readonly ComercioDominio comercioDominio;

        public ComercioTeste()
        {
            usuarioServico = new Mock<IUsuarioServico>();

            comercioDominio = new ComercioDominio(usuarioServico.Object);
        }

        [Fact]
        [Trait("Category", "Integracao")]
        public void Comercio_ListarClientes_Sucesso()
        {
            usuarioServico
                .Setup(s => s.RecuperarTodos())
                .Returns(async () => new List<UsuarioModelo>
                {
                    new UsuarioModelo
                    {
                        Id = 1
                    }
                });

            var resultado = comercioDominio.ListarClientes().Result;

            Assert.Equal(1, resultado.Count);
        }

        [Fact]
        [Trait("Category", "Integracao")]
        public void Comercio_ListarClientes_Erro()
        {
            usuarioServico
                .Setup(s => s.RecuperarTodos())
                .Returns(async () => null);

            Assert.Throws<AggregateException>(() => comercioDominio.ListarClientes().Result);
        }
    }
}
