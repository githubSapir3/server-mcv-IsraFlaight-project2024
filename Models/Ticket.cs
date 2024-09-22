// Models/Ticket.cs

using System;

    public class Ticket
    {
        public int Id { get; set; }
        public required User PassengerID { get; set; } // Assuming Passenger is another class in your project
        public required Flight Flight { get; set; } // Assuming Flight is another class in your project
        public DateTime PurchaseTime { get; set; }
        public required string Source {get; set;}
        public required string Destination {get; set;}
        
        public Ticket() { }
        public Ticket(int id, User passengerID, Flight flight, DateTime purchaseTime,string source, string destination)
        {
            Id = id;
            PassengerID = passengerID;
            Flight = flight;
            PurchaseTime = purchaseTime;
            Source = source;
            Destination = destination;

           
        }
    }

