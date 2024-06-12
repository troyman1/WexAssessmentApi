using WexAssessmentApi.Models;


namespace WexAssessmentApi.Repositories
{
    public class ProductRepository<T> : IProductRepository<Product>
    {
        private readonly List<Product> _repository;
        public ProductRepository() 
        {
            _repository = [];
        }
        public async Task AddAsync(Product entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            if (_repository.Any(r => r.Id == entity.Id)) throw new ArgumentException($"Id {entity.Id} already exists.");
            _repository.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            if (!_repository.Any(r => r.Id == id)) throw new ArgumentException($"Id {id} does not exist.");
            _repository.RemoveAll(r => r.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return _repository;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return _repository.Where(r=> r.Id == id).FirstOrDefault()!;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            return _repository.Where(r => r.Category ==  category).ToList();
        }

        public async Task UpdateAsync(Product entity)
        {
            if (!_repository.Any(r => r.Id == entity.Id)) throw new ArgumentException($"Id {entity.Id} does not exist.");
            _repository[entity.Id] = entity;
        }
    }
}
