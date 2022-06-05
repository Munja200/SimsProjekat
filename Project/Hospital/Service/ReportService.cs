using System.Collections.Generic;
using Hospital.Model;
using Hospital.Repository;
using Model;

namespace Hospital.Service
{
    public class ReportService
    {
        public Repository.ReportRepository reportRepository;

        public ReportService(ReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public List<Report> GetAll()
        {
            return reportRepository.GetAll();
        }

        public bool CreateReport(bool written, string description, int id)
        {
            return reportRepository.CreateReport(written, description, id);
        }

        public bool DeleteReport(int id)
        {
            return reportRepository.DeleteReport(id);
        }

        public Report GetReportById(int id)
        {
            return reportRepository.GetReportById(id);
        }

        public bool EditReport(bool written, string description, int id)
        {
            return reportRepository.EditReport(written, description, id);
        }

    }
}
