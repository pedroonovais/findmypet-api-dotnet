using data.Context;
using library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Service
{
    public class AnimalService
    {
        private readonly AppDbContext _context;

        public AnimalService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetAll()
        {
            return _context.Animal.ToList();
        }

        public Animal? GetById(Guid id)
        {
            return _context.Animal.FirstOrDefault(a => a.idAnimal == id);
        }

        public Animal Create(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));

            animal.idAnimal = Guid.NewGuid();
            _context.Animal.Add(animal);
            _context.SaveChanges();
            return animal;
        }

        public bool Delete(Guid id)
        {
            var animal = GetById(id);
            if (animal == null)
                return false;

            _context.Animal.Remove(animal);
            _context.SaveChanges();
            return true;
        }

        public Animal? Update(Guid id, Animal animalAtualizado)
        {
            var existente = _context.Animal.FirstOrDefault(a => a.idAnimal == id);
            if (existente == null)
                return null;

            existente.nome = animalAtualizado.nome;
            existente.especie = animalAtualizado.especie;
            existente.porte = animalAtualizado.porte;
            existente.idadeEstimada = animalAtualizado.idadeEstimada;
            existente.status = animalAtualizado.status;

            _context.SaveChanges();
            return existente;
        }
    }
}
