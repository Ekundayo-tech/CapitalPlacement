 

namespace InternshipPrograms.Application.Services.Interfaces
{
    public interface IRepository<T, R>
    {
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task<string> Add(R entity);
        Task<string> Update(R entity);
        void Delete(string id);
    }
}
