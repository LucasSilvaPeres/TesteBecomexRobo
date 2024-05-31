using roboApi.DB;
using roboApi.DB.Entities;
using roboApi.DB.Status;

namespace roboApi.Core.Services;

public class CotoveloService
{
    private readonly RoboDbContext _context;

    public CotoveloService(RoboDbContext context)
    {
        _context = context;
    }
    
    public async Task ContrairCotoveloDireito()
    {
        Robo robo = _context.Robos.First();

        robo.Direito.Cotovelo = ContrairCotovelo(robo.Direito.Cotovelo);

        await _context.SaveChangesAsync();
    }
    public async Task DescontrairCotoveloDireito()
    {
        Robo robo = _context.Robos.First();
        
        robo.Direito.Cotovelo = DescontrairCotovelo(robo.Direito.Cotovelo);

        await _context.SaveChangesAsync();
    }
    public async Task ContrairCotoveloEsquerdo()
    {
        Robo robo = _context.Robos.First();
        
        robo.Esquerdo.Cotovelo = ContrairCotovelo(robo.Esquerdo.Cotovelo);
        
        await _context.SaveChangesAsync();
    }
    public async Task DescontrairCotoveloEsquerdo()
    {
        Robo robo = _context.Robos.First();
        
        robo.Esquerdo.Cotovelo = DescontrairCotovelo(robo.Esquerdo.Cotovelo);

        await _context.SaveChangesAsync();
    }

    public BracoCotovelo ContrairCotovelo(BracoCotovelo statusCotovelo){
        
        switch (statusCotovelo)
        {
            case BracoCotovelo.Repouso:
                return BracoCotovelo.LevementeContraido;
                
            case BracoCotovelo.LevementeContraido:
                return BracoCotovelo.Contraido;
                
            case BracoCotovelo.Contraido:
                return BracoCotovelo.FortementeContraido;
                
            case BracoCotovelo.FortementeContraido:
                throw new Exception("Cotovelo ja está fortemente contraido.");
            default:
                throw new Exception("Não foi possível contrair cotovelo.");
        }
    }

    public BracoCotovelo DescontrairCotovelo(BracoCotovelo statusCotovelo)
    {
        switch (statusCotovelo)
        {
            case BracoCotovelo.Repouso:
                throw new Exception("Cotovelo ja está relaxado.");
                
            case BracoCotovelo.LevementeContraido:
                return BracoCotovelo.Repouso;
                
            case BracoCotovelo.Contraido:
                return BracoCotovelo.LevementeContraido;
                
            case BracoCotovelo.FortementeContraido:
                return BracoCotovelo.Contraido;

            default:
                throw new Exception("Não foi possível relaxar cotovelo.");
        }
    }
}
