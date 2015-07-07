using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlphaConnectApp
{
    class Tools
    {
        public List<PlatoonModel> GetPlatoonsList(string xmlString)
        {
            XDocument xDoc = XDocument.Parse(xmlString);
            List<PlatoonModel> platoonsList = new List<PlatoonModel>();
            string dateParsePattern = "dd/MM/yyyy";
            DateTime parsedDate;

            foreach (XElement xElem in xDoc.Root.Elements())
            {
                PlatoonModel platoon = new PlatoonModel();

                foreach (XElement xSubElem in xElem.Elements())
                {
                    switch(xSubElem.Name.ToString())
                    {
                        case "id":
                            platoon.id = Convert.ToInt32(xSubElem.Value);
                            break;
                        case "name":
                            platoon.name = xSubElem.Value;
                            break;
                        case "initialdate":
                            DateTime.TryParseExact(xSubElem.Value, dateParsePattern, null, DateTimeStyles.None, out parsedDate);
                            platoon.initialDate = parsedDate;
                            break;
                        case "finaldate":
                            DateTime.TryParseExact(xSubElem.Value, dateParsePattern, null, DateTimeStyles.None, out parsedDate);
                            platoon.initialDate = parsedDate;
                            break;

                    }
                }

                platoonsList.Add(platoon);
            }
            return platoonsList;
        }
    }
}
