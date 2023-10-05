using TestTask.Domain.Entities;

namespace TestTask.API.Data
{
    public class DbInitialize
    {
        public static async Task SeedData(WebApplication app)
        {
            await Task.Run(() =>
            {
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(new List<Role>
                    {
                        new Role { Name = "User" },
                        new Role { Name = "Admin" },
                        new Role { Name = "Support" },
                        new Role { Name = "SuperAdmin" },
                    });

                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>
                    {
                        new User { Name = "User1", Age = 31, Email = "user1@gmail.com" },
                        new User { Name = "User2", Age = 39, Email = "user2@gmail.com" },
                        new User { Name = "User3", Age = 18, Email = "user3@gmail.com" },
                    });

                    context.SaveChanges();
                }
            });
        }
    }
}
