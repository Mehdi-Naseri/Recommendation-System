using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecSys.Data;
using RecSys.Functions;
using RecSys.Functions.SPM;
using RecSys.Models;
using RecSys.ViewModels;

namespace RecSys.Areas.UkTraining.Controllers
{
    [Area("UkTraining")]
    public class SequentialOptimumSupportConfidenceController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SequentialOptimumSupportConfidenceController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult OptimumSupportConfidence(float supportFrom, float supportTo, float supportSteps,
            float confidenceFrom, float confidenceTo, float confidenceSteps,
            DateTime trainStartDate, DateTime trainEndDate, DateTime testStartDate, DateTime testEndDate)
        {
            List<SupportConfidenceAccuracyNrec> SupportConfidenceAccuracyNrecs = new List<SupportConfidenceAccuracyNrec>();
            //Select purchases in test period
            IList<UserItemPurchase> purchasesAllTest = _dbContext.UkRetailOriginalSales
                .Where(a => a.InvoiceDate.Date >= testStartDate.Date && a.InvoiceDate.Date <= testEndDate.Date &&
                    a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                    string.Compare(a.StockCode, "a") == -1)
                .Select(a => new UserItemPurchase { User = (Int32)a.CustomerID, Item = a.StockCode }).ToList();
            //Select purchases in train period
            IList<int> purchasesAllTrain = _dbContext.UkRetailOriginalSales
                .Where(a => a.InvoiceDate.Date >= trainStartDate.Date && a.InvoiceDate.Date <= trainEndDate.Date &&
                            a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                            string.Compare(a.StockCode, "a") == -1).Select(a => (Int32)a.CustomerID).Distinct().ToList();
            //Select users which the user bought something both in test period and train priod
            List<int> purchaseUsers = purchasesAllTest.Select(a => a.User).Where(a => purchasesAllTrain.Contains(a)).Distinct().ToList();
            //Select purchass where user has bought something both in training and testing
            IList<UserItemPurchase> purchases = purchasesAllTest.Where(a => purchaseUsers.Contains(a.User)).ToList();




            IEnumerable<SequenceSupport> sequenceSupports = ReadFrequentSequences();
            //List<FrequentSequentialRule> frequentSequentialRules = FindFrequentSequentialRules(sequenceSupports);
            List<UserSequence> userSequences = CreateUserSequences(trainStartDate, trainEndDate);
            int userCount = userSequences.Count();


            //Parallel.ForEach(counter, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, supportPercentage =>
            for (float supportPercentage = supportFrom; supportPercentage <= supportTo ; supportPercentage += supportSteps)
            {
                var counter = new List<float>();
                for (float i = confidenceFrom; i <= confidenceTo; i += confidenceSteps)
                {
                    counter.Add(i);
                }
                Parallel.ForEach(counter, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, confidence =>
                //for (float confidence = confidenceFrom; confidence <= confidenceTo; confidence += confidenceSteps)
                {
                    //=========================================================
                    //Recommend Items
                    //=========================================================
                    int support = Convert.ToInt32(Math.Floor((supportPercentage / 100) * userCount));
                    IList<SequenceSupport> sequenceSupports2Items = sequenceSupports.
                        Where(a => a.sequence.Count == 2 && a.sequence[0].Count == 1 && a.sequence[1].Count == 1 && a.support >= support).ToList();
                    IList<SequenceSupport> sequenceSupports1Items = sequenceSupports.
                         Where(a => a.sequence.Count == 1 && a.sequence[0].Count == 1 && a.support >= support).ToList();
                    IList<SequenceSupport> sequenceSupports2ItemsRules = new List<SequenceSupport>();
                    foreach (SequenceSupport sequenceSupport in sequenceSupports2Items)
                    {
                        int ancestorSupport = sequenceSupports1Items.Single(a => a.sequence[0][0] == sequenceSupport.sequence[0][0]).support;
                        if (((float)sequenceSupport.support / (float)ancestorSupport) >= ((float)confidence / 100.0))
                        {
                            sequenceSupports2ItemsRules.Add(sequenceSupport);
                        }
                    }

                    SpmRecommendation sequentialRecommendation = new SpmRecommendation();
                    List<RecommendedItems> recommendedItemsList = sequentialRecommendation.Recommend(sequenceSupports2ItemsRules, userSequences, 50);
                    System.Diagnostics.Debug.WriteLine("Step 0 - Recomendation finished: " + DateTime.Now.TimeOfDay + " - Support: " + supportPercentage + " - Confidence: " + confidence);

                    //=========================================================
                    //Evaluate recomendations
                    //=========================================================
                    //Select recomendations which user has purchased both in training and testing
                    List<RecommendedItems> recommendations = recommendedItemsList.Where(a => purchaseUsers.Contains(a.User)).ToList();
                    AccuracyNrec accuracyNrec = CalculateAccuracy(recommendations, purchases);

                    SupportConfidenceAccuracyNrec supportConfidenceAccuracyNrec = new SupportConfidenceAccuracyNrec();
                    supportConfidenceAccuracyNrec.Support = supportPercentage;
                    supportConfidenceAccuracyNrec.Confidence = confidence;
                    supportConfidenceAccuracyNrec.AccuracyNrec = accuracyNrec;
                    SupportConfidenceAccuracyNrecs.Add(supportConfidenceAccuracyNrec);

                    System.Diagnostics.Debug.WriteLine("Step 0 - Evaluation finished: " + DateTime.Now.TimeOfDay + " - Support: " + supportPercentage + " - Confidence: " + confidence);

                });
            }

            return View(SupportConfidenceAccuracyNrecs);
        }

