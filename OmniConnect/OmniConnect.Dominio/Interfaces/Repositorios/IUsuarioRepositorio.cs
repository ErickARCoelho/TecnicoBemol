using OmniConnect.Dominio.Entidades;

namespace OmniConnect.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio
    {
        void Adicionar(Usuario usuario);
        Usuario? ObterPorEmail(string email);
        IEnumerable<Usuario> ObterTodos();
    }
}
