using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaConnectApp
{
    /// <summary>
    ///  classe para guardar os membros do staff
    /// </summary>
    class StaffModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int platoonId { get; set; }
    }
}
