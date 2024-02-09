using webapi.Context;
using Task = webapi.Model.Task;

namespace webapi.Services.ServiceImpl;

public class TaskService : ITaskService
{
    
    private TaskContext context;

    public TaskService(TaskContext dbContext)
    {
        context = dbContext;
    }
    
    public IEnumerable<Task> Get()
    {
        return context.Tasks;
    }

    public void Save(Task task)
    {
        context.Tasks.Add(task);
        context.SaveChanges();
    }

    public void Update(Task task, Guid id)
    {
        var currentTask = context.Tasks.Find(id);

        if (currentTask != null)
        {
            currentTask.CategoryId = task.CategoryId;
            currentTask.Title = task.Title;
            currentTask.Description = task.Description;
            currentTask.Priority = task.Priority;
            
            context.SaveChanges();
        }
    }

    public void Delete(Guid id)
    {
        var currentTask = context.Tasks.Find(id);

        if (currentTask != null)
        {
            context.Tasks.Remove(currentTask);
            context.SaveChanges();
        }
    }
}