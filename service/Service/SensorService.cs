using data.Context;
using library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Service
{
    public class SensorService
    {
        private readonly AppDbContext _context;

        public SensorService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sensor> GetAll()
        {
            return _context.Sensor.ToList();
        }

        public Sensor? GetById(Guid id)
        {
            return _context.Sensor.FirstOrDefault(s => s.idSensor == id);
        }

        public Sensor Create(Sensor sensor)
        {
            if (sensor == null)
                throw new ArgumentNullException(nameof(sensor));

            sensor.idSensor = Guid.NewGuid();
            _context.Sensor.Add(sensor);
            _context.SaveChanges();
            return sensor;
        }

        public bool Delete(Guid id)
        {
            var sensor = GetById(id);
            if (sensor == null)
                return false;

            _context.Sensor.Remove(sensor);
            _context.SaveChanges();
            return true;
        }

        public Sensor? Update(Guid id, Sensor sensorAtualizado)
        {
            var existente = _context.Sensor.FirstOrDefault(s => s.idSensor == id);
            if (existente == null)
                return null;

            existente.tipoSensor = sensorAtualizado.tipoSensor;
            existente.latitude = sensorAtualizado.latitude;
            existente.longitude = sensorAtualizado.longitude;
            existente.ativo = sensorAtualizado.ativo;

            _context.SaveChanges();
            return existente;
        }
    }
}
