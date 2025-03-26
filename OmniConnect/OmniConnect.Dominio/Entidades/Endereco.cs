namespace OmniConnect.Dominio.Entidades
{
    public class Endereco
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        protected Endereco() { }

        private Endereco(string cep, string logradouro, string bairro, string cidade, string estado)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;

            Validar();
        }

        public static Endereco Criar(string cep, string logradouro, string bairro, string cidade, string estado)
        {
            return new Endereco(cep, logradouro, bairro, cidade, estado);
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Cep) || Cep.Length != 8)
                throw new ArgumentException("CEP inválido.");

            if (string.IsNullOrWhiteSpace(Logradouro))
                throw new ArgumentException("Logradouro é obrigatório.");

            if (string.IsNullOrWhiteSpace(Bairro))
                throw new ArgumentException("Bairro é obrigatório.");

            if (string.IsNullOrWhiteSpace(Cidade))
                throw new ArgumentException("Cidade é obrigatória.");

            if (string.IsNullOrWhiteSpace(Estado))
                throw new ArgumentException("Estado é obrigatório.");
        }
    }
}
