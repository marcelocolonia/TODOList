﻿using System.Linq;
using TODOList.Repository.Entities;
using TODOList.Repository.Interfaces;

namespace TODOList.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(User item)
        {
            throw new System.NotImplementedException();
        }

        public User Get(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<User> List()
        {
            throw new System.NotImplementedException();
        }
    }
}