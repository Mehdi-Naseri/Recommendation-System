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
    public class SequentialPurchasedEvaluationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SequentialPurchasedEvaluationController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EvaluationResults(int recommendationNumber, DateTime trainStartDate, DateTime trainEndDate, DateTime testStartDate, DateTime testEndDate)
        {
            //Select purchases in test period
            IList<UserItemPurchase> purchasesAllTest = _dbContext.UkRetailOriginalSales
                .Where(a => a.InvoiceDate >= testStartDate && a.InvoiceDate <= testEndDate &&
                            a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                            string.Compare(a.StockCode, "a") == -1)
                .Select(a => new UserItemPurchase { User = (Int32)a.CustomerID, Item = a.StockCode }).ToList();

            //Select purchases in train period
            IList<int> purchasesAllTrain = _dbContext.UkRetailOriginalSales
    .Where(a => a.InvoiceDate >= trainStartDate && a.InvoiceDate <= trainEndDate &&
                a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                string.Compare(a.StockCode, "a") == -1).Select(a => (Int32)a.CustomerID).Distinct().ToList();

            //Select users which the user bought something both in test period and train priod
            List<int> purchaseUsers = purchasesAllTest.Select(a => a.User).Where(a => purchasesAllTrain.Contains(a)).Distinct().ToList();

            IList<UserItemPurchase> purchase = purchasesAllTest.Where(a => purchaseUsers.Contains(a.User)).ToList();

            int recInfoid = _dbContext.RecommendationInfo.First(a => string.Equals(a.RecName, "SpmPurchased10Month")).RecId;
            IList<Recommendation> recommendations = _dbContext.Recommendation
                .Where(a => a.RecommendationInfoId== recInfoid && purchaseUsers.Contains(a.UserId)).ToList();


            IList<UserItemlist> recommendations5 = new List<UserItemlist>();
            foreach (Recommendation recommendation in recommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = recommendation.UserId;
                userItemlist.Items = new List<string>();
                if (recommendation.Item1 != null) userItemlist.Items.Add(recommendation.Item1);
                if (recommendation.Item2 != null) userItemlist.Items.Add(recommendation.Item2);
                if (recommendation.Item3 != null) userItemlist.Items.Add(recommendation.Item3);
                if (recommendation.Item4 != null) userItemlist.Items.Add(recommendation.Item4);
                if (recommendation.Item5 != null) userItemlist.Items.Add(recommendation.Item5);
                recommendations5.Add(userItemlist);
            }

            IList<UserItemlist> recommendations10 = new List<UserItemlist>();
            foreach (Recommendation recommendation in recommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = recommendation.UserId;
                userItemlist.Items = new List<string>();
                if (recommendation.Item1 != null) userItemlist.Items.Add(recommendation.Item1);
                if (recommendation.Item2 != null) userItemlist.Items.Add(recommendation.Item2);
                if (recommendation.Item3 != null) userItemlist.Items.Add(recommendation.Item3);
                if (recommendation.Item4 != null) userItemlist.Items.Add(recommendation.Item4);
                if (recommendation.Item5 != null) userItemlist.Items.Add(recommendation.Item5);
                if (recommendation.Item6 != null) userItemlist.Items.Add(recommendation.Item6);
                if (recommendation.Item7 != null) userItemlist.Items.Add(recommendation.Item7);
                if (recommendation.Item8 != null) userItemlist.Items.Add(recommendation.Item8);
                if (recommendation.Item9 != null) userItemlist.Items.Add(recommendation.Item9);
                if (recommendation.Item10 != null) userItemlist.Items.Add(recommendation.Item10);
                recommendations10.Add(userItemlist);
            }

            IList<UserItemlist> recommendations20 = new List<UserItemlist>();
            foreach (Recommendation recommendation in recommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = recommendation.UserId;
                userItemlist.Items = new List<string>();
                if (recommendation.Item1 != null) userItemlist.Items.Add(recommendation.Item1);
                if (recommendation.Item2 != null) userItemlist.Items.Add(recommendation.Item2);
                if (recommendation.Item3 != null) userItemlist.Items.Add(recommendation.Item3);
                if (recommendation.Item4 != null) userItemlist.Items.Add(recommendation.Item4);
                if (recommendation.Item5 != null) userItemlist.Items.Add(recommendation.Item5);
                if (recommendation.Item6 != null) userItemlist.Items.Add(recommendation.Item6);
                if (recommendation.Item7 != null) userItemlist.Items.Add(recommendation.Item7);
                if (recommendation.Item8 != null) userItemlist.Items.Add(recommendation.Item8);
                if (recommendation.Item9 != null) userItemlist.Items.Add(recommendation.Item9);
                if (recommendation.Item10 != null) userItemlist.Items.Add(recommendation.Item10);
                if (recommendation.Item11 != null) userItemlist.Items.Add(recommendation.Item11);
                if (recommendation.Item12 != null) userItemlist.Items.Add(recommendation.Item12);
                if (recommendation.Item13 != null) userItemlist.Items.Add(recommendation.Item13);
                if (recommendation.Item14 != null) userItemlist.Items.Add(recommendation.Item14);
                if (recommendation.Item15 != null) userItemlist.Items.Add(recommendation.Item15);
                if (recommendation.Item16 != null) userItemlist.Items.Add(recommendation.Item16);
                if (recommendation.Item17 != null) userItemlist.Items.Add(recommendation.Item17);
                if (recommendation.Item18 != null) userItemlist.Items.Add(recommendation.Item18);
                if (recommendation.Item19 != null) userItemlist.Items.Add(recommendation.Item19);
                if (recommendation.Item20 != null) userItemlist.Items.Add(recommendation.Item20);
                recommendations20.Add(userItemlist);
            }

            IList<UserItemlist> recommendations50 = new List<UserItemlist>();
            foreach (Recommendation recommendation in recommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = recommendation.UserId;
                userItemlist.Items = new List<string>();
                if (recommendation.Item1 != null) userItemlist.Items.Add(recommendation.Item1);
                if (recommendation.Item2 != null) userItemlist.Items.Add(recommendation.Item2);
                if (recommendation.Item3 != null) userItemlist.Items.Add(recommendation.Item3);
                if (recommendation.Item4 != null) userItemlist.Items.Add(recommendation.Item4);
                if (recommendation.Item5 != null) userItemlist.Items.Add(recommendation.Item5);
                if (recommendation.Item6 != null) userItemlist.Items.Add(recommendation.Item6);
                if (recommendation.Item7 != null) userItemlist.Items.Add(recommendation.Item7);
                if (recommendation.Item8 != null) userItemlist.Items.Add(recommendation.Item8);
                if (recommendation.Item9 != null) userItemlist.Items.Add(recommendation.Item9);
                if (recommendation.Item10 != null) userItemlist.Items.Add(recommendation.Item10);
                if (recommendation.Item11 != null) userItemlist.Items.Add(recommendation.Item11);
                if (recommendation.Item12 != null) userItemlist.Items.Add(recommendation.Item12);
                if (recommendation.Item13 != null) userItemlist.Items.Add(recommendation.Item13);
                if (recommendation.Item14 != null) userItemlist.Items.Add(recommendation.Item14);
                if (recommendation.Item15 != null) userItemlist.Items.Add(recommendation.Item15);
                if (recommendation.Item16 != null) userItemlist.Items.Add(recommendation.Item16);
                if (recommendation.Item17 != null) userItemlist.Items.Add(recommendation.Item17);
                if (recommendation.Item18 != null) userItemlist.Items.Add(recommendation.Item18);
                if (recommendation.Item19 != null) userItemlist.Items.Add(recommendation.Item19);
                if (recommendation.Item20 != null) userItemlist.Items.Add(recommendation.Item20);
                if (recommendation.Item21 != null) userItemlist.Items.Add(recommendation.Item21);
                if (recommendation.Item22 != null) userItemlist.Items.Add(recommendation.Item22);
                if (recommendation.Item23 != null) userItemlist.Items.Add(recommendation.Item23);
                if (recommendation.Item24 != null) userItemlist.Items.Add(recommendation.Item24);
                if (recommendation.Item25 != null) userItemlist.Items.Add(recommendation.Item25);
                if (recommendation.Item26 != null) userItemlist.Items.Add(recommendation.Item26);
                if (recommendation.Item27 != null) userItemlist.Items.Add(recommendation.Item27);
                if (recommendation.Item28 != null) userItemlist.Items.Add(recommendation.Item28);
                if (recommendation.Item29 != null) userItemlist.Items.Add(recommendation.Item29);
                if (recommendation.Item30 != null) userItemlist.Items.Add(recommendation.Item30);
                if (recommendation.Item31 != null) userItemlist.Items.Add(recommendation.Item31);
                if (recommendation.Item32 != null) userItemlist.Items.Add(recommendation.Item32);
                if (recommendation.Item33 != null) userItemlist.Items.Add(recommendation.Item33);
                if (recommendation.Item34 != null) userItemlist.Items.Add(recommendation.Item34);
                if (recommendation.Item35 != null) userItemlist.Items.Add(recommendation.Item35);
                if (recommendation.Item36 != null) userItemlist.Items.Add(recommendation.Item36);
                if (recommendation.Item37 != null) userItemlist.Items.Add(recommendation.Item37);
                if (recommendation.Item38 != null) userItemlist.Items.Add(recommendation.Item38);
                if (recommendation.Item39 != null) userItemlist.Items.Add(recommendation.Item39);
                if (recommendation.Item40 != null) userItemlist.Items.Add(recommendation.Item40);
                if (recommendation.Item41 != null) userItemlist.Items.Add(recommendation.Item41);
                if (recommendation.Item42 != null) userItemlist.Items.Add(recommendation.Item42);
                if (recommendation.Item43 != null) userItemlist.Items.Add(recommendation.Item43);
                if (recommendation.Item44 != null) userItemlist.Items.Add(recommendation.Item44);
                if (recommendation.Item45 != null) userItemlist.Items.Add(recommendation.Item45);
                if (recommendation.Item46 != null) userItemlist.Items.Add(recommendation.Item46);
                if (recommendation.Item47 != null) userItemlist.Items.Add(recommendation.Item47);
                if (recommendation.Item48 != null) userItemlist.Items.Add(recommendation.Item48);
                if (recommendation.Item49 != null) userItemlist.Items.Add(recommendation.Item49);
                if (recommendation.Item50 != null) userItemlist.Items.Add(recommendation.Item50);
                recommendations50.Add(userItemlist);
            }


            AccuracyNrec accuracyNrec = new AccuracyNrec();
            RecEvaluation recEvaluation = new RecEvaluation();
            accuracyNrec.Precicion5 = recEvaluation.Precision(recommendations5, purchase);
            accuracyNrec.Recall5 = recEvaluation.Recall(recommendations5, purchase);
            accuracyNrec.F15 = recEvaluation.F1(accuracyNrec.Precicion5, accuracyNrec.Recall5);
            accuracyNrec.RecallwithFrequency5 = recEvaluation.RecallWithFrequency(recommendations5, purchase);
            accuracyNrec.F1withFrequency5 = recEvaluation.F1(accuracyNrec.Precicion5, accuracyNrec.RecallwithFrequency5);

            accuracyNrec.Precicion10 = recEvaluation.Precision(recommendations10, purchase);
            accuracyNrec.Recall10 = recEvaluation.Recall(recommendations10, purchase);
            accuracyNrec.F110 = recEvaluation.F1(accuracyNrec.Precicion10, accuracyNrec.Recall10);
            accuracyNrec.RecallwithFrequency10 = recEvaluation.RecallWithFrequency(recommendations10, purchase);
            accuracyNrec.F1withFrequency10 = recEvaluation.F1(accuracyNrec.Precicion10, accuracyNrec.RecallwithFrequency10);

            accuracyNrec.Precicion20 = recEvaluation.Precision(recommendations20, purchase);
            accuracyNrec.Recall20 = recEvaluation.Recall(recommendations20, purchase);
            accuracyNrec.F120 = recEvaluation.F1(accuracyNrec.Precicion20, accuracyNrec.Recall20);
            accuracyNrec.RecallwithFrequency20 = recEvaluation.RecallWithFrequency(recommendations20, purchase);
            accuracyNrec.F1withFrequency20 = recEvaluation.F1(accuracyNrec.Precicion20, accuracyNrec.RecallwithFrequency20);

            accuracyNrec.Precicion50 = recEvaluation.Precision(recommendations50, purchase);
            accuracyNrec.Recall50 = recEvaluation.Recall(recommendations50, purchase);
            accuracyNrec.F150 = recEvaluation.F1(accuracyNrec.Precicion50, accuracyNrec.Recall50);
            accuracyNrec.RecallwithFrequency50 = recEvaluation.RecallWithFrequency(recommendations50, purchase);
            accuracyNrec.F1withFrequency50 = recEvaluation.F1(accuracyNrec.Precicion50, accuracyNrec.RecallwithFrequency50);
            return View(accuracyNrec);
        }
    }
}