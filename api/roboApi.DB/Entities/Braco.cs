using roboApi.DB.Status;

namespace roboApi.DB.Entities;

public class Braco : BaseEntity
{
    public BracoCotovelo Cotovelo { get; set; }
    public BracoPulso Pulso { get; set; }
}

