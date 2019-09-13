using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecSys.Data;
using RecSys.Functions;
using RecSys.Models;
using RecSys.ViewModels;

namespace RecSys.Areas.UkRec.Controllers
{
    [Area("UkRec")]
    public class EnsembleRecController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EnsembleRecController(ApplicationDbContext context)
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
        public IActionResult Recommendations(int recommendationNumber,int purchaseWeight,int collaborativeNotPurcasedWeight, int spmPurchasedWeight, int spmNotPurchasedWeight)
        {
            IList<Recommendation> recommendationsSpmPurchased = _dbContext.Recommendation
                 .Where(a => a.RecommendationInfoId == 8).ToList();
            IList<Recommendation> recommendationsSpmNotPurchased = _dbContext.Recommendation
                .Where(a => a.RecommendationInfoId == 9).ToList();
            IList<Recommendation> recommendationsCfNotPurchased = _dbContext.Recommendation
                .Where(a => a.RecommendationInfoId == 14).ToList();
            IList<Recommendation> recommendationsPurchaseFrequency = _dbContext.Recommendation
                .Where(a => a.RecommendationInfoId == 11).ToList();
            /*************************************************************************************/
            // Fill User Item Matrix based on support of each rule
            /*************************************************************************************/
            IList<RecommendedItems> recommendeditemsPurchaseFrequency = new List<RecommendedItems>();
            foreach (var a in recommendationsPurchaseFrequency)
            {
                RecommendedItems recommendedItems = new RecommendedItems();
                recommendedItems.User = a.UserId;
                recommendedItems.Items = new List<ItemRating>();
                if (!string.IsNullOrEmpty(a.Item1))
                    recommendedItems.Items.Add(new ItemRating(a.Item1, (float)a.Rating1.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item2))
                    recommendedItems.Items.Add(new ItemRating(a.Item2, (float)a.Rating2.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item3))
                    recommendedItems.Items.Add(new ItemRating(a.Item3, (float)a.Rating3.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item4))
                    recommendedItems.Items.Add(new ItemRating(a.Item4, (float)a.Rating4.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item5))
                    recommendedItems.Items.Add(new ItemRating(a.Item5, (float)a.Rating5.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item6))
                    recommendedItems.Items.Add(new ItemRating(a.Item6, (float)a.Rating6.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item7))
                    recommendedItems.Items.Add(new ItemRating(a.Item7, (float)a.Rating7.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item8))
                    recommendedItems.Items.Add(new ItemRating(a.Item8, (float)a.Rating8.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item9))
                    recommendedItems.Items.Add(new ItemRating(a.Item9, (float)a.Rating9.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item10))
                    recommendedItems.Items.Add(new ItemRating(a.Item10, (float)a.Rating10.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item11))
                    recommendedItems.Items.Add(new ItemRating(a.Item11, (float)a.Rating11.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item12))
                    recommendedItems.Items.Add(new ItemRating(a.Item12, (float)a.Rating12.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item13))
                    recommendedItems.Items.Add(new ItemRating(a.Item13, (float)a.Rating13.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item14))
                    recommendedItems.Items.Add(new ItemRating(a.Item14, (float)a.Rating14.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item15))
                    recommendedItems.Items.Add(new ItemRating(a.Item15, (float)a.Rating15.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item16))
                    recommendedItems.Items.Add(new ItemRating(a.Item16, (float)a.Rating16.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item17))
                    recommendedItems.Items.Add(new ItemRating(a.Item17, (float)a.Rating17.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item18))
                    recommendedItems.Items.Add(new ItemRating(a.Item18, (float)a.Rating18.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item19))
                    recommendedItems.Items.Add(new ItemRating(a.Item19, (float)a.Rating19.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item20))
                    recommendedItems.Items.Add(new ItemRating(a.Item20, (float)a.Rating20.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item21))
                    recommendedItems.Items.Add(new ItemRating(a.Item21, (float)a.Rating21.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item22))
                    recommendedItems.Items.Add(new ItemRating(a.Item22, (float)a.Rating22.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item23))
                    recommendedItems.Items.Add(new ItemRating(a.Item23, (float)a.Rating23.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item24))
                    recommendedItems.Items.Add(new ItemRating(a.Item24, (float)a.Rating24.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item25))
                    recommendedItems.Items.Add(new ItemRating(a.Item25, (float)a.Rating25.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item26))
                    recommendedItems.Items.Add(new ItemRating(a.Item26, (float)a.Rating26.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item27))
                    recommendedItems.Items.Add(new ItemRating(a.Item27, (float)a.Rating27.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item28))
                    recommendedItems.Items.Add(new ItemRating(a.Item28, (float)a.Rating28.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item29))
                    recommendedItems.Items.Add(new ItemRating(a.Item29, (float)a.Rating29.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item30))
                    recommendedItems.Items.Add(new ItemRating(a.Item30, (float)a.Rating30.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item31))
                    recommendedItems.Items.Add(new ItemRating(a.Item31, (float)a.Rating31.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item32))
                    recommendedItems.Items.Add(new ItemRating(a.Item32, (float)a.Rating32.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item33))
                    recommendedItems.Items.Add(new ItemRating(a.Item33, (float)a.Rating33.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item34))
                    recommendedItems.Items.Add(new ItemRating(a.Item34, (float)a.Rating34.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item35))
                    recommendedItems.Items.Add(new ItemRating(a.Item35, (float)a.Rating35.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item36))
                    recommendedItems.Items.Add(new ItemRating(a.Item36, (float)a.Rating36.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item37))
                    recommendedItems.Items.Add(new ItemRating(a.Item37, (float)a.Rating37.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item38))
                    recommendedItems.Items.Add(new ItemRating(a.Item38, (float)a.Rating38.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item39))
                    recommendedItems.Items.Add(new ItemRating(a.Item39, (float)a.Rating39.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item40))
                    recommendedItems.Items.Add(new ItemRating(a.Item40, (float)a.Rating40.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item41))
                    recommendedItems.Items.Add(new ItemRating(a.Item41, (float)a.Rating41.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item42))
                    recommendedItems.Items.Add(new ItemRating(a.Item42, (float)a.Rating42.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item43))
                    recommendedItems.Items.Add(new ItemRating(a.Item43, (float)a.Rating43.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item44))
                    recommendedItems.Items.Add(new ItemRating(a.Item44, (float)a.Rating44.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item45))
                    recommendedItems.Items.Add(new ItemRating(a.Item45, (float)a.Rating45.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item46))
                    recommendedItems.Items.Add(new ItemRating(a.Item46, (float)a.Rating46.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item47))
                    recommendedItems.Items.Add(new ItemRating(a.Item47, (float)a.Rating47.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item48))
                    recommendedItems.Items.Add(new ItemRating(a.Item48, (float)a.Rating48.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item49))
                    recommendedItems.Items.Add(new ItemRating(a.Item49, (float)a.Rating49.GetValueOrDefault()));
                if (!string.IsNullOrEmpty(a.Item50))
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
            List<RecommendedItems> recommendedItemsList = ensembleRecommendation.RecommendOptimized(
                recommendeditemsPurchaseFrequency,
                RecommendeditemsCollaborativeNotPurchased,
                recommendedItemsesSpmPurchased,
                recommendedItemsesSpmNotPurchased,
                (float)purchaseWeight/100, 
                (float)collaborativeNotPurcasedWeight / 100, 
                (float)spmPurchasedWeight / 100, 
                (float)spmNotPurchasedWeight / 100 , 
                recommendationNumber);

            SavetoDatabase(recommendedItemsList);

            return View(recommendedItemsList);
        }

        private void SavetoDatabase(List<RecommendedItems> recommendedItemsList)
        {
            //Clean table
            int recInfoid = _dbContext.RecommendationInfo.First(a => string.Equals(a.RecName, "SEERS11Month")).RecId;
            //Clean table
            _dbContext.Recommendation.RemoveRange(_dbContext.Recommendation.Where(r => r.RecommendationInfoId == recInfoid));


            //Save new recomended items
            foreach (RecommendedItems recommendedItem in recommendedItemsList)
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