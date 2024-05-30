using roboApi.DB;
using roboApi.DB.Entities;
using roboApi.DB.Status;

namespace roboApi.Core.Services;

public class PulsoService
{
    private readonly RoboDbContext _context;

    public PulsoService(RoboDbContext context)
    {
        _context = context;
    }
    public async Task RotacaoPulsoDireitoPositivo()
    {
        Robo robo = _context.Robos.First();

        VerificarRotacaoPulso(robo.Direito);
        robo.Direito.Pulso = RotacionarPulsoPositivo(robo.Direito.Pulso);

        
        await _context.SaveChangesAsync();

    }
    public async Task RotacaoPulsoDireitoNegativo()
    {
        Robo robo = _context.Robos.First();

        VerificarRotacaoPulso(robo.Direito);
        robo.Direito.Pulso = RotacionarPulsoNegativo(robo.Direito.Pulso);

        await _context.SaveChangesAsync();
    }
    public async Task RotacaoPulsoEsquerdoPositivo()
    {
        Robo robo = _context.Robos.First();

        VerificarRotacaoPulso(robo.Esquerdo);
        robo.Esquerdo.Pulso = RotacionarPulsoPositivo(robo.Esquerdo.Pulso);

            
        await _context.SaveChangesAsync();
    }
    public async Task RotacaoPulsoEsquerdoNegativo()
    {
        Robo robo = _context.Robos.First();
        
        VerificarRotacaoPulso(robo.Esquerdo);
        robo.Esquerdo.Pulso = RotacionarPulsoNegativo(robo.Esquerdo.Pulso);
        
        await _context.SaveChangesAsync();
    }

    private void VerificarRotacaoPulso(Braco braco){
        if (braco.Cotovelo != BracoCotovelo.FortementeContraido)
            throw new Exception("Cotovelo precisa estar Fortemente Contraido para rotacionar Pulso");
    }

    private BracoPulso RotacionarPulsoNegativo(BracoPulso statusPulso){
        switch (statusPulso)
        {
            case BracoPulso.Negativo90:
                throw new Exception("Pulso não pode ser rotacionado negativo");
                
            case BracoPulso.Negativo45:
                return BracoPulso.Negativo90;
                
            case BracoPulso.Repouso:
                return BracoPulso.Negativo45;

            case BracoPulso.Positivo45:
                return BracoPulso.Repouso;

            case BracoPulso.Positivo90:
                return BracoPulso.Positivo45;

            case BracoPulso.Positivo135:
                return BracoPulso.Positivo90;

            case BracoPulso.Positivo180:
                return BracoPulso.Positivo135;
                
            default:
                throw new Exception("Não foi possível rotacionar pulso.");
        }
    }
    private BracoPulso RotacionarPulsoPositivo(BracoPulso statusPulso){
        switch (statusPulso)
        {
            case BracoPulso.Negativo90:
                return BracoPulso.Negativo45;
                
            case BracoPulso.Negativo45:
                return BracoPulso.Repouso;
                
            case BracoPulso.Repouso:
                return BracoPulso.Positivo45;

            case BracoPulso.Positivo45:
                return BracoPulso.Positivo90;

            case BracoPulso.Positivo90:
                return BracoPulso.Positivo135;

            case BracoPulso.Positivo135:
                return BracoPulso.Positivo180;

            case BracoPulso.Positivo180:
                throw new Exception("Pulso não pode ser rotacionado positivo.");
                
            default:
                throw new Exception("Não foi possível rotacionar pulso.");
        }
    }

}
