using System.Collections.Generic;

namespace CodeConf.Api.Models
{
    public class Speaker
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        public List<Talk> Talks { get; set; }
    }
}