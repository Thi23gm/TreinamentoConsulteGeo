using backend.Models;

namespace backend.Repos
{
    public static class UserRepository
    {
        public static List<UserModel> users { get; set; } = new List<UserModel>()
        {
            new UserModel
            {
                Id = 1,
                isActive = true,
                age = 1,
                eyeColor = "teste1",
                name = "Test",
            },
            new UserModel
            {
                Id = 2,
                isActive = true,
                age = 1,
                eyeColor = "teste2",
                name = "Test2",
            },
            new UserModel
            {
                Id = 3,
                isActive = true,
                age = 1,
                eyeColor = "teste3",
                name = "Test3",
            },
            new UserModel
            {
                Id = 4,
                isActive = true,
                age = 1,
                eyeColor = "teste4",
                name = "Test4",
            }
        };
    }
}
