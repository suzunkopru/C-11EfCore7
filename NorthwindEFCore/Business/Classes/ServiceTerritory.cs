using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceTerritory : Service<Territory>, IServiceTerritory
{
    public ServiceTerritory(IEntityRepo<Territory> p_entityRepo)
                                        : base(p_entityRepo) { }
}

