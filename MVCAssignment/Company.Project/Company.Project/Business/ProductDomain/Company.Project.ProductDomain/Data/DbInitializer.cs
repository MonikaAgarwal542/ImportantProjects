using Company.Project.EventDomain.Appservices.Domain;
using Company.Project.EventDomain.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Project.EventDomain.Data
{
    public class DbInitializer
    {
        public static void Initialize(BookReadingContext bookReadingcontext)
        {
            bookReadingcontext.Database.EnsureCreated();

            // Look for any students.
            if (bookReadingcontext.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new List<User>
            {
                new User{UserName="Monika Garg" , EmailId="monika.garg@nagarro.com" , Password="12345" },
                new User{UserName="Monika Agarwal" , EmailId="myadmin@bookevents.com" , Password="12345"},
               
            };
            users.ForEach(s => bookReadingcontext.Users.Add(s));
            bookReadingcontext.SaveChanges();
            var events = new List<Event>
                {
                new Event{ Title="Atomic Habits",Date=DateTime.Now, Location="Plot 13", Duration=3, StartTime=DateTime.Now, Description=" Tiny Changs ,Remarkable Results",OtherDetails=null,Type=EventType.PRIVATE,InviteByEmail=null,UserId="Monika Garg"  }
               };
            events.ForEach(s => bookReadingcontext.Events.Add(s));
            bookReadingcontext.SaveChanges();
            var roles = new List<Role>
                {
                    new Role{AssignedRole="Admin",UserId="Monika Agarwal"},
                    new Role { AssignedRole ="User", UserId = "Monika Garg" }
                 
                };
            roles.ForEach(s => bookReadingcontext.Roles.Add(s));
            bookReadingcontext.SaveChanges();
        }
    }
}
