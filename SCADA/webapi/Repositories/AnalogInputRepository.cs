﻿using Microsoft.EntityFrameworkCore;
using webapi.model;

namespace webapi.Repositories
{
    public interface IAnalogInputRepository
    {
        List<AnalogInput> GetAll();
        AnalogInput GetById(int id);
        void Add(AnalogInput analogInput);
        void Update(AnalogInput analogInput);
        void Delete(AnalogInput analogInput);
        List<AnalogInput> GetAllScanningAnalogInputs();
    }

    public class AnalogInputRepository : IAnalogInputRepository
    {
        private readonly ScadaDBContext _context;

        public AnalogInputRepository(ScadaDBContext context)
        {
            _context = context;
        }

        public List<AnalogInput> GetAll()
        {
            return _context.AnalogInputs.Include(ai => ai.Values).ToList();
        }

        public AnalogInput GetById(int id)
        {
            return _context.AnalogInputs.Include(ai => ai.Address).FirstOrDefault(ai => ai.Id == id);
        }

        public void Add(AnalogInput analogInput)
        {
            _context.AnalogInputs.Add(analogInput);
            _context.SaveChanges();
        }
        public void Update(AnalogInput analogInput)
        {
            _context.AnalogInputs.Update(analogInput);
            _context.SaveChanges();
        }

        public void Delete(AnalogInput analogInput)
        {
            _context.AnalogInputs.Remove(analogInput);
            _context.SaveChanges();
        }

        public List<AnalogInput> GetAllScanningAnalogInputs()
        {
            return _context.AnalogInputs.Include(ai => ai.Values).Include(ai => ai.Address).Where(ai => ai.IsScanning).ToList();
        }
    }
}
