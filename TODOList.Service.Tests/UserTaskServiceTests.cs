using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Repository.Entities;
using TODOList.Repository.Interfaces;

namespace TODOList.Service.Tests
{
    public class UserTaskServiceTests
    {
        private IList<UserTask> UserTaskStub;
        private IList<User> UserListStub;

        [SetUp]
        public void Setup()
        {
            var userOne = new User()
            {
                Id = 100,
                FirstName = "User One",
                UserName = "ONE"
            };

            var userTwo = new User()
            {
                Id = 200,
                FirstName = "User Two",
                UserName = "TWO"
            };

            UserListStub = new List<User>()
            {
                userOne,
                userTwo
            };

            UserTaskStub = new List<UserTask>()
            {
                new UserTask() { User = userOne, Description = "Walk the dog", LastUpdate = DateTime.UtcNow },
                new UserTask() { User = userOne, Description = "Clean up the house", LastUpdate = DateTime.UtcNow },
                new UserTask() { User = userTwo, Description = "Buy groceries", LastUpdate = DateTime.UtcNow }
            };
        }

        [Test]
        public async Task Should_filter_tasks_from_user_one()
        {
            var mockRepository = new Mock<IUserTaskRepository>();

            mockRepository.Setup(x => x.List()).Returns(UserTaskStub.AsQueryable());

            var service = new UserTaskService(mockRepository.Object, null);

            var userOne = UserListStub.First(x => x.Id == 100);

            var userTasks = await service.GetUserTasks(100);

            //  Shouldn't contain tasks from other users
            CollectionAssert.IsEmpty(userTasks.Where(x => x.User.Id != userOne.Id));

            Assert.AreEqual(userTasks.Count(), 2);
        }
    }
}