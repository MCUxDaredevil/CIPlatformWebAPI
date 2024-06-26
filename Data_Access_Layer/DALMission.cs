﻿using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALMission
    {
        private readonly AppDbContext _cIDbContext;

        public DALMission(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }


        public List<DALCommon.Option> GetMissionSkillList()
        {
            return _cIDbContext.MissionSkill
                .Where(x => !x.IsDeleted)
                .Select(s => new DALCommon.Option { value = s.Id, text = s.SkillName })
                .ToList();
        }

        public List<DALCommon.Option> GetMissionThemeList()
        {
            return _cIDbContext.MissionTheme
                .Where(x => !x.IsDeleted)
                .Select(s => new DALCommon.Option { value = s.Id, text = s.ThemeName })
                .ToList();
        }


        public  List<Missions> MissionList()
        {
            return _cIDbContext.Missions.ToList();
        }

        public string AddMission(Missions mission)
        {
            string result = "";
            try
            {
                _cIDbContext.Missions.Add(mission);
                _cIDbContext.SaveChanges();
                result = "Mission added Successfully.";
            }
            catch (Exception ex)
            {

                result = ex.Message;
            }
            return result;
        }
    }
}
