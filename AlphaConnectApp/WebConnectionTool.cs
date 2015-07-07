using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlphaConnectApp
{
    class WebConnectionTool
    {
        /// <summary>
        ///  método para ligar ao webservice usando o client http e recuperar o xml
        /// </summary>
        /// <param name="url"></param>
        /// <param name="endpoint"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> GetXmlFromService(string url, string endpoint, string value)
        {
            Task<string> response;

            try
            {
                string address = "";

                if (string.IsNullOrEmpty(value))
                {
                    address = string.Format("{0}/{1}", url, endpoint);
                }
                else
                {
                    address = string.Format("{0}/{1}/{2}", url, endpoint, value);
                }

                HttpClient client = new HttpClient();

                response = client.GetStringAsync(address);

                return response.Result;
            }
            catch (Exception ex)
            {

            }
            return "";
        }
    }
}
