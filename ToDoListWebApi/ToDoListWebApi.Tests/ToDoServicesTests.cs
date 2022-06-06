using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDos.Core;
using ToDos.DB;

namespace ToDoListWebApi.Tests
{
    //public static class DbContextMock
    //{
    //    public static Mock<DbSet<T>> CreateDbSetMock<T> (IEnumerable<T> sourceList) where T: Todo
    //    {
    //        var tempList =new List<T>(sourceList);
    //        var queryable = tempList.AsQueryable();
    //        var dbSetMock = new Mock<DbSet<T>>();
    //        dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
    //        dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
    //        dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
    //        dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(()=>queryable.GetEnumerator());
 

    //        dbSetMock.Setup(m => m.Add(It.IsAny<T>())).Callback<T>((T todo) => tempList.Add(todo));
    //        dbSetMock.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>((T todo) => tempList.Remove(todo));
           
    //        return dbSetMock;
    //    }
    //}
    public class ToDoServicesTests
    {
        IEnumerable<Todo> todosList;
        
        int idTest = 1;
        Todo todoTest = new Todo() { Id = 1, Value = "Ostap", IsDone = true };

        [SetUp]
        public void Setup()
        {
            todosList = GetTestInstances();
           
        }

        [Test]
        public void GetToDoItems_TodoObjectPassed_ProperMethodCalled()
        {
            Mock<IAppDbContext> usersMock = new Mock<IAppDbContext>();
           var userService = new ToDoServices(usersMock.Object);

            usersMock.Setup(r => r.GetItems()).Returns(todosList);

            var result = userService.GetToDoItems();

            Assert.AreEqual(todosList.Count(), result.Count());
            // пообєктне порівняння
        }


        [Test]
        public void GetToDoItem_TodoObjectPassed_ProperMethodCalled()
        {
            Mock<IAppDbContext> usersMock = new Mock<IAppDbContext>();
            var userService = new ToDoServices(usersMock.Object);

            usersMock.Setup(r => r.GetItem(It.IsAny<int>())).Returns(todosList.First(el => el.Id == idTest));
           
            var result = userService.GetToDoItem(idTest);

            Assert.AreEqual(todoTest.Value, result.Value);
        }

        [Test]
        public void DeleteToDoItem_TodoObjectPassed_ProperMethodCalled()
        {
            Mock<IAppDbContext> usersMock = new Mock<IAppDbContext>();
            var userService = new ToDoServices(usersMock.Object);

            usersMock.Setup(r => r.DeleteItem(It.IsAny<int>())).Verifiable();

            userService.DeleteToDoItem(idTest);

            usersMock.Verify(c=>c.DeleteItem(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void EditToDoItemValue_TodoObjectPassed_ProperMethodCalled()
        {
            Mock<IAppDbContext> usersMock = new Mock<IAppDbContext>();
            var userService = new ToDoServices(usersMock.Object);

            usersMock.Setup(r => r.EditItemValue(It.IsAny<Todo>())).Verifiable();

            userService.EditToDoItemValue(todoTest);

            usersMock.Verify(c => c.EditItemValue(It.IsAny<Todo>()), Times.Once);
        }

        [Test]
        public void EditToDoItemDone_TodoObjectPassed_ProperMethodCalled()
        {
            Mock<IAppDbContext> usersMock = new Mock<IAppDbContext>();
            var userService = new ToDoServices(usersMock.Object);

            usersMock.Setup(r => r.EditItemDone(It.IsAny<int>())).Verifiable();

            userService.EditToDoItemDone(idTest);

            usersMock.Verify(c => c.EditItemDone(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CreateToDoItem_TodoObjectPassed_ProperMethodCalled()
        {
            Mock<IAppDbContext> usersMock = new Mock<IAppDbContext>();
            var userService = new ToDoServices(usersMock.Object);

            usersMock.Setup(r => r.AddItem(It.IsAny<Todo>())).Returns(todoTest);

           var result =  userService.CreateToDoItem(todoTest);

            usersMock.Verify(c => c.AddItem(It.IsAny<Todo>()), Times.Once);
            Assert.AreEqual(todoTest.Value,result.Value);
        }

        private IEnumerable<Todo> GetTestInstances()
        {
            return new List<Todo> 
            { 

                new Todo (){Id=1,Value="Ostap",IsDone=true},
                new Todo (){Id=2,Value="Mykola",IsDone=false},
                new Todo (){Id=3,Value="Vasya",IsDone=true}

            };

        }
    }
}