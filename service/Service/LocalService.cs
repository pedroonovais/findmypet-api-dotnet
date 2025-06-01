using data.Context;
using library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Service
{
    public class LocalService
    {
        private readonly AppDbContext _context;

        public LocalService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Local> GetAll()
        {
            return _context.Local.ToList();
        }

        public Local? GetById(Guid id)
        {
            return _context.Local.FirstOrDefault(l => l.idLocal == id);
        }

        public Local Create(Local local)
        {
            if (local == null)
                throw new ArgumentNullException(nameof(local));

            local.idLocal = Guid.NewGuid();
            _context.Local.Add(local);
            _context.SaveChanges();
            return local;
        }

        public bool Delete(Guid id)
        {
            var local = GetById(id);
            if (local == null)
                return false;

            _context.Local.Remove(local);
            _context.SaveChanges();
            return true;
        }

        public Local? Update(Guid id, Local localAtualizado)
        {
            var existente = _context.Local.FirstOrDefault(l => l.idLocal == id);
            if (existente == null)
                return null;

            existente.cidade = localAtualizado.cidade;
            existente.estado = localAtualizado.estado;
            existente.tipoDesastre = localAtualizado.tipoDesastre;
            existente.dataOcorrencia = localAtualizado.dataOcorrencia;

            _context.SaveChanges();
            return existente;
        }
    }
}
