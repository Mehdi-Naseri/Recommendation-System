using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using RecSys.Data;
using RecSys.Models;

namespace RecSys.Areas.UkRetail.Controllers
{
    public class SimilarityController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SimilarityController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindSimilarity()
        {
            var inputdataset = _dbContext.UkRetailOriginalSales;
            foreach(var product1 in inputdataset)
            {
                foreach (var product2 in inputdataset)
                {
                   float Similarity = CalculateSimilarity(product1.Description, product2.Description);
                }
            }
            return View();
        }

        private float CalculateSimilarity(string description1, string description2)
        {
            throw new NotImplementedException();
        }
    }
}