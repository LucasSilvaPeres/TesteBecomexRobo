using roboApi.Core.Services;
using roboApi.DB;
using roboApi.Test.Fixtures;

namespace roboApi.Test.Services
{
    
    public class RoboServiceTests
    {
        private readonly RoboService _roboService;

        public RoboServiceTests()
        {
            _roboService = new RoboService(new DbContextFixture().context);
        }
        [Fact]
        public async Task Reiniciar_DeveReiniciarEstadoRobo()
        {

            await _roboService.Reiniciar();

            var roboStatus = await _roboService.Status();
            Assert.NotNull(roboStatus);
        }
    }
}