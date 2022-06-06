using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDos.DB
{
    public  class AppDbContextRepository: IAppDbContext
    {
        private readonly AppDbContext _context;

        public AppDbContextRepository(AppDbContext context)
            => _context = context;

        public Todo AddItem(Todo todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public Todo GetItem(int id)
        {
            return _context.Todos.First(el => el.Id == id);
        }

        public IEnumerable<Todo> GetItems()
        {
            return _context.Todos.ToList();
        }

        public void DeleteItem(int id)
        {
            var deletedItem = _context.Todos.First(el => el.Id == id);
            _context.Remove(deletedItem);
            _context.SaveChanges();
        }

        public void EditItemValue(Todo todo)
        {
            var editItem = _context.Todos.First(el => el.Id == todo.Id);
            editItem.Value = todo.Value;
            _context.SaveChanges();
        }

        public void EditItemDone(int id)
        {
            var editItem = _context.Todos.First(el => el.Id == id);
            editItem.IsDone = !editItem.IsDone;
            _context.SaveChanges();
        }


    }
}
