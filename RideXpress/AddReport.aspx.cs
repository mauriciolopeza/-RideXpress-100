using RideXpress.BLL;
using RideXpress.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideXpress_StarterKit
{
    public partial class AddReport : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RideXpressConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarBLL entity = new CarBLL(connectionString);
                List<CarViewModel> CarList = new List<CarViewModel>();
                List<string> CarNames = new List<string>();
                CarList = entity.GetCarInventory();
                foreach (CarViewModel Car in CarList)
                {
                    CarNames.Add(Car.Name.ToString());
                }
                RideDropDownList.DataSource = CarNames;
                RideDropDownList.DataBind();
            }
        }
        protected void ReportAddButton_Click(object sender, EventArgs e)
        {
            string Ride = RideDropDownList.Text;           

            if (Page.IsValid)
            {                
                ReportBLL bll = new ReportBLL(connectionString);
                ReportViewModel report = new ReportViewModel();
                report.CarID = Convert.ToInt32(GetCarId(Ride));                                
                report.DateOfIncident = DateOfIncident.Text;               
                report.ReportName = ReportName.Text;
                report.ReportDescription = ReportDescription.Text;
                report.DateOfReport = DateTime.Now.ToString();               
                bll.AddReport(report);
                Response.Redirect("~/Reports.aspx");
            }
        }

        public int GetCarId(string carName)
        {
            CarBLL entity = new CarBLL(connectionString);
            return entity.GetIdByCarName(carName).CarID;
        }
    }
}


