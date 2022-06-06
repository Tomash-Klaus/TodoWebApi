using System;
using System.Collections.Generic;
using System.Text;
using ToDos.DB;

namespace ToDos.Core
{
    public interface ITodosService
    {
        Todo CreateToDoItem(Todo newTodo);
        Todo GetToDoItem(int id);
        IEnumerable<Todo> GetToDoItems();
        void DeleteToDoItem(int id);
        void EditToDoItemValue(Todo todo);
        void EditToDoItemDone(int id);



    }
}
