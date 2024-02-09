using webapi.Context;
using webapi.Model;

namespace webapi.Services.ServiceImpl;

public class CategoryService : ICategoryService
{
    private TaskContext context;

    public CategoryService(TaskContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Category> Get()
    {
        return context.Categories;
    }

    public void Save(Category category)
    {
        context.Add(category);
        context.SaveChanges();
    }

    public void Update(Guid id, Category category)
    {
        var currentCategory = context.Categories.Find(id);
        if (currentCategory != null)
        {
            currentCategory.Name = category.Name;
            currentCategory.Description = category.Description;
            currentCategory.Weight = category.Weight;

            context.SaveChanges();
        }
    }

    public void Delete(Guid id)
    {
        var currentCategory = context.Categories.Find(id);
        if (currentCategory != null)
        {
            context.Categories.Remove(currentCategory);
            context.SaveChanges();
        }
    }
}