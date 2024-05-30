using roboApi.DB.Status;

namespace roboApi.DB.Entities;
public class Cabeca : BaseEntity
{
    public CabecaInclinacao Inclinacao { get; set; }
    public CabecaRotacao Rotacao { get; set; }
}
