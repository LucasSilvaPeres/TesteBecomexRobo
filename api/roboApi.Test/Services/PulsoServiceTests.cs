using roboApi.Core.Services;
using roboApi.DB;
using roboApi.DB.Status;

namespace roboApi.Test.Services
{
  public class PulsoServiceTest
  {
    private readonly PulsoService service;
    public PulsoServiceTest()
    {
      service = new PulsoService(new RoboDbContext());
    }

    [Theory]
    [InlineData(BracoCotovelo.Repouso)]
    [InlineData(BracoCotovelo.LevementeContraido)]
    [InlineData(BracoCotovelo.Contraido)]
    public void VerificarRotacaoPulso_DeveLancarExcecaoQuandoCotoveloNaoEstaFirmementeContraido(BracoCotovelo statusCotevelo)
    {

      Assert.Throws<Exception>(() => service.VerificarRotacaoPulso(statusCotevelo));

    }

    [Fact]
    public void RotacionarPulsoNegativo_DeveLancarExcecaoQuandoPulsoNaoPodeSerRotacionadoNegativo()
    {

      Assert.Throws<Exception>(() => service.RotacionarPulsoNegativo(BracoPulso.Negativo90));

    }

    [Fact]
    public void RotacionarPulsoNegativo_DeveLancarExcecaoQuandoPulsoNaoPodeSerRotacionadoPositivo()
    {

      Assert.Throws<Exception>(() => service.RotacionarPulsoPositivo(BracoPulso.Positivo180));

    }

    [Theory]
    [InlineData(BracoPulso.Negativo90, BracoPulso.Negativo45)]
    [InlineData(BracoPulso.Negativo45, BracoPulso.Repouso)]
    [InlineData(BracoPulso.Repouso, BracoPulso.Positivo45)]
    [InlineData(BracoPulso.Positivo45, BracoPulso.Positivo90)]
    [InlineData(BracoPulso.Positivo90, BracoPulso.Positivo135)]
    [InlineData(BracoPulso.Positivo135, BracoPulso.Positivo180)]
    public void RotacionarPulsoPositivo_DeveRetornarStatusEsperado(BracoPulso entrada, BracoPulso esperado)
    {

      var resultado = service.RotacionarPulsoPositivo(entrada);

      Assert.Equal(esperado, resultado);

    }

    [Theory]
    [InlineData(BracoPulso.Positivo180, BracoPulso.Positivo135)]
    [InlineData(BracoPulso.Positivo135, BracoPulso.Positivo90)]
    [InlineData(BracoPulso.Positivo90, BracoPulso.Positivo45)]
    [InlineData(BracoPulso.Positivo45, BracoPulso.Repouso)]
    [InlineData(BracoPulso.Repouso, BracoPulso.Negativo45)]
    [InlineData(BracoPulso.Negativo45, BracoPulso.Negativo90)]

    public void RotacionarPulsoNegatio_DeveRetornarStatusEsperado(BracoPulso entrada, BracoPulso esperado)
    {

      var resultado = service.RotacionarPulsoNegativo(entrada);

      Assert.Equal(esperado, resultado);

    }
  }
}