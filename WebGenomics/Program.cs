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
            var genomics = GetResult("facebook.com");
            Console.ReadKey();
        }

        internal static Analysis GetResult(string uri)
        {
            Analysis result = null;
            try
            {
                var url = "http://websitegenomics.cloudapp.net/Classify/?uri=" + uri;
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.UTF8Encoding.UTF8;
                    wc.Headers["Accept"] = "application/json";
                    wc.Credentials = new NetworkCredential("demo", "demo");
                    var jsonString = wc.DownloadString(url);
                    Console.WriteLine("Result: " + jsonString);
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
