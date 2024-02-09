using webapi.Model;

namespace webapi.Services;

public interface ICategoryService
{
    IEnumerable<Category> Get();
    void Save(Category category);
    void Update(Guid id, Category category);
    void Delete(Guid id);
}