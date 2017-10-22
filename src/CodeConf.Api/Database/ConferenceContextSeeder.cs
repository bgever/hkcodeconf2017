using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeConf.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CodeConf.Api.Database
{
    public static class ConferenceContextSeeder
    {
        /// <summary>
        /// If no database exists, creates the database and its schema.
        /// </summary>
        /// <param name="builder">The builder to retrieve the database context from.</param>
        /// <returns>The builder for chaining.</returns>
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder builder)
        {
            using (var context = builder.ApplicationServices.GetService<ConferenceContext>())
            {
                context.Database.EnsureCreated();

                if (!context.Speakers.Any())
                {
                    context.Speakers.AddRange(_speakers);
                    context.SaveChanges();
                }

                if (!context.Talks.Any())
                {
                    context.Talks.AddRange(_talks);
                    context.SaveChanges();
                }
            }
            return builder;
        }

        static IEnumerable<Speaker> _speakers = new List<Speaker>
        {
            new Speaker {
                FullName = "Davide Benvegnù",
                ImageUrl = "https://pbs.twimg.com/profile_images/898042323581390848/R9LliEMJ_400x400.jpg"
            },
            new Speaker {
                FullName = "Jamie Wilde & Taylor Host",
                ImageUrl = "https://s.gravatar.com/avatar/f5b4a103303de5fe4592735ff6106808?s=300"
            },
            new Speaker {
                FullName = "Denis Tsoi",
                ImageUrl = "https://instagram.fhkg3-1.fna.fbcdn.net/t51.2885-19/s320x320/17076676_338016916593011_2320432038160629760_a.jpg"
            },
            new Speaker {
                FullName = "Tomas Tauber",
                ImageUrl = "Looking at Bitcoin and Ethereum from the Programming Language Perspective"
            },
            new Speaker {
                FullName = "Eddie Lau",
                ImageUrl = "Tech Team Culture - Panel Discussion"
            },
            new Speaker {
                FullName = "Thomas Weiss",
                ImageUrl = "CQRS applied: implementation, challenges and benefits"
            },
            new Speaker {
                FullName = "William Taysom",
                ImageUrl = "https://pbs.twimg.com/profile_images/216689361/will-who-cropped_400x400.png"
            },
            new Speaker {
                FullName = "Bart Verkoeijen",
                ImageUrl = "http://codeconf.hk/img/bart.jpg"
            },
            new Speaker {
                FullName = "William Wong",
                ImageUrl = "http://codeconf.hk/img/william_wong.jpg"
            },
            new Speaker {
                FullName = "Kirill Pavlov",
                ImageUrl = "https://www.gravatar.com/avatar/4ad1cf8cf3515355e570a73a1cfca54e?s=200"
            },
            new Speaker {
                FullName = "Richard Cohen",
                ImageUrl = "http://hongkong.codeconf.io/images/2016/speakers/richard-cohen.jpg"
            },
            new Speaker {
                FullName = "Pedro Pimentel",
                ImageUrl = "http://codeconf.hk/img/pedro.jpg"
            }
        };

        static IEnumerable<Talk> _talks = new List<Talk>
        {
            new Talk {
                Speaker = _speakers.First(s => s.FullName == "Davide Benvegnù"),
                Title = "Go Serverless - Design Patterns and Best Practices"
            }
        };
    }
}