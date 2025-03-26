namespace OmniConnect.Web.Models
{
    public class UsuarioInputModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string? Mensagem { get; set; }
    }
}
