using MinhaAplicacao.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAplicacao.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly HttpClient client;

        public UsuarioServico()
        {
            client = new HttpClient();
        }

        public async Task<IList<UsuarioModelo>> RecuperarTodos()
        {
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var usuarios = JsonConvert.DeserializeObject<IList<UsuarioModelo>>(resultado);

                return usuarios;
            }

            return null;
        }
    }
}
