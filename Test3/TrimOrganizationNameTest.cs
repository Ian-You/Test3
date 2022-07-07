using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Test3
{
    public class TrimOrganizationNameTest
    {      
      private readonly string BaseAddress = "https://force24.pipedrive.com/v1/organizations/search";


        public void Test()
        {
            var testStr1 = "NgÄ Kaitiaki o Te Puna RongoÄ o Aotearoa â€“ The MÄori Pharmacistsâ€™ Association Incorporated (MPA)";
            var testStr2 = "NgÄ";

            //var result1 = GetOrganizationByName(testStr1).Result;
            var result2 = GetOrganizationByName(testStr2).Result;

            //Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        public async Task<string> GetOrganizationByName(string organizationName)
        {
            Dictionary<string, string> settings = new Dictionary<string, string>
            {
                ["term"] = organizationName,
                ["api_token"] = "3d60762488050ab098e6372629745bac247315ff"
            };
            return await this.GetAsync(this.BaseAddress, settings);
        }

        private async Task<string> GetAsync(string baseAddress, Dictionary<string, string> settings)
        {            
            var address = string.Format("{0}?{1}", baseAddress, string.Join('&',
                settings.Select(s => GetParamValue(baseAddress, s.Key, s.Value))));

            return address;

            //return await this.GetAsync(address);
        }

        private string GetParamValue(string baseAddress, string key, string value)
        {
            if (!baseAddress.Contains("search") || key != "term")
            {
                return string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value));
            }

            return string.Format("{0}={1}", HttpUtility.UrlEncode(key), UrlEncode(value));
        }

        private string UrlEncode(string value)
        {
            var encodedStr = HttpUtility.UrlEncode(value);

            if (encodedStr.Length <= 100)
            {
                return encodedStr;
            }

            var words = value.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            if (words.Length > 1)
                return UrlEncode(string.Join(" ", words.Take(words.Length - 1)));

            return encodedStr.Substring(0, 100);
        }
    }
}
