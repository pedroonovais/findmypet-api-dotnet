using data.Context;
using library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Service
{
    public class PessoaService
    {
        private readonly AppDbContext _context;

        public PessoaService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _context.Pessoa.ToList();
        }

        public Pessoa? GetById(Guid id)
        {
            return _context.Pessoa.FirstOrDefault(p => p.idPessoa == id);
        }

        public Pessoa Create(Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentNullException(nameof(pessoa));

            pessoa.idPessoa = Guid.NewGuid();
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
            return pessoa;
        }

        public bool Delete(Guid id)
        {
            var pessoa = GetById(id);
            if (pessoa == null)
                return false;

            _context.Pessoa.Remove(pessoa);
            _context.SaveChanges();
            return true;
        }

        public Pessoa? Update(Guid id, Pessoa pessoaAtualizada)
        {
            var existente = _context.Pessoa.FirstOrDefault(p => p.idPessoa == id);
            if (existente == null)
                return null;

            existente.nome = pessoaAtualizada.nome;
            existente.telefone = pessoaAtualizada.telefone;
            existente.tipoPessoa = pessoaAtualizada.tipoPessoa;
            existente.cpf = pessoaAtualizada.cpf;
            existente.email = pessoaAtualizada.email;
            existente.senha = pessoaAtualizada.senha;

            _context.SaveChanges();
            return existente;
        }
    }
}
