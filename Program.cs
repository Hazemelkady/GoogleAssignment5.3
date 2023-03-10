using System;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using InfraStructer;
using InfraStructer.Data;

namespace GoogleAssignment5._3
{
   
    class Program
    {
        
        static void Main(string[] args)
        {

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
           
             
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Google Calender API Connect:");
            Console.WriteLine("Select Task:");
            Console.WriteLine("1) Retrieve List Of Upcomming Events");
            Console.WriteLine("2) Create a New Event");
            Console.WriteLine("3) Delete Exist Event");
            Console.WriteLine("4) Send a Notification To User Email Address");
            Console.WriteLine("0) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    RetrieveUpcommingEvents();
                    return true;
                case "2":
                    CreateEvent();
                    return true;
                case "3":
                    RemoveEvent();
                    return true;
                case "4":
                    SendMail("measage");
                    return true;
                
                default:
                    return true;
            }
        }
        private static string RetrieveUpcommingEvents()
        {
              string[] scopsfram = { CalendarService.Scope.Calendar };
          string credPath = "web.json";
        GCalendarService _s = new GCalendarService(credPath, "admin", scopsfram);
           _s.GetCalendarService();
           
            
            return Console.ReadLine();
        }

        private static string CreateEvent()
        {
               string[] scopsfram = { CalendarService.Scope.Calendar };
          string credPath = "web.json";
            string evid = "eventid" + 7;
            Event _ev = new Event()
            {
                Id = evid,
                Summary = "A Tech I/O 2023",
                Location = "Katamia Maasi",
                Description = "An Assignment job",

                ConferenceData = new ConferenceData
                {
                    Notes = ""
                },

                Start = new EventDateTime()
                {
                    DateTime = new DateTime(2023, 03, 10, 15, 30, 0),
                    TimeZone = "UTC"
                }
               ,
                End = new EventDateTime()
                {
                    DateTime = new DateTime(2023, 03, 10, 16, 30, 0),
                    TimeZone = "UTC"

                }
               ,

                Attendees = new List<EventAttendee>
                    {
                        new EventAttendee() { Email = "hazem_elkady@hotmail.com"},

                    }
            };
            CreateNewEvent _crv = new CreateNewEvent(credPath, "admin", scopsfram, evid);
            _crv.insertEvent(_ev);

            return Console.ReadLine();

        }

        private static string RemoveEvent()
        {
            string evid = "eventid" + 6;
            string[] scopsfram = { CalendarService.Scope.Calendar };
            string credPath = "web.json";
            DeleteGEvent _Delv = new DeleteGEvent(credPath, "admin", scopsfram);
            _Delv.DelEvent(evid);

            return Console.ReadLine();
        }

        private static void SendMail(string message)
        {
            Console.WriteLine($"\r\nYour modified string is: {message}");
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }
    }
}
 