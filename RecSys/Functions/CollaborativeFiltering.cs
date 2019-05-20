using RecSys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.Functions
{
    public class CollaborativeFiltering
    {
        public List<RecommendedItems> Recommend(IEnumerable<UserItemPurchase> userItemPurchases, int kValue, int recommendationNumber, DateTime TrainingStartDate, DateTime trainingEndDate)
        {
            Console.WriteLine("Step 0: " + DateTime.Now.TimeOfDay);
            /*************************************************************************************/
            //Step 1: Fill up User-Item matrix
            /*************************************************************************************/
            List<UserItemRating> userItemRatingMatrix = new List<UserItemRating>();

            foreach (var customerOrder in userItemPurchases)
            {
                var u = userItemRatingMatrix.FirstOrDefault(a => a.UserId == customerOrder.User && string.Equals(a.ItemId, customerOrder.Item));
                if (u != null)
                {
                    u.Rating++;
                }
                else
                {
                    userItemRatingMatrix.Add(new UserItemRating(customerOrder.User, customerOrder.Item, 1));
                }
            }
            System.Diagnostics.Debug.WriteLine("Step 1: " + DateTime.Now.TimeOfDay);



            /*************************************************************************************/
            //Step 2: Normalized UserItemRatingMatrix with user's purchase average
            /*************************************************************************************/
            /*************************************************************************************/
            // Normalized UserItemRatingMatrix with user's producs purchase average
            /*************************************************************************************/
            //IEnumerable<int> users = userItemPurchases.Select(a => a.User).Distinct();
            //List<UserItemRating> userItemRatingMatrixAdjusted = new List<UserItemRating>();
            //List<UserMeanrating> userMeanratingList = new List<UserMeanrating>();
            ////Find average rating of each user
            //foreach (int customer1 in users)
            //{
            //    UserMeanrating userMeanrating = new UserMeanrating() { };
            //    userMeanrating.User = customer1;
            //    userMeanrating.Meanrating = (float)userItemRatingMatrix.Where(a => a.UserId == customer1).Select(a => a.Rating).Average();
            //    userMeanratingList.Add(userMeanrating);
            //}
            ////fillup adjusted UserItem matrix
            //foreach (UserItemRating userItemRating in userItemRatingMatrix)
            //{
            //    float adjustedRating = userItemRating.Rating - userMeanratingList.Where(a => a.User == userItemRating.UserId).First().Meanrating;
            //    UserItemRating userItemRatingAdjusted = new UserItemRating(userItemRating.UserId, userItemRating.ItemId, adjustedRating);
            //    userItemRatingMatrixAdjusted.Add(userItemRatingAdjusted);
            //}
            /*************************************************************************************/
            // Normalized UserItemRatingMatrix with unit vector method
            /*************************************************************************************/
            IEnumerable<int> users = userItemPurchases.Select(a => a.User).Distinct();
            List<UserItemRating> userItemRatingMatrixNormalized = new List<UserItemRating>();
            List<UserVector> userVectors = new List<UserVector>();
            //Find average rating of each user
            foreach (int user1 in users)
            {
                UserVector userVector = new UserVector() { };
                userVector.User = user1;
                IEnumerable<float> ratings = userItemRatingMatrix.Where(a => a.UserId == user1).Select(a => a.Rating);
                float ratingsPower2 = 0;
                foreach (float rating in ratings)
                {
                    ratingsPower2 += (float)Math.Pow(rating, 2.0);
                }
                userVector.Vector = (float)Math.Sqrt(ratingsPower2);
                userVectors.Add(userVector);
            }
            //fillup adjusted UserItem matrix
            foreach (UserItemRating userItemRating in userItemRatingMatrix)
            {
                float NormalziedRating = userItemRating.Rating / userVectors.Where(a => a.User == userItemRating.UserId).First().Vector;
                UserItemRating userItemRatingAdjusted = new UserItemRating(userItemRating.UserId, userItemRating.ItemId, NormalziedRating);
                userItemRatingMatrixNormalized.Add(userItemRatingAdjusted);
            }
            System.Diagnostics.Debug.WriteLine("Step 2: " + DateTime.Now.TimeOfDay);


            /*************************************************************************************/
            //Step 3: Find Similar users in User-Item matrix
            /*************************************************************************************/
            List<UseresSimilarity> useresSimilarity = new List<UseresSimilarity>();
            foreach (int user1 in users)
            {
                foreach (int user2 in users)
                {
                    if (user1 == user2)
                    {
                        //useresSimilarity.Add(new UseresSimilarity() { User1 = user1, User2 = user2, Similarity = 1 });
                    }
                    else if (user1 < user2)
                    {
                        float similarityValue = FindTwoUserSimilarity(user1, user2, userItemRatingMatrixNormalized);
                        if (similarityValue > 0)
                        {
                            useresSimilarity.Add(new UseresSimilarity() { User1 = user1, User2 = user2, Similarity = similarityValue });
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Step 3: " + DateTime.Now.TimeOfDay);

            /*************************************************************************************/
            //Step 4: Fill up UserItemRatingMatrix missing values with collaborative filtering
            /*************************************************************************************/
            List<UserItemRating> userItemRatingMatrixCollaborative = new List<UserItemRating>();
            //IEnumerable<string> items = userItemRatingMatrixNormalized.Select(a => a.ItemId).Distinct();
            foreach (int user1 in users)
            {
                IEnumerable<UserSimilarity> similarUsers = (useresSimilarity.Where(a => a.User1 == user1).Select(a => new UserSimilarity { User = a.User2, Similarity = a.Similarity }))
                    .Union(useresSimilarity.Where(a => a.User2 == user1).Select(a => new UserSimilarity { User = a.User1, Similarity = a.Similarity }))
                    .OrderByDescending(a => a.Similarity)
                    .Take(kValue);

                IEnumerable<string> items = userItemRatingMatrixNormalized
                    .Where(a => a.UserId == user1 || similarUsers.Any(s => s.User == a.UserId))
                    .Select(a => a.ItemId).Distinct();

                foreach (string item in items)
                {
                    UserItemRating UserItemRatingCollaborative = userItemRatingMatrixNormalized.FirstOrDefault(a => a.UserId == user1 && string.Equals(a.ItemId, item));
                    if (UserItemRatingCollaborative != null)
                    {
                        userItemRatingMatrixCollaborative.Add(UserItemRatingCollaborative);
                    }
                    else
                    {
                        if (similarUsers != null)
                        {
                            float sumSumilarityRating = 0;
                            float sumSimilirity = 0;
                            foreach (UserSimilarity user2Similarity in similarUsers)
                            {
                                float user1user2Similarity = user2Similarity.Similarity;
                                var user2Normalized = userItemRatingMatrixNormalized.FirstOrDefault(a => a.UserId == user2Similarity.User && a.ItemId == item);
                                if (user2Normalized != null)
                                {
                                    float user2RatingNormalized = user2Normalized.Rating;
                                    sumSumilarityRating += (user1user2Similarity * user2RatingNormalized);
                                    sumSimilirity += user1user2Similarity;
                                }
                            }
                            if (sumSimilirity > 0)
                            { 
                               float ratingCollaborative = sumSumilarityRating / sumSimilirity;
                               UserItemRatingCollaborative = new UserItemRating() { UserId = user1, ItemId = item, Rating = ratingCollaborative };
                               userItemRatingMatrixCollaborative.Add(UserItemRatingCollaborative);
                            }
                        }
                    }
                    
                }
            }
            System.Diagnostics.Debug.WriteLine("Step 4: " + DateTime.Now.TimeOfDay);

            /*************************************************************************************/
            //  Step 5:   Recommend products
            /*************************************************************************************/
            List<RecommendedItems> recomendations = new List<RecommendedItems>() { };
            foreach (int user in users)
            {
                RecommendedItems recomendation = new RecommendedItems() { };
                recomendation.User = user;
                recomendation.Items = new List<ItemRating>();
                IEnumerable<UserItemRating> userItemRatings = userItemRatingMatrixCollaborative.Where(a => a.UserId == user).OrderByDescending(a => a.Rating);
                int recommendationCount = recommendationNumber <= userItemRatings.Count() ? recommendationNumber : userItemRatings.Count();
                for (int i = 0; i < recommendationCount; i++)
                {
                    UserItemRating userItemRating = userItemRatings.Skip(i).FirstOrDefault();
                    if (userItemRating != null)
                    {
                        ItemRating itemRating = new ItemRating(userItemRating.ItemId, userItemRating.Rating);
                        recomendation.Items.Add(itemRating);
                    }
                    else
                    {
                        break;
                    }
                }
                recomendations.Add(recomendation);
            }
            Console.WriteLine("Step 5: " + DateTime.Now.TimeOfDay);
            return recomendations;
        }

        //Find similarity based on UserItemRating Matrix
        private float FindTwoUserSimilarity(int user1, int user2, List<UserItemRating> userItemRatingMatrix)
        {
            float similarity;
            //Find list of products purchased by two users
            IEnumerable<string> items = userItemRatingMatrix
                .Where(a => a.UserId == user1 || a.UserId == user2)
                .Select(a => a.ItemId).Distinct();
            //Find cosine similarity of two user
            float sumXY = 0, sumX2 = 0, SumY2 = 0;
            foreach (string item in items)
            {
                var user1Item = userItemRatingMatrix.FirstOrDefault(a => a.UserId == user1 && a.ItemId == item);
                float x = (user1Item != null) ? user1Item.Rating : 0;
                var user2Item = userItemRatingMatrix.FirstOrDefault(a => a.UserId == user2 && a.ItemId == item);
                float y = (user2Item != null) ? user2Item.Rating : 0;
                if (x > 0 || y > 0)
                {
                    sumXY += x * y;
                    sumX2 += (float)Math.Pow(x, 2);
                    SumY2 += (float)Math.Pow(y, 2);
                }
            }
            similarity = (float)(sumXY / (Math.Sqrt(sumX2) * Math.Sqrt(SumY2)));
            return similarity;
        }

        private class UseresSimilarity
        {
            [Key, Column(Order = 0)]
            public int User1 { get; set; }
            [Key, Column(Order = 1)]
            public int User2 { get; set; }
            public float Similarity { get; set; }
        }
        //private class SimilarUsers
        //{
        //    [Key]
        //    public int customerId { get; set; }
        //    public List<int> SimilarcustomersId { get; set; }
        //}
        private class UserMeanrating
        {
            [Key]
            public int User { get; set; }
            public float Meanrating { get; set; }
        }

        private class UserVector
        {
            [Key]
            public int User { get; set; }
            public float Vector { get; set; }
        }

        private class UserSimilarity
        {
            [Key]
            public int User { get; set; }
            public float Similarity { get; set; }
        }
    }
}
