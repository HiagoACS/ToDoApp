using System;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.Repositories
{
    public interface ITodoRepository
    {
        void AddTodoItem(TodoItem item);
        void UpdateTodoItem(TodoItem item);
        List<TodoItem> GetAllTodoItems();
        TodoItem GetTodoItemById(Guid id);
        void DeleteTodoItem(Guid id);
    }
}