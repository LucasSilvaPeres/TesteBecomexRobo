using Microsoft.EntityFrameworkCore;
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
        Robo robo = await _context.Robos.SingleAsync();

        VerificarRotacaoPulso(robo.Direito.Cotovelo);
        robo.Direito.Pulso = RotacionarPulsoPositivo(robo.Direito.Pulso);

        
        await _context.SaveChangesAsync();

    }
    public async Task RotacaoPulsoDireitoNegativo()
    {
        Robo robo = await _context.Robos.SingleAsync();

        VerificarRotacaoPulso(robo.Direito.Cotovelo);
        robo.Direito.Pulso = RotacionarPulsoNegativo(robo.Direito.Pulso);

        await _context.SaveChangesAsync();
    }
    public async Task RotacaoPulsoEsquerdoPositivo()
    {
        Robo robo = await _context.Robos.SingleAsync();

        VerificarRotacaoPulso(robo.Esquerdo.Cotovelo);
        robo.Esquerdo.Pulso = RotacionarPulsoPositivo(robo.Esquerdo.Pulso);

            
        await _context.SaveChangesAsync();
    }
    public async Task RotacaoPulsoEsquerdoNegativo()
    {
        Robo robo = await _context.Robos.SingleAsync();
        
        VerificarRotacaoPulso(robo.Esquerdo.Cotovelo);
        robo.Esquerdo.Pulso = RotacionarPulsoNegativo(robo.Esquerdo.Pulso);
        
        await _context.SaveChangesAsync();
    }

    public void VerificarRotacaoPulso(BracoCotovelo cotovelo){
        if (cotovelo != BracoCotovelo.Fortemente_Contraido)
            throw new Exception("Cotovelo precisa estar Fortemente Contraido para rotacionar Pulso");
    }

    public BracoPulso RotacionarPulsoNegativo(BracoPulso statusPulso){
        switch (statusPulso)
        {
            case BracoPulso.Negativo_90:
                throw new Exception("Pulso não pode ser rotacionado negativo");
                
            case BracoPulso.Negativo_45:
                return BracoPulso.Negativo_90;
                
            case BracoPulso.Repouso:
                return BracoPulso.Negativo_45;

            case BracoPulso.Positivo_45:
                return BracoPulso.Repouso;

            case BracoPulso.Positivo_90:
                return BracoPulso.Positivo_45;

            case BracoPulso.Positivo_135:
                return BracoPulso.Positivo_90;

            case BracoPulso.Positivo_180:
                return BracoPulso.Positivo_135;
                
            default:
                throw new Exception("Não foi possível rotacionar pulso.");
        }
    }
    public BracoPulso RotacionarPulsoPositivo(BracoPulso statusPulso){
        switch (statusPulso)
        {
            case BracoPulso.Negativo_90:
                return BracoPulso.Negativo_45;
                
            case BracoPulso.Negativo_45:
                return BracoPulso.Repouso;
                
            case BracoPulso.Repouso:
                return BracoPulso.Positivo_45;

            case BracoPulso.Positivo_45:
                return BracoPulso.Positivo_90;

            case BracoPulso.Positivo_90:
                return BracoPulso.Positivo_135;

            case BracoPulso.Positivo_135:
                return BracoPulso.Positivo_180;

            case BracoPulso.Positivo_180:
                throw new Exception("Pulso não pode ser rotacionado positivo.");
                
            default:
                throw new Exception("Não foi possível rotacionar pulso.");
        }
    }

}
