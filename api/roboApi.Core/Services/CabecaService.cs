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

        VerificarInclinacaoCabeca(robo);
        robo.Cabeca.Rotacao = RotacionarCabecaPositivo(robo.Cabeca.Rotacao);

        await _context.SaveChangesAsync();
    }
    public async Task RotacaoNegativo()
    {
        Robo robo = _context.Robos.First();

        VerificarInclinacaoCabeca(robo);
        robo.Cabeca.Rotacao = RotacionarCabecaNegativo(robo.Cabeca.Rotacao);

        await _context.SaveChangesAsync();
    }

    private void VerificarInclinacaoCabeca(Robo robo){
        if(robo.Cabeca.Inclinacao == CabecaInclinacao.Baixo)
            throw new Exception("Cabeca não pode estar inclinada para baixo ao rotacionar.");

    }

    private CabecaInclinacao InclinarCabecaCima(CabecaInclinacao statusInclinacao){
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
    private CabecaInclinacao InclinarCabecaBaixo(CabecaInclinacao statusInclinacao){
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

    private CabecaRotacao RotacionarCabecaPositivo(CabecaRotacao statusRotacao){
        switch (statusRotacao){
            case CabecaRotacao.Negativo90:
                return CabecaRotacao.Negativo45;

            case CabecaRotacao.Negativo45:
                return CabecaRotacao.Repouso;

            case CabecaRotacao.Repouso:
                return CabecaRotacao.Positivo45;

            case CabecaRotacao.Positivo45:
                return CabecaRotacao.Positivo90;

            case CabecaRotacao.Positivo90:
                throw new Exception("Não pode rotacionar mais.");

            default:
                throw new Exception("Não foi possível rotacionar cabeça.");

        }
    }
    private CabecaRotacao RotacionarCabecaNegativo(CabecaRotacao statusRotacao){
        switch (statusRotacao){
            case CabecaRotacao.Negativo90:
                throw new Exception("Não pode rotacionar mais.");

            case CabecaRotacao.Negativo45:
                return CabecaRotacao.Negativo90;

            case CabecaRotacao.Repouso:
                return CabecaRotacao.Negativo45;

            case CabecaRotacao.Positivo45:
                return CabecaRotacao.Repouso;

            case CabecaRotacao.Positivo90:
                return CabecaRotacao.Positivo45;

            default:
                throw new Exception("Não foi possível rotacionar cabeça.");

        }
    }
}
