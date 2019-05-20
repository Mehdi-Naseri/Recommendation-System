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
    public class CollaborativeEvaluationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CollaborativeEvaluationController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult EvaluationResults(int recommendationNumber, DateTime trainStartDate, DateTime trainEndDate, DateTime testStartDate, DateTime testEndDate)
        {
            //Select purchases that collaborative filtering recoemnded item for them
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

            
            IList<CollaborativeRecommendation> collaborativeRecommendations = _dbContext.CollaborativeRecommendation
                .Where(a => purchaseUsers.Contains(a.UserId)).ToList();
            IList<UserItemlist> recommendations5 = new List<UserItemlist>();
            foreach (CollaborativeRecommendation collaborativeRecommendation in collaborativeRecommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = collaborativeRecommendation.UserId;
                userItemlist.Items = new List<string>();
                if (collaborativeRecommendation.Item1 != null) userItemlist.Items.Add(collaborativeRecommendation.Item1);
                if (collaborativeRecommendation.Item2 != null) userItemlist.Items.Add(collaborativeRecommendation.Item2);
                if (collaborativeRecommendation.Item3 != null) userItemlist.Items.Add(collaborativeRecommendation.Item3);
                if (collaborativeRecommendation.Item4 != null) userItemlist.Items.Add(collaborativeRecommendation.Item4);
                if (collaborativeRecommendation.Item5 != null) userItemlist.Items.Add(collaborativeRecommendation.Item5);
                recommendations5.Add(userItemlist);
            }

            IList<UserItemlist> recommendations10 = new List<UserItemlist>();
            foreach (CollaborativeRecommendation collaborativeRecommendation in collaborativeRecommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = collaborativeRecommendation.UserId;
                userItemlist.Items = new List<string>();
                if (collaborativeRecommendation.Item1 != null) userItemlist.Items.Add(collaborativeRecommendation.Item1);
                if (collaborativeRecommendation.Item2 != null) userItemlist.Items.Add(collaborativeRecommendation.Item2);
                if (collaborativeRecommendation.Item3 != null) userItemlist.Items.Add(collaborativeRecommendation.Item3);
                if (collaborativeRecommendation.Item4 != null) userItemlist.Items.Add(collaborativeRecommendation.Item4);
                if (collaborativeRecommendation.Item5 != null) userItemlist.Items.Add(collaborativeRecommendation.Item5);
                if (collaborativeRecommendation.Item6 != null) userItemlist.Items.Add(collaborativeRecommendation.Item6);
                if (collaborativeRecommendation.Item7 != null) userItemlist.Items.Add(collaborativeRecommendation.Item7);
                if (collaborativeRecommendation.Item8 != null) userItemlist.Items.Add(collaborativeRecommendation.Item8);
                if (collaborativeRecommendation.Item9 != null) userItemlist.Items.Add(collaborativeRecommendation.Item9);
                if (collaborativeRecommendation.Item10 != null) userItemlist.Items.Add(collaborativeRecommendation.Item10);
                recommendations10.Add(userItemlist);
            }

            IList<UserItemlist> recommendations20 = new List<UserItemlist>();
            foreach (CollaborativeRecommendation collaborativeRecommendation in collaborativeRecommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = collaborativeRecommendation.UserId;
                userItemlist.Items = new List<string>();
                if (collaborativeRecommendation.Item1 != null) userItemlist.Items.Add(collaborativeRecommendation.Item1);
                if (collaborativeRecommendation.Item2 != null) userItemlist.Items.Add(collaborativeRecommendation.Item2);
                if (collaborativeRecommendation.Item3 != null) userItemlist.Items.Add(collaborativeRecommendation.Item3);
                if (collaborativeRecommendation.Item4 != null) userItemlist.Items.Add(collaborativeRecommendation.Item4);
                if (collaborativeRecommendation.Item5 != null) userItemlist.Items.Add(collaborativeRecommendation.Item5);
                if (collaborativeRecommendation.Item6 != null) userItemlist.Items.Add(collaborativeRecommendation.Item6);
                if (collaborativeRecommendation.Item7 != null) userItemlist.Items.Add(collaborativeRecommendation.Item7);
                if (collaborativeRecommendation.Item8 != null) userItemlist.Items.Add(collaborativeRecommendation.Item8);
                if (collaborativeRecommendation.Item9 != null) userItemlist.Items.Add(collaborativeRecommendation.Item9);
                if (collaborativeRecommendation.Item10 != null) userItemlist.Items.Add(collaborativeRecommendation.Item10);
                if (collaborativeRecommendation.Item11 != null) userItemlist.Items.Add(collaborativeRecommendation.Item11);
                if (collaborativeRecommendation.Item12 != null) userItemlist.Items.Add(collaborativeRecommendation.Item12);
                if (collaborativeRecommendation.Item13 != null) userItemlist.Items.Add(collaborativeRecommendation.Item13);
                if (collaborativeRecommendation.Item14 != null) userItemlist.Items.Add(collaborativeRecommendation.Item14);
                if (collaborativeRecommendation.Item15 != null) userItemlist.Items.Add(collaborativeRecommendation.Item15);
                if (collaborativeRecommendation.Item16 != null) userItemlist.Items.Add(collaborativeRecommendation.Item16);
                if (collaborativeRecommendation.Item17 != null) userItemlist.Items.Add(collaborativeRecommendation.Item17);
                if (collaborativeRecommendation.Item18 != null) userItemlist.Items.Add(collaborativeRecommendation.Item18);
                if (collaborativeRecommendation.Item19 != null) userItemlist.Items.Add(collaborativeRecommendation.Item19);
                if (collaborativeRecommendation.Item20 != null) userItemlist.Items.Add(collaborativeRecommendation.Item20);
                recommendations20.Add(userItemlist);
            }

            IList<UserItemlist> recommendations50 = new List<UserItemlist>();
            foreach (CollaborativeRecommendation collaborativeRecommendation in collaborativeRecommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = collaborativeRecommendation.UserId;
                userItemlist.Items = new List<string>();
                if (collaborativeRecommendation.Item1 != null) userItemlist.Items.Add(collaborativeRecommendation.Item1);
                if (collaborativeRecommendation.Item2 != null) userItemlist.Items.Add(collaborativeRecommendation.Item2);
                if (collaborativeRecommendation.Item3 != null) userItemlist.Items.Add(collaborativeRecommendation.Item3);
                if (collaborativeRecommendation.Item4 != null) userItemlist.Items.Add(collaborativeRecommendation.Item4);
                if (collaborativeRecommendation.Item5 != null) userItemlist.Items.Add(collaborativeRecommendation.Item5);
                if (collaborativeRecommendation.Item6 != null) userItemlist.Items.Add(collaborativeRecommendation.Item6);
                if (collaborativeRecommendation.Item7 != null) userItemlist.Items.Add(collaborativeRecommendation.Item7);
                if (collaborativeRecommendation.Item8 != null) userItemlist.Items.Add(collaborativeRecommendation.Item8);
                if (collaborativeRecommendation.Item9 != null) userItemlist.Items.Add(collaborativeRecommendation.Item9);
                if (collaborativeRecommendation.Item10 != null) userItemlist.Items.Add(collaborativeRecommendation.Item10);
                if (collaborativeRecommendation.Item11 != null) userItemlist.Items.Add(collaborativeRecommendation.Item11);
                if (collaborativeRecommendation.Item12 != null) userItemlist.Items.Add(collaborativeRecommendation.Item12);
                if (collaborativeRecommendation.Item13 != null) userItemlist.Items.Add(collaborativeRecommendation.Item13);
                if (collaborativeRecommendation.Item14 != null) userItemlist.Items.Add(collaborativeRecommendation.Item14);
                if (collaborativeRecommendation.Item15 != null) userItemlist.Items.Add(collaborativeRecommendation.Item15);
                if (collaborativeRecommendation.Item16 != null) userItemlist.Items.Add(collaborativeRecommendation.Item16);
                if (collaborativeRecommendation.Item17 != null) userItemlist.Items.Add(collaborativeRecommendation.Item17);
                if (collaborativeRecommendation.Item18 != null) userItemlist.Items.Add(collaborativeRecommendation.Item18);
                if (collaborativeRecommendation.Item19 != null) userItemlist.Items.Add(collaborativeRecommendation.Item19);
                if (collaborativeRecommendation.Item20 != null) userItemlist.Items.Add(collaborativeRecommendation.Item20);
                if (collaborativeRecommendation.Item21 != null) userItemlist.Items.Add(collaborativeRecommendation.Item21);
                if (collaborativeRecommendation.Item22 != null) userItemlist.Items.Add(collaborativeRecommendation.Item22);
                if (collaborativeRecommendation.Item23 != null) userItemlist.Items.Add(collaborativeRecommendation.Item23);
                if (collaborativeRecommendation.Item24 != null) userItemlist.Items.Add(collaborativeRecommendation.Item24);
                if (collaborativeRecommendation.Item25 != null) userItemlist.Items.Add(collaborativeRecommendation.Item25);
                if (collaborativeRecommendation.Item26 != null) userItemlist.Items.Add(collaborativeRecommendation.Item26);
                if (collaborativeRecommendation.Item27 != null) userItemlist.Items.Add(collaborativeRecommendation.Item27);
                if (collaborativeRecommendation.Item28 != null) userItemlist.Items.Add(collaborativeRecommendation.Item28);
                if (collaborativeRecommendation.Item29 != null) userItemlist.Items.Add(collaborativeRecommendation.Item29);
                if (collaborativeRecommendation.Item30 != null) userItemlist.Items.Add(collaborativeRecommendation.Item30);
                if (collaborativeRecommendation.Item31 != null) userItemlist.Items.Add(collaborativeRecommendation.Item31);
                if (collaborativeRecommendation.Item32 != null) userItemlist.Items.Add(collaborativeRecommendation.Item32);
                if (collaborativeRecommendation.Item33 != null) userItemlist.Items.Add(collaborativeRecommendation.Item33);
                if (collaborativeRecommendation.Item34 != null) userItemlist.Items.Add(collaborativeRecommendation.Item34);
                if (collaborativeRecommendation.Item35 != null) userItemlist.Items.Add(collaborativeRecommendation.Item35);
                if (collaborativeRecommendation.Item36 != null) userItemlist.Items.Add(collaborativeRecommendation.Item36);
                if (collaborativeRecommendation.Item37 != null) userItemlist.Items.Add(collaborativeRecommendation.Item37);
                if (collaborativeRecommendation.Item38 != null) userItemlist.Items.Add(collaborativeRecommendation.Item38);
                if (collaborativeRecommendation.Item39 != null) userItemlist.Items.Add(collaborativeRecommendation.Item39);
                if (collaborativeRecommendation.Item40 != null) userItemlist.Items.Add(collaborativeRecommendation.Item40);
                if (collaborativeRecommendation.Item41 != null) userItemlist.Items.Add(collaborativeRecommendation.Item41);
                if (collaborativeRecommendation.Item42 != null) userItemlist.Items.Add(collaborativeRecommendation.Item42);
                if (collaborativeRecommendation.Item43 != null) userItemlist.Items.Add(collaborativeRecommendation.Item43);
                if (collaborativeRecommendation.Item44 != null) userItemlist.Items.Add(collaborativeRecommendation.Item44);
                if (collaborativeRecommendation.Item45 != null) userItemlist.Items.Add(collaborativeRecommendation.Item45);
                if (collaborativeRecommendation.Item46 != null) userItemlist.Items.Add(collaborativeRecommendation.Item46);
                if (collaborativeRecommendation.Item47 != null) userItemlist.Items.Add(collaborativeRecommendation.Item47);
                if (collaborativeRecommendation.Item48 != null) userItemlist.Items.Add(collaborativeRecommendation.Item48);
                if (collaborativeRecommendation.Item49 != null) userItemlist.Items.Add(collaborativeRecommendation.Item49);
                if (collaborativeRecommendation.Item50 != null) userItemlist.Items.Add(collaborativeRecommendation.Item50);
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