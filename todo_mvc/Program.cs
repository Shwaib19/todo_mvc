using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using todo_mvc;
using todo_mvc.Controller;
using todo_mvc.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
builder.Services.AddControllers();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

//app.MapGet("/todos/list", (AppDbContext context) =>
//{
//    return "s";
//})
//.WithName("GetTodos");

//app.MapGet("/todos/add", (string name, AppDbContext context) =>
//    {
//            var todo = new Todo(name);
//            context.Todos.Add(todo);
//            context.SaveChanges();
//            return new TodoResponse();
        
//  })
//    .WithName("AddTodo");

app.Run();