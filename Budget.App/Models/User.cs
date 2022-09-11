namespace Budget.App.Models
{
    public class User
    {
        public User(string name, string email, int userId, string userString)
        {
            Name = name;
            Email = email;
            UserId = userId;
            UserString = userString;
        }

        public string Name { get; }
        public string Email { get; }
        public int UserId { get; }
        public string UserString { get; }
    }
}
