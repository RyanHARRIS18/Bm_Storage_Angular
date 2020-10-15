using API.Models;

namespace API.Interfaces
{
    public interface ITokenService
    {
     string CreateToekn(AppUser user);    
    }
}