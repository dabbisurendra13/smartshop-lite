using SmartShopLite.Models;

namespace SmartShopLite.Services
{
    public interface IAuthService
    {
        bool IsLoggedIn { get; }
        User? CurrentUser { get; }
        bool Login(string username, string password);
        void Logout();
    }
}
