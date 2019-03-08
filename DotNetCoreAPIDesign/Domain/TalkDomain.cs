using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetCoreAPIDesign.Data.Entities;

namespace DotNetCoreAPIDesign.Domain
{
    public class TalkDomain
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public Speaker Speaker { get; set; }
    }
}
