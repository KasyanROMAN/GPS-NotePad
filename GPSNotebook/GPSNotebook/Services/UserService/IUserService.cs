using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GPSNotebook.Models;

namespace GPSNotebook.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetItemsAsync();

        Task<User> GetItemAsync(int id);
        Task<User> GetItemAsync(Expression<Func<User, bool>> predicate);

        Task<int> InsertItemAsync(User item);
        Task<int> UpdateItemAsync(User item);

        Task<int> DeleteItemAsync(User item);
    }
}
