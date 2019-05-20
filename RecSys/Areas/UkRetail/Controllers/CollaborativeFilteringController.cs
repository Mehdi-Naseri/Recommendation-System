using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecSys.Data;
using RecSys.Models;
using RecSys.ViewModels;

using RecSys.Functions;

namespace RecSys.Areas.UkRetail.Controllers
{
    [Area("UkRetail")]
    public class CollaborativeFilteringController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaborativeFilteringController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Recommendations(int kValue, int recommendationNumber, DateTime startDate, DateTime endDate)
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
            IEnumerable<UserItemPurchase> userItemPurchases = _dbContext.UkRetailOriginalSales
                .Where(a => a.InvoiceDate >= startDate && a.InvoiceDate <= endDate && a.CustomerID != null )
                .Select(a => new UserItemPurchase { User = a.CustomerID.GetValueOrDefault(), Item = a.StockCode });
            List<RecommendedItems> recommendedItemsList = new List<RecommendedItems>();
            CollaborativeFiltering collaborativeFiltering = new CollaborativeFiltering();
            recommendedItemsList = collaborativeFiltering.Recommend(userItemPurchases, kValue, recommendationNumber, startDate, endDate);

            SavetoDatabase(recommendedItemsList);
            /*************************************************************************************/
            //    Dispaly results
            /*************************************************************************************/
            return View(recommendedItemsList);
        }

        private void SavetoDatabase(List<RecommendedItems> recommendedItemsList)
        {
            //Clean table
            _dbContext.CollaborativeRecommendation.RemoveRange(_dbContext.CollaborativeRecommendation);

            //Save new recomended items
            foreach(RecommendedItems recommendedItem in recommendedItemsList)
            {
                CollaborativeRecommendation collaborativeRecommendation = new CollaborativeRecommendation();
                collaborativeRecommendation.UserId = recommendedItem.User;
                try
                {
                    if (recommendedItem.Items[0].ItemId != null)
                    {
                        collaborativeRecommendation.Item1 = string.Copy(recommendedItem.Items[0].ItemId);
                        collaborativeRecommendation.Rating1 = recommendedItem.Items[0].Rating;
                    }
                    if (recommendedItem.Items[1].ItemId != null)
                    {
                        collaborativeRecommendation.Item2 = string.Copy(recommendedItem.Items[1].ItemId);
                        collaborativeRecommendation.Rating2 = recommendedItem.Items[1].Rating;
                    }
                    if (recommendedItem.Items[2].ItemId != null)
                    {
                        collaborativeRecommendation.Item3 = string.Copy(recommendedItem.Items[2].ItemId);
                        collaborativeRecommendation.Rating3 = recommendedItem.Items[2].Rating;
                    }
                    if (recommendedItem.Items[3].ItemId != null)
                    {
                        collaborativeRecommendation.Item4 = string.Copy(recommendedItem.Items[3].ItemId);
                        collaborativeRecommendation.Rating4 = recommendedItem.Items[3].Rating;
                    }
                    if (recommendedItem.Items[4].ItemId != null)
                    {
                        collaborativeRecommendation.Item5 = string.Copy(recommendedItem.Items[4].ItemId);
                        collaborativeRecommendation.Rating5 = recommendedItem.Items[4].Rating;
                    }
                    if (recommendedItem.Items[5].ItemId != null)
                    {
                        collaborativeRecommendation.Item6 = string.Copy(recommendedItem.Items[5].ItemId);
                        collaborativeRecommendation.Rating6 = recommendedItem.Items[5].Rating;
                    }
                    if (recommendedItem.Items[6].ItemId != null)
                    {
                        collaborativeRecommendation.Item7 = string.Copy(recommendedItem.Items[6].ItemId);
                        collaborativeRecommendation.Rating7 = recommendedItem.Items[6].Rating;
                    }
                    if (recommendedItem.Items[7].ItemId != null)
                    {
                        collaborativeRecommendation.Item8 = string.Copy(recommendedItem.Items[7].ItemId);
                        collaborativeRecommendation.Rating8 = recommendedItem.Items[7].Rating;
                    }
                    if (recommendedItem.Items[8].ItemId != null)
                    {
                        collaborativeRecommendation.Item9 = string.Copy(recommendedItem.Items[8].ItemId);
                        collaborativeRecommendation.Rating9 = recommendedItem.Items[8].Rating;
                    }
                    if (recommendedItem.Items[9].ItemId != null)
                    {
                        collaborativeRecommendation.Item10 = string.Copy(recommendedItem.Items[9].ItemId);
                        collaborativeRecommendation.Rating10 = recommendedItem.Items[9].Rating;
                    }
                    if (recommendedItem.Items[10].ItemId != null)
                    {
                        collaborativeRecommendation.Item11 = string.Copy(recommendedItem.Items[10].ItemId);
                        collaborativeRecommendation.Rating11 = recommendedItem.Items[10].Rating;
                    }
                    if (recommendedItem.Items[11].ItemId != null)
                    {
                        collaborativeRecommendation.Item12 = string.Copy(recommendedItem.Items[11].ItemId);
                        collaborativeRecommendation.Rating12 = recommendedItem.Items[11].Rating;
                    }
                    if (recommendedItem.Items[12].ItemId != null)
                    {
                        collaborativeRecommendation.Item13 = string.Copy(recommendedItem.Items[12].ItemId);
                        collaborativeRecommendation.Rating13 = recommendedItem.Items[12].Rating;
                    }
                    if (recommendedItem.Items[13].ItemId != null)
                    {
                        collaborativeRecommendation.Item14 = string.Copy(recommendedItem.Items[13].ItemId);
                        collaborativeRecommendation.Rating14 = recommendedItem.Items[13].Rating;
                    }
                    if (recommendedItem.Items[14].ItemId != null)
                    {
                        collaborativeRecommendation.Item15 = string.Copy(recommendedItem.Items[14].ItemId);
                        collaborativeRecommendation.Rating15 = recommendedItem.Items[14].Rating;
                    }
                    if (recommendedItem.Items[15].ItemId != null)
                    {
                        collaborativeRecommendation.Item16 = string.Copy(recommendedItem.Items[15].ItemId);
                        collaborativeRecommendation.Rating16 = recommendedItem.Items[15].Rating;
                    }
                    if (recommendedItem.Items[16].ItemId != null)
                    {
                        collaborativeRecommendation.Item17 = string.Copy(recommendedItem.Items[16].ItemId);
                        collaborativeRecommendation.Rating17 = recommendedItem.Items[16].Rating;
                    }
                    if (recommendedItem.Items[17].ItemId != null)
                    {
                        collaborativeRecommendation.Item18 = string.Copy(recommendedItem.Items[17].ItemId);
                        collaborativeRecommendation.Rating18 = recommendedItem.Items[17].Rating;
                    }
                    if (recommendedItem.Items[18].ItemId != null)
                    {
                        collaborativeRecommendation.Item19 = string.Copy(recommendedItem.Items[18].ItemId);
                        collaborativeRecommendation.Rating19 = recommendedItem.Items[18].Rating;
                    }
                    if (recommendedItem.Items[19].ItemId != null)
                    {
                        collaborativeRecommendation.Item20 = string.Copy(recommendedItem.Items[19].ItemId);
                        collaborativeRecommendation.Rating20 = recommendedItem.Items[19].Rating;
                    }
                    if (recommendedItem.Items[20].ItemId != null)
                    {
                        collaborativeRecommendation.Item21 = string.Copy(recommendedItem.Items[20].ItemId);
                        collaborativeRecommendation.Rating21 = recommendedItem.Items[20].Rating;
                    }
                    if (recommendedItem.Items[21].ItemId != null)
                    {
                        collaborativeRecommendation.Item22 = string.Copy(recommendedItem.Items[21].ItemId);
                        collaborativeRecommendation.Rating22 = recommendedItem.Items[21].Rating;
                    }
                    if (recommendedItem.Items[22].ItemId != null)
                    {
                        collaborativeRecommendation.Item23 = string.Copy(recommendedItem.Items[22].ItemId);
                        collaborativeRecommendation.Rating23 = recommendedItem.Items[22].Rating;
                    }
                    if (recommendedItem.Items[23].ItemId != null)
                    {
                        collaborativeRecommendation.Item24 = string.Copy(recommendedItem.Items[23].ItemId);
                        collaborativeRecommendation.Rating24 = recommendedItem.Items[23].Rating;
                    }
                    if (recommendedItem.Items[24].ItemId != null)
                    {
                        collaborativeRecommendation.Item25 = string.Copy(recommendedItem.Items[24].ItemId);
                        collaborativeRecommendation.Rating25 = recommendedItem.Items[24].Rating;
                    }
                    if (recommendedItem.Items[25].ItemId != null)
                    {
                        collaborativeRecommendation.Item26 = string.Copy(recommendedItem.Items[25].ItemId);
                        collaborativeRecommendation.Rating26 = recommendedItem.Items[25].Rating;
                    }
                    if (recommendedItem.Items[26].ItemId != null)
                    {
                        collaborativeRecommendation.Item27 = string.Copy(recommendedItem.Items[26].ItemId);
                        collaborativeRecommendation.Rating27 = recommendedItem.Items[26].Rating;
                    }
                    if (recommendedItem.Items[27].ItemId != null)
                    {
                        collaborativeRecommendation.Item28 = string.Copy(recommendedItem.Items[27].ItemId);
                        collaborativeRecommendation.Rating28 = recommendedItem.Items[27].Rating;
                    }
                    if (recommendedItem.Items[28].ItemId != null)
                    {
                        collaborativeRecommendation.Item29 = string.Copy(recommendedItem.Items[28].ItemId);
                        collaborativeRecommendation.Rating29 = recommendedItem.Items[28].Rating;
                    }
                    if (recommendedItem.Items[29].ItemId != null)
                    {
                        collaborativeRecommendation.Item30 = string.Copy(recommendedItem.Items[29].ItemId);
                        collaborativeRecommendation.Rating30 = recommendedItem.Items[29].Rating;
                    }
                    if (recommendedItem.Items[30].ItemId != null)
                    {
                        collaborativeRecommendation.Item31 = string.Copy(recommendedItem.Items[30].ItemId);
                        collaborativeRecommendation.Rating31 = recommendedItem.Items[30].Rating;
                    }
                    if (recommendedItem.Items[31].ItemId != null)
                    {
                        collaborativeRecommendation.Item32 = string.Copy(recommendedItem.Items[31].ItemId);
                        collaborativeRecommendation.Rating32 = recommendedItem.Items[31].Rating;
                    }
                    if (recommendedItem.Items[32].ItemId != null)
                    {
                        collaborativeRecommendation.Item33 = string.Copy(recommendedItem.Items[32].ItemId);
                        collaborativeRecommendation.Rating33 = recommendedItem.Items[32].Rating;
                    }
                    if (recommendedItem.Items[33].ItemId != null)
                    {
                        collaborativeRecommendation.Item34 = string.Copy(recommendedItem.Items[33].ItemId);
                        collaborativeRecommendation.Rating34 = recommendedItem.Items[33].Rating;
                    }
                    if (recommendedItem.Items[34].ItemId != null)
                    {
                        collaborativeRecommendation.Item35 = string.Copy(recommendedItem.Items[34].ItemId);
                        collaborativeRecommendation.Rating35 = recommendedItem.Items[34].Rating;
                    }
                    if (recommendedItem.Items[35].ItemId != null)
                    {
                        collaborativeRecommendation.Item36 = string.Copy(recommendedItem.Items[35].ItemId);
                        collaborativeRecommendation.Rating36 = recommendedItem.Items[35].Rating;
                    }
                    if (recommendedItem.Items[36].ItemId != null)
                    {
                        collaborativeRecommendation.Item37 = string.Copy(recommendedItem.Items[36].ItemId);
                        collaborativeRecommendation.Rating37 = recommendedItem.Items[36].Rating;
                    }
                    if (recommendedItem.Items[37].ItemId != null)
                    {
                        collaborativeRecommendation.Item38 = string.Copy(recommendedItem.Items[37].ItemId);
                        collaborativeRecommendation.Rating38 = recommendedItem.Items[37].Rating;
                    }
                    if (recommendedItem.Items[38].ItemId != null)
                    {
                        collaborativeRecommendation.Item39 = string.Copy(recommendedItem.Items[38].ItemId);
                        collaborativeRecommendation.Rating39 = recommendedItem.Items[38].Rating;
                    }
                    if (recommendedItem.Items[39].ItemId != null)
                    {
                        collaborativeRecommendation.Item40 = string.Copy(recommendedItem.Items[39].ItemId);
                        collaborativeRecommendation.Rating40 = recommendedItem.Items[39].Rating;
                    }
                    if (recommendedItem.Items[40].ItemId != null)
                    {
                        collaborativeRecommendation.Item41 = string.Copy(recommendedItem.Items[40].ItemId);
                        collaborativeRecommendation.Rating41 = recommendedItem.Items[40].Rating;
                    }
                    if (recommendedItem.Items[41].ItemId != null)
                    {
                        collaborativeRecommendation.Item42 = string.Copy(recommendedItem.Items[41].ItemId);
                        collaborativeRecommendation.Rating42 = recommendedItem.Items[41].Rating;
                    }
                    if (recommendedItem.Items[42].ItemId != null)
                    {
                        collaborativeRecommendation.Item43 = string.Copy(recommendedItem.Items[42].ItemId);
                        collaborativeRecommendation.Rating43 = recommendedItem.Items[42].Rating;
                    }
                    if (recommendedItem.Items[43].ItemId != null)
                    {
                        collaborativeRecommendation.Item44 = string.Copy(recommendedItem.Items[43].ItemId);
                        collaborativeRecommendation.Rating44 = recommendedItem.Items[43].Rating;
                    }
                    if (recommendedItem.Items[44].ItemId != null)
                    {
                        collaborativeRecommendation.Item45 = string.Copy(recommendedItem.Items[44].ItemId);
                        collaborativeRecommendation.Rating45 = recommendedItem.Items[44].Rating;
                    }
                    if (recommendedItem.Items[45].ItemId != null)
                    {
                        collaborativeRecommendation.Item46 = string.Copy(recommendedItem.Items[45].ItemId);
                        collaborativeRecommendation.Rating46 = recommendedItem.Items[45].Rating;
                    }
                    if (recommendedItem.Items[46].ItemId != null)
                    {
                        collaborativeRecommendation.Item47 = string.Copy(recommendedItem.Items[46].ItemId);
                        collaborativeRecommendation.Rating47 = recommendedItem.Items[46].Rating;
                    }
                    if (recommendedItem.Items[47].ItemId != null)
                    {
                        collaborativeRecommendation.Item48 = string.Copy(recommendedItem.Items[47].ItemId);
                        collaborativeRecommendation.Rating48 = recommendedItem.Items[47].Rating;
                    }
                    if (recommendedItem.Items[48].ItemId != null)
                    {
                        collaborativeRecommendation.Item49 = string.Copy(recommendedItem.Items[48].ItemId);
                        collaborativeRecommendation.Rating49 = recommendedItem.Items[48].Rating;
                    }
                    if (recommendedItem.Items[49].ItemId != null)
                    {
                        collaborativeRecommendation.Item50 = string.Copy(recommendedItem.Items[49].ItemId);
                        collaborativeRecommendation.Rating50 = recommendedItem.Items[49].Rating;
                    }
            }
                catch (ArgumentOutOfRangeException ex)
                {

                }
                _dbContext.CollaborativeRecommendation.Add(collaborativeRecommendation);
            }
            _dbContext.SaveChanges();
        }
    }
}
 
 
 