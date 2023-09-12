using System;
using System.Security.Cryptography;
using System.Text;

public static class AuthenticationUtil
{
    private static readonly Dictionary<string, User> users = new Dictionary<string, User>
    {
        { "admin", new User { Username = "admin", Password = "admin123", Salt = "somesalt" } },
        { "user1", new User { Username = "user1", Password = "password1", Salt = "anothersalt" } },
        { "user2", new User { Username = "user2", Password = "password2", Salt = "moresalt" } }
    };

    public static bool AuthenticateUser(string username, string password)
    {
        if (users.ContainsKey(username))
        {
            User user = users[username];
            string hashedPassword = HashPassword(password, user.Salt);
            return user.Password == hashedPassword;
        }

        return false;
    }

    private static string HashPassword(string password, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
        {
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(saltBytes, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}
