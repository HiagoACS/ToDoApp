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

        //ADICIONANDO LOG DE ERRO
        private void LogError(Exception ex)
        {
            try
            {
                var logPath = AppDomain.CurrentDomain.BaseDirectory + "error.log";
                var message = $"{DateTime.Now}: {ex.Message} - {ex.StackTrace}\n";
                file.AppendAllText(logPath, message);
            }
            catch
            {
                // Se falhar ao logar, não fazer nada para evitar loop infinito
            }
        }

        // ADICIONANDO ITEM NO BANCO
        public void AddTodoItem(TodoItem item)
        {
            try
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
            catch (Exception ex)
            {
                LogError(ex);
                throw; // Relança a exceção após logar para que o chamador possa lidar com ela
            }
        }

        //ATUALIZANDO ITEM
        public void UpdateTodoItem(TodoItem item)
        {
            try
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
            catch (Exception ex)
            {
                LogError(ex);
                throw; // Relança a exceção após logar para que o chamador possa lidar com ela
            }
        }

        //PEGANDO TODOS OS ITENS DO BANCO
        public List<TodoItem> GetAllTodoItems()
        {
            try
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
            catch (Exception ex)
            {
                LogError(ex);
                throw; // Relança a exceção após logar para que o chamador possa lidar com ela
            }
        }

        //PEGANDO ITEM POR ID
        public TodoItem GetTodoItemById(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                LogError(ex);
                throw; // Relança a exceção após logar para que o chamador possa lidar com ela
            }
        }


        //DELETANDO ITEM
        public void DeleteTodoItem(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                LogError(ex);
                throw; // Relança a exceção após logar para que o chamador possa lidar com ela
            }
        }
    }
}