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
        public List<Continent> SaveContinent()
        {
            var body = Request.Body.ReadToString();

            var continent = body.FromJson<Continent>();

            if (continent.Name.IsEmpty())
            {
                throw new Exception("Name is invalid.");
            }

            var obj = _context.Continent.SingleOrDefault(c => c.Name.Trim().ToLower() == continent.Name.Trim().ToLower());
            if(obj == null)
            {
                obj = new Continent();
                _context.Continent.Add(obj);
            }
            obj.Name = continent.Name;

            _context.SaveChanges();

            return _context.Continent.ToList();
        }
    }
}