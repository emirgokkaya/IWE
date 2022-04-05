using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using IWE.DAL.Contexts;
using IWE.Entity.Concrete;
using IWE.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IWE.Repository.Concrete;

public class AuthRepository : IAuthRepository
{
    private readonly IConfiguration _configuration;
    private readonly IWEContext _context;
    public AuthRepository(IWEContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public User Register(User user, string password)
    {
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.Set<User>().Add(user);
        _context.SaveChanges();

        return user;
    }

    public User Login(string email, string password)
    {
        var user = _context.Set<User>().FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }
        }

        return null;
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}