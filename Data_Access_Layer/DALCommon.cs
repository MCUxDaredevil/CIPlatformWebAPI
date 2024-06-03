using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using System.Data;

namespace Data_Access_Layer
{
    public class DALCommon
    {
        private readonly AppDbContext _cIDbContext;
        public DALCommon(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public class Option
        {
            public int value { get; set; }
            public string text { get; set; }
        }

        public List<Option> GetCountryList()
        {
            return _cIDbContext.Country
                .Select(c => new Option { value = c.Id, text = c.CountryName })
                .ToList();
        }

        public List<Option> GetCityList(int countryId)
        {
            return _cIDbContext.City.Where(c => c.CountryId == countryId)
                .Select(c => new Option { value = c.Id, text = c.CityName})
                .ToList();
        }
    }
}
