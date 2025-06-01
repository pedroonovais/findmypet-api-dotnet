using data.Context;
using library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Service
{
    public class ReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetAll()
        {
            return _context.Report.ToList();
        }

        public Report? GetById(Guid id)
        {
            return _context.Report.FirstOrDefault(r => r.idReport == id);
        }

        public Report Create(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));

            // Gera um novo Guid para idReport
            report.idReport = Guid.NewGuid();

            // Validação mínima das FKs (todas são Guid)
            if (report.idPessoa == Guid.Empty ||
                report.idAnimal == Guid.Empty ||
                report.idLocal == Guid.Empty ||
                report.idSensor == Guid.Empty)
            {
                throw new ArgumentException("Uma ou mais chaves estrangeiras estão inválidas.");
            }

            _context.Report.Add(report);
            _context.SaveChanges();
            return report;
        }

        public bool Delete(Guid id)
        {
            var report = GetById(id);
            if (report == null)
                return false;

            _context.Report.Remove(report);
            _context.SaveChanges();
            return true;
        }

        public Report? Update(Guid id, Report reportAtualizado)
        {
            var existente = _context.Report.FirstOrDefault(r => r.idReport == id);
            if (existente == null)
                return null;

            // Validação mínima das FKs (todas são Guid)
            if (reportAtualizado.idPessoa == Guid.Empty ||
                reportAtualizado.idAnimal == Guid.Empty ||
                reportAtualizado.idLocal == Guid.Empty ||
                reportAtualizado.idSensor == Guid.Empty)
            {
                throw new ArgumentException("Uma ou mais chaves estrangeiras estão inválidas.");
            }

            existente.idPessoa = reportAtualizado.idPessoa;
            existente.idAnimal = reportAtualizado.idAnimal;
            existente.idLocal = reportAtualizado.idLocal;
            existente.idSensor = reportAtualizado.idSensor;
            existente.dataReport = reportAtualizado.dataReport;
            existente.descricaoLocal = reportAtualizado.descricaoLocal;
            existente.statusReport = reportAtualizado.statusReport;

            _context.SaveChanges();
            return existente;
        }
    }
}
