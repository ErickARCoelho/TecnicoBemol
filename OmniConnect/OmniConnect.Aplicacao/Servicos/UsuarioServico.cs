using OmniConnect.Aplicacao.DTOs;
using OmniConnect.Aplicacao.Interfaces;
using OmniConnect.Dominio.Entidades;
using OmniConnect.Dominio.Interfaces.Repositorios;
using OmniConnect.Dominio.Interfaces.Servicos;

namespace OmniConnect.Aplicacao.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IViaCepServico _viaCepServico;

        public UsuarioServico(
            IUsuarioRepositorio usuarioRepositorio,
            IViaCepServico viaCepServico)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _viaCepServico = viaCepServico;
        }

        public void CriarUsuario(CriarUsuarioDTO dto)
        {
            var enderecoDto = _viaCepServico.BuscarEndereco(dto.Cep) ?? throw new ArgumentException("CEP inválido ou não encontrado.");
            var endereco = Endereco.Criar(
                dto.Cep,
                enderecoDto.Logradouro,
                enderecoDto.Bairro,
                enderecoDto.Cidade,
                enderecoDto.Estado
            );

            var usuario = Usuario.Criar(dto.Nome, dto.Email, endereco);

            _usuarioRepositorio.Adicionar(usuario);
        }
    }
}
