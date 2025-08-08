using System;
using System.Collections.Generic;
using System.Configuration;
using Backend.Models;
using Npgsql;

namespace Backend.Repositories
{
    public class ToDoRepository : ITodoRepository
    {
        private readonly string _connectionString;
        public ToDoRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }


        // ADICIONANDO ITEM NO BANCO
        public void AddTodoItem(TodoItem item)
        {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("INSERT INTO todo_items (title, is_completed, created_at, completed_at) VALUES (@title, @is_completed, @created_at, @completed_at)", connection))
                    {
                        command.Parameters.AddWithValue("title", item.Title);
                        command.Parameters.AddWithValue("is_completed", item.IsCompleted);
                        command.Parameters.AddWithValue("created_at", item.CreatedAt);
                        command.Parameters.AddWithValue("completed_at", (object)item.CompletedAt ?? DBNull.Value); //se existir item.CompletedAt, senão adiciona DBNull.Value
                        command.ExecuteNonQuery();
                    }
                }
        }

        //ATUALIZANDO ITEM
        public void UpdateTodoItem(TodoItem item)
        {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("UPDATE todo_items SET title = @title, is_completed = @is_completed, created_at = @created_at, completed_at = @completed_at WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("id", item.Id);
                        command.Parameters.AddWithValue("title", item.Title);
                        command.Parameters.AddWithValue("is_completed", item.IsCompleted);
                        command.Parameters.AddWithValue("created_at", item.CreatedAt);
                        command.Parameters.AddWithValue("completed_at", (object)item.CompletedAt ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
        }

        //PEGANDO TODOS OS ITENS DO BANCO
        public List<TodoItem> GetAllTodoItems()
        {
                var items = new List<TodoItem>();
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT id, title, is_completed, created_at, completed_at FROM todo_items", connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new TodoItem
                            {
                                Id = reader.GetGuid(0),
                                Title = reader.GetString(1),
                                IsCompleted = reader.GetBoolean(2),
                                CreatedAt = reader.GetDateTime(3),
                                CompletedAt = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4)
                            };
                            items.Add(item);
                        }
                    }
                }
                return items;
        }

        //PEGANDO ITEM POR ID
        public TodoItem GetTodoItemById(Guid id)
        {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT id, title, is_completed, created_at, completed_at FROM todo_items WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TodoItem
                                {
                                    Id = reader.GetGuid(0),
                                    Title = reader.GetString(1),
                                    IsCompleted = reader.GetBoolean(2),
                                    CreatedAt = reader.GetDateTime(3),
                                    CompletedAt = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4)
                                };
                            }
                        }
                    }
                }
                return null; // Retorna null se o item não for encontrado
        }


        //DELETANDO ITEM
        public void DeleteTodoItem(Guid id)
        {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM todo_items WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("id", id);
                        command.ExecuteNonQuery();
                    }
                }
        }
    }
}