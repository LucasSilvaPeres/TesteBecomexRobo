using Microsoft.EntityFrameworkCore;
using roboApi.Core.Services;
using roboApi.DB;
using roboApi.DB.Entities;
using roboApi.DB.Status;
using roboApi.Test.Fixtures;

namespace roboApi.Test.Services
{
    public class CabecaServiceTest
    {
        private readonly DbContextFixture _dbContextFixture;
        private readonly CabecaService _cabecaService;
        public CabecaServiceTest()
        {
            _dbContextFixture = new DbContextFixture();
            _cabecaService = new CabecaService(_dbContextFixture.context);
            
        }

        [Fact]
        public async void InclinacaoBaixo_DeveAtualizarEstadoCabeca()
        {
            
            Robo robo = await _dbContextFixture.context.Robos.SingleAsync();
            robo.Cabeca.Inclinacao = CabecaInclinacao.Repouso;
            await _cabecaService.InclinacaoBaixo();

            var updatedRobo = _dbContextFixture.context.Robos.Single();
            Assert.Equal(CabecaInclinacao.Baixo, updatedRobo.Cabeca.Inclinacao);

        }
        [Fact]
        public async void InclinacaoBaixo_DeveRetornarExcessao()
        {
            Robo robo = await _dbContextFixture.context.Robos.SingleAsync();
            robo.Cabeca.Inclinacao = CabecaInclinacao.Baixo;

            Task exception = _cabecaService.InclinacaoBaixo();

            await Assert.ThrowsAsync<Exception>(() => exception );

        } 
        [Fact]
        public async void InclinacaoCima_DeveAtualizarEstadoCabeca()
        {
            Robo robo = await _dbContextFixture.context.Robos.SingleAsync();
            robo.Cabeca.Inclinacao = CabecaInclinacao.Repouso;
            await _dbContextFixture.context.SaveChangesAsync();

            await _cabecaService.InclinacaoCima();

            var updatedRobo = await _dbContextFixture.context.Robos.SingleAsync();
            Assert.Equal(CabecaInclinacao.Cima, updatedRobo.Cabeca.Inclinacao);

        }
        [Fact]
        public async void InclinacaoCima_DeveRetornarExcessao()
        {
            Robo robo = await _dbContextFixture.context.Robos.SingleAsync();
            robo.Cabeca.Inclinacao = CabecaInclinacao.Cima;

            Task exception = _cabecaService.InclinacaoCima();

            await Assert.ThrowsAsync<Exception>(() => exception );

        }
    }
}