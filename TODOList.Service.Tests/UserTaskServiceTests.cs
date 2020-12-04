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

        [Test]
        public void Should_throw_exception_when_creating_a_task_for_invalid_user()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns<User>(null);

            var userTaskService = new UserTaskService(null, userRepositoryMock.Object);

            Assert.ThrowsAsync<Exception>(() => userTaskService.CreateUserTask(100, "this user doesnt exist"));
        }

        [Test]
        public async Task Should_correctly_create_task_for_user()
        {
            var userTaskRepositoryMock = new Mock<IUserTaskRepository>();
            userTaskRepositoryMock.Setup(x => x.Create(It.IsAny<UserTask>())).Returns(200);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Get(100)).Returns(new User() { Id = 100 });

            var service = new UserTaskService(userTaskRepositoryMock.Object, userRepositoryMock.Object);

            var newTaskId = await service.CreateUserTask(100, "my new task");

            userTaskRepositoryMock.Verify(x => x.Create(It.Is<UserTask>(u => u.User.Id == 100 && u.Description == "my new task")), Times.Once);

            Assert.AreEqual(newTaskId, 200);
        }

        [Test]
        public async Task Should_never_delete_tasks_from_other_users()
        {
            var userTaskRepositoryMock = new Mock<IUserTaskRepository>();

            var taskList = new List<UserTask>()
            {
                new UserTask() { User = new User() { Id = 100 }, Id = 110, Description = "user 100, task 110" },
                new UserTask() { User = new User() { Id = 100 }, Id = 120, Description = "user 100, task 120" },
                new UserTask() { User = new User() { Id = 200 }, Id = 210, Description = "user 200, task 210" },
            };

            userTaskRepositoryMock.Setup(x => x.List()).Returns(taskList.AsQueryable());

            var service = new UserTaskService(userTaskRepositoryMock.Object, null);

            await service.DeleteUserTask(100, new int[] { 110, 120, 210 });

            userTaskRepositoryMock.Verify(x => x.Delete(110), Times.Once);
            userTaskRepositoryMock.Verify(x => x.Delete(120), Times.Once);
            userTaskRepositoryMock.Verify(x => x.Delete(200), Times.Never);
        }
    }
}