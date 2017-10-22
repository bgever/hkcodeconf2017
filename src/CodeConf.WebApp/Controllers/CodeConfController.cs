using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CodeConf.WebApp.Controllers
{
    public class CodeConfController : Controller
    {
        private HttpClient Backchannel { get; }

        public CodeConfController(HttpClient backchannel)
        {
            Backchannel = backchannel;
        }

        public async Task<IActionResult> Index()
        {
            string raw = await Backchannel
                .GetStringAsync("http://api/api/speakers/");
            var speakers = JArray
                .Parse(raw)
                .Select(x => x.Value<string>())
                .ToList();
            speakers.Sort();
            ViewData["Speakers"] = speakers;
            return View();
        }
    }
}
