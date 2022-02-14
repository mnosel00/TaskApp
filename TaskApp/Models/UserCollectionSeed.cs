using Microsoft.EntityFrameworkCore;

namespace TaskApp.Models
{
    public static class UserCollectionSeed
    {
        public static void UserSeed(this ModelBuilder builder)
        {
            builder.Entity<UserCollection>().HasData(
                new UserCollection()
                {
                    Id = 1,
                    firstName = "Krystian",
                    lastName = "Nowak"
                },
                new UserCollection()
                {
                    Id = 2,
                    firstName = "Maciej",
                    lastName = "Kowalski"
                },
                new UserCollection()
                {
                    Id = 3,
                    firstName = "Zbigniew",
                    lastName = "Czajka"
                }

                ) ;
        }
    }
}
