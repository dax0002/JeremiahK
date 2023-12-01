using FinalProject.Controllers;
using FinalProject.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public enum PaymentMethod
    {
        CashorCard,
        PopcornPoints
    }
    public class TransactionDetail
    {
        public int TransactionDetailID { get; set; }

        public int TransactionNumber { get; set; }

        [Display(Name = "Ticket Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Seat { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public decimal TicketPrice
        {
            get { return Schedule.Price.Cost; }
        }
        public Int32 PointChange
        {
            get
            {
                // Assuming there is a valid relationship between TransactionDetails, Schedule, and Price
                // Calculate popcorn points based on the associated price
                if (Schedule != null && Schedule.Price != null)
                {
                    decimal price = Schedule.Price.Cost; // Accessing the Price property from the related Schedule
                                                           // Assuming each dollar spent equals one popcorn point
                    int popcornPoints = (int)price;

                    return popcornPoints;
                }

                return 0; // Default value if the relationship is not set or data is missing
            }
        }


        public Transaction Transaction { get; set; }   
        public Schedule Schedule { get; set; } 

    }
}
