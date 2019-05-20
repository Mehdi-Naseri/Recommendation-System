using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using RecSys.Data;
using RecSys.Functions.SPM;
using RecSys.Models;
using RecSys.ViewModels;

namespace RecSys.Areas.UkRetail.Controllers
{
    [Area("UkRetail")]
    public class SequentialPatternsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SequentialPatternsController(ApplicationDbContext context)
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
        public IActionResult FindSpm(int support, DateTime startDate, DateTime endDate)
        {
            //  IEnumerable<UkRetailOriginalSales> inputDataset = _dbContext.UkRetailOriginalSales.Select(a => a.CustomerID , a. ).ToList();
            var customerOrders = _dbContext.UkRetailOriginalSales
                .Where(a => a.InvoiceDate >= startDate && a.InvoiceDate <= endDate &&
                            a.CustomerID != null && a.CustomerID < 13000 && a.Quantity > 0 &&
                            string.Compare(a.StockCode , "a") == -1)
                .Select(a => new { a.CustomerID, Year = a.InvoiceDate.Year, Month = a.InvoiceDate.Month, a.StockCode })
                //.OrderBy(a => new { a.Year, a.Month })
                .GroupBy(a => new { a.CustomerID }).AsQueryable();
            //.GroupBy(a => new { a.CustomerID, a.Year, a.Month }); 

            List<List<List<string>>> transformedSequences = new List<List<List<string>>>();
            foreach (var groupCustomer in customerOrders)
            {
                var customerMonthlyorder = groupCustomer.GroupBy(a => new { a.Year, a.Month });
                List<List<string>> sequence = new List<List<string>>();
                foreach (var groupCustomerMontlyOrder in customerMonthlyorder)
                {
                    List<string> itemset = new List<string>();
                    foreach(var order in groupCustomerMontlyOrder)
                    {
                        itemset.Add(order.StockCode);
                    }
                    sequence.Add(itemset);
                }
                transformedSequences.Add(sequence);
            }

            GSP gsp = new GSP();
            List<SequenceSupport> frequentSequences = gsp.FindSequentialPatterns(transformedSequences, support);

            List<SequenceSupportPercentage> frequentSequencesPercentages = new List<SequenceSupportPercentage>();
            foreach (SequenceSupport frequentSequence in frequentSequences)
            {
                SequenceSupportPercentage frequentSequencesPercentage = new SequenceSupportPercentage();
                frequentSequencesPercentage.sequence = frequentSequence.sequence;
                frequentSequencesPercentage.support = frequentSequence.support;
                frequentSequencesPercentage.supportPercentage = ((float)frequentSequence.support / transformedSequences.Count())*100;
                frequentSequencesPercentages.Add(frequentSequencesPercentage);
            }

            // SavetoDatabase(frequentSequencesPercentages.Where(a => a.sequence.Count()>1).ToList());
            SavetoDatabase(frequentSequencesPercentages.ToList());
            //return View(frequentSequences.Where(a => a.sequence.Count>=1));
            return View(frequentSequencesPercentages);
        }

        private void SavetoDatabase(List<SequenceSupportPercentage> frequentSequencesPercentages)
        {
            //Clean table
            _dbContext.FrequentSequentialPattern.RemoveRange(_dbContext.FrequentSequentialPattern);

            List<FrequentSequentialPattern> frequentSequentialPatterns = new List<FrequentSequentialPattern>();
            foreach (SequenceSupportPercentage sequenceSupportPercentage in frequentSequencesPercentages)
            {
                StringBuilder sequence = new StringBuilder();
                sequence.Append("<");
                foreach (List<string> itemset in sequenceSupportPercentage.sequence)
                {
                    sequence.Append("(");
                    for (int i = 0; i < itemset.Count - 1; i++)
                    {
                        sequence.Append(itemset[i]);
                        sequence.Append(" - ");
                    }

                    sequence.Append(itemset.Last());
                    sequence.Append(")");
                }
                sequence.Append(">");
                FrequentSequentialPattern frequentSequentialPattern = new FrequentSequentialPattern();
                frequentSequentialPattern.Support = sequenceSupportPercentage.support;
                frequentSequentialPattern.Sequence = sequence.ToString();
                frequentSequentialPatterns.Add(frequentSequentialPattern);
            }

            _dbContext.FrequentSequentialPattern.AddRange(frequentSequentialPatterns);
            _dbContext.SaveChanges();
        }
    }
}