// Models/Ticket.cs

using System;

    public class Ticket
    {
        public int Id { get; set; }
        public required Passenger Passenger { get; set; } // Assuming Passenger is another class in your project
        public required Flight Flight { get; set; } // Assuming Flight is another class in your project
        public DateTime PurchaseTime { get; set; }
        public required string PdfUrl { get; set; }
        public Ticket() { }
        public Ticket(int id, Passenger passenger, Flight flight, DateTime purchaseTime, string pdfUrl)
        {
            Id = id;
            Passenger = passenger;
            Flight = flight;
            PurchaseTime = purchaseTime;
            PdfUrl = pdfUrl;
        }
    }

