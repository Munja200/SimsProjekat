using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Model;

namespace Hospital.Repository
{
    public class ReportRepository
    {

        public List<Report> reports;

        public ReportRepository()
        {
            reportFileHandler = new FileHandler.ReportFileHandler();
            reports = new List<Report>();
        }

        public bool CreateReport(bool written, string description, int id)
        {
            reports.Add(new Report(written, description, GenerateId()));
            reportFileHandler.Write(reports);
            return true;
        }

        public int GenerateId()
        {
            int id = 0;

            foreach (Report report in reports)
            {
                if (report.Id > id)
                {
                    id = report.Id;
                }
            }

            return id + 1;
        }

        public bool DeleteReport(int id)
        {
            foreach (Report report in reports)
            {
                if (report.Id.Equals(id))
                {
                    reports.Remove(report);
                    reportFileHandler.Write(reports);
                    return true;
                }
            }
            return false;
        }

        public bool EditReport(bool written, string description, int id)
        {

            foreach (Report report in reports)
            {
                if (report.Id.Equals(id))
                {
                    report.Written = written;
                    report.Description = description;
                    report.Id = id;
              

                    reportFileHandler.Write(reports);

                    return true;
                }
            }

            return false;
        }

        public List<Report> GetAll()
        {

            if (reportFileHandler.Read() == null)
                return reports;

            reports = reportFileHandler.Read();

            return reports;
        }

        public Report GetReportById(int id)
        {
            foreach (Report report in reports)
            {
                if (report.Id.Equals(id))
                    return report;
            }
            return null;
        }

        public FileHandler.ReportFileHandler reportFileHandler;

    }

}
