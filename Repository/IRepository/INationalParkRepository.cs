using ParkyApplication.Models;

namespace ParkyApplication.Repository.IRepository
{
    public interface INationalParkRepository
    {
        ICollection<NationalParkModel> GetNationalParks();
        NationalParkModel GetNationalPark(int parkId);
        bool NationalParkExists(string name);
        bool NationalParkExists(int id);
        bool CreateNationalPark(NationalParkModel park);
        bool UpdateNationalPark(NationalParkModel park);
        bool DeleteNationalPark(NationalParkModel park);
        bool Save();
    }
}
