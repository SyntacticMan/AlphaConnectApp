using System;
using System.Collections.Generic;
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
                            platoon.initialDate = Convert.ToDateTime(xSubElem.Value);
                            break;
                        case "finaldate":
                            platoon.finalDate = Convert.ToDateTime(xSubElem.Value);
                            break;

                    }
                }

                platoonsList.Add(platoon);
            }
            return platoonsList;
        }
    }
}
