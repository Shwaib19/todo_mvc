using Microsoft.AspNetCore.Mvc;
using todo_mvc.data;

namespace todo_mvc.Controller;

[Route("api/[controller]")]
[ApiController]
public class TodoApiController(AppDbContext context) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    [Route("GetTodos")]
    public IEnumerable<Todo> GetTodos()
    {
        return context.Todos.ToList().OrderBy(t => t.GetId());
    }
    
    [HttpPost]
    [Route("AddTodo")]
    public void AddTodo(CreateTodoRequest todo)
    {
        Todo t = new Todo(todo.Name);
        context.Todos.Add(t);
        context.SaveChanges();
    }
    
    [HttpPost]
    [Route("UpdateTodo/{id}")]
    public void UpdateTodo(int id, UpdateTodoRequest todo)
    {
        var todoExist = context.Todos.Find(id);
        if (todoExist == null)
        {
            throw new KeyNotFoundException();
        }
        else
        {
            todoExist.update(todo.Name,todo.IsDone);
            context.SaveChanges();
        }
    }
    
    [HttpDelete]
    [Route("RemoveTodo/{id}")]
    public void DeleteTodo(int id)
    {
        var todoExist = context.Todos.Find(id);
        if (todoExist  != null)
        {
            context.Todos.Remove(todoExist);
            context.SaveChanges();
        }
    }
    

    [HttpDelete]
    [Route("DeleteTodo/Done")]
    public void DeleteTodoDone()
    {
        var todos = context.Todos.ToList();

            foreach (var todo in todos)
            {
                if (todo.getStatus() == true)
                {
                    DeleteTodo(todo.GetId());
                }
            }
            context.SaveChanges();
    }
    
    
    [HttpGet]
    [Route("ChangeAllTodo/")]
    public IEnumerable<Todo> ChangeAllStatus()
    {
        var todos = context.Todos.ToList();
        var unfinished= todos.Any(t => t.getStatus() == false);
        if (unfinished)
        {
            foreach (var todo in todos)
            {
                todo.SetStatus(true);
            }
        }
        else
        {
            foreach (var todo in todos)
            {
                todo.SetStatus(false);
            }
        }
        context.SaveChanges();
        return GetTodos();
    }
    
}