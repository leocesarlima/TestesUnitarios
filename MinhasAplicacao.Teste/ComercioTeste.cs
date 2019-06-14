using MinhaAplicacao.Dominios;
using MinhaAplicacao.Modelos;
using MinhaAplicacao.Servicos;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MinhasAplicacao.Teste
{
    public class ComercioTeste
    {
        private readonly Mock<IUsuarioServico> _usuarioServico;
        private readonly ComercioDominio comercioDominio;

        public ComercioTeste()
        {
            _usuarioServico = new Mock<IUsuarioServico>();
            comercioDominio = new ComercioDominio(_usuarioServico.Object);
        }

        [Fact]
        public void Comercio_ListarUmCliente_Sucesso()
        {
            bool flag = false;

            _usuarioServico
                .Setup(s => s.RecuperarTodos())
                .Returns(async () => new List<UsuarioModelo>
                {
                    new UsuarioModelo
                    {
                        Id = 1
                    }
                })
                .Callback(() => flag = true);

            var resultado = comercioDominio.ListarClientes();

            Assert.True(flag);
        }

        [Fact]
        public void Comercio_CalcularLucro_Sucesso()
        {
            var resultado = comercioDominio.CalcularLucro(10).ToString("N1");

            Assert.Equal("11,0", resultado);
        }
    }
}
