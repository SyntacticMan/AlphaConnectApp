using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaConnectApp
{
    /// <summary>
    /// classe para definir um recruta
    /// </summary>
    class RecruitModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int platoonId { get; set; }
    }
}
