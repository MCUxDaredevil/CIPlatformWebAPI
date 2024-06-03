using Data_Access_Layer;
using Data_Access_Layer.JWTService;
using Data_Access_Layer.Repository.Entities;

namespace Business_logic_Layer
{
    public class BALCommon
    {
        private readonly DALCommon _dalCommon;
        private readonly JwtService _jwtService;
        ResponseResult result = new ResponseResult();

        public BALCommon(DALCommon dalCommon, JwtService jwtService)
        {
            _dalCommon = dalCommon;
            _jwtService = jwtService;
        }

        public ResponseResult GetCountryList()
        {
            try
            {
                var countryList = _dalCommon.GetCountryList();

                if (countryList != null)
                {
                    result.Message = "Country List Found";
                    result.Result = ResponseStatus.Success;
                    result.Data = countryList;
                }
                else
                {
                    result.Message = "Country List Not Found";
                    result.Result = ResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public ResponseResult GetCityList(int countryId)
        {
            try
            {
                var cityList = _dalCommon.GetCityList(countryId);

                if (cityList != null)
                {
                    result.Message = "City List Found";
                    result.Result = ResponseStatus.Success;
                    result.Data = cityList;
                }
                else
                {
                    result.Message = "City List Not Found";
                    result.Result = ResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
