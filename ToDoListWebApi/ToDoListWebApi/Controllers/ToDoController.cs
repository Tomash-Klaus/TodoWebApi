using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ToDos.Core;
using ToDos.DB;

namespace ToDoListWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private ITodosService _todoServices;

        public ToDoController( ITodosService todoServices)
        {
            _todoServices = todoServices;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetItem(int id)
        {
            return Ok(_todoServices.GetToDoItem(id));
        }

        [HttpPost]
        public IActionResult CreateItem(Todo todo)
        {
            var newTodo = _todoServices.CreateToDoItem(todo);
            return CreatedAtRoute("GetTodo", new { newTodo.Id }, newTodo);
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_todoServices.GetToDoItems());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            _todoServices.DeleteToDoItem(id); 
            return Ok(id);
        }

        [HttpPut]
        public IActionResult EditItem([FromBody] Todo todo)
        {
            
            _todoServices.EditToDoItemValue(todo);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditItemDone(int id)
        {
            _todoServices.EditToDoItemDone(id);
            return Ok(id);
        }

    }
}
