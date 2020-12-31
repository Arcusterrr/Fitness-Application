using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Storage;

namespace Infrastructure
{
    public class ListUserStorage: IUserStorage
    {
        private static List<User> storage = new List<User>();
        
        public Task<User> GetUserById(int id)
        {
            var user = storage.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(user);
        }

        public Task SaveUser(User user)
        {
            var maxId = storage
                .OrderByDescending(x => x.Id)
                .Select(x => x.Id)
                .FirstOrDefault();

            user.Id = maxId + 1;

            storage.Add(user);
            
            return Task.CompletedTask;
        }
    }
}