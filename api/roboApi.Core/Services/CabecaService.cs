using roboApi.DB;
using roboApi.DB.Entities;
using roboApi.DB.Status;

namespace roboApi.Core.Services;

public class CabecaService
{
    private readonly RoboDbContext _context;

    public CabecaService(RoboDbContext context)
    {
        _context = context;
    }

    public async Task InclinacaoBaixo()
    {
        Robo robo = _context.Robos.First();

        robo.Cabeca.Inclinacao = InclinarCabecaBaixo(robo.Cabeca.Inclinacao);

        await _context.SaveChangesAsync();
    }
    public async Task InclinacaoCima()
    {
        Robo robo = _context.Robos.First();

        robo.Cabeca.Inclinacao = InclinarCabecaCima(robo.Cabeca.Inclinacao);

        await _context.SaveChangesAsync();
    }
    public async Task RotacaoPositivo()
    {
        Robo robo = _context.Robos.First();

        VerificarInclinacaoCabeca(robo.Cabeca.Inclinacao);
        robo.Cabeca.Rotacao = RotacionarCabecaPositivo(robo.Cabeca.Rotacao);

        await _context.SaveChangesAsync();
    }
    public async Task RotacaoNegativo()
    {
        Robo robo = _context.Robos.First();

        VerificarInclinacaoCabeca(robo.Cabeca.Inclinacao);
        robo.Cabeca.Rotacao = RotacionarCabecaNegativo(robo.Cabeca.Rotacao);

        await _context.SaveChangesAsync();
    }

    public void VerificarInclinacaoCabeca(CabecaInclinacao status){
        if(status == CabecaInclinacao.Baixo)
            throw new Exception("Cabeca não pode estar inclinada para baixo ao rotacionar.");

    }

    public CabecaInclinacao InclinarCabecaCima(CabecaInclinacao statusInclinacao){
        switch (statusInclinacao)
        {
            case CabecaInclinacao.Cima:
                throw new Exception("Não pode inclinar mais.");
                
            case CabecaInclinacao.Repouso:
                return CabecaInclinacao.Cima;
                
            case CabecaInclinacao.Baixo:
                return CabecaInclinacao.Repouso;
                
            default:
                throw new Exception("Não foi possível inclinar cabeça.");
        }
    }
    public CabecaInclinacao InclinarCabecaBaixo(CabecaInclinacao statusInclinacao){
        switch (statusInclinacao)
        {
            case CabecaInclinacao.Cima:
                return CabecaInclinacao.Repouso;
                
            case CabecaInclinacao.Repouso:
                return CabecaInclinacao.Baixo;
                
            case CabecaInclinacao.Baixo:
                throw new Exception("Não pode inclinar mais.");
                
            default:
                throw new Exception("Não foi possível inclinar cabeça.");
        }
    }

    public CabecaRotacao RotacionarCabecaPositivo(CabecaRotacao statusRotacao){
        switch (statusRotacao){
            case CabecaRotacao.Negativo_90:
                return CabecaRotacao.Negativo_45;

            case CabecaRotacao.Negativo_45:
                return CabecaRotacao.Repouso;

            case CabecaRotacao.Repouso:
                return CabecaRotacao.Positivo_45;

            case CabecaRotacao.Positivo_45:
                return CabecaRotacao.Positivo_90;

            case CabecaRotacao.Positivo_90:
                throw new Exception("Não pode rotacionar mais.");

            default:
                throw new Exception("Não foi possível rotacionar cabeça.");

        }
    }
    public CabecaRotacao RotacionarCabecaNegativo(CabecaRotacao statusRotacao){
        switch (statusRotacao){
            case CabecaRotacao.Negativo_90:
                throw new Exception("Não pode rotacionar mais.");

            case CabecaRotacao.Negativo_45:
                return CabecaRotacao.Negativo_90;

            case CabecaRotacao.Repouso:
                return CabecaRotacao.Negativo_45;

            case CabecaRotacao.Positivo_45:
                return CabecaRotacao.Repouso;

            case CabecaRotacao.Positivo_90:
                return CabecaRotacao.Positivo_45;

            default:
                throw new Exception("Não foi possível rotacionar cabeça.");

        }
    }
}
