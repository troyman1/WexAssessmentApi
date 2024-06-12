using WexAssessmentApi.Models;

namespace WexAssessmentApi.Repositories
{
    interface IProductRepository<T> : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoryId);
    }
}
