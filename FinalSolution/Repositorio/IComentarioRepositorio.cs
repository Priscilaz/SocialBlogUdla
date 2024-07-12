using BloggieWebProject.Models.Dominio;

namespace BloggieWebProject.Repositorio
{
    public interface IComentarioRepositorio
    {
        Task<IEnumerable<Comentario>> GetAllAsync();
        Task<Comentario?> GetAsync(Guid id);
        Task<Comentario> AddAsync(Comentario comentario);
        Task<Comentario?> UpdateAsync(Comentario comentario);
        Task<Comentario?> DeleteAsync(Guid id);
    }
}
