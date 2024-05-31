using roboApi.Core.Services;
using roboApi.DB;
using roboApi.DB.Status;

namespace roboApi.Test.Services
{
    
    public class RoboServiceTests
    {
        private readonly RoboService _roboService;

        public RoboServiceTests()
        {
            _roboService = new RoboService(new RoboDbContext());

        }
        [Fact]
        public async Task Reiniciar_DeveReiniciarEstadoRobo()
        {

            await _roboService.Reiniciar();

            var roboStatus = await _roboService.Status();
            Assert.NotNull(roboStatus);
            Assert.Equal(BracoPulso.Repouso, roboStatus.Direito.Pulso);
            Assert.Equal(BracoPulso.Repouso, roboStatus.Esquerdo.Pulso);
            Assert.Equal(BracoCotovelo.Repouso, roboStatus.Direito.Cotovelo);
            Assert.Equal(BracoCotovelo.Repouso, roboStatus.Esquerdo.Cotovelo);
            Assert.Equal(CabecaInclinacao.Repouso, roboStatus.Cabeca.Inclinacao);
            Assert.Equal(CabecaRotacao.Repouso, roboStatus.Cabeca.Rotacao);
        }
    }
}