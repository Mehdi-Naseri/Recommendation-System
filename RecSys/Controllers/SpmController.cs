using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using RecSys.Functions.SPM;
using RecSys.ViewModels;

namespace RecSys.Controllers
{
    public class SpmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindSpm(string inputData, int support)
        {
            List<List<List<string>>> transformedSequences = new List<List<List<string>>>();
           // List<List<string>> inputSequence = new List<List<string>>();
           // List<string> itemList = new List<List<string>>();

            List<string> sequenceList = new List<string>();
            sequenceList = inputData.Split("\r\n").Where(r => (r != "") && (r != " ")).ToList();
            //sequenceList = inputData.Split('<','>').Where(r => (r != "") && (r != "\r\n")).ToList();
            foreach (string sequence in sequenceList)
            {
                List<string> sequenceItemlists = sequence.Split(' ').ToList();

                List<List<string>> inputSequence = new List<List<string>>();
                foreach (string sequenceItemlist in sequenceItemlists)
                {
                    List<string> itemlist = sequenceItemlist.Split(',').ToList();
                    inputSequence.Add(itemlist);
                }
                transformedSequences.Add(inputSequence);
            }

            GSP gsp = new GSP();
            List<SequenceSupport> frequentSequences =  gsp.FindSequentialPatterns(transformedSequences, support);
            List<SequenceSupportPercentage> frequentSequencesPercentages = new List<SequenceSupportPercentage>();
            foreach(SequenceSupport frequentSequence in frequentSequences)
            {
                SequenceSupportPercentage frequentSequencesPercentage = new SequenceSupportPercentage();
                frequentSequencesPercentage.sequence = frequentSequence.sequence;
                frequentSequencesPercentage.support = frequentSequence.support;
                frequentSequencesPercentage.supportPercentage = ((float)frequentSequence.support/ transformedSequences.Count())*100;
                frequentSequencesPercentages.Add(frequentSequencesPercentage);
            }

            return View(frequentSequencesPercentages);
        }
    }
}