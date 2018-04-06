using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PredictionGuru.DataContext;
using PredictionGuru.Models;

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
    }
}