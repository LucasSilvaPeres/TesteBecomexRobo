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
  [InlineData(BracoCotovelo.Repouso, BracoCotovelo.Levemente_Contraido)]
  [InlineData(BracoCotovelo.Levemente_Contraido, BracoCotovelo.Contraido)]
  [InlineData(BracoCotovelo.Contraido, BracoCotovelo.Fortemente_Contraido)]
  public void ContrairCotovelo_DeveRetornarStatusEsperado(BracoCotovelo entrada, BracoCotovelo esperado)
  {

    var resultado = service.ContrairCotovelo(entrada);

    Assert.Equal(esperado, resultado);

  }

  [Theory]
  [InlineData(BracoCotovelo.Levemente_Contraido, BracoCotovelo.Repouso)]
  [InlineData(BracoCotovelo.Contraido, BracoCotovelo.Levemente_Contraido)]
  [InlineData(BracoCotovelo.Fortemente_Contraido, BracoCotovelo.Contraido)]
  public void DescontrairCotovelo_DeveRetornarStatusEsperado(BracoCotovelo entrada, BracoCotovelo esperado)
  {

    var resultado = service.DescontrairCotovelo(entrada);

    Assert.Equal(esperado, resultado);

  }


  [Fact]
  public void ContrairCotovelo_DeveLancarExcecaoQuandoCotoveloJaEstaFortementeContraido()
  {

    Assert.Throws<Exception>(() => service.ContrairCotovelo(BracoCotovelo.Fortemente_Contraido));

  }

  [Fact]
  public void DescontrairCotovelo_DeveLancarExcecaoQuandoCotoveloJaEstaRelaxado()
  {

    Assert.Throws<Exception>(() => service.DescontrairCotovelo(BracoCotovelo.Repouso));

  }
}

