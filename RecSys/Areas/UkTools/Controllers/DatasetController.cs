using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using RecSys.Data;
using RecSys.Models;


namespace RecSys.Areas.UkTools.Controllers
{
    [Area("UkTools")]
    public class DatasetController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DatasetController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Read()
        {
            IEnumerable<UkRetailOriginalSales> data = _dbContext.UkRetailOriginalSales.ToList();
            //IEnumerable<ProjectViewModel> a = _projectService.GetAll().MapModelToViewModel();
            return Json(data);
        }
    }
}