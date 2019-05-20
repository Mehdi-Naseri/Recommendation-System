using RecSys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Design;

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
    }
}
