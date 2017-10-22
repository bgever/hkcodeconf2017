using System.ComponentModel.DataAnnotations;

namespace CodeConf.Api.Models
{
    /// <summary>
    /// Conference talk done by a speaker.
    /// </summary>
    public class Talk
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public Speaker Speaker { get; set; }
    }
}