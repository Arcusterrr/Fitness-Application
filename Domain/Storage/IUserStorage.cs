using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Storage
{
    public interface IUserStorage
    {
        Task<User> GetUserById(int id);
        Task SaveUser(User user);
    }
}