using Microsoft.AspNetCore.Mvc;
using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly BALCommon _balCommon;
        ResponseResult result = new ResponseResult();
        public CommonController(BALCommon balCommon)
        {
            _balCommon = balCommon;
        }

        [HttpGet]
        [Route("CountryList")]
        public ResponseResult GetCountryList()
        {
            try
            {
                var response = _balCommon.GetCountryList();
                result.Data = response.Data;
                result.Result = ResponseStatus.Success;
                result.Message = response.Message;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("CityList/{id}")]
        public ResponseResult GetCityList(int id)
        {
            try
            {
                var response = _balCommon.GetCityList(id);
                result.Data = response.Data;
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}