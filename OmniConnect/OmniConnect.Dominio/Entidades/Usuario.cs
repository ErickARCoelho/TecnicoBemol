namespace OmniConnect.Dominio.Entidades
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }

        protected Usuario() { }

        private Usuario(Guid id, string nome, string email, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Endereco = endereco;

            Validar();
        }

        public static Usuario Criar(string nome, string email, Endereco endereco)
        {
            return new Usuario(Guid.NewGuid(), nome, email, endereco);
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
                throw new ArgumentException("Email inválido.");

            if (Endereco is null)
                throw new ArgumentException("Endereço é obrigatório.");
        }
    }
}
