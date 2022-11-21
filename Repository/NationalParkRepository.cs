using ParkyApplication.Data;
using ParkyApplication.Models;
using ParkyApplication.Repository.IRepository;

namespace ParkyApplication.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _context;

        public NationalParkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateNationalPark(NationalParkModel park)
        {
            _context.NationalParks.Add(park);
            return Save();
        }

        public bool DeleteNationalPark(NationalParkModel park)
        {
            _context.NationalParks.Remove(park);
            return Save();
        }

        public NationalParkModel GetNationalPark(int parkId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.NationalParks.FirstOrDefault(n => n.nationslParkId == parkId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public ICollection<NationalParkModel> GetNationalParks()
        {
            return _context.NationalParks.OrderBy(p => p.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool value = _context.NationalParks.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            return _context.NationalParks.Any(p => p.nationslParkId == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalParkModel park)
        {
            _context.NationalParks.Update(park);
            return Save();
        }
    }
}
