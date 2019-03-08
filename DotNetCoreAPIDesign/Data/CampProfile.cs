using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DotNetCoreAPIDesign.Data.Entities;
using DotNetCoreAPIDesign.Domain;

namespace DotNetCoreAPIDesign.Data
{
    public class CampProfile:Profile
    {
        public CampProfile()
        {
            CreateMap<Camp, CampDomain>().ForMember(c=>c.Venue,o=>o.MapFrom(m=>m.Location.VenueName));
        }
    }
}
