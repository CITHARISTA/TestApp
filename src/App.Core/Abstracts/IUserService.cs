using App.Core.Models;

namespace App.Core.Abstracts
{
    public interface IUserService
    {
        Task PostUserAsync(User user);
    }
}
