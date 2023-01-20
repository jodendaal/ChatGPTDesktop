using ChatGPTDesktop.Models;

namespace ChatGPTDesktop.Services
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(string id);
        List<TEntity> GetAll();
        void Save(TEntity item);
        void SaveAll(List<TEntity> items);
        public void Delete(TEntity item);
    }
}