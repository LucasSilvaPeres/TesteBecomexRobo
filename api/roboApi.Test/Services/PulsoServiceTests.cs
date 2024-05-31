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
    [InlineData(BracoCotovelo.Levemente_Contraido)]
    [InlineData(BracoCotovelo.Contraido)]
    public void VerificarRotacaoPulso_DeveLancarExcecaoQuandoCotoveloNaoEstaFirmementeContraido(BracoCotovelo statusCotevelo)
    {

      Assert.Throws<Exception>(() => service.VerificarRotacaoPulso(statusCotevelo));

    }

    [Fact]
    public void RotacionarPulsoNegativo_DeveLancarExcecaoQuandoPulsoNaoPodeSerRotacionadoNegativo()
    {

      Assert.Throws<Exception>(() => service.RotacionarPulsoNegativo(BracoPulso.Negativo_90));

    }

    [Fact]
    public void RotacionarPulsoNegativo_DeveLancarExcecaoQuandoPulsoNaoPodeSerRotacionadoPositivo()
    {

      Assert.Throws<Exception>(() => service.RotacionarPulsoPositivo(BracoPulso.Positivo_180));

    }

    [Theory]
    [InlineData(BracoPulso.Negativo_90, BracoPulso.Negativo_45)]
    [InlineData(BracoPulso.Negativo_45, BracoPulso.Repouso)]
    [InlineData(BracoPulso.Repouso, BracoPulso.Positivo_45)]
    [InlineData(BracoPulso.Positivo_45, BracoPulso.Positivo_90)]
    [InlineData(BracoPulso.Positivo_90, BracoPulso.Positivo_135)]
    [InlineData(BracoPulso.Positivo_135, BracoPulso.Positivo_180)]
    public void RotacionarPulsoPositivo_DeveRetornarStatusEsperado(BracoPulso entrada, BracoPulso esperado)
    {

      var resultado = service.RotacionarPulsoPositivo(entrada);

      Assert.Equal(esperado, resultado);

    }

    [Theory]
    [InlineData(BracoPulso.Positivo_180, BracoPulso.Positivo_135)]
    [InlineData(BracoPulso.Positivo_135, BracoPulso.Positivo_90)]
    [InlineData(BracoPulso.Positivo_90, BracoPulso.Positivo_45)]
    [InlineData(BracoPulso.Positivo_45, BracoPulso.Repouso)]
    [InlineData(BracoPulso.Repouso, BracoPulso.Negativo_45)]
    [InlineData(BracoPulso.Negativo_45, BracoPulso.Negativo_90)]

    public void RotacionarPulsoNegatio_DeveRetornarStatusEsperado(BracoPulso entrada, BracoPulso esperado)
    {

      var resultado = service.RotacionarPulsoNegativo(entrada);

      Assert.Equal(esperado, resultado);

    }
  }
}