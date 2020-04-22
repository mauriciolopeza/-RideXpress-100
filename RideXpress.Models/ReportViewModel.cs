using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace RideXpress.Models
{
    //This is a POCO, or Plain Old CLR Object that represents
    //a Report, a POCO should only have properties that are represented
    //the same as the database.
    public class ReportViewModel
    {
        public int ReportID { get; set; }
        public int CarID { get; set; }        
        public string DateOfIncident { get; set; }
        public string ReportName { get; set; }
        public string ReportDescription { get; set; }
        public string DateOfReport { get; set; }        
    }
}
