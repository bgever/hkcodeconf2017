using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeConf.Api.Database;
using Microsoft.AspNetCore.Mvc;

namespace CodeConf.Api.Controllers
{
    [Route("api/[controller]")]
    public class SpeakersController : Controller
    {
        public SpeakersController(ConferenceContext db)
        {
            Db = db;
        }

        private ConferenceContext Db;

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Db.Speakers.Select(s => s.FullName);
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return (await Db.Speakers.FindAsync(id))?.FullName;
        }
    }
}
