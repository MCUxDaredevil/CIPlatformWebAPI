using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly BALMission _balMission;
        private readonly ResponseResult result = new ResponseResult();

        public MissionController(BALMission balMission)
        {
            _balMission = balMission;
        }

        [HttpGet]
        [Route("GetMissionSkillList")]
        public ResponseResult GetMissionSkillList()
        {
            try
            {
                result.Data = _balMission.GetMissionSkillList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("GetMissionThemeList")]
        public ResponseResult GetMissionThemeList()
        {
            try
            {
                result.Data = _balMission.GetMissionThemeList();
                ;
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("MissionList")]
        public ResponseResult MissionList()
        {
            try
            {
                result.Data = _balMission.MissionList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpPost]
        [Route("AddMission")]
        public ResponseResult AddMission(Missions mission)
        {
            try
            {
                result.Data = _balMission.AddMission(mission);
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