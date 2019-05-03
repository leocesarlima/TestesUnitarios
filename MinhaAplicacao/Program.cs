using MinhaAplicacao.Dominios;
using MinhaAplicacao.Servicos;
using System;

namespace MinhaAplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nIniciando...");

            try
            {
                var servico = new UsuarioServico();
                var dominio = new ComercioDominio(servico);

                var clientes = dominio.ListarClientes().Result;
                var lucro = dominio.CalcularLucro(10);

                Console.WriteLine("Listando clientes..:");

                for (int i = 0; i < clientes.Count; i++)
                    Console.WriteLine($"{clientes[i].Id} - {clientes[i].Name} - {clientes[i].Email}");

                Console.WriteLine($"\n\nLucro..: {lucro.ToString("C2")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
