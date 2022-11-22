using Microsoft.EntityFrameworkCore;
using ParkyApplication.Data;
using ParkyApplication.Models;
using ParkyApplication.Repository.IRepository;

namespace ParkyApplication.Repository
{
    public class TrailRepository : ITrailsRepository
    {
        private readonly ApplicationDbContext _context;

        public TrailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateTrail(TrailModels trail)
        {
            _context.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(TrailModels trail)
        {
            _context.Trails.Remove(trail);
            return Save();
        }

        public TrailModels GetTrail(int trailId)
        {
            return _context.Trails.Include(d => d.NationalPark).FirstOrDefault(d => d.trailId == trailId);
        }

        public ICollection<TrailModels> GetTrails()
        {
            return _context.Trails.Include(d => d.NationalPark).OrderBy(d => d.Name).ToList();
        }

        public ICollection<TrailModels> GetTrailsInNationalPark(int npId)
        {
            return _context.Trails.Include(d => d.NationalPark).Where(d => d.nationslParkId == npId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool TrailExist(string name)
        {
            return _context.Trails.Any(s => s.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool TrailExists(int id)
        {
            return _context.Trails.Any(f => f.nationslParkId == id);
        }

        public bool UpdateTrail(TrailModels trail)
        {
            _context.Trails.Update(trail);
            return Save();
        }
    }
}
