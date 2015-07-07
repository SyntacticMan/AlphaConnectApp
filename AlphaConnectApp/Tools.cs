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

        /// <summary>
        /// recebe a string xml vinda ada base de dados e converte-a para uma lista do tipo RecruitModel
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public List<RecruitModel> GetRecruitsList(string xmlString)
        {
            XDocument xDoc = XDocument.Parse(xmlString);
            List<RecruitModel> recruitsList = new List<RecruitModel>();

            foreach (XElement xElem in xDoc.Root.Elements())
            {
                RecruitModel recruit = new RecruitModel();

                foreach (XElement xSubElem in xElem.Elements())
                {
                    switch (xSubElem.Name.ToString())
                    {
                        case "id":
                            recruit.id = Convert.ToInt32(xSubElem.Value);
                            break;
                        case "name":
                            recruit.name = xSubElem.Value;
                            break;
                        case "email":
                            recruit.email = xSubElem.Value;
                            break;
                        case "platoonid":
                            recruit.platoonId = Convert.ToInt32(xSubElem.Value);
                            break;
                    }
                }
                recruitsList.Add(recruit);
            }
            return recruitsList;
        }

        /// <summary>
        ///  convert o xml do webservice numa lista do tipo StaffModel
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public List<StaffModel> GetStaffList(string xmlString)
        {
            XDocument xDoc = XDocument.Parse(xmlString);
            List<StaffModel> staffList = new List<StaffModel>();

            foreach (XElement xElem in xDoc.Root.Elements())
            {
                StaffModel staff = new StaffModel();

                foreach (XElement xSubElem in xElem.Elements())
                {
                    switch (xSubElem.Name.ToString())
                    {
                        case "id":
                            staff.id = Convert.ToInt32(xSubElem.Value);
                            break;
                        case "name":
                            staff.name = xSubElem.Value;
                            break;
                        case "email":
                            staff.email = xSubElem.Value;
                            break;
                        case "platoonid":
                            if (xSubElem.Value != "")
                            {
                                staff.platoonId = Convert.ToInt32(xSubElem.Value);
                            }
                            
                            break;
                    }
                }
                staffList.Add(staff);
            }
            return staffList;
        }
    }
}
