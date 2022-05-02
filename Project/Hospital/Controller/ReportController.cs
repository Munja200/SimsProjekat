using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Service;
using Model;

namespace Hospital.Controller
{
    public class ReportController
    {
        private readonly ReportService _service;
        public ReportController(ReportService reportService)
        {
            _service = reportService;
        }

        public List<Report> GetAll()
        {
            return _service.GetAll();
        }

        public bool CreateReport(bool written, string description, int id)
        {
            return _service.CreateReport(written, description, id);
        }

        public bool DeleteReport(int id)
        {
            return _service.DeleteReport(id);
        }

        public Report GetReportById(int id)
        {
            return _service.GetReportById(id);
        }

        public bool EditReport(bool written, string description, int id)
        {
            return _service.EditReport(written, description, id);
        }

        
    }

}
