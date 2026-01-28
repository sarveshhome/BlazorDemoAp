using BlazerDemoApp.Models;

namespace BlazerDemoApp.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
}