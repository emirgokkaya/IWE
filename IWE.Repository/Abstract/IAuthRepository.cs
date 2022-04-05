using IWE.Entity.Concrete;

namespace IWE.Repository.Abstract;

public interface IAuthRepository
{
    User Login(string email, string password);
    User Register(User user, string password);
}