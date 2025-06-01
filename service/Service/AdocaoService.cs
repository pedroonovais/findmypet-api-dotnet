using data.Context;
using library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Service
{
    public class AdocaoService
    {
        private readonly AppDbContext _context;

        public AdocaoService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Adocao> GetAll()
        {
            return _context.Adocao.ToList();
        }

        public Adocao? GetById(Guid id)
        {
            return _context.Adocao.FirstOrDefault(a => a.idAdocao == id);
        }

        public Adocao Create(Adocao adocao)
        {
            if (adocao == null)
                throw new ArgumentNullException(nameof(adocao));

            adocao.idAdocao = Guid.NewGuid();

            _context.Adocao.Add(adocao);
            _context.SaveChanges();
            return adocao;
        }

        public bool Delete(Guid id)
        {
            var adocao = GetById(id);
            if (adocao == null)
                return false;

            _context.Adocao.Remove(adocao);
            _context.SaveChanges();
            return true;
        }

        public Adocao? Update(Guid id, Adocao adocaoAtualizada)
        {
            var existente = _context.Adocao.FirstOrDefault(a => a.idAdocao == id);
            if (existente == null)
                return null;

            existente.idPessoa = adocaoAtualizada.idPessoa;
            existente.idAnimal = adocaoAtualizada.idAnimal;
            existente.dataAdocao = adocaoAtualizada.dataAdocao;
            existente.tipoAdocao = adocaoAtualizada.tipoAdocao;

            _context.SaveChanges();
            return existente;
        }
    }
}
