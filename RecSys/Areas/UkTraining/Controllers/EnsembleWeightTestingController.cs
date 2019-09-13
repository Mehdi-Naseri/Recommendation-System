using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using RecSys.Data;
using RecSys.Functions;
using RecSys.Models;
using RecSys.ViewModels;

namespace RecSys.Areas.UkTraining.Controllers
{
    [Area("UkTraining")]
    public class EnsembleWeightTestingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EnsembleWeightTestingController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EvaluationResults(int recommendationNumber, DateTime trainStartDate, DateTime trainEndDate, DateTime testStartDate, DateTime testEndDate)
        {
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

            IList<Recommendation> recommendationsSpmPurchased = _dbContext.Recommendation
                .Where(a => a.RecommendationInfoId == 2 && purchaseUsers.Contains(a.UserId)).ToList();
            IList<Recommendation> recommendationsSpmNotPurchased = _dbContext.Recommendation
                .Where(a => a.RecommendationInfoId == 3 && purchaseUsers.Contains(a.UserId)).ToList();
            IList<Recommendation> recommendationsCfNotPurchased = _dbContext.Recommendation
                .Where(a => a.RecommendationInfoId == 13 && purchaseUsers.Contains(a.UserId)).ToList();
            IList<Recommendation> recommendationsPurchaseFrequency = _dbContext.Recommendation
                .Where(a => a.RecommendationInfoId == 5 && purchaseUsers.Contains(a.UserId)).ToList();
            /*************************************************************************************/
            // Fill User Item Matrix based on support of each rule
            /*************************************************************************************/
            IList<RecommendedItems> recommendeditemsPurchaseFrequency = new List<RecommendedItems>();
            foreach (var a in recommendationsPurchaseFrequency)
            {
                RecommendedItems recommendedItems = new RecommendedItems();
                recommendedItems.User = a.UserId;
                recommendedItems.Items = new List<ItemRating>();
                if (a.Item1 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item1, (float)a.Rating1.GetValueOrDefault()));
                if (a.Item2 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item2, (float)a.Rating2.GetValueOrDefault()));
                if (a.Item3 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item3, (float)a.Rating3.GetValueOrDefault()));
                if (a.Item4 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item4, (float)a.Rating4.GetValueOrDefault()));
                if (a.Item5 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item5, (float)a.Rating5.GetValueOrDefault()));
                if (a.Item6 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item6, (float)a.Rating6.GetValueOrDefault()));
                if (a.Item7 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item7, (float)a.Rating7.GetValueOrDefault()));
                if (a.Item8 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item8, (float)a.Rating8.GetValueOrDefault()));
                if (a.Item9 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item9, (float)a.Rating9.GetValueOrDefault()));
                if (a.Item10 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item10, (float)a.Rating10.GetValueOrDefault()));
                if (a.Item11 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item11, (float)a.Rating11.GetValueOrDefault()));
                if (a.Item12 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item12, (float)a.Rating12.GetValueOrDefault()));
                if (a.Item13 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item13, (float)a.Rating13.GetValueOrDefault()));
                if (a.Item14 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item14, (float)a.Rating14.GetValueOrDefault()));
                if (a.Item15 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item15, (float)a.Rating15.GetValueOrDefault()));
                if (a.Item16 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item16, (float)a.Rating16.GetValueOrDefault()));
                if (a.Item17 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item17, (float)a.Rating17.GetValueOrDefault()));
                if (a.Item18 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item18, (float)a.Rating18.GetValueOrDefault()));
                if (a.Item19 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item19, (float)a.Rating19.GetValueOrDefault()));
                if (a.Item20 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item20, (float)a.Rating20.GetValueOrDefault()));
                if (a.Item21 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item21, (float)a.Rating21.GetValueOrDefault()));
                if (a.Item22 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item22, (float)a.Rating22.GetValueOrDefault()));
                if (a.Item23 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item23, (float)a.Rating23.GetValueOrDefault()));
                if (a.Item24 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item24, (float)a.Rating24.GetValueOrDefault()));
                if (a.Item25 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item25, (float)a.Rating25.GetValueOrDefault()));
                if (a.Item26 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item26, (float)a.Rating26.GetValueOrDefault()));
                if (a.Item27 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item27, (float)a.Rating27.GetValueOrDefault()));
                if (a.Item28 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item28, (float)a.Rating28.GetValueOrDefault()));
                if (a.Item29 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item29, (float)a.Rating29.GetValueOrDefault()));
                if (a.Item30 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item30, (float)a.Rating30.GetValueOrDefault()));
                if (a.Item31 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item31, (float)a.Rating31.GetValueOrDefault()));
                if (a.Item32 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item32, (float)a.Rating32.GetValueOrDefault()));
                if (a.Item33 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item33, (float)a.Rating33.GetValueOrDefault()));
                if (a.Item34 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item34, (float)a.Rating34.GetValueOrDefault()));
                if (a.Item35 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item35, (float)a.Rating35.GetValueOrDefault()));
                if (a.Item36 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item36, (float)a.Rating36.GetValueOrDefault()));
                if (a.Item37 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item37, (float)a.Rating37.GetValueOrDefault()));
                if (a.Item38 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item38, (float)a.Rating38.GetValueOrDefault()));
                if (a.Item39 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item39, (float)a.Rating39.GetValueOrDefault()));
                if (a.Item40 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item40, (float)a.Rating40.GetValueOrDefault()));
                if (a.Item41 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item41, (float)a.Rating41.GetValueOrDefault()));
                if (a.Item42 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item42, (float)a.Rating42.GetValueOrDefault()));
                if (a.Item43 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item43, (float)a.Rating43.GetValueOrDefault()));
                if (a.Item44 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item44, (float)a.Rating44.GetValueOrDefault()));
                if (a.Item45 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item45, (float)a.Rating45.GetValueOrDefault()));
                if (a.Item46 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item46, (float)a.Rating46.GetValueOrDefault()));
                if (a.Item47 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item47, (float)a.Rating47.GetValueOrDefault()));
                if (a.Item48 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item48, (float)a.Rating48.GetValueOrDefault()));
                if (a.Item49 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item49, (float)a.Rating49.GetValueOrDefault()));
                if (a.Item50 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item50, (float)a.Rating50.GetValueOrDefault()));

                recommendeditemsPurchaseFrequency.Add(recommendedItems);
            }


            IList<RecommendedItems> RecommendeditemsCollaborativeNotPurchased = new List<RecommendedItems>();
            foreach (var a in recommendationsCfNotPurchased)
            {
                RecommendedItems recommendedItems = new RecommendedItems();
                recommendedItems.User = a.UserId;
                recommendedItems.Items = new List<ItemRating>();
                if (a.Item1 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item1, (float)a.Rating1.GetValueOrDefault()));
                if (a.Item2 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item2, (float)a.Rating2.GetValueOrDefault()));
                if (a.Item3 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item3, (float)a.Rating3.GetValueOrDefault()));
                if (a.Item4 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item4, (float)a.Rating4.GetValueOrDefault()));
                if (a.Item5 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item5, (float)a.Rating5.GetValueOrDefault()));
                if (a.Item6 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item6, (float)a.Rating6.GetValueOrDefault()));
                if (a.Item7 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item7, (float)a.Rating7.GetValueOrDefault()));
                if (a.Item8 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item8, (float)a.Rating8.GetValueOrDefault()));
                if (a.Item9 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item9, (float)a.Rating9.GetValueOrDefault()));
                if (a.Item10 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item10, (float)a.Rating10.GetValueOrDefault()));
                if (a.Item11 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item11, (float)a.Rating11.GetValueOrDefault()));
                if (a.Item12 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item12, (float)a.Rating12.GetValueOrDefault()));
                if (a.Item13 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item13, (float)a.Rating13.GetValueOrDefault()));
                if (a.Item14 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item14, (float)a.Rating14.GetValueOrDefault()));
                if (a.Item15 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item15, (float)a.Rating15.GetValueOrDefault()));
                if (a.Item16 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item16, (float)a.Rating16.GetValueOrDefault()));
                if (a.Item17 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item17, (float)a.Rating17.GetValueOrDefault()));
                if (a.Item18 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item18, (float)a.Rating18.GetValueOrDefault()));
                if (a.Item19 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item19, (float)a.Rating19.GetValueOrDefault()));
                if (a.Item20 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item20, (float)a.Rating20.GetValueOrDefault()));
                if (a.Item21 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item21, (float)a.Rating21.GetValueOrDefault()));
                if (a.Item22 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item22, (float)a.Rating22.GetValueOrDefault()));
                if (a.Item23 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item23, (float)a.Rating23.GetValueOrDefault()));
                if (a.Item24 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item24, (float)a.Rating24.GetValueOrDefault()));
                if (a.Item25 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item25, (float)a.Rating25.GetValueOrDefault()));
                if (a.Item26 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item26, (float)a.Rating26.GetValueOrDefault()));
                if (a.Item27 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item27, (float)a.Rating27.GetValueOrDefault()));
                if (a.Item28 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item28, (float)a.Rating28.GetValueOrDefault()));
                if (a.Item29 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item29, (float)a.Rating29.GetValueOrDefault()));
                if (a.Item30 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item30, (float)a.Rating30.GetValueOrDefault()));
                if (a.Item31 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item31, (float)a.Rating31.GetValueOrDefault()));
                if (a.Item32 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item32, (float)a.Rating32.GetValueOrDefault()));
                if (a.Item33 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item33, (float)a.Rating33.GetValueOrDefault()));
                if (a.Item34 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item34, (float)a.Rating34.GetValueOrDefault()));
                if (a.Item35 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item35, (float)a.Rating35.GetValueOrDefault()));
                if (a.Item36 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item36, (float)a.Rating36.GetValueOrDefault()));
                if (a.Item37 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item37, (float)a.Rating37.GetValueOrDefault()));
                if (a.Item38 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item38, (float)a.Rating38.GetValueOrDefault()));
                if (a.Item39 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item39, (float)a.Rating39.GetValueOrDefault()));
                if (a.Item40 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item40, (float)a.Rating40.GetValueOrDefault()));
                if (a.Item41 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item41, (float)a.Rating41.GetValueOrDefault()));
                if (a.Item42 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item42, (float)a.Rating42.GetValueOrDefault()));
                if (a.Item43 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item43, (float)a.Rating43.GetValueOrDefault()));
                if (a.Item44 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item44, (float)a.Rating44.GetValueOrDefault()));
                if (a.Item45 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item45, (float)a.Rating45.GetValueOrDefault()));
                if (a.Item46 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item46, (float)a.Rating46.GetValueOrDefault()));
                if (a.Item47 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item47, (float)a.Rating47.GetValueOrDefault()));
                if (a.Item48 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item48, (float)a.Rating48.GetValueOrDefault()));
                if (a.Item49 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item49, (float)a.Rating49.GetValueOrDefault()));
                if (a.Item50 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item50, (float)a.Rating50.GetValueOrDefault()));
                RecommendeditemsCollaborativeNotPurchased.Add(recommendedItems);
            }


            IList<RecommendedItems> recommendedItemsesSpmPurchased = new List<RecommendedItems>();
            foreach (var a in recommendationsSpmPurchased)
            {
                RecommendedItems recommendedItems = new RecommendedItems();
                recommendedItems.User = a.UserId;
                recommendedItems.Items = new List<ItemRating>();
                if (a.Item1 != null && a.Item1 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item1, (float)a.Rating1.GetValueOrDefault()));
                if (a.Item2 != null && a.Item2 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item2, (float)a.Rating2.GetValueOrDefault()));
                if (a.Item3 != null && a.Item3 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item3, (float)a.Rating3.GetValueOrDefault()));
                if (a.Item4 != null && a.Item4 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item4, (float)a.Rating4.GetValueOrDefault()));
                if (a.Item5 != null && a.Item5 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item5, (float)a.Rating5.GetValueOrDefault()));
                if (a.Item6 != null && a.Item6 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item6, (float)a.Rating6.GetValueOrDefault()));
                if (a.Item7 != null && a.Item7 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item7, (float)a.Rating7.GetValueOrDefault()));
                if (a.Item8 != null && a.Item8 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item8, (float)a.Rating8.GetValueOrDefault()));
                if (a.Item9 != null && a.Item9 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item9, (float)a.Rating9.GetValueOrDefault()));
                if (a.Item10 != null && a.Item10 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item10, (float)a.Rating10.GetValueOrDefault()));
                if (a.Item11 != null && a.Item11 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item11, (float)a.Rating11.GetValueOrDefault()));
                if (a.Item12 != null && a.Item12 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item12, (float)a.Rating12.GetValueOrDefault()));
                if (a.Item13 != null && a.Item13 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item13, (float)a.Rating13.GetValueOrDefault()));
                if (a.Item14 != null && a.Item14 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item14, (float)a.Rating14.GetValueOrDefault()));
                if (a.Item15 != null && a.Item15 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item15, (float)a.Rating15.GetValueOrDefault()));
                if (a.Item16 != null && a.Item16 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item16, (float)a.Rating16.GetValueOrDefault()));
                if (a.Item17 != null && a.Item17 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item17, (float)a.Rating17.GetValueOrDefault()));
                if (a.Item18 != null && a.Item18 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item18, (float)a.Rating18.GetValueOrDefault()));
                if (a.Item19 != null && a.Item19 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item19, (float)a.Rating19.GetValueOrDefault()));
                if (a.Item20 != null && a.Item20 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item20, (float)a.Rating20.GetValueOrDefault()));
                if (a.Item21 != null && a.Item21 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item21, (float)a.Rating21.GetValueOrDefault()));
                if (a.Item22 != null && a.Item22 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item22, (float)a.Rating22.GetValueOrDefault()));
                if (a.Item23 != null && a.Item23 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item23, (float)a.Rating23.GetValueOrDefault()));
                if (a.Item24 != null && a.Item24 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item24, (float)a.Rating24.GetValueOrDefault()));
                if (a.Item25 != null && a.Item25 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item25, (float)a.Rating25.GetValueOrDefault()));
                if (a.Item26 != null && a.Item26 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item26, (float)a.Rating26.GetValueOrDefault()));
                if (a.Item27 != null && a.Item27 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item27, (float)a.Rating27.GetValueOrDefault()));
                if (a.Item28 != null && a.Item28 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item28, (float)a.Rating28.GetValueOrDefault()));
                if (a.Item29 != null && a.Item29 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item29, (float)a.Rating29.GetValueOrDefault()));
                if (a.Item30 != null && a.Item30 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item30, (float)a.Rating30.GetValueOrDefault()));
                if (a.Item31 != null && a.Item31 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item31, (float)a.Rating31.GetValueOrDefault()));
                if (a.Item32 != null && a.Item32 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item32, (float)a.Rating32.GetValueOrDefault()));
                if (a.Item33 != null && a.Item33 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item33, (float)a.Rating33.GetValueOrDefault()));
                if (a.Item34 != null && a.Item34 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item34, (float)a.Rating34.GetValueOrDefault()));
                if (a.Item35 != null && a.Item35 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item35, (float)a.Rating35.GetValueOrDefault()));
                if (a.Item36 != null && a.Item36 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item36, (float)a.Rating36.GetValueOrDefault()));
                if (a.Item37 != null && a.Item37 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item37, (float)a.Rating37.GetValueOrDefault()));
                if (a.Item38 != null && a.Item38 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item38, (float)a.Rating38.GetValueOrDefault()));
                if (a.Item39 != null && a.Item39 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item39, (float)a.Rating39.GetValueOrDefault()));
                if (a.Item40 != null && a.Item40 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item40, (float)a.Rating40.GetValueOrDefault()));
                if (a.Item41 != null && a.Item41 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item41, (float)a.Rating41.GetValueOrDefault()));
                if (a.Item42 != null && a.Item42 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item42, (float)a.Rating42.GetValueOrDefault()));
                if (a.Item43 != null && a.Item43 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item43, (float)a.Rating43.GetValueOrDefault()));
                if (a.Item44 != null && a.Item44 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item44, (float)a.Rating44.GetValueOrDefault()));
                if (a.Item45 != null && a.Item45 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item45, (float)a.Rating45.GetValueOrDefault()));
                if (a.Item46 != null && a.Item46 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item46, (float)a.Rating46.GetValueOrDefault()));
                if (a.Item47 != null && a.Item47 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item47, (float)a.Rating47.GetValueOrDefault()));
                if (a.Item48 != null && a.Item48 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item48, (float)a.Rating48.GetValueOrDefault()));
                if (a.Item49 != null && a.Item49 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item49, (float)a.Rating49.GetValueOrDefault()));
                if (a.Item50 != null && a.Item50 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item50, (float)a.Rating50.GetValueOrDefault()));
                recommendedItemsesSpmPurchased.Add(recommendedItems);
            }

            IList<RecommendedItems> recommendedItemsesSpmNotPurchased = new List<RecommendedItems>();
            foreach (var a in recommendationsSpmNotPurchased)
            {
                RecommendedItems recommendedItems = new RecommendedItems();
                recommendedItems.User = a.UserId;
                recommendedItems.Items = new List<ItemRating>();
                if (a.Item1 != null && a.Item1 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item1, (float)a.Rating1.GetValueOrDefault()));
                if (a.Item2 != null && a.Item2 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item2, (float)a.Rating2.GetValueOrDefault()));
                if (a.Item3 != null && a.Item3 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item3, (float)a.Rating3.GetValueOrDefault()));
                if (a.Item4 != null && a.Item4 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item4, (float)a.Rating4.GetValueOrDefault()));
                if (a.Item5 != null && a.Item5 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item5, (float)a.Rating5.GetValueOrDefault()));
                if (a.Item6 != null && a.Item6 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item6, (float)a.Rating6.GetValueOrDefault()));
                if (a.Item7 != null && a.Item7 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item7, (float)a.Rating7.GetValueOrDefault()));
                if (a.Item8 != null && a.Item8 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item8, (float)a.Rating8.GetValueOrDefault()));
                if (a.Item9 != null && a.Item9 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item9, (float)a.Rating9.GetValueOrDefault()));
                if (a.Item10 != null && a.Item10 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item10, (float)a.Rating10.GetValueOrDefault()));
                if (a.Item11 != null && a.Item11 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item11, (float)a.Rating11.GetValueOrDefault()));
                if (a.Item12 != null && a.Item12 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item12, (float)a.Rating12.GetValueOrDefault()));
                if (a.Item13 != null && a.Item13 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item13, (float)a.Rating13.GetValueOrDefault()));
                if (a.Item14 != null && a.Item14 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item14, (float)a.Rating14.GetValueOrDefault()));
                if (a.Item15 != null && a.Item15 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item15, (float)a.Rating15.GetValueOrDefault()));
                if (a.Item16 != null && a.Item16 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item16, (float)a.Rating16.GetValueOrDefault()));
                if (a.Item17 != null && a.Item17 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item17, (float)a.Rating17.GetValueOrDefault()));
                if (a.Item18 != null && a.Item18 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item18, (float)a.Rating18.GetValueOrDefault()));
                if (a.Item19 != null && a.Item19 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item19, (float)a.Rating19.GetValueOrDefault()));
                if (a.Item20 != null && a.Item20 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item20, (float)a.Rating20.GetValueOrDefault()));
                if (a.Item21 != null && a.Item21 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item21, (float)a.Rating21.GetValueOrDefault()));
                if (a.Item22 != null && a.Item22 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item22, (float)a.Rating22.GetValueOrDefault()));
                if (a.Item23 != null && a.Item23 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item23, (float)a.Rating23.GetValueOrDefault()));
                if (a.Item24 != null && a.Item24 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item24, (float)a.Rating24.GetValueOrDefault()));
                if (a.Item25 != null && a.Item25 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item25, (float)a.Rating25.GetValueOrDefault()));
                if (a.Item26 != null && a.Item26 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item26, (float)a.Rating26.GetValueOrDefault()));
                if (a.Item27 != null && a.Item27 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item27, (float)a.Rating27.GetValueOrDefault()));
                if (a.Item28 != null && a.Item28 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item28, (float)a.Rating28.GetValueOrDefault()));
                if (a.Item29 != null && a.Item29 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item29, (float)a.Rating29.GetValueOrDefault()));
                if (a.Item30 != null && a.Item30 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item30, (float)a.Rating30.GetValueOrDefault()));
                if (a.Item31 != null && a.Item31 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item31, (float)a.Rating31.GetValueOrDefault()));
                if (a.Item32 != null && a.Item32 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item32, (float)a.Rating32.GetValueOrDefault()));
                if (a.Item33 != null && a.Item33 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item33, (float)a.Rating33.GetValueOrDefault()));
                if (a.Item34 != null && a.Item34 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item34, (float)a.Rating34.GetValueOrDefault()));
                if (a.Item35 != null && a.Item35 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item35, (float)a.Rating35.GetValueOrDefault()));
                if (a.Item36 != null && a.Item36 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item36, (float)a.Rating36.GetValueOrDefault()));
                if (a.Item37 != null && a.Item37 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item37, (float)a.Rating37.GetValueOrDefault()));
                if (a.Item38 != null && a.Item38 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item38, (float)a.Rating38.GetValueOrDefault()));
                if (a.Item39 != null && a.Item39 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item39, (float)a.Rating39.GetValueOrDefault()));
                if (a.Item40 != null && a.Item40 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item40, (float)a.Rating40.GetValueOrDefault()));
                if (a.Item41 != null && a.Item41 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item41, (float)a.Rating41.GetValueOrDefault()));
                if (a.Item42 != null && a.Item42 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item42, (float)a.Rating42.GetValueOrDefault()));
                if (a.Item43 != null && a.Item43 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item43, (float)a.Rating43.GetValueOrDefault()));
                if (a.Item44 != null && a.Item44 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item44, (float)a.Rating44.GetValueOrDefault()));
                if (a.Item45 != null && a.Item45 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item45, (float)a.Rating45.GetValueOrDefault()));
                if (a.Item46 != null && a.Item46 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item46, (float)a.Rating46.GetValueOrDefault()));
                if (a.Item47 != null && a.Item47 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item47, (float)a.Rating47.GetValueOrDefault()));
                if (a.Item48 != null && a.Item48 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item48, (float)a.Rating48.GetValueOrDefault()));
                if (a.Item49 != null && a.Item49 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item49, (float)a.Rating49.GetValueOrDefault()));
                if (a.Item50 != null && a.Item50 != string.Empty)
                    recommendedItems.Items.Add(new ItemRating(a.Item50, (float)a.Rating50.GetValueOrDefault()));
                recommendedItemsesSpmNotPurchased.Add(recommendedItems);
            }

            EnsembleRecommendationService ensembleRecommendation = new EnsembleRecommendationService();
            List<WeightAccuracyNrec> weightAccuracys = new List<WeightAccuracyNrec>();

           // int purchaseWeight = 0;
           for (int purchaseWeight = 20; purchaseWeight <= 100; purchaseWeight+=5)
           {
               //int collaborativeNotPurcasedWeight = 0;
                for (int collaborativeNotPurcasedWeight = 5; collaborativeNotPurcasedWeight <= 40; collaborativeNotPurcasedWeight+=5)
                {
                    for (int spmPurchasedWeight = 50; spmPurchasedWeight <= 100; spmPurchasedWeight += 5)
                    {
                        for (int spmNotPurchasedWeight = 5; spmNotPurchasedWeight <= 40; spmNotPurchasedWeight += 5)
                        {
                            List<RecommendedItems> recommendedItemsList = ensembleRecommendation.RecommendOptimized(
                                recommendeditemsPurchaseFrequency,
                                RecommendeditemsCollaborativeNotPurchased,
                                recommendedItemsesSpmPurchased,
                                recommendedItemsesSpmNotPurchased,
                                ((float)purchaseWeight ), (float)collaborativeNotPurcasedWeight ,
                                (float)spmPurchasedWeight , (float)spmNotPurchasedWeight , recommendationNumber);
                            AccuracyNrec accuracyNrec = CalculateAccuracy(recommendationNumber, recommendedItemsList, purchasesAllTest);

                            WeightAccuracyNrec weightAccuracy = new WeightAccuracyNrec();
                            weightAccuracy.PurchaseWeight = purchaseWeight;
                            weightAccuracy.CollaborativeNotPurcasedWeight = collaborativeNotPurcasedWeight;
                            weightAccuracy.SpmPurchasedWeight = spmPurchasedWeight;
                            weightAccuracy.SpmNotPurchasedWeight = spmNotPurchasedWeight;
                            weightAccuracy.AccuracyNrec = accuracyNrec;
                            weightAccuracys.Add(weightAccuracy);
                        }
                    }
                    System.Diagnostics.Debug.WriteLine("collaborativeNotPurcasedWeight: " + collaborativeNotPurcasedWeight + " : " + DateTime.Now.TimeOfDay);
                }
            }
            return View(weightAccuracys);
        }

        private AccuracyNrec CalculateAccuracy(int recommendationNumber, List<RecommendedItems> recommendedItemsList, IList<UserItemPurchase> purchasesAll)
        {
            //Select purchases that recoemnded item for them

            //List<int> recomendationUsers = _dbContext.EnsembleRecommendation.Select(a => a.UserId).Distinct().ToList();
            List<int> recomendationUsers = recommendedItemsList.Select(a => a.User).Distinct().ToList();
            // IList<UserItemPurchase> purchases = purchasesAll.Where(a => recomendationUsers.Contains(a.User)).ToList();
            IList<UserItemPurchase> purchases = purchasesAll.ToList();

            //Select recommendations which the user bought something
            List<int> purchaseUsers = purchases.Select(a => a.User).Distinct().ToList();

            IList<UserItemlist> recommendations5 = recommendedItemsList
                .Where(a => purchaseUsers.Contains(a.User))
                .Select(a => new UserItemlist
                {
                    UserId = a.User,
                    Items = a.Items.OrderByDescending(b => b.Rating).Take(5).Select(c => c.ItemId).ToList()
                }).ToList();

            IList<UserItemlist> recommendations10 = recommendedItemsList
                .Where(a => purchaseUsers.Contains(a.User))
                .Select(a => new UserItemlist
                {
                    UserId = a.User,
                    Items = a.Items.OrderByDescending(b => b.Rating).Take(10).Select(c => c.ItemId).ToList()
                }).ToList();

            IList<UserItemlist> recommendations20 = recommendedItemsList
                .Where(a => purchaseUsers.Contains(a.User))
                .Select(a => new UserItemlist
                {
                    UserId = a.User,
                    Items = a.Items.OrderByDescending(b => b.Rating).Take(20).Select(c => c.ItemId).ToList()
                }).ToList();

            IList<UserItemlist> recommendations50 = recommendedItemsList
                .Where(a => purchaseUsers.Contains(a.User))
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