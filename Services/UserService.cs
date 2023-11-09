
using voluntariado2.Models;
using voluntariado2.Repositories;

namespace voluntariado2.Services
{
    public class UserService
    {
        public bool CreateUser(UserModel userModel) { 
            
            UserRepository repository = new UserRepository();

            return repository.CreateUser(userModel);
        }
    }
}