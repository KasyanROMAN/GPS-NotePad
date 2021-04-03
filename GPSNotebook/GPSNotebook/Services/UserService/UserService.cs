using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GPSNotebook.Models;
using GPSNotebook.Services.Repository;

namespace GPSNotebook.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;

            _repository.CreateTableAsync<User>();
        }

        public Task<List<User>> GetItemsAsync()
        {
            return _repository.GetItemsAsync<User>();
        }

        public Task<User> GetItemAsync(int id)
        {
            return _repository.GetItemAsync<User>(id);
        }

        public Task<User> GetItemAsync(Expression<Func<User, bool>> predicate)
        {
            return _repository.GetItemAsync(predicate);
        }

        public Task<int> InsertItemAsync(User item)
        {
            return _repository.InsertItemAsync(item);
        }

        public Task<int> UpdateItemAsync(User item)
        {
            return _repository.UpdateItemAsync(item);
        }

        public Task<int> DeleteItemAsync(User item)
        {
            return _repository.DeleteItemAsync(item);
        }
    }
}
