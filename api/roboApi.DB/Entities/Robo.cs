namespace roboApi.DB.Entities;
public class Robo : BaseEntity
{
    public Cabeca Cabeca { get; set; }
    public Braco Esquerdo { get; set; }
    public Braco Direito { get; set; }
}
