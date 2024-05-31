using roboApi.DB.Entities;
using roboApi.DB.Status;

namespace roboApi.Test.Fixtures
{
    public class RoboFixture
    {
        public readonly Robo Robo;
        public RoboFixture(){
            Robo = Setup();
        }
        public static Robo Setup(){
            Braco bracoD = new(){
                Cotovelo = BracoCotovelo.Repouso,
                Pulso = BracoPulso.Repouso,
            };

            Braco bracoE = new(){
                Cotovelo = BracoCotovelo.Repouso,
                Pulso = BracoPulso.Repouso,
            };

            Cabeca cabeca = new(){
                Inclinacao = CabecaInclinacao.Repouso,
                Rotacao = CabecaRotacao.Repouso,
            };

            return new Robo(){
                Cabeca = cabeca,
                Direito = bracoD,
                Esquerdo = bracoE,
            };
        }
    }
}