using RecSys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using RecSys.Models;

namespace RecSys.Functions
{
    public class EnsembleRecommendationService
    {
        public List<RecommendedItems> Recommend(IEnumerable<CollaborativeRecommendation> purchasedRecommendation,
            IEnumerable<CollaborativeNotPurchasedRecommendation> CollaborativeNotPurchasedRecommendation,
            IEnumerable<SequentialRecommendation> spmRecommendations,
            float purchaseWeight, float collaborativeNotPurcasedWeight, float spmPurchasedWeight, float spmNotPurchasedWeight, int recommendationNumber)
        {
            /*************************************************************************************/
            // Fill User Item Matrix based on support of each rule
            /*************************************************************************************/
            IList<RecommendedItems> spmRecommendeditems = new List<RecommendedItems>();
            foreach (var a in spmRecommendations)
            {
                RecommendedItems recommendedItems = new RecommendedItems();
                recommendedItems.User = a.UserId;
                recommendedItems.Items = new List<ItemRating>();
                if (a.Item1 != null)
                    recommendedItems.Items.Add(new ItemRating(a.Item1, (float) a.Rating1.GetValueOrDefault()));
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

                spmRecommendeditems.Add(recommendedItems);
            }


            IList<RecommendedItems> CollaborativeNotPurchasedRecommendeditems = new List<RecommendedItems>();
   foreach (var a in CollaborativeNotPurchasedRecommendation)
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

                CollaborativeNotPurchasedRecommendeditems.Add(recommendedItems);
            }

            IList<RecommendedItems> purchasedRecommendedItemses = new List<RecommendedItems>();
            foreach (var a in purchasedRecommendation)
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

                purchasedRecommendedItemses.Add(recommendedItems);
            }


            IList<RecommendedItems> ensembleRecomendations = new List<RecommendedItems>();
            List<int> users = purchasedRecommendation.Select(a => a.UserId).ToList();
            //Add purchase recommendations
            if (purchaseWeight > 0)
            {
                foreach (RecommendedItems recommendedItems in purchasedRecommendedItemses)
                {
                    RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                    recommendedItemsWeighted.User = recommendedItems.User;
                    recommendedItemsWeighted.Items = new List<ItemRating>();
                    foreach (ItemRating itemRating in recommendedItems.Items)
                    {
                        recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                            itemRating.Rating * purchaseWeight));
                    }

