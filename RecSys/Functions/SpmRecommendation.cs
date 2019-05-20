using RecSys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.Functions
{
    public class SpmRecommendation
    {
        public List<RecommendedItems> Recommend(IList<SequenceSupport> sequenceSupports2Items, IList<UserSequence> userSequences,int recommendationNumber)
        {
            /*************************************************************************************/
            // Fill User Item Matrix based on support of each rule
            /*************************************************************************************/
            List<string> preRule = sequenceSupports2Items.SelectMany(a => a.sequence[0]).ToList();
            List<UserItemRating> userItemRatingMatrix = new List<UserItemRating>();
            foreach (UserSequence userSequence in userSequences)
            {
                List<string> userPurchasedItems = userSequence.Sequence.SelectMany(a => a).Distinct().ToList();
                foreach (string item in userPurchasedItems)
                {
                    if (preRule.Contains(item))
                    {
                        IList<SequenceSupport> sequenceSupports = sequenceSupports2Items
                            .Where(a => string.Equals(a.sequence[0][0], item)).ToList();
                        foreach (SequenceSupport sequenceSupport in sequenceSupports)
                        {
                            if (userItemRatingMatrix.Any(a =>
                                a.UserId == userSequence.User &&
                                a.ItemId == string.Copy(sequenceSupport.sequence[1][0])))
                            {
                                userItemRatingMatrix.FirstOrDefault(a =>
                                        a.UserId == userSequence.User &&
                                        a.ItemId == string.Copy(sequenceSupport.sequence[1][0])).Rating +=
                                    sequenceSupport.support;
                            }
                            else
                            {
                                UserItemRating userItemRating = new UserItemRating();
                                userItemRating.UserId = userSequence.User;
                                userItemRating.ItemId = string.Copy(sequenceSupport.sequence[1][0]);
                                userItemRating.Rating = sequenceSupport.support;
                                userItemRatingMatrix.Add(userItemRating);
                            }
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Step 1: " + DateTime.Now.TimeOfDay + " - UserItemMatrix created");
            /*************************************************************************************/
            // Normalized UserItemRatingMatrix with unit vector method
            /*************************************************************************************/
            IEnumerable<int> users = userItemRatingMatrix.Select(a => a.UserId).Distinct();
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
            System.Diagnostics.Debug.WriteLine("Step 2: " + DateTime.Now.TimeOfDay + " - UserItemMatrix normalized");
            /*************************************************************************************/
            //  Step 5:   Recommend products
            /*************************************************************************************/
            List<RecommendedItems> recomendations = new List<RecommendedItems>() { };
            foreach (int user in users)
            {
                RecommendedItems recomendation = new RecommendedItems() { };
                recomendation.User = user;
                recomendation.Items = new List<ItemRating>();
                IEnumerable<UserItemRating> userItemRatings = userItemRatingMatrixNormalized.Where(a => a.UserId == user).OrderByDescending(a => a.Rating);

                for (int i = 0; i < recommendationNumber; i++)
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
            Console.WriteLine("Step 3: " + DateTime.Now.TimeOfDay + " - Recommend products");
            return recomendations;
        }

        public List<RecommendedItems> RecommendPurchased(IList<SequenceSupport> sequenceSupports2Items, IList<UserSequence> userSequences, int recommendationNumber)
        {
            /*************************************************************************************/
            // Fill User Item Matrix based on support of each rule
            /*************************************************************************************/
            List<string> preRule = sequenceSupports2Items.SelectMany(a => a.sequence[0]).ToList();
            List<UserItemRating> userItemRatingMatrix = new List<UserItemRating>();
            foreach (UserSequence userSequence in userSequences)
            {
                List<string> userPurchasedItems = userSequence.Sequence.SelectMany(a => a).Distinct().ToList();
                foreach (string item in userPurchasedItems)
                {
                    if (preRule.Contains(item))
                    {
                        IList<SequenceSupport> sequenceSupports = sequenceSupports2Items
                            .Where(a => string.Equals(a.sequence[0][0], item)).ToList();
                        foreach (SequenceSupport sequenceSupport in sequenceSupports)
                        {
                            string descendantRule = sequenceSupport.sequence[1][0];
                            //select rules which user has purchased the rule's descendant
                            if (userPurchasedItems.Contains(descendantRule))
                            { 
                                if (userItemRatingMatrix.Any(a =>
                                    a.UserId == userSequence.User &&
                                    a.ItemId == string.Copy(sequenceSupport.sequence[1][0])))
                                {
                                    userItemRatingMatrix.FirstOrDefault(a =>
                                            a.UserId == userSequence.User &&
                                            a.ItemId == string.Copy(sequenceSupport.sequence[1][0])).Rating +=
                                        sequenceSupport.support;
                                }
                                else
                                {
                                    UserItemRating userItemRating = new UserItemRating();
                                    userItemRating.UserId = userSequence.User;
                                    userItemRating.ItemId = string.Copy(sequenceSupport.sequence[1][0]);
                                    userItemRating.Rating = sequenceSupport.support;
                                    userItemRatingMatrix.Add(userItemRating);
                                }
                            }
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Step 1: " + DateTime.Now.TimeOfDay + " - UserItemMatrix created");
            /*************************************************************************************/
            // Normalized UserItemRatingMatrix with unit vector method
            /*************************************************************************************/
            IEnumerable<int> users = userItemRatingMatrix.Select(a => a.UserId).Distinct();
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
            System.Diagnostics.Debug.WriteLine("Step 2: " + DateTime.Now.TimeOfDay + " - UserItemMatrix normalized");
            /*************************************************************************************/
            //  Step 5:   Recommend products
            /*************************************************************************************/
            List<RecommendedItems> recomendations = new List<RecommendedItems>() { };
            foreach (int user in users)
            {
                RecommendedItems recomendation = new RecommendedItems() { };
                recomendation.User = user;
                recomendation.Items = new List<ItemRating>();
                IEnumerable<UserItemRating> userItemRatings = userItemRatingMatrixNormalized.Where(a => a.UserId == user).OrderByDescending(a => a.Rating);

                for (int i = 0; i < recommendationNumber; i++)
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
            Console.WriteLine("Step 3: " + DateTime.Now.TimeOfDay + " - Recommend products");
            return recomendations;
        }

        public List<RecommendedItems> RecommendNotPurchased(IList<SequenceSupport> sequenceSupports2Items, IList<UserSequence> userSequences, int recommendationNumber)
        {
            /*************************************************************************************/
            // Fill User Item Matrix based on support of each rule
            /*************************************************************************************/
            List<string> preRule = sequenceSupports2Items.SelectMany(a => a.sequence[0]).ToList();
            List<UserItemRating> userItemRatingMatrix = new List<UserItemRating>();
            foreach (UserSequence userSequence in userSequences)
            {
                List<string> userPurchasedItems = userSequence.Sequence.SelectMany(a => a).Distinct().ToList();
                foreach (string item in userPurchasedItems)
                {
                    if (preRule.Contains(item))
                    {
                        IList<SequenceSupport> sequenceSupports = sequenceSupports2Items
                            .Where(a => string.Equals(a.sequence[0][0], item)).ToList();
                        foreach (SequenceSupport sequenceSupport in sequenceSupports)
                        {
                            string descendantRule = sequenceSupport.sequence[1][0];
                            //select rules which user has not purchased the rule's descendant
                            if (! userPurchasedItems.Contains(descendantRule))
                            {
                                if (userItemRatingMatrix.Any(a =>
                                a.UserId == userSequence.User &&
                                a.ItemId == string.Copy(sequenceSupport.sequence[1][0])))
                                {
                                    userItemRatingMatrix.FirstOrDefault(a =>
                                            a.UserId == userSequence.User &&
                                            a.ItemId == string.Copy(sequenceSupport.sequence[1][0])).Rating +=
                                        sequenceSupport.support;
                                }
                                else
                                {
                                    UserItemRating userItemRating = new UserItemRating();
                                    userItemRating.UserId = userSequence.User;
                                    userItemRating.ItemId = string.Copy(sequenceSupport.sequence[1][0]);
                                    userItemRating.Rating = sequenceSupport.support;
                                    userItemRatingMatrix.Add(userItemRating);
                                }
                            }
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Step 1: " + DateTime.Now.TimeOfDay + " - UserItemMatrix created");
            /*************************************************************************************/
            // Normalized UserItemRatingMatrix with unit vector method
            /*************************************************************************************/
            IEnumerable<int> users = userItemRatingMatrix.Select(a => a.UserId).Distinct();
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
            System.Diagnostics.Debug.WriteLine("Step 2: " + DateTime.Now.TimeOfDay + " - UserItemMatrix normalized");
            /*************************************************************************************/
            //  Step 5:   Recommend products
            /*************************************************************************************/
            List<RecommendedItems> recomendations = new List<RecommendedItems>() { };
            foreach (int user in users)
            {
                RecommendedItems recomendation = new RecommendedItems() { };
                recomendation.User = user;
                recomendation.Items = new List<ItemRating>();
                IEnumerable<UserItemRating> userItemRatings = userItemRatingMatrixNormalized.Where(a => a.UserId == user).OrderByDescending(a => a.Rating);

                for (int i = 0; i < recommendationNumber; i++)
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
            Console.WriteLine("Step 3: " + DateTime.Now.TimeOfDay + " - Recommend products");
            return recomendations;
        }

        private class UserVector
        {
            [Key]
            public int User { get; set; }
            public float Vector { get; set; }
        }
    }
}
