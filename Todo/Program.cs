using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using System.Reflection;
using Todo.Application.Common.Interfaces;
using Todo.Application.TodoLists.Commands.CreateTodoListCommand;
using Todo.Domain.Entities;
using Todo.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MediatR services
builder.Services.AddMediatR(typeof(WebApplication));

var assemblies = new List<Assembly>();
assemblies.Add(typeof(IRepository<TodoList>).Assembly);
assemblies.Add(Assembly.GetExecutingAssembly());
var domainAssembly = typeof(IRepository<TodoList>).Assembly;

builder.Services.AddMediatR(domainAssembly);

builder.Services.AddFluentValidation(new[] { domainAssembly });

builder.Services.AddSingleton<Todo.Application.Common.Interfaces.IRepository<TodoList>, InMemoryRepository<TodoList>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
