using System;
using System.Net;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private string imageapiUri;

        public HomeController()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ImageApiUri")))
                imageapiUri = "http://localhost:8080/api/image";
            else
                imageapiUri = Environment.GetEnvironmentVariable("ImageApiUri");
        }


        public async Task<IActionResult> Index()
        {
            ViewData["imageuri"] = await getAnswer("web host " + Dns.GetHostName());
            //ViewData["imageuri"] = await getAnswer("Vinícius");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private async Task<string> getAnswer(string name)
        {

            UriBuilder uri = new UriBuilder(string.Format("{0}/{1}", this.imageapiUri, name));
            Console.WriteLine("executando o request uri: " + uri);


            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri.ToString());
            req.Method = "GET";

            try
            {
                HttpWebResponse response = await req.GetResponseAsync() as HttpWebResponse;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string imageurl = reader.ReadToEnd();

                    return imageurl;
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Erro ocorrido ao realizar o request");
                Console.WriteLine(ex.StackTrace);

                return ex.Message;
            }

            return string.Empty;
        }
    }
}
