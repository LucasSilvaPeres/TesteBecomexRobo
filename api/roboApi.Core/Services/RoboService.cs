using Microsoft.EntityFrameworkCore;
using roboApi.DB;
using roboApi.DB.Entities;
using roboApi.DB.Status;

namespace roboApi.Core.Services;

public class RoboService
{
    private readonly RoboDbContext _context;

    public RoboService(RoboDbContext context)
    {
        _context = context;
    }

    public async Task Reiniciar()
    {
        _context.RemoveRange(_context.Robos);

        Braco bracoD = new Braco(){
            Cotovelo = BracoCotovelo.Repouso,
            Pulso = BracoPulso.Repouso,
        };

        Braco bracoE = new Braco(){
            Cotovelo = BracoCotovelo.Repouso,
            Pulso = BracoPulso.Repouso,
        };

        Cabeca cabeca = new Cabeca(){
            Inclinacao = CabecaInclinacao.Repouso,
            Rotacao = CabecaRotacao.Repouso,
        };

        Robo robo = new Robo(){
            Cabeca = cabeca,
            Direito = bracoD,
            Esquerdo = bracoE,
        };
        _context.Add(robo);

        await _context.SaveChangesAsync();

    }

    public async Task<Robo> Status(){
        return await _context.Robos.SingleAsync();
    }
}
