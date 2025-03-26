using OmniConnect.Dominio.Entidades;
using OmniConnect.Dominio.Interfaces.Repositorios;

namespace OmniConnect.Infraestrutura.Repositorios
{
    public class UsuarioRepositorioFake : IUsuarioRepositorio
    {
        private readonly List<Usuario> _usuarios = new();

        public void Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public Usuario? ObterPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarios;
        }
    }
}
