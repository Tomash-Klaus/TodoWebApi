using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoListWebApi.Controllers;
using ToDos.Core;
using ToDos.DB;

namespace ToDoListWebApi.Tests
{
    public class ControllerTests
    {
        Mock<ITodosService> mock;
        ToDoController controller;
        Todo testItem = new Todo { Id = 1, IsDone = true, Value = "test" };

        [SetUp]
        public void Setup()
        {
             mock = new Mock<ITodosService>();
            mock.Setup(x => x.CreateToDoItem(It.IsAny<Todo>())).Returns(testItem);
                controller = new ToDoController(mock.Object);
            
            // mock = new Mock<DbContext>();
            //var mockDbSet = DbContextMock.GetQueryableMockDbSet<Todo>(GetTestInstances());
            //_service = new ToDoServices(mockDbSet);
        }

        [Test]
        public void Test1()
        {
            var rez = controller.GetItem(testItem.Id);
            Assert.IsInstanceOf(typeof(IActionResult), rez);

        }

        [Test]
        public void Test2()
        {
            var rez = controller.DeleteItem(testItem.Id);
            mock.Verify(m => m.DeleteToDoItem(testItem.Id), Times.Once);
            Assert.IsInstanceOf(typeof(IActionResult), rez);
        }

        [Test]
        public void Test3()
        {
            var rez = controller.EditItem(testItem);
            Assert.IsInstanceOf(typeof(IActionResult), rez);
        }


        [Test]
        public void Test4()
        {
            var rez = controller.EditItemDone(testItem.Id);
            Assert.IsInstanceOf(typeof(IActionResult), rez);
            
        }


        [Test]
        public void Test5()
        {
            var rez = controller.GetItems();
            Assert.IsInstanceOf(typeof(IActionResult), rez);
        }

        [Test]
        public void Test6()
        {
            var rez = controller.CreateItem(testItem);
            mock.Verify(m => m.CreateToDoItem(testItem), Times.Once);
            Assert.IsInstanceOf(typeof(IActionResult), rez);
        }

    }
}
