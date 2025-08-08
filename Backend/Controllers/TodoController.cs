using System;
using Backend.Models;
using Backend.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/todo")]
    public class TodoController : ApiController
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController()
        {
            _todoRepository = new ToDoRepository();
        }

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        /// <summary>
        /// Adicionando uma tarefa no banco de dados
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Tarefa Criada</returns>
        [HttpPost]
        public IHttpActionResult AddTodoItem([FromBody] TodoItem item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.Title))
            {
                return BadRequest("Invalid todo item.");
            }
            _todoRepository.AddTodoItem(item);
            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        /// <summary>
        /// Mostrando toda a lista de Tarefas do banco de dados
        /// </summary>
        /// <returns>Tarefas Retornadas</returns>
        [HttpGet]
        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _todoRepository.GetAllTodoItems();
        }

        /// <summary>
        /// Imprimindo uma tarefa específica do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tarefa Retornada</returns>
        [HttpGet]
        public IHttpActionResult GetTodoItemById(Guid id)
        {
            var item = _todoRepository.GetTodoItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Atualizando um item do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>Tarefa Atualizada</returns>
        [HttpPut]
        public IHttpActionResult UpdateTodoItem(Guid id, [FromBody] TodoItem item)
        {

            if (item == null || string.IsNullOrWhiteSpace(item.Title))
            {
                return BadRequest("Invalid todo item.");
            }

            item.Id = id;

            _todoRepository.UpdateTodoItem(item);
            return Ok(item);
        }

        /// <summary>
        /// Deletando um item do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tarefa Deletada</returns>
        [HttpDelete]
        public IHttpActionResult DeleteTodoItem(Guid id)
        {
            _todoRepository.DeleteTodoItem(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Teste para o GlobalExceptionFilter
        /// </summary>
        /// <returns>Teste Completo</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("test/throw")]
        public IHttpActionResult ThrowException()
        {
            throw new Exception("Erro de teste para o GlobalExceptionFilter");
        }
    }
}