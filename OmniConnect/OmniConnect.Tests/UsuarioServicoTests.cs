using Moq;
using OmniConnect.Aplicacao.DTOs;
using OmniConnect.Aplicacao.Servicos;
using OmniConnect.Dominio.Entidades;
using OmniConnect.Dominio.Interfaces.Repositorios;
using OmniConnect.Dominio.Interfaces.Servicos;

namespace OmniConnect.Tests
{
    public class UsuarioServicoTests
    {
        private readonly Mock<IUsuarioRepositorio> _usuarioRepoMock;
        private readonly Mock<IViaCepServico> _viaCepServicoMock;
        private readonly UsuarioServico _servico;

        public UsuarioServicoTests()
        {
            _usuarioRepoMock = new Mock<IUsuarioRepositorio>();
            _viaCepServicoMock = new Mock<IViaCepServico>();
            _servico = new UsuarioServico(_usuarioRepoMock.Object, _viaCepServicoMock.Object);
        }

        [Fact]
        public void Deve_Criar_Usuario_Com_Endereco_Valido()
        {
            var dto = new CriarUsuarioDTO
            {
                Nome = "Eric",
                Email = "eric@email.com",
                Cep = "01001000"
            };

            _viaCepServicoMock.Setup(v => v.BuscarEndereco(dto.Cep)).Returns(new EnderecoDtoViaCep
            {
                Logradouro = "Praça da Sé",
                Bairro = "Sé",
                Cidade = "São Paulo",
                Estado = "SP"
            });

            _servico.CriarUsuario(dto);

            _usuarioRepoMock.Verify(r => r.Adicionar(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public void Nao_Deve_Criar_Usuario_Com_Cep_Invalido()
        {
            var dto = new CriarUsuarioDTO
            {
                Nome = "Eric",
                Email = "eric@email.com",
                Cep = "99999999"
            };

            _viaCepServicoMock.Setup(v => v.BuscarEndereco(dto.Cep)).Returns((EnderecoDtoViaCep?)null);

            var ex = Assert.Throws<ArgumentException>(() => _servico.CriarUsuario(dto));
            Assert.Equal("CEP inválido ou não encontrado.", ex.Message);
        }

        [Fact]
        public void Nao_Deve_Criar_Usuario_Com_Email_Invalido()
        {
            var dto = new CriarUsuarioDTO
            {
                Nome = "Eric",
                Email = "emailsemarroba",
                Cep = "01001000"
            };

            _viaCepServicoMock.Setup(v => v.BuscarEndereco(dto.Cep)).Returns(new EnderecoDtoViaCep
            {
                Logradouro = "Praça da Sé",
                Bairro = "Sé",
                Cidade = "São Paulo",
                Estado = "SP"
            });

            var ex = Assert.Throws<ArgumentException>(() => _servico.CriarUsuario(dto));
            Assert.Equal("Email inválido.", ex.Message);
        }
    }
}
