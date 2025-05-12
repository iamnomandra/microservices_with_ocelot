namespace AuthServices
{
    public class UserModel
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; } 
    }

    public static class UserList
    {
        public static List<UserModel> Users()
        {
            var userList = new List<UserModel>
            {
                new UserModel { Id = 1, UserName = "rahul", Password="user123" },
                new UserModel { Id = 2, UserName = "anuj", Password="user12" },
                new UserModel { Id = 3, UserName = "varpreet", Password="user456" },
            };
            return userList;
        }
    }
}