        private List<SequenceSupport> ReadFrequentSequences()
        {
            List<SequenceSupport> sequenceSupports = new List<SequenceSupport>();
            var a = _dbContext.FrequentSequentialPattern.Where(r => r.Train == true);
            foreach (var item in a)
            {
                char[] splitChars = new[] { '(', ')', '<', '>' };
                string[] itemsets = item.Sequence.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                List<List<string>> itemsetsList = new List<List<string>>();
                foreach (string i in itemsets)
                {
                    splitChars = new[] { ' ', '-' };
                    string[] itemset = i.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                    List<string> itemsetList = new List<string>(itemset);
                    itemsetsList.Add(itemsetList);
                }
                SequenceSupport sequenceSupport = new SequenceSupport();
                sequenceSupport.support = item.Support;
                sequenceSupport.sequence = itemsetsList;
                sequenceSupports.Add(sequenceSupport);
            }
            return sequenceSupports;
        }

        private List<UserSequence> CreateUserSequences(DateTime startDate, DateTime endDate)
        {
            var customerOrders = _dbContext.UkRetailOriginalSales
                .Where(a => a.InvoiceDate.Date >= startDate.Date && a.InvoiceDate.Date <= endDate.Date &&
                            a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                            string.Compare(a.StockCode, "a") == -1)
                .Select(a => new { a.CustomerID, Year = a.InvoiceDate.Year, Month = a.InvoiceDate.Month, a.StockCode })
                //.OrderBy(a => new { a.Year, a.Month })
                .GroupBy(a => new { a.CustomerID });
            //.GroupBy(a => new { a.CustomerID, a.Year, a.Month }); 

            List<UserSequence> userSequences = new List<UserSequence>();
            foreach (var groupCustomer in customerOrders)
            {
                var customerMonthlyorder = groupCustomer.GroupBy(a => new { a.Year, a.Month });
                UserSequence userSequence = new UserSequence();
                List<List<string>> sequence = new List<List<string>>();
                foreach (var groupCustomerMontlyOrder in customerMonthlyorder)
                {
                    List<string> itemset = new List<string>();
                    foreach (var order in groupCustomerMontlyOrder)
                    {
                        itemset.Add(order.StockCode);
                    }
                    sequence.Add(itemset);
                    userSequence.User = groupCustomerMontlyOrder.Select(a => a.CustomerID.GetValueOrDefault()).FirstOrDefault();
                    userSequence.Sequence = sequence;
                }
                userSequences.Add(userSequence);
            }
            return userSequences;
        }


        private AccuracyNrec CalculateAccuracy(List<RecommendedItems> recommendations, IList<UserItemPurchase> purchases)
        {
            IList<UserItemlist> recommendations5 = recommendations
                .Select(a => new UserItemlist
                {
                    UserId = a.User,
                    Items = a.Items.OrderByDescending(b => b.Rating).Take(5).Select(c => c.ItemId).ToList()
                }).ToList();

            IList<UserItemlist> recommendations10 = recommendations
                .Select(a => new UserItemlist
                {
                    UserId = a.User,
                    Items = a.Items.OrderByDescending(b => b.Rating).Take(10).Select(c => c.ItemId).ToList()
                }).ToList();

            IList<UserItemlist> recommendations20 = recommendations
                .Select(a => new UserItemlist
                {
                    UserId = a.User,
                    Items = a.Items.OrderByDescending(b => b.Rating).Take(20).Select(c => c.ItemId).ToList()
                }).ToList();

            IList<UserItemlist> recommendations50 = recommendations
                .Select(a => new UserItemlist
                {
                    UserId = a.User,
                    Items = a.Items.OrderByDescending(b => b.Rating).Take(50).Select(c => c.ItemId).ToList()
                }).ToList();

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

            return accuracyNrec;
        }

    }
}