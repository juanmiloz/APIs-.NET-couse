using Task = webapi.Model.Task;

namespace webapi.Services;

public interface ITaskService
{
    IEnumerable<Task> Get();
    void Save(Task task);
    void Update(Task task, Guid id);
    void Delete(Guid id);
}