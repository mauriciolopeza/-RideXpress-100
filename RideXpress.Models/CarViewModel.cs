using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideXpress.Models
{
    //This is a POCO, or Plain Old CLR Object that represents
    //a Car, a POCO should only have properties that are represented
    //the same as the database.
    public class CarViewModel
    {
        public int CarID { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int CityMPG { get; set; }
        public int HighwayMPG { get; set; }
        public bool IsAutomatic { get; set; }
        public double HourlyRate { get; set; }
        public string AutomaticDisplay
        {
            get
            {
                String isAutom = "";

                if (this.IsAutomatic)
                    isAutom = "Automatic";
                else
                    isAutom = "Manual";

                return isAutom;
            }
        }

        internal IEnumerable<object> AsEnumerable()
        {
            throw new NotImplementedException();
        }

        public double DailyRate
        {
            // Daily Rates for RideXpress vehicles are 10 times the amount of Hourly Rates.
            get
            {
                double dailyRate = 0;

                dailyRate = this.HourlyRate * 10;

                return dailyRate;
            }
        }        
    }
}
