namespace OmniConnect.Dominio.Interfaces.Servicos
{
    public interface IViaCepServico
    {
        EnderecoDtoViaCep? BuscarEndereco(string cep);
    }

    public class EnderecoDtoViaCep
    {
        public string Logradouro { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
