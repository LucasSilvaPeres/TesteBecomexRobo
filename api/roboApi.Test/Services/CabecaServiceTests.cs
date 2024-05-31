using roboApi.Core.Services;
using roboApi.DB;
using roboApi.DB.Status;

namespace roboApi.Test.Services;
public class CabecaServiceTests
{
    private readonly CabecaService _cabecaService;
    public CabecaServiceTests()
    {
        _cabecaService = new CabecaService(new RoboDbContext());

    }

    [Theory]
    [InlineData(CabecaInclinacao.Repouso, CabecaInclinacao.Baixo)]
    [InlineData(CabecaInclinacao.Cima, CabecaInclinacao.Repouso)]
    public void InclinarCabecaBaixo_DeveAtualizarEstadoInclinacaoCabecaBaixo(CabecaInclinacao entrada, CabecaInclinacao esperado)
    {
        var resultado = _cabecaService.InclinarCabecaBaixo(entrada);

        Assert.Equal(esperado, resultado);

    }

    [Theory]
    [InlineData(CabecaInclinacao.Repouso, CabecaInclinacao.Cima)]
    [InlineData(CabecaInclinacao.Baixo, CabecaInclinacao.Repouso)]
    public void InclinarCabecaCima_DeveAtualizarEstadoInclinacaoCabecaCima(CabecaInclinacao entrada, CabecaInclinacao esperado)
    {
        var resultado = _cabecaService.InclinarCabecaCima(entrada);

        Assert.Equal(esperado, resultado);

    }

    [Fact]
    public void InclinarCabecaBaixo_DeveRetornarExcessaoSeCabecaEstiverBaixo(){

        Assert.Throws<Exception>(() => _cabecaService.InclinarCabecaBaixo(CabecaInclinacao.Baixo));
    }

    [Fact]
    public void InclinarCabecaCima_DeveRetornarExcessaoSeCabecaEstiverCima(){

        Assert.Throws<Exception>(() => _cabecaService.InclinarCabecaCima(CabecaInclinacao.Cima));
    }

    [Theory]
    [InlineData(CabecaRotacao.Negativo_90, CabecaRotacao.Negativo_45)]
    [InlineData(CabecaRotacao.Negativo_45, CabecaRotacao.Repouso)]
    [InlineData(CabecaRotacao.Repouso, CabecaRotacao.Positivo_45)]
    [InlineData(CabecaRotacao.Positivo_45, CabecaRotacao.Positivo_90)]
    public void RotacionarCabecaPositivo_DeveAtualizarEstadoRotacaoCabecaPositivamente(CabecaRotacao entrada, CabecaRotacao esperado){
        var resultado = _cabecaService.RotacionarCabecaPositivo(entrada);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(CabecaRotacao.Positivo_90, CabecaRotacao.Positivo_45)]
    [InlineData(CabecaRotacao.Positivo_45, CabecaRotacao.Repouso)]
    [InlineData(CabecaRotacao.Repouso, CabecaRotacao.Negativo_45)]
    [InlineData(CabecaRotacao.Negativo_45, CabecaRotacao.Negativo_90)]
    public void RotacionarCabecaNegativo_DeveAtualizarEstadoRotacaoCabecaNegativamente(CabecaRotacao entrada, CabecaRotacao esperado){
        var resultado = _cabecaService.RotacionarCabecaNegativo(entrada);

        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void VerificarInclinacaoCabeca_DeveRetornarExcessaoSeInclinacaoCabecaEstiverBaixo(){
        Assert.Throws<Exception>(() => _cabecaService.VerificarInclinacaoCabeca(CabecaInclinacao.Baixo));
    }

    [Fact]
    public void RotacionarCabecaNegativo_DeveRetornarExcessaoSeRotacaoCabecaEstiverNegativo90(){
        Assert.Throws<Exception>(() => _cabecaService.RotacionarCabecaNegativo(CabecaRotacao.Negativo_90));
    }

    [Fact]
    public void RotacionarCabecaPositivo_DeveRetornarExcessaoSeRotacaoCabecaEstiverPositivo90(){
        Assert.Throws<Exception>(() => _cabecaService.RotacionarCabecaPositivo(CabecaRotacao.Positivo_90));
    }
}