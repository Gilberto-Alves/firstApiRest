using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JornadaNet.Entities
{
    public class ShortnedCustomLink
    {
        public ShortnedCustomLink(string title, string destinationLink)
        {
            var code = title.Split(" ")[0];

            Title = title;
            DestinationLink = destinationLink;
            ShortenedLink = $"localhost:3000/{code}";
            Code = code;
            CreatedAt = DateTime.Now.ToShortDateString();

        }

        public int Id {get; set;}
        public string Title { get; set; }
        public string ShortenedLink { get; set; }
        public string DestinationLink { get; set; }
        public string Code { get; set; }
        public string CreatedAt { get; set; }

        public void Update(string title, string destinationLink){
            Title = title;
            DestinationLink = destinationLink;
        }
    }
}