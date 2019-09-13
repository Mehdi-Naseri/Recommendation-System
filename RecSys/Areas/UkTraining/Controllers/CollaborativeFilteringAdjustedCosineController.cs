using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecSys.Data;
using RecSys.Models;
using RecSys.ViewModels;

using RecSys.Functions;

namespace RecSys.Areas.UkTraining.Controllers
{
    [Area("UkTraining")]
    public class CollaborativeFilteringAdjustedCosineController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaborativeFilteringAdjustedCosineController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Recommendations(float kPercentage, int recommendationNumber, DateTime startDate, DateTime endDate)
        {
            /*************************************************************************************/
            //    Sample test data
            /*************************************************************************************/
            //List<UserItemPurchase> userItemPurchasesSample = new List<UserItemPurchase>();

            //userItemPurchasesSample.Add(new UserItemPurchase(1, "item1"));
            //userItemPurchasesSample.Add(new UserItemPurchase(1, "item2"));
            //userItemPurchasesSample.Add(new UserItemPurchase(1, "item2"));
            //userItemPurchasesSample.Add(new UserItemPurchase(1, "item3"));
            //userItemPurchasesSample.Add(new UserItemPurchase(1, "item3"));
            //userItemPurchasesSample.Add(new UserItemPurchase(1, "item3"));
            //userItemPurchasesSample.Add(new UserItemPurchase(2, "item1"));
            //userItemPurchasesSample.Add(new UserItemPurchase(2, "item1"));
            //userItemPurchasesSample.Add(new UserItemPurchase(2, "item1"));
            //userItemPurchasesSample.Add(new UserItemPurchase(2, "item2"));
            //userItemPurchasesSample.Add(new UserItemPurchase(3, "item2"));
            //userItemPurchasesSample.Add(new UserItemPurchase(3, "item2"));
            //userItemPurchasesSample.Add(new UserItemPurchase(3, "item3"));

            //IEnumerable<UserItemPurchase> userItemPurchases = userItemPurchasesSample;

            /*************************************************************************************/
            //    Run KNN item based similarity
            /*************************************************************************************/
            //        IEnumerable<UserItemPurchase> userItemPurchases = _dbContext.UkRetailOriginalSales
            //.Where(a => a.InvoiceDate >= startDate && a.InvoiceDate <= endDate && a.CustomerID != null && (string.Compare(a.StockCode, "20000") <= 0))
            //.Select(a => new UserItemPurchase { User = a.CustomerID.GetValueOrDefault(), Item = a.StockCode });

            //K is number of similar users
            //K is number of similar users
            IList<UserItemPurchase> userItemPurchases = _dbContext.UkRetailOriginalSales
                .Where(a => a.InvoiceDate.Date >= startDate.Date && a.InvoiceDate.Date <= endDate.Date &&
                            a.CustomerID != null && a.CustomerID < 12350 && a.Quantity > 0 &&
                            string.Compare(a.StockCode, "a") == -1)
                .Select(a => new UserItemPurchase { User = a.CustomerID.GetValueOrDefault(), Item = a.StockCode }).ToList();
            List<List<RecommendedItems>> recommendedItemsList3CfTypes = new List<List<RecommendedItems>>();
            CollaborativeFiltering collaborativeFiltering = new CollaborativeFiltering();
            int kValue = Convert.ToInt32(Math.Floor((kPercentage / 100) * userItemPurchases.Select(a => a.User).Distinct().Count()));
            recommendedItemsList3CfTypes = collaborativeFiltering.Recommend3CfTypesAdjustedCosine(userItemPurchases, kValue, recommendationNumber);

            SavetoDatabase(recommendedItemsList3CfTypes);
            /*************************************************************************************/
            //    Dispaly results
            /*************************************************************************************/
            return View(recommendedItemsList3CfTypes);
        }

