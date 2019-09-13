using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecSys.Data;
using RecSys.Functions;
using RecSys.Models;
using RecSys.ViewModels;

namespace RecSys.Areas.UkTraining.Controllers
{
    [Area("UkTraining")]
    public class CollaborativeNotPurchasedAdjustedCosineEvaluationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CollaborativeNotPurchasedAdjustedCosineEvaluationController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult EvaluationResults(int recommendationNumber, DateTime trainStartDate, DateTime trainEndDate, DateTime testStartDate, DateTime testEndDate)
        {
            string recType = "CfNotPurchased10MonthAdjusted";
            int recInfoid = _dbContext.RecommendationInfo.First(a => string.Equals(a.RecName, recType)).RecId;

            IQueryable<UkRetailOriginalSales> ukRetailOriginalSales = _dbContext.UkRetailOriginalSales;
            IQueryable<Recommendation> recommendations = _dbContext.Recommendation.
                Where(a => a.RecommendationInfoId == recInfoid);

            RecEvaluation recEvaluation = new RecEvaluation();
            AccuracyNrec accuracyNrec = recEvaluation.RecEvaluate(ukRetailOriginalSales, recommendations, recType, trainStartDate, trainEndDate, testStartDate, testEndDate);

            return View(accuracyNrec);
        }
    }
}