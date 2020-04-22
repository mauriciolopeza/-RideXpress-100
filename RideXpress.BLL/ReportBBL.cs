using RideXpress.DAL;
using RideXpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideXpress.BLL
{
    /// <summary>
    /// This is the Business Logic Layer (BLL) class for RideXpress.
    /// The Business Logic Layer should only have dependencies on 
    /// the RideXpress.Models project and the RideXpress.DAL project
    /// The BLL is responsible for grabbing any data to/from the DAL
    /// and performing any "business logic" on the data to be presentable
    /// to the web application.
    /// </summary>
    public class ReportBLL
    {
        private ReportDAL data;
        public ReportBLL(string connectionString)
        {
            data = new ReportDAL(connectionString);
        }

        public List<ReportViewModel> GetReportInventory()
        {
            List<ReportViewModel> reports = new List<ReportViewModel>();
            foreach (ReportViewModel model in data.GetReportInventory())
            {
                reports.Add(model);
            }
            return reports;
        }

        public ReportViewModel GetReportById(int id)
        {
            return data.GetReportById(id);
        }

        public int EditReport(ReportViewModel edit)
        {
            return data.EditReport(edit);
        }

        public int AddReport(ReportViewModel add)
        {
            return data.AddReport(add);
        }

        public int DeleteReport(int id)
        {
            return data.DeleteReport(id);
        }
    }
}