        private void SavetoDatabase(List<List<RecommendedItems>> recommendedItemsList3CfTypes)
        {
            int recInfoid = _dbContext.RecommendationInfo.First(a => string.Equals(a.RecName, "Cf10MonthAdjusted")).RecId;
            //Clean CF11Month table
            _dbContext.Recommendation.RemoveRange(_dbContext.Recommendation.Where(r => r.RecommendationInfoId == recInfoid));
            //Save CF recommended items
            foreach (RecommendedItems recommendedItem in recommendedItemsList3CfTypes[0])
            {
                Recommendation recommendation = new Recommendation();
                recommendation.RecommendationInfoId = recInfoid;
                recommendation.UserId = recommendedItem.User;
                try
                {
                    if (recommendedItem.Items[0].ItemId != null)
                    {
                        recommendation.Item1 = string.Copy(recommendedItem.Items[0].ItemId);
                        recommendation.Rating1 = recommendedItem.Items[0].Rating;
                    }
                    if (recommendedItem.Items[1].ItemId != null)
                    {
                        recommendation.Item2 = string.Copy(recommendedItem.Items[1].ItemId);
                        recommendation.Rating2 = recommendedItem.Items[1].Rating;
                    }
                    if (recommendedItem.Items[2].ItemId != null)
                    {
                        recommendation.Item3 = string.Copy(recommendedItem.Items[2].ItemId);
                        recommendation.Rating3 = recommendedItem.Items[2].Rating;
                    }
                    if (recommendedItem.Items[3].ItemId != null)
                    {
                        recommendation.Item4 = string.Copy(recommendedItem.Items[3].ItemId);
                        recommendation.Rating4 = recommendedItem.Items[3].Rating;
                    }
                    if (recommendedItem.Items[4].ItemId != null)
                    {
                        recommendation.Item5 = string.Copy(recommendedItem.Items[4].ItemId);
                        recommendation.Rating5 = recommendedItem.Items[4].Rating;
                    }
                    if (recommendedItem.Items[5].ItemId != null)
                    {
                        recommendation.Item6 = string.Copy(recommendedItem.Items[5].ItemId);
                        recommendation.Rating6 = recommendedItem.Items[5].Rating;
                    }
                    if (recommendedItem.Items[6].ItemId != null)
                    {
                        recommendation.Item7 = string.Copy(recommendedItem.Items[6].ItemId);
                        recommendation.Rating7 = recommendedItem.Items[6].Rating;
                    }
                    if (recommendedItem.Items[7].ItemId != null)
                    {
                        recommendation.Item8 = string.Copy(recommendedItem.Items[7].ItemId);
                        recommendation.Rating8 = recommendedItem.Items[7].Rating;
                    }
                    if (recommendedItem.Items[8].ItemId != null)
                    {
                        recommendation.Item9 = string.Copy(recommendedItem.Items[8].ItemId);
                        recommendation.Rating9 = recommendedItem.Items[8].Rating;
                    }
                    if (recommendedItem.Items[9].ItemId != null)
                    {
                        recommendation.Item10 = string.Copy(recommendedItem.Items[9].ItemId);
                        recommendation.Rating10 = recommendedItem.Items[9].Rating;
                    }
                    if (recommendedItem.Items[10].ItemId != null)
                    {
                        recommendation.Item11 = string.Copy(recommendedItem.Items[10].ItemId);
                        recommendation.Rating11 = recommendedItem.Items[10].Rating;
                    }
                    if (recommendedItem.Items[11].ItemId != null)
                    {
                        recommendation.Item12 = string.Copy(recommendedItem.Items[11].ItemId);
                        recommendation.Rating12 = recommendedItem.Items[11].Rating;
                    }
                    if (recommendedItem.Items[12].ItemId != null)
                    {
                        recommendation.Item13 = string.Copy(recommendedItem.Items[12].ItemId);
                        recommendation.Rating13 = recommendedItem.Items[12].Rating;
                    }
                    if (recommendedItem.Items[13].ItemId != null)
                    {
                        recommendation.Item14 = string.Copy(recommendedItem.Items[13].ItemId);
                        recommendation.Rating14 = recommendedItem.Items[13].Rating;
                    }
                    if (recommendedItem.Items[14].ItemId != null)
                    {
                        recommendation.Item15 = string.Copy(recommendedItem.Items[14].ItemId);
                        recommendation.Rating15 = recommendedItem.Items[14].Rating;
                    }
                    if (recommendedItem.Items[15].ItemId != null)
                    {
                        recommendation.Item16 = string.Copy(recommendedItem.Items[15].ItemId);
                        recommendation.Rating16 = recommendedItem.Items[15].Rating;
                    }
                    if (recommendedItem.Items[16].ItemId != null)
                    {
                        recommendation.Item17 = string.Copy(recommendedItem.Items[16].ItemId);
                        recommendation.Rating17 = recommendedItem.Items[16].Rating;
                    }
                    if (recommendedItem.Items[17].ItemId != null)
                    {
                        recommendation.Item18 = string.Copy(recommendedItem.Items[17].ItemId);
                        recommendation.Rating18 = recommendedItem.Items[17].Rating;
                    }
                    if (recommendedItem.Items[18].ItemId != null)
                    {
                        recommendation.Item19 = string.Copy(recommendedItem.Items[18].ItemId);
                        recommendation.Rating19 = recommendedItem.Items[18].Rating;
                    }
                    if (recommendedItem.Items[19].ItemId != null)
                    {
                        recommendation.Item20 = string.Copy(recommendedItem.Items[19].ItemId);
                        recommendation.Rating20 = recommendedItem.Items[19].Rating;
                    }
                    if (recommendedItem.Items[20].ItemId != null)
                    {
                        recommendation.Item21 = string.Copy(recommendedItem.Items[20].ItemId);
                        recommendation.Rating21 = recommendedItem.Items[20].Rating;
                    }
                    if (recommendedItem.Items[21].ItemId != null)
                    {
                        recommendation.Item22 = string.Copy(recommendedItem.Items[21].ItemId);
                        recommendation.Rating22 = recommendedItem.Items[21].Rating;
                    }
                    if (recommendedItem.Items[22].ItemId != null)
                    {
                        recommendation.Item23 = string.Copy(recommendedItem.Items[22].ItemId);
                        recommendation.Rating23 = recommendedItem.Items[22].Rating;
                    }
                    if (recommendedItem.Items[23].ItemId != null)
                    {
                        recommendation.Item24 = string.Copy(recommendedItem.Items[23].ItemId);
                        recommendation.Rating24 = recommendedItem.Items[23].Rating;
                    }
                    if (recommendedItem.Items[24].ItemId != null)
                    {
                        recommendation.Item25 = string.Copy(recommendedItem.Items[24].ItemId);
                        recommendation.Rating25 = recommendedItem.Items[24].Rating;
                    }
                    if (recommendedItem.Items[25].ItemId != null)
                    {
                        recommendation.Item26 = string.Copy(recommendedItem.Items[25].ItemId);
                        recommendation.Rating26 = recommendedItem.Items[25].Rating;
                    }
                    if (recommendedItem.Items[26].ItemId != null)
                    {
                        recommendation.Item27 = string.Copy(recommendedItem.Items[26].ItemId);
                        recommendation.Rating27 = recommendedItem.Items[26].Rating;
                    }
                    if (recommendedItem.Items[27].ItemId != null)
                    {
                        recommendation.Item28 = string.Copy(recommendedItem.Items[27].ItemId);
                        recommendation.Rating28 = recommendedItem.Items[27].Rating;
                    }
                    if (recommendedItem.Items[28].ItemId != null)
                    {
                        recommendation.Item29 = string.Copy(recommendedItem.Items[28].ItemId);
                        recommendation.Rating29 = recommendedItem.Items[28].Rating;
                    }
                    if (recommendedItem.Items[29].ItemId != null)
                    {
                        recommendation.Item30 = string.Copy(recommendedItem.Items[29].ItemId);
                        recommendation.Rating30 = recommendedItem.Items[29].Rating;
                    }
                    if (recommendedItem.Items[30].ItemId != null)
                    {
                        recommendation.Item31 = string.Copy(recommendedItem.Items[30].ItemId);
                        recommendation.Rating31 = recommendedItem.Items[30].Rating;
                    }
                    if (recommendedItem.Items[31].ItemId != null)
                    {
                        recommendation.Item32 = string.Copy(recommendedItem.Items[31].ItemId);
                        recommendation.Rating32 = recommendedItem.Items[31].Rating;
                    }
                    if (recommendedItem.Items[32].ItemId != null)
                    {
                        recommendation.Item33 = string.Copy(recommendedItem.Items[32].ItemId);
                        recommendation.Rating33 = recommendedItem.Items[32].Rating;
                    }
                    if (recommendedItem.Items[33].ItemId != null)
                    {
                        recommendation.Item34 = string.Copy(recommendedItem.Items[33].ItemId);
                        recommendation.Rating34 = recommendedItem.Items[33].Rating;
                    }
                    if (recommendedItem.Items[34].ItemId != null)
                    {
                        recommendation.Item35 = string.Copy(recommendedItem.Items[34].ItemId);
                        recommendation.Rating35 = recommendedItem.Items[34].Rating;
                    }
                    if (recommendedItem.Items[35].ItemId != null)
                    {
                        recommendation.Item36 = string.Copy(recommendedItem.Items[35].ItemId);
                        recommendation.Rating36 = recommendedItem.Items[35].Rating;
                    }
                    if (recommendedItem.Items[36].ItemId != null)
                    {
                        recommendation.Item37 = string.Copy(recommendedItem.Items[36].ItemId);
                        recommendation.Rating37 = recommendedItem.Items[36].Rating;
                    }
                    if (recommendedItem.Items[37].ItemId != null)
                    {
                        recommendation.Item38 = string.Copy(recommendedItem.Items[37].ItemId);
                        recommendation.Rating38 = recommendedItem.Items[37].Rating;
                    }
                    if (recommendedItem.Items[38].ItemId != null)
                    {
                        recommendation.Item39 = string.Copy(recommendedItem.Items[38].ItemId);
                        recommendation.Rating39 = recommendedItem.Items[38].Rating;
                    }
                    if (recommendedItem.Items[39].ItemId != null)
                    {
                        recommendation.Item40 = string.Copy(recommendedItem.Items[39].ItemId);
                        recommendation.Rating40 = recommendedItem.Items[39].Rating;
                    }
                    if (recommendedItem.Items[40].ItemId != null)
                    {
                        recommendation.Item41 = string.Copy(recommendedItem.Items[40].ItemId);
                        recommendation.Rating41 = recommendedItem.Items[40].Rating;
                    }
                    if (recommendedItem.Items[41].ItemId != null)
                    {
                        recommendation.Item42 = string.Copy(recommendedItem.Items[41].ItemId);
                        recommendation.Rating42 = recommendedItem.Items[41].Rating;
                    }
                    if (recommendedItem.Items[42].ItemId != null)
                    {
                        recommendation.Item43 = string.Copy(recommendedItem.Items[42].ItemId);
                        recommendation.Rating43 = recommendedItem.Items[42].Rating;
                    }
                    if (recommendedItem.Items[43].ItemId != null)
                    {
                        recommendation.Item44 = string.Copy(recommendedItem.Items[43].ItemId);
                        recommendation.Rating44 = recommendedItem.Items[43].Rating;
                    }
                    if (recommendedItem.Items[44].ItemId != null)
                    {
                        recommendation.Item45 = string.Copy(recommendedItem.Items[44].ItemId);
                        recommendation.Rating45 = recommendedItem.Items[44].Rating;
                    }
                    if (recommendedItem.Items[45].ItemId != null)
                    {
                        recommendation.Item46 = string.Copy(recommendedItem.Items[45].ItemId);
                        recommendation.Rating46 = recommendedItem.Items[45].Rating;
                    }
                    if (recommendedItem.Items[46].ItemId != null)
                    {
                        recommendation.Item47 = string.Copy(recommendedItem.Items[46].ItemId);
                        recommendation.Rating47 = recommendedItem.Items[46].Rating;
                    }
                    if (recommendedItem.Items[47].ItemId != null)
                    {
                        recommendation.Item48 = string.Copy(recommendedItem.Items[47].ItemId);
                        recommendation.Rating48 = recommendedItem.Items[47].Rating;
                    }
                    if (recommendedItem.Items[48].ItemId != null)
                    {
                        recommendation.Item49 = string.Copy(recommendedItem.Items[48].ItemId);
                        recommendation.Rating49 = recommendedItem.Items[48].Rating;
                    }
                    if (recommendedItem.Items[49].ItemId != null)
                    {
                        recommendation.Item50 = string.Copy(recommendedItem.Items[49].ItemId);
                        recommendation.Rating50 = recommendedItem.Items[49].Rating;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {

                }
                _dbContext.Recommendation.Add(recommendation);
            }


            recInfoid = _dbContext.RecommendationInfo.First(a => string.Equals(a.RecName, "PurchaseFrequency10MonthAdjusted")).RecId;
            //Clean table
            _dbContext.Recommendation.RemoveRange(_dbContext.Recommendation.Where(r => r.RecommendationInfoId == recInfoid));
            //Save Purchase Frequency recommended items
            foreach (RecommendedItems recommendedItem in recommendedItemsList3CfTypes[1])
            {
                Recommendation recommendation = new Recommendation();
                recommendation.RecommendationInfoId = recInfoid;
                recommendation.UserId = recommendedItem.User;
                try
                {
                    if (recommendedItem.Items[0].ItemId != null)
                    {
                        recommendation.Item1 = string.Copy(recommendedItem.Items[0].ItemId);
                        recommendation.Rating1 = recommendedItem.Items[0].Rating;
                    }
                    if (recommendedItem.Items[1].ItemId != null)
                    {
                        recommendation.Item2 = string.Copy(recommendedItem.Items[1].ItemId);
                        recommendation.Rating2 = recommendedItem.Items[1].Rating;
                    }
                    if (recommendedItem.Items[2].ItemId != null)
                    {
                        recommendation.Item3 = string.Copy(recommendedItem.Items[2].ItemId);
                        recommendation.Rating3 = recommendedItem.Items[2].Rating;
                    }
                    if (recommendedItem.Items[3].ItemId != null)
                    {
                        recommendation.Item4 = string.Copy(recommendedItem.Items[3].ItemId);
                        recommendation.Rating4 = recommendedItem.Items[3].Rating;
                    }
                    if (recommendedItem.Items[4].ItemId != null)
                    {
                        recommendation.Item5 = string.Copy(recommendedItem.Items[4].ItemId);
                        recommendation.Rating5 = recommendedItem.Items[4].Rating;
                    }
                    if (recommendedItem.Items[5].ItemId != null)
                    {
                        recommendation.Item6 = string.Copy(recommendedItem.Items[5].ItemId);
                        recommendation.Rating6 = recommendedItem.Items[5].Rating;
                    }
                    if (recommendedItem.Items[6].ItemId != null)
                    {
                        recommendation.Item7 = string.Copy(recommendedItem.Items[6].ItemId);
                        recommendation.Rating7 = recommendedItem.Items[6].Rating;
                    }
                    if (recommendedItem.Items[7].ItemId != null)
                    {
                        recommendation.Item8 = string.Copy(recommendedItem.Items[7].ItemId);
                        recommendation.Rating8 = recommendedItem.Items[7].Rating;
                    }
                    if (recommendedItem.Items[8].ItemId != null)
                    {
                        recommendation.Item9 = string.Copy(recommendedItem.Items[8].ItemId);
                        recommendation.Rating9 = recommendedItem.Items[8].Rating;
                    }
                    if (recommendedItem.Items[9].ItemId != null)
                    {
                        recommendation.Item10 = string.Copy(recommendedItem.Items[9].ItemId);
                        recommendation.Rating10 = recommendedItem.Items[9].Rating;
                    }
                    if (recommendedItem.Items[10].ItemId != null)
                    {
                        recommendation.Item11 = string.Copy(recommendedItem.Items[10].ItemId);
                        recommendation.Rating11 = recommendedItem.Items[10].Rating;
                    }
                    if (recommendedItem.Items[11].ItemId != null)
                    {
                        recommendation.Item12 = string.Copy(recommendedItem.Items[11].ItemId);
                        recommendation.Rating12 = recommendedItem.Items[11].Rating;
                    }
                    if (recommendedItem.Items[12].ItemId != null)
                    {
                        recommendation.Item13 = string.Copy(recommendedItem.Items[12].ItemId);
                        recommendation.Rating13 = recommendedItem.Items[12].Rating;
                    }
                    if (recommendedItem.Items[13].ItemId != null)
                    {
                        recommendation.Item14 = string.Copy(recommendedItem.Items[13].ItemId);
                        recommendation.Rating14 = recommendedItem.Items[13].Rating;
                    }
                    if (recommendedItem.Items[14].ItemId != null)
                    {
                        recommendation.Item15 = string.Copy(recommendedItem.Items[14].ItemId);
                        recommendation.Rating15 = recommendedItem.Items[14].Rating;
                    }
                    if (recommendedItem.Items[15].ItemId != null)
                    {
                        recommendation.Item16 = string.Copy(recommendedItem.Items[15].ItemId);
                        recommendation.Rating16 = recommendedItem.Items[15].Rating;
                    }
                    if (recommendedItem.Items[16].ItemId != null)
                    {
                        recommendation.Item17 = string.Copy(recommendedItem.Items[16].ItemId);
                        recommendation.Rating17 = recommendedItem.Items[16].Rating;
                    }
                    if (recommendedItem.Items[17].ItemId != null)
                    {
                        recommendation.Item18 = string.Copy(recommendedItem.Items[17].ItemId);
                        recommendation.Rating18 = recommendedItem.Items[17].Rating;
                    }
                    if (recommendedItem.Items[18].ItemId != null)
                    {
                        recommendation.Item19 = string.Copy(recommendedItem.Items[18].ItemId);
                        recommendation.Rating19 = recommendedItem.Items[18].Rating;
                    }
                    if (recommendedItem.Items[19].ItemId != null)
                    {
                        recommendation.Item20 = string.Copy(recommendedItem.Items[19].ItemId);
                        recommendation.Rating20 = recommendedItem.Items[19].Rating;
                    }
                    if (recommendedItem.Items[20].ItemId != null)
                    {
                        recommendation.Item21 = string.Copy(recommendedItem.Items[20].ItemId);
                        recommendation.Rating21 = recommendedItem.Items[20].Rating;
                    }
                    if (recommendedItem.Items[21].ItemId != null)
                    {
                        recommendation.Item22 = string.Copy(recommendedItem.Items[21].ItemId);
                        recommendation.Rating22 = recommendedItem.Items[21].Rating;
                    }
                    if (recommendedItem.Items[22].ItemId != null)
                    {
                        recommendation.Item23 = string.Copy(recommendedItem.Items[22].ItemId);
                        recommendation.Rating23 = recommendedItem.Items[22].Rating;
                    }
                    if (recommendedItem.Items[23].ItemId != null)
                    {
                        recommendation.Item24 = string.Copy(recommendedItem.Items[23].ItemId);
                        recommendation.Rating24 = recommendedItem.Items[23].Rating;
                    }
                    if (recommendedItem.Items[24].ItemId != null)
                    {
                        recommendation.Item25 = string.Copy(recommendedItem.Items[24].ItemId);
                        recommendation.Rating25 = recommendedItem.Items[24].Rating;
                    }
                    if (recommendedItem.Items[25].ItemId != null)
                    {
                        recommendation.Item26 = string.Copy(recommendedItem.Items[25].ItemId);
                        recommendation.Rating26 = recommendedItem.Items[25].Rating;
                    }
                    if (recommendedItem.Items[26].ItemId != null)
                    {
                        recommendation.Item27 = string.Copy(recommendedItem.Items[26].ItemId);
                        recommendation.Rating27 = recommendedItem.Items[26].Rating;
                    }
                    if (recommendedItem.Items[27].ItemId != null)
                    {
                        recommendation.Item28 = string.Copy(recommendedItem.Items[27].ItemId);
                        recommendation.Rating28 = recommendedItem.Items[27].Rating;
                    }
                    if (recommendedItem.Items[28].ItemId != null)
                    {
                        recommendation.Item29 = string.Copy(recommendedItem.Items[28].ItemId);
                        recommendation.Rating29 = recommendedItem.Items[28].Rating;
                    }
                    if (recommendedItem.Items[29].ItemId != null)
                    {
                        recommendation.Item30 = string.Copy(recommendedItem.Items[29].ItemId);
                        recommendation.Rating30 = recommendedItem.Items[29].Rating;
                    }
                    if (recommendedItem.Items[30].ItemId != null)
                    {
                        recommendation.Item31 = string.Copy(recommendedItem.Items[30].ItemId);
                        recommendation.Rating31 = recommendedItem.Items[30].Rating;
                    }
                    if (recommendedItem.Items[31].ItemId != null)
                    {
                        recommendation.Item32 = string.Copy(recommendedItem.Items[31].ItemId);
                        recommendation.Rating32 = recommendedItem.Items[31].Rating;
                    }
                    if (recommendedItem.Items[32].ItemId != null)
                    {
                        recommendation.Item33 = string.Copy(recommendedItem.Items[32].ItemId);
                        recommendation.Rating33 = recommendedItem.Items[32].Rating;
                    }
                    if (recommendedItem.Items[33].ItemId != null)
                    {
                        recommendation.Item34 = string.Copy(recommendedItem.Items[33].ItemId);
                        recommendation.Rating34 = recommendedItem.Items[33].Rating;
                    }
                    if (recommendedItem.Items[34].ItemId != null)
                    {
                        recommendation.Item35 = string.Copy(recommendedItem.Items[34].ItemId);
                        recommendation.Rating35 = recommendedItem.Items[34].Rating;
                    }
                    if (recommendedItem.Items[35].ItemId != null)
                    {
                        recommendation.Item36 = string.Copy(recommendedItem.Items[35].ItemId);
                        recommendation.Rating36 = recommendedItem.Items[35].Rating;
                    }
                    if (recommendedItem.Items[36].ItemId != null)
                    {
                        recommendation.Item37 = string.Copy(recommendedItem.Items[36].ItemId);
                        recommendation.Rating37 = recommendedItem.Items[36].Rating;
                    }
                    if (recommendedItem.Items[37].ItemId != null)
                    {
                        recommendation.Item38 = string.Copy(recommendedItem.Items[37].ItemId);
                        recommendation.Rating38 = recommendedItem.Items[37].Rating;
                    }
                    if (recommendedItem.Items[38].ItemId != null)
                    {
                        recommendation.Item39 = string.Copy(recommendedItem.Items[38].ItemId);
                        recommendation.Rating39 = recommendedItem.Items[38].Rating;
                    }
                    if (recommendedItem.Items[39].ItemId != null)
                    {
                        recommendation.Item40 = string.Copy(recommendedItem.Items[39].ItemId);
                        recommendation.Rating40 = recommendedItem.Items[39].Rating;
                    }
                    if (recommendedItem.Items[40].ItemId != null)
                    {
                        recommendation.Item41 = string.Copy(recommendedItem.Items[40].ItemId);
                        recommendation.Rating41 = recommendedItem.Items[40].Rating;
                    }
                    if (recommendedItem.Items[41].ItemId != null)
                    {
                        recommendation.Item42 = string.Copy(recommendedItem.Items[41].ItemId);
                        recommendation.Rating42 = recommendedItem.Items[41].Rating;
                    }
                    if (recommendedItem.Items[42].ItemId != null)
                    {
                        recommendation.Item43 = string.Copy(recommendedItem.Items[42].ItemId);
                        recommendation.Rating43 = recommendedItem.Items[42].Rating;
                    }
                    if (recommendedItem.Items[43].ItemId != null)
                    {
                        recommendation.Item44 = string.Copy(recommendedItem.Items[43].ItemId);
                        recommendation.Rating44 = recommendedItem.Items[43].Rating;
                    }
                    if (recommendedItem.Items[44].ItemId != null)
                    {
                        recommendation.Item45 = string.Copy(recommendedItem.Items[44].ItemId);
                        recommendation.Rating45 = recommendedItem.Items[44].Rating;
                    }
                    if (recommendedItem.Items[45].ItemId != null)
                    {
                        recommendation.Item46 = string.Copy(recommendedItem.Items[45].ItemId);
                        recommendation.Rating46 = recommendedItem.Items[45].Rating;
                    }
                    if (recommendedItem.Items[46].ItemId != null)
                    {
                        recommendation.Item47 = string.Copy(recommendedItem.Items[46].ItemId);
                        recommendation.Rating47 = recommendedItem.Items[46].Rating;
                    }
                    if (recommendedItem.Items[47].ItemId != null)
                    {
                        recommendation.Item48 = string.Copy(recommendedItem.Items[47].ItemId);
                        recommendation.Rating48 = recommendedItem.Items[47].Rating;
                    }
                    if (recommendedItem.Items[48].ItemId != null)
                    {
                        recommendation.Item49 = string.Copy(recommendedItem.Items[48].ItemId);
                        recommendation.Rating49 = recommendedItem.Items[48].Rating;
                    }
                    if (recommendedItem.Items[49].ItemId != null)
                    {
                        recommendation.Item50 = string.Copy(recommendedItem.Items[49].ItemId);
                        recommendation.Rating50 = recommendedItem.Items[49].Rating;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {

                }
                _dbContext.Recommendation.Add(recommendation);
            }


            recInfoid = _dbContext.RecommendationInfo.First(a => string.Equals(a.RecName, "CfNotPurchased10MonthAdjusted")).RecId;
            //Clean CfNotPurchased11Month table
            _dbContext.Recommendation.RemoveRange(_dbContext.Recommendation.Where(r => r.RecommendationInfoId == recInfoid));
            //Save CF not purchased recommended items
            foreach (RecommendedItems recommendedItem in recommendedItemsList3CfTypes[1])
            {
                Recommendation recommendation = new Recommendation();
                recommendation.RecommendationInfoId = recInfoid;
                recommendation.UserId = recommendedItem.User;
                try
                {
                    if (recommendedItem.Items[0].ItemId != null)
                    {
                        recommendation.Item1 = string.Copy(recommendedItem.Items[0].ItemId);
                        recommendation.Rating1 = recommendedItem.Items[0].Rating;
                    }
                    if (recommendedItem.Items[1].ItemId != null)
                    {
                        recommendation.Item2 = string.Copy(recommendedItem.Items[1].ItemId);
                        recommendation.Rating2 = recommendedItem.Items[1].Rating;
                    }
                    if (recommendedItem.Items[2].ItemId != null)
                    {
                        recommendation.Item3 = string.Copy(recommendedItem.Items[2].ItemId);
                        recommendation.Rating3 = recommendedItem.Items[2].Rating;
                    }
                    if (recommendedItem.Items[3].ItemId != null)
                    {
                        recommendation.Item4 = string.Copy(recommendedItem.Items[3].ItemId);
                        recommendation.Rating4 = recommendedItem.Items[3].Rating;
                    }
                    if (recommendedItem.Items[4].ItemId != null)
                    {
                        recommendation.Item5 = string.Copy(recommendedItem.Items[4].ItemId);
                        recommendation.Rating5 = recommendedItem.Items[4].Rating;
                    }
                    if (recommendedItem.Items[5].ItemId != null)
                    {
                        recommendation.Item6 = string.Copy(recommendedItem.Items[5].ItemId);
                        recommendation.Rating6 = recommendedItem.Items[5].Rating;
                    }
                    if (recommendedItem.Items[6].ItemId != null)
                    {
                        recommendation.Item7 = string.Copy(recommendedItem.Items[6].ItemId);
                        recommendation.Rating7 = recommendedItem.Items[6].Rating;
                    }
                    if (recommendedItem.Items[7].ItemId != null)
                    {
                        recommendation.Item8 = string.Copy(recommendedItem.Items[7].ItemId);
                        recommendation.Rating8 = recommendedItem.Items[7].Rating;
                    }
                    if (recommendedItem.Items[8].ItemId != null)
                    {
                        recommendation.Item9 = string.Copy(recommendedItem.Items[8].ItemId);
                        recommendation.Rating9 = recommendedItem.Items[8].Rating;
                    }
                    if (recommendedItem.Items[9].ItemId != null)
                    {
                        recommendation.Item10 = string.Copy(recommendedItem.Items[9].ItemId);
                        recommendation.Rating10 = recommendedItem.Items[9].Rating;
                    }
                    if (recommendedItem.Items[10].ItemId != null)
                    {
                        recommendation.Item11 = string.Copy(recommendedItem.Items[10].ItemId);
                        recommendation.Rating11 = recommendedItem.Items[10].Rating;
                    }
                    if (recommendedItem.Items[11].ItemId != null)
                    {
                        recommendation.Item12 = string.Copy(recommendedItem.Items[11].ItemId);
                        recommendation.Rating12 = recommendedItem.Items[11].Rating;
                    }
                    if (recommendedItem.Items[12].ItemId != null)
                    {
                        recommendation.Item13 = string.Copy(recommendedItem.Items[12].ItemId);
                        recommendation.Rating13 = recommendedItem.Items[12].Rating;
                    }
                    if (recommendedItem.Items[13].ItemId != null)
                    {
                        recommendation.Item14 = string.Copy(recommendedItem.Items[13].ItemId);
                        recommendation.Rating14 = recommendedItem.Items[13].Rating;
                    }
                    if (recommendedItem.Items[14].ItemId != null)
                    {
                        recommendation.Item15 = string.Copy(recommendedItem.Items[14].ItemId);
                        recommendation.Rating15 = recommendedItem.Items[14].Rating;
                    }
                    if (recommendedItem.Items[15].ItemId != null)
                    {
                        recommendation.Item16 = string.Copy(recommendedItem.Items[15].ItemId);
                        recommendation.Rating16 = recommendedItem.Items[15].Rating;
                    }
                    if (recommendedItem.Items[16].ItemId != null)
                    {
                        recommendation.Item17 = string.Copy(recommendedItem.Items[16].ItemId);
                        recommendation.Rating17 = recommendedItem.Items[16].Rating;
                    }
                    if (recommendedItem.Items[17].ItemId != null)
                    {
                        recommendation.Item18 = string.Copy(recommendedItem.Items[17].ItemId);
                        recommendation.Rating18 = recommendedItem.Items[17].Rating;
                    }
                    if (recommendedItem.Items[18].ItemId != null)
                    {
                        recommendation.Item19 = string.Copy(recommendedItem.Items[18].ItemId);
                        recommendation.Rating19 = recommendedItem.Items[18].Rating;
                    }
                    if (recommendedItem.Items[19].ItemId != null)
                    {
                        recommendation.Item20 = string.Copy(recommendedItem.Items[19].ItemId);
                        recommendation.Rating20 = recommendedItem.Items[19].Rating;
                    }
                    if (recommendedItem.Items[20].ItemId != null)
                    {
                        recommendation.Item21 = string.Copy(recommendedItem.Items[20].ItemId);
                        recommendation.Rating21 = recommendedItem.Items[20].Rating;
                    }
                    if (recommendedItem.Items[21].ItemId != null)
                    {
                        recommendation.Item22 = string.Copy(recommendedItem.Items[21].ItemId);
                        recommendation.Rating22 = recommendedItem.Items[21].Rating;
                    }
                    if (recommendedItem.Items[22].ItemId != null)
                    {
                        recommendation.Item23 = string.Copy(recommendedItem.Items[22].ItemId);
                        recommendation.Rating23 = recommendedItem.Items[22].Rating;
                    }
                    if (recommendedItem.Items[23].ItemId != null)
                    {
                        recommendation.Item24 = string.Copy(recommendedItem.Items[23].ItemId);
                        recommendation.Rating24 = recommendedItem.Items[23].Rating;
                    }
                    if (recommendedItem.Items[24].ItemId != null)
                    {
                        recommendation.Item25 = string.Copy(recommendedItem.Items[24].ItemId);
                        recommendation.Rating25 = recommendedItem.Items[24].Rating;
                    }
                    if (recommendedItem.Items[25].ItemId != null)
                    {
                        recommendation.Item26 = string.Copy(recommendedItem.Items[25].ItemId);
                        recommendation.Rating26 = recommendedItem.Items[25].Rating;
                    }
                    if (recommendedItem.Items[26].ItemId != null)
                    {
                        recommendation.Item27 = string.Copy(recommendedItem.Items[26].ItemId);
                        recommendation.Rating27 = recommendedItem.Items[26].Rating;
                    }
                    if (recommendedItem.Items[27].ItemId != null)
                    {
                        recommendation.Item28 = string.Copy(recommendedItem.Items[27].ItemId);
                        recommendation.Rating28 = recommendedItem.Items[27].Rating;
                    }
                    if (recommendedItem.Items[28].ItemId != null)
                    {
                        recommendation.Item29 = string.Copy(recommendedItem.Items[28].ItemId);
                        recommendation.Rating29 = recommendedItem.Items[28].Rating;
                    }
                    if (recommendedItem.Items[29].ItemId != null)
                    {
                        recommendation.Item30 = string.Copy(recommendedItem.Items[29].ItemId);
                        recommendation.Rating30 = recommendedItem.Items[29].Rating;
                    }
                    if (recommendedItem.Items[30].ItemId != null)
                    {
                        recommendation.Item31 = string.Copy(recommendedItem.Items[30].ItemId);
                        recommendation.Rating31 = recommendedItem.Items[30].Rating;
                    }
                    if (recommendedItem.Items[31].ItemId != null)
                    {
                        recommendation.Item32 = string.Copy(recommendedItem.Items[31].ItemId);
                        recommendation.Rating32 = recommendedItem.Items[31].Rating;
                    }
                    if (recommendedItem.Items[32].ItemId != null)
                    {
                        recommendation.Item33 = string.Copy(recommendedItem.Items[32].ItemId);
                        recommendation.Rating33 = recommendedItem.Items[32].Rating;
                    }
                    if (recommendedItem.Items[33].ItemId != null)
                    {
                        recommendation.Item34 = string.Copy(recommendedItem.Items[33].ItemId);
                        recommendation.Rating34 = recommendedItem.Items[33].Rating;
                    }
                    if (recommendedItem.Items[34].ItemId != null)
                    {
                        recommendation.Item35 = string.Copy(recommendedItem.Items[34].ItemId);
                        recommendation.Rating35 = recommendedItem.Items[34].Rating;
                    }
                    if (recommendedItem.Items[35].ItemId != null)
                    {
                        recommendation.Item36 = string.Copy(recommendedItem.Items[35].ItemId);
                        recommendation.Rating36 = recommendedItem.Items[35].Rating;
                    }
                    if (recommendedItem.Items[36].ItemId != null)
                    {
                        recommendation.Item37 = string.Copy(recommendedItem.Items[36].ItemId);
                        recommendation.Rating37 = recommendedItem.Items[36].Rating;
                    }
                    if (recommendedItem.Items[37].ItemId != null)
                    {
                        recommendation.Item38 = string.Copy(recommendedItem.Items[37].ItemId);
                        recommendation.Rating38 = recommendedItem.Items[37].Rating;
                    }
                    if (recommendedItem.Items[38].ItemId != null)
                    {
                        recommendation.Item39 = string.Copy(recommendedItem.Items[38].ItemId);
                        recommendation.Rating39 = recommendedItem.Items[38].Rating;
                    }
                    if (recommendedItem.Items[39].ItemId != null)
                    {
                        recommendation.Item40 = string.Copy(recommendedItem.Items[39].ItemId);
                        recommendation.Rating40 = recommendedItem.Items[39].Rating;
                    }
                    if (recommendedItem.Items[40].ItemId != null)
                    {
                        recommendation.Item41 = string.Copy(recommendedItem.Items[40].ItemId);
                        recommendation.Rating41 = recommendedItem.Items[40].Rating;
                    }
                    if (recommendedItem.Items[41].ItemId != null)
                    {
                        recommendation.Item42 = string.Copy(recommendedItem.Items[41].ItemId);
                        recommendation.Rating42 = recommendedItem.Items[41].Rating;
                    }
                    if (recommendedItem.Items[42].ItemId != null)
                    {
                        recommendation.Item43 = string.Copy(recommendedItem.Items[42].ItemId);
                        recommendation.Rating43 = recommendedItem.Items[42].Rating;
                    }
                    if (recommendedItem.Items[43].ItemId != null)
                    {
                        recommendation.Item44 = string.Copy(recommendedItem.Items[43].ItemId);
                        recommendation.Rating44 = recommendedItem.Items[43].Rating;
                    }
                    if (recommendedItem.Items[44].ItemId != null)
                    {
                        recommendation.Item45 = string.Copy(recommendedItem.Items[44].ItemId);
                        recommendation.Rating45 = recommendedItem.Items[44].Rating;
                    }
                    if (recommendedItem.Items[45].ItemId != null)
                    {
                        recommendation.Item46 = string.Copy(recommendedItem.Items[45].ItemId);
                        recommendation.Rating46 = recommendedItem.Items[45].Rating;
                    }
                    if (recommendedItem.Items[46].ItemId != null)
                    {
                        recommendation.Item47 = string.Copy(recommendedItem.Items[46].ItemId);
                        recommendation.Rating47 = recommendedItem.Items[46].Rating;
                    }
                    if (recommendedItem.Items[47].ItemId != null)
                    {
                        recommendation.Item48 = string.Copy(recommendedItem.Items[47].ItemId);
                        recommendation.Rating48 = recommendedItem.Items[47].Rating;
                    }
                    if (recommendedItem.Items[48].ItemId != null)
                    {
                        recommendation.Item49 = string.Copy(recommendedItem.Items[48].ItemId);
                        recommendation.Rating49 = recommendedItem.Items[48].Rating;
                    }
                    if (recommendedItem.Items[49].ItemId != null)
                    {
                        recommendation.Item50 = string.Copy(recommendedItem.Items[49].ItemId);
                        recommendation.Rating50 = recommendedItem.Items[49].Rating;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {

                }
                _dbContext.Recommendation.Add(recommendation);
            }

            _dbContext.SaveChanges();
        }
    }
}
 
 
 