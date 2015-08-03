using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebGenomics
{
    class Program
    {
        static void Main(string[] args)
        {
            //The target website
            var uri = "facebook.com";
            var genomics = GetWebSiteGenome(uri);
            Console.ReadKey();
        }

        internal static Analysis GetWebSiteGenome(string uri)
        {
            Analysis result = null;
            try
            {
                var url = "http://websitegenomics.cloudapp.net/Classify/?uri=" + uri;
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.UTF8Encoding.UTF8;
                    //Accept header must be specified
                    wc.Headers["Accept"] = "application/json";
                    // Username and password which you get when you registerd on the WebGenomics
                    wc.Credentials = new NetworkCredential("demo", "demo");
                    var jsonString = wc.DownloadString(url);
                    Console.WriteLine("Result: " + jsonString);
                    //Deserialize to Analysis class
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<Analysis>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = null;
            }
            return result;
        }
    }
}
