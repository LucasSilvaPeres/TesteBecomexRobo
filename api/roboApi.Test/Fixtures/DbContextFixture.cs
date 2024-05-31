using roboApi.DB;

namespace roboApi.Test.Fixtures
{
    public class DbContextFixture
    {
        public readonly RoboDbContext context;
        private readonly RoboFixture roboFixture;
        public DbContextFixture(){
            context = new RoboDbContext();
            roboFixture = new RoboFixture();
            SetupDatabase();
        }

        private async void SetupDatabase()
        {
            await context.Database.EnsureDeletedAsync();
            await context.Robos.AddAsync(roboFixture.Robo);
            await context.SaveChangesAsync();
        }
    }
}