using Microsoft.AspNetCore.Mvc;
using PredictionGuru.DataContext;
using PredictionGuru.Helpers;
using PredictionGuru.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PredictionGuru.Controllers
{
    [Route("api/[controller]")]
    public class ContinentsAPIController : Controller
    {
        private readonly PredictionGuruContext _context;

        public ContinentsAPIController(PredictionGuruContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public List<Continent> Continents()
        {
            return _context.Continent.ToList();
        }

        [HttpPost("[action]")]
        public List<Continent> SaveContinent(int id, string name)
        {
            name = name.SafeValue();
            if (name.IsEmpty())
            {
                throw new Exception("Name is invalid.");
            }

            Continent obj = null;
            if(id > 0)
            {
                obj = _context.Continent.SingleOrDefault(c => c.Id == id);
            }
            if(obj == null)
            {
                obj = new Continent();
                _context.Continent.Add(obj);
            }
            obj.Name = name;

            _context.SaveChanges();

            return _context.Continent.ToList();
        }

        [HttpPost("[action]")]
        public List<Continent> DeleteContinent(int id)
        {
            if (id < 1)
            {
                throw new Exception("Id is invalid.");
            }

            var obj = _context.Continent.SingleOrDefault(c => c.Id == id);
            if (obj == null)
            {
                throw new Exception("Id is invalid.");
            }

            _context.Continent.Remove(obj);

            _context.SaveChanges();

            return _context.Continent.ToList();
        }
    }
}