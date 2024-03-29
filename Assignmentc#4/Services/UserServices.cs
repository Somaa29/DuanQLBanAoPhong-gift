﻿using Assignmentc_4.IServices;
using Assignmentc_4.Models;

namespace Assignmentc_4.Services
{
    public class UserServices : IUserServices
    {
        AsmDbContext _dbContext;
        public UserServices()
        {
            _dbContext = new AsmDbContext();
        }
        public bool CreateUser(User p)
        {
            try
            {
                _dbContext.Users.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                dynamic user = _dbContext.Users.Find(id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(p => p.Id == id);
        }

        public List<User> GetUserByName(string name)
        {
            return _dbContext.Users.Where(p => p.UserName.Contains(name)).ToList();
        }

        public bool UpdateUser(User p)
        {
            try
            {
                var user = _dbContext.Users.Find(p.Id);
                user.UserName = p.UserName;
                user.PassWord = p.PassWord;
                user.Status = p.Status;
                _dbContext.Update(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
