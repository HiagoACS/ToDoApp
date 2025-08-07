using System;
using Backend.Models;
using Backend.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace Backend.Controllers
{
    public class TodoController : ApiController
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController()
        {
            _todoRepository = new ToDoRepository();
        }

        // ADICIONANDO ITEM NO BANCO
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

        //PEGANDO TODOS OS ITENS DO BANCO
        [HttpGet]
        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _todoRepository.GetAllTodoItems();
        }

        //PEGANDO ITEM POR ID
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

        //ATUALIZANDO ITEM
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

        //DELETANDO ITEM
        [HttpDelete]
        public IHttpActionResult DeleteTodoItem(Guid id)
        {
            _todoRepository.DeleteTodoItem(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}