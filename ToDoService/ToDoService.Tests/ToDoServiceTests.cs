using System.Collections.Generic;
using System;
using Xunit;
using ToDoService.Controllers;
using ToDoService.Models;
using ToDoService.Service;
using Moq;

namespace ToDoService.Tests
{
    public class ToDoServiceTests
    {
        private readonly Mock<IToDoService> _todoserivice; 

        public ToDoServiceTests(){
            _todoserivice = new Mock<IToDoService>();
        }

        [Fact]
        public void Test_For_Getall()
        {
            var testObject = new ToDoTask() { id = 1,timeStamp=DateTime.Now,description="test" };
            var testList = new List<ToDoTask>() { testObject };

            _todoserivice.Setup(x=>x.GetAllTask()).Returns(testList);
            var controller = new TodoController(_todoserivice.Object);
            var result = controller.Get();

            Assert.Equal(testList,result);
        }

        [Theory]
        [InlineData("Test 1")]
        [InlineData("Test 2")]
        [InlineData("Test 3")]
        public void Test_For_Post(string desc)
        {
            var testObject = new ToDoTask() { timeStamp=DateTime.Now,description= desc};

            _todoserivice.Setup(x=>x.SaveTask(testObject)).Returns(1);
            var controller = new TodoController(_todoserivice.Object);
            var result = controller.Post(testObject);

            Assert.Equal(1,result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_For_Delete(int id)
        {
            _todoserivice.Setup(x=>x.DeleteTask(id)).Returns(true);
            var controller = new TodoController(_todoserivice.Object);
            var result = controller.Delete(id);

            Assert.True(result);
        }
    }
}
