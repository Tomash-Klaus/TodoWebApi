using System;
using System.Collections.Generic;
using System.Linq;
using ToDos.DB;

namespace ToDos.Core
{
    public class ToDoServices : ITodosService
    {
        private IAppDbContext _context;
        public ToDoServices(IAppDbContext context)
        {
            _context = context;
        }
       
        public Todo CreateToDoItem(Todo newTodo)
        {
           return _context.AddItem(newTodo);
        }

        public Todo GetToDoItem(int id)
        { 
            return _context.GetItem(id);
        }

              
       public IEnumerable<Todo> GetToDoItems()
        {
            return _context.GetItems();
        }

       public void DeleteToDoItem(int id)
        {
            _context.DeleteItem(id);
        }

        public void EditToDoItemValue(Todo todo)
        {
            _context.EditItemValue(todo);
        }

        public void EditToDoItemDone(int id)
        {
            _context.EditItemDone(id);
        }
    }
}