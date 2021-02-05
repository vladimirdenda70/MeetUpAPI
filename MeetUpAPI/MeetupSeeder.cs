using MeetUpAPI.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUpAPI
{
    public class MeetupSeeder
    {
        private readonly MeetupContext _meetupContext;

        public MeetupSeeder(MeetupContext meetupContext)
        {
            _meetupContext = meetupContext;
        }

        public void Seed()
        {
            if (_meetupContext.Database.CanConnect())
            {
                if (!_meetupContext.Meetups.Any())
                {
                    InsertsampleData();
                }
            }
        }

        private void InsertsampleData()
        {
            var meetups = new List<Meetup>

          {
                new Meetup
                 {

                    Name ="Web Summit",
                    Date= DateTime.Now.AddDays(7),
                    IsPrivate= false,
                    Organizer="MS",
                    Location= new Location
                    {
                        City="Belgrade",
                        Street = "Bulevar Mira 22",
                        PostCode="11070"
                    },

                    Lectures= new List<Lecture>
                    {
                        new Lecture
                        {
                        Author="Bob Klark",
                        Topic="Browsers",
                        Description="Dive into V8"
                        }

                    }

                },

new Meetup
                 {

                    Name ="4Devs",
                    Date= DateTime.Now.AddDays(10),
                    IsPrivate= false,
                    Organizer="KGD",
                    Location= new Location
                    {
                        City="Belgrade",
                        Street = "Bulevar Revolucije 212",
                        PostCode="11000"
                    },

                    Lectures= new List<Lecture>
                    {
                        new Lecture
                        {
                        Author="Rob smith",
                        Topic=".NET",
                        Description="Dive into .NET 5"
                        }

                    }

                }


          };


            _meetupContext.AddRange(meetups);
            _meetupContext.SaveChanges();

        }
    }
}
