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
        /// <summary>
        ///  método para transformar o xml que vem do webservice numa lista que pode ser enviada para a listview
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public List<PlatoonModel> GetPlatoonsList(string xmlString)
        {
            XDocument xDoc = XDocument.Parse(xmlString);
            List<PlatoonModel> platoonsList = new List<PlatoonModel>();

            // as datas que vêem do webservice não são compatíveis com o formato existente na app
            // por isso faço parse usando o padrão abaixo para a processar
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
