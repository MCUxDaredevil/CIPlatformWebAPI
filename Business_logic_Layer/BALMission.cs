using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALMission
    {
        private readonly DALMission _dalMission;

        public BALMission(DALMission dalMission)
        {
            _dalMission = dalMission;
        }

        public List<DALCommon.Option> GetMissionThemeList()
        {
            return _dalMission.GetMissionThemeList();
        }

        public List<DALCommon.Option> GetMissionSkillList()
        {
            return _dalMission.GetMissionSkillList();
        }

        public List<Missions> MissionList()
        {
            return _dalMission.MissionList();
        } 

        public string AddMission(Missions mission)
        {
            return _dalMission.AddMission(mission);
        }
    }
}
