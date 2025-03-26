using OmniConnect.Dominio.Interfaces.Servicos;
using System.Net.Http.Json;

namespace OmniConnect.Infraestrutura.Servicos
{
    public class ViaCepServico : IViaCepServico
    {
        private readonly HttpClient _httpClient;

        public ViaCepServico(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public EnderecoDtoViaCep? BuscarEndereco(string cep)
        {
            var response = _httpClient
                .GetFromJsonAsync<ViaCepResponse>($"https://viacep.com.br/ws/{cep}/json/")
                .GetAwaiter()
                .GetResult();

            if (response == null || response.Erro)
                return null;

            return new EnderecoDtoViaCep
            {
                Logradouro = response.Logradouro,
                Bairro = response.Bairro,
                Cidade = response.Localidade,
                Estado = response.Uf
            };
        }

        private class ViaCepResponse
        {
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            public string Uf { get; set; }
            public bool Erro { get; set; }
        }
    }
}
