using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IWE.Entity.Concrete;
using IWE.UnitOfWork.Abstract;
using Microsoft.IdentityModel.Tokens;

namespace IWE.Service.Authorization;

public class TokenHandler
{
    private IConfiguration Configuration { get; }
    public TokenHandler(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    //Token üretecek metot.
    public Token CreateAccessToken(User user)
    {
        var claims = new List<Claim> {    
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            new Claim(ClaimTypes.NameIdentifier,
                Guid.NewGuid().ToString())
        };
        
        Token tokenInstance = new Token();
 
        //Security  Key'in simetriğini alıyoruz.
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
 
        //Şifrelenmiş kimliği oluşturuyoruz.
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
 
        //Oluşturulacak token ayarlarını veriyoruz.
        tokenInstance.Expiration = DateTime.Now.AddMinutes(10);
        JwtSecurityToken securityToken = new JwtSecurityToken(
            issuer: Configuration["Token:Issuer"],
            audience: Configuration["Token:Audience"],
            expires: tokenInstance.Expiration,//Token süresini 5 dk olarak belirliyorum
            notBefore: DateTime.Now,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
            signingCredentials: signingCredentials,
            claims: claims
        );
 
        //Token oluşturucu sınıfında bir örnek alıyoruz.
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
 
        //Token üretiyoruz.
        tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);
        return tokenInstance;
    }
}