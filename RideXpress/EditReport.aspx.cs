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
    public partial class EditReport : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RideXpressConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                ReportBLL bll = new ReportBLL(connectionString);
                ReportViewModel report = bll.GetReportById(Convert.ToInt32(Request.QueryString["ReportID"]));
                RideDropDownList.SelectedValue = GetCarName(report.CarID);                
                DateOfIncident.Text = Convert.ToDateTime(report.DateOfIncident).ToString("yyyy-MM-dd");                
                ReportName.Text = report.ReportName;
                ReportDescription.Text = report.ReportDescription;
            }

        }
        protected void ReportEditButton_Click(object sender, EventArgs e)
        {
            string Ride = RideDropDownList.Text;

            if (Page.IsValid)
            {
                ReportBLL bll = new ReportBLL(connectionString);
                ReportViewModel report = new ReportViewModel();
                report.ReportID = Convert.ToInt32(Request.QueryString["ReportID"]);
                report.CarID = Convert.ToInt32(GetCarId(Ride));
                report.DateOfIncident = DateOfIncident.Text;
                report.ReportName = ReportName.Text;
                report.ReportDescription = ReportDescription.Text;
                report.DateOfReport = DateTime.Now.ToString();
                bll.EditReport(report);
                Response.Redirect("~/Reports.aspx");
            }
        }
        public int GetCarId(string carName)
        {
            CarBLL entity = new CarBLL(connectionString);
            return entity.GetIdByCarName(carName).CarID;
        }
        public string GetCarName(int carID)
        {
            CarBLL entity = new CarBLL(connectionString);
            return entity.GetCarInventory().Where(x => x.CarID == carID).Select(x => x.Name).FirstOrDefault();
        }
    }
}