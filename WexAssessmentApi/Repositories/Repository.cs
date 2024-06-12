namespace WexAssessmentApi.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected Dictionary<string, T>? _data = [];

        public abstract void AddAsync(T entity);
        public abstract void DeleteAsync(int id);
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<T> GetByIdAsync(int id);
        public abstract void UpdateAsync(T entity);
    }
}
