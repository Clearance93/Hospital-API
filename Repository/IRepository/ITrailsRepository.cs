using ParkyApplication.Models;

namespace ParkyApplication.Repository.IRepository
{
    public interface ITrailsRepository
    {
        ICollection<TrailModels> GetTrails();
        ICollection<TrailModels> GetTrailsInNationalPark(int npId);
        TrailModels GetTrail(int trailId);
        bool TrailExist(string name);
        bool TrailExists(int id);
        bool CreateTrail(TrailModels trail);
        bool UpdateTrail(TrailModels trail);
        bool DeleteTrail(TrailModels trail);
        bool Save();
    }
}
