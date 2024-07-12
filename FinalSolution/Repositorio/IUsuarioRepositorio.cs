using BloggieWebProject.Models.Dominio;

namespace BloggieWebProject.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetAsync(Guid id);
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario?> UpdateAsync(Usuario usuario);
        Task<Usuario?> DeleteAsync(Guid id);
    }
}
