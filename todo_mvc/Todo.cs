using System.ComponentModel.DataAnnotations;
using todo_mvc;


public class Todo
{
    [Key]
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool isDone{ get; internal set; } = false;

    public void update(string task, Boolean isDone)
    {
        this.Name = task;
        this.isDone = isDone;
    }

    public string getTask()
    {
        return this.Name;
    }

    public Boolean getStatus()
    {
        return this.isDone;
    }
    
    public void ChangeStatus()
    {
        this.isDone = (this.isDone)? false : true;
    }

    public void SetStatus(bool status)
    {
        this.isDone = status;
    }
    public int GetId()
    {
        return this.Id;
        
    }
    
    public Todo(string task)
    {
        this.Name = task;
        
    }

    public Todo(UpdateTodoRequest todo)
    {
        this.Name =todo.Name;
        this.isDone = todo.IsDone;
    }
        

    private Todo()
    {
    }
}

