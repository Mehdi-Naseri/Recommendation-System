using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecSys.Models;

namespace RecSys.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<RecSys.Models.UkRetailOriginalSales> UkRetailOriginalSales { get; set; }

        public DbSet<RecSys.Models.FrequentSequentialPattern> FrequentSequentialPattern { get; set; }

        public DbSet<RecSys.Models.PurchaseHistoryRecommendation> PurchaseHistoryRecommendation { get; set; }

        public DbSet<RecSys.Models.CollaborativeRecommendation> CollaborativeRecommendation { get; set; }

        public DbSet<RecSys.Models.SequentialRecommendation> SequentialRecommendation { get; set; }

        public DbSet<RecSys.Models.CollaborativeNotPurchasedRecommendation> CollaborativeNotPurchasedRecommendation { get; set; }

        public DbSet<RecSys.Models.EnsembleRecommendation> EnsembleRecommendation { get; set; }

        public DbSet<RecSys.Models.Recommendation> Recommendation { get; set; }
        public DbSet<RecSys.Models.RecommendationInfo> RecommendationInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Recommendation>().HasKey(u => new { u.RecommendationInfoId, u.UserId });
        }
    }
}
