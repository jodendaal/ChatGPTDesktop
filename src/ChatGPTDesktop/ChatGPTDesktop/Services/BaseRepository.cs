using ChatGPTDesktop.Models;
using System.Text.Json;
using System.Linq.Dynamic.Core;

namespace ChatGPTDesktop.Services
{
    public class BaseRepository<TRepository, TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        string _folder = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\ChatGPTDesktop";
        string _file;
        private readonly string _idField;

        public BaseRepository(string idField)
        {
            _file = $@"{_folder}\{nameof(TRepository)}.json";
            _idField = idField;
            Initialise();
        }

        private void Initialise()
        {
            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }

            if (!File.Exists(_file))
            {
                File.WriteAllText(_file, JsonSerializer.Serialize(new List<TEntity>()));
            }
        }

        public List<TEntity> GetAll()
        {
            var json = File.ReadAllText(_file);
            return JsonSerializer.Deserialize<List<TEntity>>(json);
        }

        public TEntity Get(string id)
        {
            return GetAll().AsQueryable().Where($@"{_idField} == ""{id}""").FirstOrDefault();
        }

        public void SaveAll(List<TEntity> items)
        {
            File.WriteAllText(_file.ToString(), JsonSerializer.Serialize(items));
        }

        public void Save(TEntity item)
        {
            var items = GetAll();
            var result = items.AsQueryable().Where($@"{_idField} == ""{item.Id()}""").FirstOrDefault();
            if(result != null)
            {
                items[items.IndexOf(result)] = item;
            }
            else
            {
                items.Add(item);
            }
            
            SaveAll(items);
        }
    }
}
