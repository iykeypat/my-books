using Microsoft.EntityFrameworkCore;
using my_books.Data;
using NUnit.Framework;

namespace my_books_tests
{
    public class PublishersServiceTest
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BookDbTest")
            .Options;
        AppDbContext context;


        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {

        }
    }
}