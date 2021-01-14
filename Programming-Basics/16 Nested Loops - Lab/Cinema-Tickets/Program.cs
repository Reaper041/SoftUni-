using System;

namespace Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int studentTicketcount = 0;
            int standardTicketcount = 0;
            int kidsTicketcount = 0;
            int totalTicketsCount = 0;

            while (filmName != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                string ticketKind = Console.ReadLine();
                int totalTicketCountPerFilm = 0;
                while (ticketKind != "End")
                {
                    totalTicketCountPerFilm++;
                    totalTicketsCount++;
                    if (ticketKind == "student")
                    {
                        studentTicketcount++;
                    }
                    else if (ticketKind == "standard")
                    {
                        standardTicketcount++;
                    }
                    else if (ticketKind == "kid")
                    {
                        kidsTicketcount++;
                    }
                    if (totalTicketCountPerFilm == freeSeats)
                    {
                        break;
                    }
                    ticketKind = Console.ReadLine();
                }
                Console.WriteLine($"{filmName} - {totalTicketCountPerFilm * 1.0 / freeSeats * 100:f2}% full.");
                
                
                filmName = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalTicketsCount}");
            Console.WriteLine($"{studentTicketcount * 1.0 / totalTicketsCount * 100:f2}% student tickets.");
            Console.WriteLine($"{standardTicketcount * 100.0 / totalTicketsCount:f2}% standard tickets.");
            Console.WriteLine($"{kidsTicketcount * 100.0 / totalTicketsCount:f2}% kids tickets.");
        }
    }
}
