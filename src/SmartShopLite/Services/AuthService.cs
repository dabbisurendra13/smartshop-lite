using System.Text.Json;
using SmartShopLite.Models;

namespace SmartShopLite.Services
{
    public class AuthService : IAuthService
    {
        private const string SessionKey = "SmartShopLite.User";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext?.Session ?? throw new InvalidOperationException("Session is not available.");

        private User? LoadUser()
        {
            var json = Session.GetString(SessionKey);
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return JsonSerializer.Deserialize<User>(json);
        }

        private void SaveUser(User? user)
        {
            if (user is null)
            {
                Session.Remove(SessionKey);
                return;
            }

            Session.SetString(SessionKey, JsonSerializer.Serialize(user));
        }

        public bool IsLoggedIn => CurrentUser != null;

        public User? CurrentUser => LoadUser();

        public bool Login(string username, string password)
        {
            // NOTE: This is a mock authentication implementation for demo purposes.
            // Replace with real authentication in a production scenario.
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "password")
            {
                var user = new User
                {
                    Username = "admin",
                    DisplayName = "Administrator"
                };

                SaveUser(user);
                return true;
            }

            if (username.Equals("guest", StringComparison.OrdinalIgnoreCase) && password == "guest")
            {
                var user = new User
                {
                    Username = "guest",
                    DisplayName = "Guest User"
                };

                SaveUser(user);
                return true;
            }

            return false;
        }

        public void Logout()
        {
            SaveUser(null);
        }
    }
}