                    ensembleRecomendations.Add(recommendedItemsWeighted);
                }
            }

            //Add collaborative non purchased recommended
            if (collaborativeNotPurcasedWeight>0)
            { 
                foreach (RecommendedItems recommendedItems in CollaborativeNotPurchasedRecommendeditems)
                {
                    foreach (ItemRating itemRating in recommendedItems.Items)
                    {
                        if (ensembleRecomendations.Any(a => a.User == recommendedItems.User))
                        {
                        ensembleRecomendations.First(a => a.User == recommendedItems.User).Items.Add(
                            new ItemRating(itemRating.ItemId, itemRating.Rating * collaborativeNotPurcasedWeight));
                        }
                        else
                        {
                            RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                            recommendedItemsWeighted.User = recommendedItems.User;
                            recommendedItemsWeighted.Items = new List<ItemRating>();
                            recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                                itemRating.Rating * collaborativeNotPurcasedWeight));
                            ensembleRecomendations.Add(recommendedItemsWeighted);
                        }
                }
                }
            }
            //Add SPM to Ensemble recomendations
            foreach (RecommendedItems recommendedItems in spmRecommendeditems)
            {

                foreach (ItemRating itemRating in recommendedItems.Items)
                {
                    float spmRatingWeighted;
                    if (purchasedRecommendedItemses.Any(a =>
                        a.User == recommendedItems.User && a.Items.Select(i => i.ItemId).Contains(itemRating.ItemId)))
                    {
                        if (spmPurchasedWeight > 0)
                        {
                            if (purchaseWeight > 0)
                            {
                                spmRatingWeighted = itemRating.Rating * spmPurchasedWeight;
                                ensembleRecomendations.First(a => a.User == recommendedItems.User).Items
                                    .First(i => i.ItemId == itemRating.ItemId).Rating += spmRatingWeighted;
                            }
                            else
                            {
                                RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                                recommendedItemsWeighted.User = recommendedItems.User;
                                recommendedItemsWeighted.Items = new List<ItemRating>();
                                recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                                    itemRating.Rating * spmPurchasedWeight));
                                ensembleRecomendations.Add(recommendedItemsWeighted);
                            }
                        }
                    }
                    else if (spmNotPurchasedWeight > 0)
                    {
                        if (collaborativeNotPurcasedWeight>0 && CollaborativeNotPurchasedRecommendeditems.Any(a =>
                            a.User == recommendedItems.User &&
                            a.Items.Select(i => i.ItemId).Contains(itemRating.ItemId)))
                        {
                            spmRatingWeighted = itemRating.Rating * spmNotPurchasedWeight;
                            ensembleRecomendations.FirstOrDefault(a => a.User == recommendedItems.User).Items
                                .FirstOrDefault(i => i.ItemId == itemRating.ItemId).Rating += spmRatingWeighted;
                        }
                        else
                        {
                            RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                            recommendedItemsWeighted.User = recommendedItems.User;
                            recommendedItemsWeighted.Items = new List<ItemRating>();
                            recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                                itemRating.Rating * spmNotPurchasedWeight));
                            ensembleRecomendations.Add(recommendedItemsWeighted);
                        }
                    }
                }
                
            }


            /*************************************************************************************/
            //  Step 5:   Recommend products
            /*************************************************************************************/
            List<RecommendedItems> recommendations = new List<RecommendedItems>();
            foreach (int user in users)
            {
                if (ensembleRecomendations.FirstOrDefault(a => a.User == user) != null)
                {
                    IList<ItemRating> ItemRatings = ensembleRecomendations.FirstOrDefault(a => a.User == user).Items.OrderByDescending(a => a.Rating).ToList();

                    RecommendedItems recommendation = new RecommendedItems() { };
                    recommendation.User = user;
                    recommendation.Items = new List<ItemRating>();
                    

                    int recommendationCount = recommendationNumber <= ItemRatings.Count()
                        ? recommendationNumber
                        : ItemRatings.Count();
                    for (int i = 0; i < recommendationCount; i++)
                    {
                        if (ItemRatings[i] != null)
                        {
                            ItemRating itemRating = new ItemRating(ItemRatings[i].ItemId, ItemRatings[i].Rating);
                            recommendation.Items.Add(itemRating);
                        }
                        else
                        {
                            break;
                        }
                    }
                    recommendations.Add(recommendation);
                }
            }
            Console.WriteLine("Step 3: " + DateTime.Now.TimeOfDay + " - Recommend products");
            //return recomendations;
            return recommendations;
        }



















        /// <summary>
        /// /////////Optimized Version of recomendation which take data from single Recommendation table
        /// </summary>
        /// <param name="recommendationsPurchaseFrequency"></param>
        /// <param name="recommendationsCollaborativeFiltering"></param>
        /// <param name="recommendationsSpmPurchased"></param>
        /// <param name="recommendationsSpmNotPurchased"></param>
        /// <param name="purchaseWeight"></param>
        /// <param name="collaborativeNotPurcasedWeight"></param>
        /// <param name="spmPurchasedWeight"></param>
        /// <param name="spmNotPurchasedWeight"></param>
        /// <param name="recommendationNumber"></param>
        /// <returns></returns>

        public List<RecommendedItems> RecommendOptimized(
            IList<RecommendedItems> recommendedItemsesPurchaseFrequency,
           IList<RecommendedItems> recommendedItemsesCollaborativeFiltering,
           IList<RecommendedItems> recommendedItemsesSpmPurchased,
           IList<RecommendedItems> recommendedItemsesSpmNotPurchased,
           float purchaseWeight, 
           float collaborativeNotPurcasedWeight,
           float spmPurchasedWeight, 
           float spmNotPurchasedWeight, 
           int recommendationNumber)
        {
            IList<RecommendedItems> ensembleRecomendations = new List<RecommendedItems>();
            List<int> users = recommendedItemsesPurchaseFrequency.Select(a => a.User).ToList();
            //Add purchase recommendations
            if (purchaseWeight > 0)
            {
                foreach (RecommendedItems recommendedItems in recommendedItemsesPurchaseFrequency)
                {
                    RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                    recommendedItemsWeighted.User = recommendedItems.User;
                    recommendedItemsWeighted.Items = new List<ItemRating>();
                    foreach (ItemRating itemRating in recommendedItems.Items)
                    {
                        recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                            itemRating.Rating * purchaseWeight));
                    }

                    ensembleRecomendations.Add(recommendedItemsWeighted);
                }
            }

            //Add collaborative non purchased recommended
            if (collaborativeNotPurcasedWeight > 0)
            {
                foreach (RecommendedItems recommendedItems in recommendedItemsesCollaborativeFiltering)
                {
                    foreach (ItemRating itemRating in recommendedItems.Items)
                    {
                        if (ensembleRecomendations.Any(a => a.User == recommendedItems.User))
                        {
                            ensembleRecomendations.First(a => a.User == recommendedItems.User).Items.Add(
                                new ItemRating(itemRating.ItemId, itemRating.Rating * collaborativeNotPurcasedWeight));
                        }
                        else
                        {
                            RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                            recommendedItemsWeighted.User = recommendedItems.User;
                            recommendedItemsWeighted.Items = new List<ItemRating>();
                            recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                                itemRating.Rating * collaborativeNotPurcasedWeight));
                            ensembleRecomendations.Add(recommendedItemsWeighted);
                        }
                    }
                }
            }
            //Add SPM-Purchased to Ensemble recomendations
            if (spmPurchasedWeight > 0)
            {
                foreach (RecommendedItems recommendedItems in recommendedItemsesSpmPurchased)
                {
                    foreach (ItemRating itemRating in recommendedItems.Items)
                    {
                        if (ensembleRecomendations.Any(a => a.User == recommendedItems.User))
                        {
                            var rec = ensembleRecomendations.First(a => a.User == recommendedItems.User);
                            if (rec.Items.Any(a => a.ItemId == itemRating.ItemId))
                            {
                                float spmRatingWeighted = itemRating.Rating * spmPurchasedWeight;
                                ensembleRecomendations.First(a => a.User == recommendedItems.User).Items
                                    .First(i => i.ItemId == itemRating.ItemId).Rating += spmRatingWeighted;
                            }
                            else
                            {
                                ensembleRecomendations.First(a => a.User == recommendedItems.User).Items.Add(
                                new ItemRating(itemRating.ItemId, itemRating.Rating * spmPurchasedWeight));
                            }

                        }
                        else
                        {
                            RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                            recommendedItemsWeighted.User = recommendedItems.User;
                            recommendedItemsWeighted.Items = new List<ItemRating>();
                            recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                                itemRating.Rating * spmPurchasedWeight));
                            ensembleRecomendations.Add(recommendedItemsWeighted);
                        }
                    }
                }
            }

            //Add SPM-Purchased to Ensemble recomendations
            if (spmNotPurchasedWeight > 0)
            {
                foreach (RecommendedItems recommendedItems in recommendedItemsesSpmNotPurchased)
                {
                    foreach (ItemRating itemRating in recommendedItems.Items)
                    {
                        if (ensembleRecomendations.Any(a => a.User == recommendedItems.User))
                        {
                            var rec = ensembleRecomendations.First(a => a.User == recommendedItems.User);
                            if (rec.Items.Any(a => a.ItemId == itemRating.ItemId))
                            {
                                float spmRatingWeighted = itemRating.Rating * spmNotPurchasedWeight;
                                ensembleRecomendations.First(a => a.User == recommendedItems.User).Items
                                    .First(i => i.ItemId == itemRating.ItemId).Rating += spmRatingWeighted;
                            }
                            else
                            {
                                ensembleRecomendations.First(a => a.User == recommendedItems.User).Items.Add(
                                new ItemRating(itemRating.ItemId, itemRating.Rating * spmNotPurchasedWeight));
                            }

                        }
                        else
                        {
                            RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                            recommendedItemsWeighted.User = recommendedItems.User;
                            recommendedItemsWeighted.Items = new List<ItemRating>();
                            recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                                itemRating.Rating * spmNotPurchasedWeight));
                            ensembleRecomendations.Add(recommendedItemsWeighted);
                        }
                    }
                }
            }

            /*************************************************************************************/
            //  Step 5:   Recommend products
            /*************************************************************************************/
            List<RecommendedItems> recommendations = new List<RecommendedItems>();
            foreach (int user in users)
            {
                if (ensembleRecomendations.FirstOrDefault(a => a.User == user) != null)
                {
                    IList<ItemRating> ItemRatings = ensembleRecomendations.FirstOrDefault(a => a.User == user).Items.OrderByDescending(a => a.Rating).ToList();

                    RecommendedItems recommendation = new RecommendedItems() { };
                    recommendation.User = user;
                    recommendation.Items = new List<ItemRating>();


                    int recommendationCount = recommendationNumber <= ItemRatings.Count()
                        ? recommendationNumber
                        : ItemRatings.Count();
                    for (int i = 0; i < recommendationCount; i++)
                    {
                        if (ItemRatings[i] != null)
                        {
                            ItemRating itemRating = new ItemRating(ItemRatings[i].ItemId, ItemRatings[i].Rating);
                            recommendation.Items.Add(itemRating);
                        }
                        else
                        {
                            break;
                        }
                    }
                    recommendations.Add(recommendation);
                }
            }
            Console.WriteLine("Step 3: " + DateTime.Now.TimeOfDay + " - Recommend products");
            //return recomendations;
            return recommendations;
        }


        public List<RecommendedItems> RecommendOptimizedHope(
          IList<RecommendedItems> recommendedItemsesCf,
          IList<RecommendedItems> recommendedItemsesSpm,
          float cfWeight,
          float spmWeight,
          int recommendationNumber)
        {
            IList<RecommendedItems> ensembleRecomendations = new List<RecommendedItems>();
            List<int> users = recommendedItemsesCf.Select(a => a.User).Union(recommendedItemsesSpm.Select(a => a.User)).ToList();
            //Add purchase recommendations
            if (cfWeight > 0)
            {
                foreach (RecommendedItems recommendedItems in recommendedItemsesCf)
                {
                    RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                    recommendedItemsWeighted.User = recommendedItems.User;
                    recommendedItemsWeighted.Items = new List<ItemRating>();
                    foreach (ItemRating itemRating in recommendedItems.Items)
                    {
                        recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                            itemRating.Rating * cfWeight));
                    }

                    ensembleRecomendations.Add(recommendedItemsWeighted);
                }
            }

            //Add collaborative non purchased recommended
            if (spmWeight > 0)
            {
                foreach (RecommendedItems recommendedItems in recommendedItemsesSpm)
                {
                    foreach (ItemRating itemRating in recommendedItems.Items)
                    {
                        if (ensembleRecomendations.Any(a => a.User == recommendedItems.User))
                        {
                            ensembleRecomendations.First(a => a.User == recommendedItems.User).Items.Add(
                                new ItemRating(itemRating.ItemId, itemRating.Rating * spmWeight));
                        }
                        else
                        {
                            RecommendedItems recommendedItemsWeighted = new RecommendedItems();
                            recommendedItemsWeighted.User = recommendedItems.User;
                            recommendedItemsWeighted.Items = new List<ItemRating>();
                            recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
                                itemRating.Rating * spmWeight));
                            ensembleRecomendations.Add(recommendedItemsWeighted);
                        }
                    }
                }
            }
            ////Add SPM-Purchased to Ensemble recomendations
            //if (spmPurchasedWeight > 0)
            //{
            //    foreach (RecommendedItems recommendedItems in recommendedItemsesSpmPurchased)
            //    {
            //        foreach (ItemRating itemRating in recommendedItems.Items)
            //        {
            //            if (ensembleRecomendations.Any(a => a.User == recommendedItems.User))
            //            {
            //                var rec = ensembleRecomendations.First(a => a.User == recommendedItems.User);
            //                if (rec.Items.Any(a => a.ItemId == itemRating.ItemId))
            //                {
            //                    float spmRatingWeighted = itemRating.Rating * spmPurchasedWeight;
            //                    ensembleRecomendations.First(a => a.User == recommendedItems.User).Items
            //                        .First(i => i.ItemId == itemRating.ItemId).Rating += spmRatingWeighted;
            //                }
            //                else
            //                {
            //                    ensembleRecomendations.First(a => a.User == recommendedItems.User).Items.Add(
            //                    new ItemRating(itemRating.ItemId, itemRating.Rating * spmPurchasedWeight));
            //                }

            //            }
            //            else
            //            {
            //                RecommendedItems recommendedItemsWeighted = new RecommendedItems();
            //                recommendedItemsWeighted.User = recommendedItems.User;
            //                recommendedItemsWeighted.Items = new List<ItemRating>();
            //                recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
            //                    itemRating.Rating * spmPurchasedWeight));
            //                ensembleRecomendations.Add(recommendedItemsWeighted);
            //            }
            //        }
            //    }
            //}

            ////Add SPM-Purchased to Ensemble recomendations
            //if (spmNotPurchasedWeight > 0)
            //{
            //    foreach (RecommendedItems recommendedItems in recommendedItemsesSpmNotPurchased)
            //    {
            //        foreach (ItemRating itemRating in recommendedItems.Items)
            //        {
            //            if (ensembleRecomendations.Any(a => a.User == recommendedItems.User))
            //            {
            //                var rec = ensembleRecomendations.First(a => a.User == recommendedItems.User);
            //                if (rec.Items.Any(a => a.ItemId == itemRating.ItemId))
            //                {
            //                    float spmRatingWeighted = itemRating.Rating * spmNotPurchasedWeight;
            //                    ensembleRecomendations.First(a => a.User == recommendedItems.User).Items
            //                        .First(i => i.ItemId == itemRating.ItemId).Rating += spmRatingWeighted;
            //                }
            //                else
            //                {
            //                    ensembleRecomendations.First(a => a.User == recommendedItems.User).Items.Add(
            //                    new ItemRating(itemRating.ItemId, itemRating.Rating * spmNotPurchasedWeight));
            //                }

            //            }
            //            else
            //            {
            //                RecommendedItems recommendedItemsWeighted = new RecommendedItems();
            //                recommendedItemsWeighted.User = recommendedItems.User;
            //                recommendedItemsWeighted.Items = new List<ItemRating>();
            //                recommendedItemsWeighted.Items.Add(new ItemRating(itemRating.ItemId,
            //                    itemRating.Rating * spmNotPurchasedWeight));
            //                ensembleRecomendations.Add(recommendedItemsWeighted);
            //            }
            //        }
            //    }
            //}

            /*************************************************************************************/
            //  Step 5:   Recommend products
            /*************************************************************************************/
            List<RecommendedItems> recommendations = new List<RecommendedItems>();
            foreach (int user in users)
            {
                if (ensembleRecomendations.FirstOrDefault(a => a.User == user) != null)
                {
                    IList<ItemRating> ItemRatings = ensembleRecomendations.FirstOrDefault(a => a.User == user).Items.OrderByDescending(a => a.Rating).ToList();

                    RecommendedItems recommendation = new RecommendedItems() { };
                    recommendation.User = user;
                    recommendation.Items = new List<ItemRating>();


                    int recommendationCount = recommendationNumber <= ItemRatings.Count()
                        ? recommendationNumber
                        : ItemRatings.Count();
                    for (int i = 0; i < recommendationCount; i++)
                    {
                        if (ItemRatings[i] != null)
                        {
                            ItemRating itemRating = new ItemRating(ItemRatings[i].ItemId, ItemRatings[i].Rating);
                            recommendation.Items.Add(itemRating);
                        }
                        else
                        {
                            break;
                        }
                    }
                    recommendations.Add(recommendation);
                }
            }
            Console.WriteLine("Step 3: " + DateTime.Now.TimeOfDay + " - Recommend products");
            //return recomendations;
            return recommendations;
        }
    }
}
