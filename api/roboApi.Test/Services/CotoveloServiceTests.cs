using roboApi.DB.Status;
using roboApi.Core.Services;
using roboApi.DB;

namespace roboApi.Test.Services;

public class CotoveloServiceTests
{
  private readonly CotoveloService service;
  public CotoveloServiceTests()
  {
    service = new CotoveloService(new RoboDbContext());

  }

  [Theory]
  [InlineData(BracoCotovelo.Repouso, BracoCotovelo.LevementeContraido)]
  [InlineData(BracoCotovelo.LevementeContraido, BracoCotovelo.Contraido)]
  [InlineData(BracoCotovelo.Contraido, BracoCotovelo.FortementeContraido)]
  public void ContrairCotovelo_DeveRetornarStatusEsperado(BracoCotovelo entrada, BracoCotovelo esperado)
  {

    var resultado = service.ContrairCotovelo(entrada);

    Assert.Equal(esperado, resultado);

  }

  [Theory]
  [InlineData(BracoCotovelo.LevementeContraido, BracoCotovelo.Repouso)]
  [InlineData(BracoCotovelo.Contraido, BracoCotovelo.LevementeContraido)]
  [InlineData(BracoCotovelo.FortementeContraido, BracoCotovelo.Contraido)]
  public void DescontrairCotovelo_DeveRetornarStatusEsperado(BracoCotovelo entrada, BracoCotovelo esperado)
  {

    var resultado = service.DescontrairCotovelo(entrada);

    Assert.Equal(esperado, resultado);

  }


  [Fact]
  public void ContrairCotovelo_DeveLancarExcecaoQuandoCotoveloJaEstaFortementeContraido()
  {

    Assert.Throws<Exception>(() => service.ContrairCotovelo(BracoCotovelo.FortementeContraido));

  }

  [Fact]
  public void DescontrairCotovelo_DeveLancarExcecaoQuandoCotoveloJaEstaRelaxado()
  {

    Assert.Throws<Exception>(() => service.DescontrairCotovelo(BracoCotovelo.Repouso));

  }
}

