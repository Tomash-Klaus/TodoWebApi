using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.Text;

namespace ToDos.DB
{
    public interface IAppDbContext
    {
        public Todo AddItem(Todo todo);
        public Todo GetItem(int id);
        public IEnumerable<Todo> GetItems();
        public void DeleteItem(int id);
        public void EditItemValue(Todo todo);
        public void EditItemDone(int id);


    }
}
