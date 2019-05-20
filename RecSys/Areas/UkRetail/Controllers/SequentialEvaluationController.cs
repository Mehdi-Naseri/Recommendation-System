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
    public class SequentialEvaluationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SequentialEvaluationController(ApplicationDbContext context)
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

            List<int> recomendationUsers = _dbContext.SequentialRecommendation.Select(a => a.UserId).Distinct().ToList();
           // IList<UserItemPurchase> purchases = purchasesAll.Where(a => recomendationUsers.Contains(a.User)).ToList();
            IList<UserItemPurchase> purchases = purchasesAll.ToList();

            //Select recommendations which the user bought something
            List<int> purchaseUsers = purchases.Select(a => a.User).Distinct().ToList();

            IList<UserItemlist> recommendations5 = new List<UserItemlist>();
            IList<SequentialRecommendation> sequentialRecommendations = _dbContext.SequentialRecommendation
                .Where(a => purchaseUsers.Contains(a.UserId)).ToList();
            foreach (SequentialRecommendation sequentialRecommendation in sequentialRecommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = sequentialRecommendation.UserId;
                userItemlist.Items = new List<string>();
                if (sequentialRecommendation.Item1 != null) userItemlist.Items.Add(sequentialRecommendation.Item1);
                if (sequentialRecommendation.Item2 != null) userItemlist.Items.Add(sequentialRecommendation.Item2);
                if (sequentialRecommendation.Item3 != null) userItemlist.Items.Add(sequentialRecommendation.Item3);
                if (sequentialRecommendation.Item4 != null) userItemlist.Items.Add(sequentialRecommendation.Item4);
                if (sequentialRecommendation.Item5 != null) userItemlist.Items.Add(sequentialRecommendation.Item5);
                recommendations5.Add(userItemlist);
            }

            IList<UserItemlist> recommendations10 = new List<UserItemlist>();
            foreach (SequentialRecommendation sequentialRecommendation in sequentialRecommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = sequentialRecommendation.UserId;
                userItemlist.Items = new List<string>();
                if (sequentialRecommendation.Item1 != null) userItemlist.Items.Add(sequentialRecommendation.Item1);
                if (sequentialRecommendation.Item2 != null) userItemlist.Items.Add(sequentialRecommendation.Item2);
                if (sequentialRecommendation.Item3 != null) userItemlist.Items.Add(sequentialRecommendation.Item3);
                if (sequentialRecommendation.Item4 != null) userItemlist.Items.Add(sequentialRecommendation.Item4);
                if (sequentialRecommendation.Item5 != null) userItemlist.Items.Add(sequentialRecommendation.Item5);
                if (sequentialRecommendation.Item6 != null) userItemlist.Items.Add(sequentialRecommendation.Item6);
                if (sequentialRecommendation.Item7 != null) userItemlist.Items.Add(sequentialRecommendation.Item7);
                if (sequentialRecommendation.Item8 != null) userItemlist.Items.Add(sequentialRecommendation.Item8);
                if (sequentialRecommendation.Item9 != null) userItemlist.Items.Add(sequentialRecommendation.Item9);
                if (sequentialRecommendation.Item10 != null) userItemlist.Items.Add(sequentialRecommendation.Item10);
                recommendations10.Add(userItemlist);
            }

            IList<UserItemlist> recommendations20 = new List<UserItemlist>();
            foreach (SequentialRecommendation sequentialRecommendation in sequentialRecommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = sequentialRecommendation.UserId;
                userItemlist.Items = new List<string>();
                if (sequentialRecommendation.Item1 != null) userItemlist.Items.Add(sequentialRecommendation.Item1);
                if (sequentialRecommendation.Item2 != null) userItemlist.Items.Add(sequentialRecommendation.Item2);
                if (sequentialRecommendation.Item3 != null) userItemlist.Items.Add(sequentialRecommendation.Item3);
                if (sequentialRecommendation.Item4 != null) userItemlist.Items.Add(sequentialRecommendation.Item4);
                if (sequentialRecommendation.Item5 != null) userItemlist.Items.Add(sequentialRecommendation.Item5);
                if (sequentialRecommendation.Item6 != null) userItemlist.Items.Add(sequentialRecommendation.Item6);
                if (sequentialRecommendation.Item7 != null) userItemlist.Items.Add(sequentialRecommendation.Item7);
                if (sequentialRecommendation.Item8 != null) userItemlist.Items.Add(sequentialRecommendation.Item8);
                if (sequentialRecommendation.Item9 != null) userItemlist.Items.Add(sequentialRecommendation.Item9);
                if (sequentialRecommendation.Item10 != null) userItemlist.Items.Add(sequentialRecommendation.Item10);
                if (sequentialRecommendation.Item11 != null) userItemlist.Items.Add(sequentialRecommendation.Item11);
                if (sequentialRecommendation.Item12 != null) userItemlist.Items.Add(sequentialRecommendation.Item12);
                if (sequentialRecommendation.Item13 != null) userItemlist.Items.Add(sequentialRecommendation.Item13);
                if (sequentialRecommendation.Item14 != null) userItemlist.Items.Add(sequentialRecommendation.Item14);
                if (sequentialRecommendation.Item15 != null) userItemlist.Items.Add(sequentialRecommendation.Item15);
                if (sequentialRecommendation.Item16 != null) userItemlist.Items.Add(sequentialRecommendation.Item16);
                if (sequentialRecommendation.Item17 != null) userItemlist.Items.Add(sequentialRecommendation.Item17);
                if (sequentialRecommendation.Item18 != null) userItemlist.Items.Add(sequentialRecommendation.Item18);
                if (sequentialRecommendation.Item19 != null) userItemlist.Items.Add(sequentialRecommendation.Item19);
                if (sequentialRecommendation.Item20 != null) userItemlist.Items.Add(sequentialRecommendation.Item20);
                recommendations20.Add(userItemlist);
            }

            IList<UserItemlist> recommendations50 = new List<UserItemlist>();
            foreach (SequentialRecommendation sequentialRecommendation in sequentialRecommendations)
            {
                UserItemlist userItemlist = new UserItemlist();
                userItemlist.UserId = sequentialRecommendation.UserId;
                userItemlist.Items = new List<string>();
                if (sequentialRecommendation.Item1 != null) userItemlist.Items.Add(sequentialRecommendation.Item1);
                if (sequentialRecommendation.Item2 != null) userItemlist.Items.Add(sequentialRecommendation.Item2);
                if (sequentialRecommendation.Item3 != null) userItemlist.Items.Add(sequentialRecommendation.Item3);
                if (sequentialRecommendation.Item4 != null) userItemlist.Items.Add(sequentialRecommendation.Item4);
                if (sequentialRecommendation.Item5 != null) userItemlist.Items.Add(sequentialRecommendation.Item5);
                if (sequentialRecommendation.Item6 != null) userItemlist.Items.Add(sequentialRecommendation.Item6);
                if (sequentialRecommendation.Item7 != null) userItemlist.Items.Add(sequentialRecommendation.Item7);
                if (sequentialRecommendation.Item8 != null) userItemlist.Items.Add(sequentialRecommendation.Item8);
                if (sequentialRecommendation.Item9 != null) userItemlist.Items.Add(sequentialRecommendation.Item9);
                if (sequentialRecommendation.Item10 != null) userItemlist.Items.Add(sequentialRecommendation.Item10);
                if (sequentialRecommendation.Item11 != null) userItemlist.Items.Add(sequentialRecommendation.Item11);
                if (sequentialRecommendation.Item12 != null) userItemlist.Items.Add(sequentialRecommendation.Item12);
                if (sequentialRecommendation.Item13 != null) userItemlist.Items.Add(sequentialRecommendation.Item13);
                if (sequentialRecommendation.Item14 != null) userItemlist.Items.Add(sequentialRecommendation.Item14);
                if (sequentialRecommendation.Item15 != null) userItemlist.Items.Add(sequentialRecommendation.Item15);
                if (sequentialRecommendation.Item16 != null) userItemlist.Items.Add(sequentialRecommendation.Item16);
                if (sequentialRecommendation.Item17 != null) userItemlist.Items.Add(sequentialRecommendation.Item17);
                if (sequentialRecommendation.Item18 != null) userItemlist.Items.Add(sequentialRecommendation.Item18);
                if (sequentialRecommendation.Item19 != null) userItemlist.Items.Add(sequentialRecommendation.Item19);
                if (sequentialRecommendation.Item20 != null) userItemlist.Items.Add(sequentialRecommendation.Item20);
                if (sequentialRecommendation.Item21 != null) userItemlist.Items.Add(sequentialRecommendation.Item21);
                if (sequentialRecommendation.Item22 != null) userItemlist.Items.Add(sequentialRecommendation.Item22);
                if (sequentialRecommendation.Item23 != null) userItemlist.Items.Add(sequentialRecommendation.Item23);
                if (sequentialRecommendation.Item24 != null) userItemlist.Items.Add(sequentialRecommendation.Item24);
                if (sequentialRecommendation.Item25 != null) userItemlist.Items.Add(sequentialRecommendation.Item25);
                if (sequentialRecommendation.Item26 != null) userItemlist.Items.Add(sequentialRecommendation.Item26);
                if (sequentialRecommendation.Item27 != null) userItemlist.Items.Add(sequentialRecommendation.Item27);
                if (sequentialRecommendation.Item28 != null) userItemlist.Items.Add(sequentialRecommendation.Item28);
                if (sequentialRecommendation.Item29 != null) userItemlist.Items.Add(sequentialRecommendation.Item29);
                if (sequentialRecommendation.Item30 != null) userItemlist.Items.Add(sequentialRecommendation.Item30);
                if (sequentialRecommendation.Item31 != null) userItemlist.Items.Add(sequentialRecommendation.Item31);
                if (sequentialRecommendation.Item32 != null) userItemlist.Items.Add(sequentialRecommendation.Item32);
                if (sequentialRecommendation.Item33 != null) userItemlist.Items.Add(sequentialRecommendation.Item33);
                if (sequentialRecommendation.Item34 != null) userItemlist.Items.Add(sequentialRecommendation.Item34);
                if (sequentialRecommendation.Item35 != null) userItemlist.Items.Add(sequentialRecommendation.Item35);
                if (sequentialRecommendation.Item36 != null) userItemlist.Items.Add(sequentialRecommendation.Item36);
                if (sequentialRecommendation.Item37 != null) userItemlist.Items.Add(sequentialRecommendation.Item37);
                if (sequentialRecommendation.Item38 != null) userItemlist.Items.Add(sequentialRecommendation.Item38);
                if (sequentialRecommendation.Item39 != null) userItemlist.Items.Add(sequentialRecommendation.Item39);
                if (sequentialRecommendation.Item40 != null) userItemlist.Items.Add(sequentialRecommendation.Item40);
                if (sequentialRecommendation.Item41 != null) userItemlist.Items.Add(sequentialRecommendation.Item41);
                if (sequentialRecommendation.Item42 != null) userItemlist.Items.Add(sequentialRecommendation.Item42);
                if (sequentialRecommendation.Item43 != null) userItemlist.Items.Add(sequentialRecommendation.Item43);
                if (sequentialRecommendation.Item44 != null) userItemlist.Items.Add(sequentialRecommendation.Item44);
                if (sequentialRecommendation.Item45 != null) userItemlist.Items.Add(sequentialRecommendation.Item45);
                if (sequentialRecommendation.Item46 != null) userItemlist.Items.Add(sequentialRecommendation.Item46);
                if (sequentialRecommendation.Item47 != null) userItemlist.Items.Add(sequentialRecommendation.Item47);
                if (sequentialRecommendation.Item48 != null) userItemlist.Items.Add(sequentialRecommendation.Item48);
                if (sequentialRecommendation.Item49 != null) userItemlist.Items.Add(sequentialRecommendation.Item49);
                if (sequentialRecommendation.Item50 != null) userItemlist.Items.Add(sequentialRecommendation.Item50);
                recommendations50.Add(userItemlist);
            }


            AccuracyNrec accuracyNrec = new AccuracyNrec();
            RecEvaluation recEvaluation = new RecEvaluation();
            accuracyNrec.Precicion5 = recEvaluation.Precision(recommendations5, purchases);
            accuracyNrec.Recall5 = recEvaluation.Recall(recommendations5, purchases);
            accuracyNrec.F15 = recEvaluation.F1(accuracyNrec.Precicion5, accuracyNrec.Recall5);
            accuracyNrec.RecallwithFrequency5 = recEvaluation.RecallWithFrequency(recommendations5, purchases);
            accuracyNrec.F1withFrequency5 = recEvaluation.F1(accuracyNrec.Precicion5, accuracyNrec.RecallwithFrequency5);

            accuracyNrec.Precicion10 = recEvaluation.Precision(recommendations10, purchases);
            accuracyNrec.Recall10 = recEvaluation.Recall(recommendations10, purchases);
            accuracyNrec.F110 = recEvaluation.F1(accuracyNrec.Precicion10, accuracyNrec.Recall10);
            accuracyNrec.RecallwithFrequency10 = recEvaluation.RecallWithFrequency(recommendations10, purchases);
            accuracyNrec.F1withFrequency10 = recEvaluation.F1(accuracyNrec.Precicion10, accuracyNrec.RecallwithFrequency10);

            accuracyNrec.Precicion20 = recEvaluation.Precision(recommendations20, purchases);
            accuracyNrec.Recall20 = recEvaluation.Recall(recommendations20, purchases);
            accuracyNrec.F120 = recEvaluation.F1(accuracyNrec.Precicion20, accuracyNrec.Recall20);
            accuracyNrec.RecallwithFrequency20 = recEvaluation.RecallWithFrequency(recommendations20, purchases);
            accuracyNrec.F1withFrequency20 = recEvaluation.F1(accuracyNrec.Precicion20, accuracyNrec.RecallwithFrequency20);

            accuracyNrec.Precicion50 = recEvaluation.Precision(recommendations50, purchases);
            accuracyNrec.Recall50 = recEvaluation.Recall(recommendations50, purchases);
            accuracyNrec.F150 = recEvaluation.F1(accuracyNrec.Precicion50, accuracyNrec.Recall50);
            accuracyNrec.RecallwithFrequency50 = recEvaluation.RecallWithFrequency(recommendations50, purchases);
            accuracyNrec.F1withFrequency50 = recEvaluation.F1(accuracyNrec.Precicion50, accuracyNrec.RecallwithFrequency50);
            return View(accuracyNrec);
        }
    }
}