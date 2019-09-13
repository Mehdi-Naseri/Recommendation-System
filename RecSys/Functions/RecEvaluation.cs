using RecSys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Design;
using RecSys.Models;

namespace RecSys.Functions
{
    public class RecEvaluation
    {

        public float Precision(IList<UserItemlist> recommendations, IList<UserItemPurchase> purchases)
        {
            int tp = 0, fp = 0;
            foreach (UserItemlist userItemlist in recommendations)
            {
                foreach (string item in userItemlist.Items)
                {
                    bool tpBool = purchases.Any(a => a.User == userItemlist.UserId && a.Item == item);
                    if (tpBool)
                    {
                        tp++;
                    }
                    else
                    {
                        fp++;
                    }
                }
            }

            float precision =0;
            if ((tp + fp) > 0)
            {
                precision = (float)tp / (tp + fp);
            }
            return precision;
        }

        //Recall method without frequency (If user buy an item multiple times it is consider once)
        public float Recall(IList<UserItemlist> recommendations, IList<UserItemPurchase> purchases)
        {
            int tp = 0, fn = 0;
            IList<int> users = purchases.Select(a => a.User).Distinct().ToList();
            foreach (int user in users)
            {
                List<string> userPurchasedItems = purchases.Where(a => a.User == user).Select(a => a.Item).Distinct().ToList();
                foreach (string item in userPurchasedItems)
                {
                    bool tpBool = recommendations.Any(a => a.UserId==user && a.Items.Contains(item));
                    if (tpBool)
                    {
                        tp++;
                    }
                    else
                    {
                        fn++;
                    }
                }
            }
            float recall = 0;
            if ((tp + fn) > 0)
            {
                recall = (float)tp / (tp + fn);
            }
            return recall;
        }

        //Recall with frequency (If user buy an item multiple times it is consider multiple times) (RecallWithFrequency)
        public float RecallWithFrequency(IList<UserItemlist> recommendations, IList<UserItemPurchase> purchases)
        {
            int tp = 0, fn = 0;
            foreach (UserItemPurchase userItemPurchase in purchases)
            {
                bool tpBool = recommendations.Any(a => a.UserId == userItemPurchase.User && a.Items.Contains(userItemPurchase.Item));
                if (tpBool)
                {
                    tp++;
                }
                else
                {
                    fn++;
                }
            }
            float recall = 0;
            if ((tp + fn) > 0)
            {
                recall = (float)tp / (tp + fn);
            }
            return recall;
        }

        public float F1(float precision, float recall)
        {
            float f1 = 0;
            if ((precision + recall) > 0)
            {
                float top = (float) (precision * recall);
                float down = (float) (precision + recall);
               f1 =2 * ( top/ down);
            }
            return f1;
        }

        public AccuracyNrec RecEvaluate(IQueryable<UkRetailOriginalSales> ukRetailOriginalSales, IQueryable<Recommendation> recommendationsAll, string recType, DateTime trainStartDate, DateTime trainEndDate, DateTime testStartDate, DateTime testEndDate)
        {
            //Select purchases in test period
            IList<UserItemPurchase> purchasesAllTest = ukRetailOriginalSales
                          .Where(a => a.InvoiceDate.Date >= testStartDate.Date && a.InvoiceDate.Date <= testEndDate.Date &&
                                      a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                                      string.Compare(a.StockCode, "a") == -1)
                          .Select(a => new UserItemPurchase { User = (Int32)a.CustomerID, Item = a.StockCode }).ToList();

            //Select purchases in train period
            IList<int> purchasesAllTrain = ukRetailOriginalSales
                .Where(a => a.InvoiceDate.Date >= trainStartDate.Date && a.InvoiceDate.Date <= trainEndDate.Date &&
                a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                string.Compare(a.StockCode, "a") == -1).Select(a => (Int32)a.CustomerID).Distinct().ToList();

            //Select users which the user bought something both in test period and train priod
            List<int> purchaseUsers = purchasesAllTest.Select(a => a.User).Where(a => purchasesAllTrain.Contains(a)).Distinct().ToList();
            //Select purchass where user has bought something both in training and testing
            IList<UserItemPurchase> purchase = purchasesAllTest.Where(a => purchaseUsers.Contains(a.User)).ToList();

            IList<Recommendation> recommendations = recommendationsAll
                .Where(a => purchaseUsers.Contains(a.UserId)).ToList();

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

            return accuracyNrec;
        }
    }
}
