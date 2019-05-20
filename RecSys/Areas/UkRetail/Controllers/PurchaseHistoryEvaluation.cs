using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecSys.Data;
using RecSys.Functions;
using RecSys.Models;
using RecSys.ViewModels;

namespace RecSys.Areas.UkRetail.Controllers
{
    [Area("UkRetail")]
    public class PurchaseHistoryEvaluationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public PurchaseHistoryEvaluationController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult EvaluationResults(int recommendationNumber, DateTime startDate, DateTime endDate)
        {
            //Select purchases that collaborative filtering recoemnded item for them
            IEnumerable<UserItemPurchase> purchasesAll = _dbContext.UkRetailOriginalSales
                .Where(a => a.InvoiceDate >= startDate && a.InvoiceDate <= endDate &&
                            a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                            string.Compare(a.StockCode, "a") == -1)
                .Select(a => new UserItemPurchase { User = (Int32)a.CustomerID, Item = a.StockCode });
            List<int> recomendationUsers = _dbContext.PurchaseHistoryRecommendation.Select(a => a.UserId).Distinct().ToList();
            IList<UserItemPurchase> purchases = purchasesAll.Where(a => recomendationUsers.Contains(a.User)).ToList();

            //Select recommendations which the user bought something
            List<int> purchaseUsers = purchases.Select(a => a.User).Distinct().ToList();
            List<PurchaseHistoryRecommendation> purchaseHistoryRecommendation = _dbContext.PurchaseHistoryRecommendation
                .Where(a => purchaseUsers.Contains(a.UserId)).ToList();

            IList<UserItemlist> recommendations5 = purchaseHistoryRecommendation
                .Select(a => new UserItemlist
                {
                    UserId = a.UserId,
                    Items = new List<string>()
                    {
                        a.Item1 , a.Item2, a.Item3 , a.Item4 , a.Item5
                    }
                }).ToList();

            IList<UserItemlist> recommendations10 = purchaseHistoryRecommendation
                .Select(a => new UserItemlist
                {
                    UserId = a.UserId,
                    Items = new List<string>()
                    {
                        a.Item1 , a.Item2, a.Item3 , a.Item4 , a.Item5 , a.Item6 , a.Item7 , a.Item8 , a.Item9 , a.Item10
                    }
                }).ToList();

            IList<UserItemlist> recommendations20 = purchaseHistoryRecommendation
                .Select(a => new UserItemlist
                {
                    UserId = a.UserId,
                    Items = new List<string>()
                    {
                        a.Item1 , a.Item2, a.Item3 , a.Item4 , a.Item5 , a.Item6 , a.Item7 , a.Item8 , a.Item9 , a.Item10,
                        a.Item11 , a.Item12, a.Item13 , a.Item14 , a.Item15 , a.Item16 , a.Item17 , a.Item18 , a.Item19 , a.Item20
                    }
                }).ToList();

            IList<UserItemlist> recommendations50 = purchaseHistoryRecommendation
                .Select(a => new UserItemlist {UserId = a.UserId , Items = new List<string>()
                {
                    a.Item1 , a.Item2, a.Item3 , a.Item4 , a.Item5 , a.Item6 , a.Item7 , a.Item8 , a.Item9 , a.Item10,
                    a.Item11 , a.Item12, a.Item13 , a.Item14 , a.Item15 , a.Item16 , a.Item17 , a.Item18 , a.Item19 , a.Item20,
                    a.Item21 , a.Item22, a.Item23 , a.Item24 , a.Item25 , a.Item26 , a.Item27 , a.Item28 , a.Item29 , a.Item30,
                    a.Item31 , a.Item32, a.Item33 , a.Item34 , a.Item35 , a.Item36 , a.Item37 , a.Item38 , a.Item39 , a.Item40,
                    a.Item41 , a.Item42, a.Item43 , a.Item44 , a.Item45 , a.Item46 , a.Item47 , a.Item48 , a.Item49 , a.Item50
                } }).ToList();


            AccuracyNrec accuracyNrec = new AccuracyNrec();
            RecEvaluation recEvaluation = new RecEvaluation();
            accuracyNrec.Precicion5 = recEvaluation.Precision(recommendations5, purchases);
            accuracyNrec.Recall5 = recEvaluation.Recall(recommendations5, purchases);
            accuracyNrec.F15 = recEvaluation.F1(accuracyNrec.Precicion5, accuracyNrec.Recall5);
            accuracyNrec.RecallwithFrequency5 = recEvaluation.RecallWithFrequency(recommendations5, purchases);
            accuracyNrec.F1withFrequency5 = recEvaluation.F1(accuracyNrec.Precicion5, accuracyNrec.RecallwithFrequency5);

            accuracyNrec.Precicion10 = recEvaluation.Precision(recommendations10, purchases);
            accuracyNrec.Recall10 = recEvaluation.Recall(recommendations10, purchases);
            accuracyNrec.F110 = recEvaluation.F1(accuracyNrec.Precicion10, accuracyNrec.Recall5);
            accuracyNrec.RecallwithFrequency10 = recEvaluation.RecallWithFrequency(recommendations10, purchases);
            accuracyNrec.F1withFrequency10 = recEvaluation.F1(accuracyNrec.Precicion10, accuracyNrec.RecallwithFrequency10);

            accuracyNrec.Precicion20 = recEvaluation.Precision(recommendations20, purchases);
            accuracyNrec.Recall20 = recEvaluation.Recall(recommendations20, purchases);
            accuracyNrec.F120 = recEvaluation.F1(accuracyNrec.Precicion20, accuracyNrec.Recall5);
            accuracyNrec.RecallwithFrequency20 = recEvaluation.RecallWithFrequency(recommendations20, purchases);
            accuracyNrec.F1withFrequency20 = recEvaluation.F1(accuracyNrec.Precicion20, accuracyNrec.RecallwithFrequency20);

            accuracyNrec.Precicion50 = recEvaluation.Precision(recommendations50, purchases);
            accuracyNrec.Recall50 = recEvaluation.Recall(recommendations50, purchases);
            accuracyNrec.F150 = recEvaluation.F1(accuracyNrec.Precicion50, accuracyNrec.Recall5);
            accuracyNrec.RecallwithFrequency50 = recEvaluation.RecallWithFrequency(recommendations50, purchases);
            accuracyNrec.F1withFrequency50 = recEvaluation.F1(accuracyNrec.Precicion50, accuracyNrec.RecallwithFrequency50);

            return View(accuracyNrec);
        }
    }
}