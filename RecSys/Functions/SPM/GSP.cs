using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

using RecSys.ViewModels;

namespace RecSys.Functions.SPM
{
    public class GSP
    {

        public List<SequenceSupport> FindSequentialPatterns(List<List<List<string>>> datasetSequences, int support)
        {
            List<SequenceSupport> frequentSequences = new List<SequenceSupport>();
            List<SequenceSupport> candidates = new List<SequenceSupport>();

            float supportFrequency = ((float)support / 100) * datasetSequences.Count();

            //Find all 1 items
            List<string> items = new List<string>();

            items = datasetSequences.SelectMany(a => a.SelectMany(i => i)).Distinct().OrderBy(a => a).ToList();

            foreach (string item in items)
            {
                SequenceSupport candidate = new SequenceSupport();
                candidate.sequence = new List<List<string>>() { new List<string>() { item } };
                candidates.Add(candidate);
            }

            //Calculate 1 itemsets frequency
            candidates = CountSupport(datasetSequences, candidates);

            //Find frequent 1 itemsset 
            frequentSequences = candidates.Where(a => a.support >= supportFrequency).ToList();
            List<List<List<string>>> lastFrequentSequences = frequentSequences.Select(a => a.sequence).ToList();

            int sequenceLenght = 0;
            System.Diagnostics.Debug.WriteLine("Start Sequence Lenght:"+sequenceLenght++ + " : " + DateTime.Now.TimeOfDay);
            bool l1Join = true;
            while (lastFrequentSequences.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine("Start Sequence Lenght:" + sequenceLenght++ +" : "+ DateTime.Now.TimeOfDay);
                if (l1Join == true)
                { 
                    candidates = CandidateGenerationC2(lastFrequentSequences);
                    l1Join = false;
                }
                else
                {
                    candidates = CandidateGeneration(lastFrequentSequences);
                    candidates = CandidatePruning(candidates, lastFrequentSequences);
                }
                candidates = SupportCounting(datasetSequences , candidates);
                candidates = CandidateElimination(candidates, supportFrequency);

                frequentSequences.AddRange(candidates);
                lastFrequentSequences = candidates.Select(a => a.sequence).ToList();
            }
            //comment!

            return frequentSequences;
        }

        private List<SequenceSupport> CandidatePruning(List<SequenceSupport> candidates, List<List<List<string>>> lastFrequentSequences)
        {
            List<SequenceSupport> candidatesPruned = new List<SequenceSupport>();
            foreach(SequenceSupport candidate in candidates)
            {
                List<List<List<string>>> candidateSubsequences = new List<List<List<string>>>();
                //foreach (List<string> candidateitemset in candidate.sequence)
                for(int i=0; i< candidate.sequence.Count();i++)
                {
                    if (candidate.sequence[i].Count == 1)
                    {
                        List<List<string>> candidateSubsequence = candidate.sequence.ConvertAll(a => new List<string>(a.ToList()));
                        candidateSubsequence.RemoveAt(i);
                        candidateSubsequences.Add(candidateSubsequence);
                    }
                    else
                    {
                        for (int j = 0; j < candidate.sequence[i].Count(); j++)
                        {
                            List<List<string>> candidateSubsequence = candidate.sequence.ConvertAll(a => new List<string>(a.ToList()));
                            candidateSubsequence[i].RemoveAt(j);
                            candidateSubsequences.Add(candidateSubsequence);
                        }
                    }
                }

                bool allSubcandidateAreFrequent = true;
                foreach (List<List<string>> candidateSubsequence in candidateSubsequences)
                {
                    bool subcandidateIsFrequent = false;
                    foreach (List<List<string>> lastFrequentSequence in lastFrequentSequences)
                    {
                        if (CompareListofLists(candidateSubsequence, lastFrequentSequence))
                        {
                            subcandidateIsFrequent = true;
                            break;
                        }
                    }
                    if(subcandidateIsFrequent == false)
                    {
                        allSubcandidateAreFrequent = false;
                    }
                }
                if(allSubcandidateAreFrequent)
                {
                    candidatesPruned.Add(candidate);
                }
            }
            return candidatesPruned;
        }

        private List<SequenceSupport> CandidateGeneration(List<List<List<string>>> lastFrequentSequences)
        {
            
            List<SequenceTrimed> SequencesTrimed = new List<SequenceTrimed>();
            foreach (List<List<string>> sequence in lastFrequentSequences)
            {
                SequenceTrimed SequenceTrimed = new SequenceTrimed();
                SequenceTrimed.sequenceOriginal = new List<List<string>>(sequence);
                List<List<string>> sequenceCopied = sequence.ConvertAll(a => new List<string>(a.ToList())); 
                //First itemset lenght ==1  E.g. A(BC)
                if (sequence[0].Count == 1)
                {
                    sequenceCopied.RemoveAt(0);
                    SequenceTrimed.sequenceRemovedFirst = sequenceCopied.ConvertAll(a => new List<string>(a.ToList()));


                    sequenceCopied = sequence.ConvertAll(a => new List<string>(a.ToList()));
                    int sequenceCount = sequence.Count();
                    if (sequence[sequenceCount - 1].Count == 1)
                    {
                        //First itemset lenght ==1 & last itemset==1 ----- E.g. AB
                        sequenceCopied.RemoveAt(sequenceCount - 1);
                        SequenceTrimed.sequenceRemovedLast = sequenceCopied.ConvertAll(a => new List<string>(a.ToList()));
                        SequenceTrimed.lastItem = sequence[sequenceCount - 1].First();

                        SequencesTrimed.Add(SequenceTrimed);
                    }
                    else
                    {
                        //First itemset lenght == 1 & last itemset > 1 ----- E.g. A(BC)
                        foreach (string item in sequence[sequenceCount - 1])
                        {
                            sequenceCopied = sequence.ConvertAll(a => new List<string>(a.ToList()));
                            sequenceCopied[sequenceCount - 1].Remove(item);
                            SequenceTrimed.sequenceRemovedLast = sequenceCopied.ConvertAll(a => new List<string>(a.ToList()));
                            SequenceTrimed.lastItem = item;

                            SequencesTrimed.Add(SequenceTrimed);
                        }
                    }
                    
                }
                else
                {
                    foreach (string item in sequence[0])
                    {
                        
                        sequenceCopied = sequence.ConvertAll(a => new List<string>(a.ToList()));
                        sequenceCopied[0].Remove(item);
                        SequenceTrimed.sequenceRemovedFirst = sequenceCopied.ConvertAll(a => new List<string>(a.ToList()));

                        int sequenceCount = sequence.Count();
                        if (sequence[sequenceCount - 1].Count == 1)
                        {
                            //First itemset lenght > 1 & last itemset == 1 ----- E.g. (AB)C
                            sequenceCopied.RemoveAt(sequenceCount - 1);
                            SequenceTrimed.sequenceRemovedLast = sequenceCopied.ConvertAll(a => new List<string>(a.ToList()));
                            SequenceTrimed.lastItem = sequence[sequenceCount - 1].First();

                            SequencesTrimed.Add(SequenceTrimed);
                        }
                        else
                        {
                            foreach (string itemlast in sequence[sequenceCount - 1])
                            {
                                //First itemset lenght > 1 & last itemset > 1 ----- E.g. (AB)(CD)
                                sequenceCopied = sequence.ConvertAll(a => new List<string>(a.ToList()));
                                sequenceCopied[sequenceCount - 1].Remove(itemlast);
                                SequenceTrimed.sequenceRemovedLast = sequenceCopied.ConvertAll(a => new List<string>(a.ToList()));
                                SequenceTrimed.lastItem = itemlast;

                                SequencesTrimed.Add(SequenceTrimed);
                            }
                        }
                    }
                }
            }

            List<SequenceSupport> candidates = new List<SequenceSupport>();
            foreach (SequenceTrimed sequenceTrimed1 in SequencesTrimed)
            {
                foreach (SequenceTrimed sequenceTrimed2 in SequencesTrimed)
                {
                    if(CompareListofLists(sequenceTrimed1.sequenceRemovedFirst,sequenceTrimed2.sequenceRemovedLast))
                    {
                        SequenceSupport candidate = new SequenceSupport();
                        if (sequenceTrimed2.sequenceOriginal.Last().Count() == 1)
                        {
                            candidate.sequence= sequenceTrimed1.sequenceOriginal.ConvertAll(a => new List<string>(a.ToList()));
                            candidate.sequence.Add(new List<string>() { sequenceTrimed2.lastItem });
                            if(candidateNotExist(candidates, candidate))
                            { 
                                candidates.Add(candidate);
                            }
                        }
                        else
                        {
                            if(! sequenceTrimed1.sequenceOriginal.Last().Contains(sequenceTrimed2.lastItem))
                            { 
                                candidate.sequence = sequenceTrimed1.sequenceOriginal.ConvertAll(a => new List<string>(a.ToList())); ;
                                candidate.sequence.Last().Add(sequenceTrimed2.lastItem);
                                if (candidateNotExist(candidates, candidate))
                                {
                                    candidates.Add(candidate);
                                }
                            }
                        }
                        
                    }
                    
                }
            }
            return candidates;
        }

        private bool candidateNotExist(List<SequenceSupport> candidates, SequenceSupport candidate)
        {
            bool notexist = true;
            foreach(SequenceSupport existingCandidate in candidates)
            {
                if(CompareListofLists(existingCandidate.sequence, candidate.sequence))
                {
                    notexist = false;
                }
            }
            return notexist;
        }

        private bool CompareListofLists(List<List<string>> sequence1RemovedFirst, List<List<string>> sequence2RemovedLast)
        {
            bool comparison = false;
            int lenght = sequence1RemovedFirst.Count();
            if (lenght == sequence2RemovedLast.Count())
            {
                comparison = true;
                for(int i=0; i<lenght; i++)
                {
                    if(!sequence1RemovedFirst[i].SequenceEqual(sequence2RemovedLast[i]))
                    {
                        comparison = false;
                        break;
                    }
                }
            }
            else
            {
                comparison = false;
            }
            return comparison;
        }

        private List<SequenceSupport> CountSupport(List<List<List<string>>> sequences, List<SequenceSupport> candidates)
        {
            foreach (SequenceSupport candidate in candidates)
            {
                foreach (List<List<string>> sequence in sequences)
                {
                    foreach (List<string> itemset in sequence)
                        if (itemset.Contains(candidate.sequence.First()[0]))
                        {
                            candidate.support++;
                            break;
                        }
                }
            }
            return candidates;

        }

        private List<SequenceSupport> CandidateElimination(List<SequenceSupport> candidates, float supportFrequency)
        {
            List<SequenceSupport> frequentCandidates = new List<SequenceSupport>();
            foreach (SequenceSupport candidate in candidates)
            {
                if (candidate.support >= supportFrequency)
                {
                    frequentCandidates.Add(candidate);
                }
            }
            return frequentCandidates;
        }

        private List<SequenceSupport> SupportCounting(List<List<List<string>>> datasetSequences, List<SequenceSupport> candidates)
        {
            foreach (SequenceSupport candidate in candidates)
            {
                int candidateLenght = candidate.sequence.Count();
                foreach (List<List<string>> datasetSequence in datasetSequences)
                {
                    //E.g. Candidate: <AB>  &  datasetSequense: <A B (FG) C D>
                    int similarityCount = 0;
                    for (int i = 0; i < datasetSequence.Count(); i++)
                    {
                        bool similarityCandidateitemsetSequenceitemset = false;
                        foreach (string candidateItem in candidate.sequence[similarityCount])
                        {
                            similarityCandidateitemsetSequenceitemset = true;
                            if (!datasetSequence[i].Contains(candidateItem))
                            {
                                similarityCandidateitemsetSequenceitemset = false;
                                break;
                            }
                        }

                        if (similarityCandidateitemsetSequenceitemset == true)
                        {
                            similarityCount++;
                        }

                        if (similarityCount == candidateLenght)
                        {
                            candidate.support++;
                            similarityCount = 0;
                            break;
                        }
                    }


                }
            }
            return candidates;
        }

        private List<SequenceSupport> CandidateGenerationC2(List<List<List<string>>> lastFrequentSequences)
        {
            List<SequenceSupport> candidates = new List<SequenceSupport>();
            foreach (List<List<string>> lastFrequentSequence1 in lastFrequentSequences)
            {
                foreach (List<List<string>> lastFrequentSequence2 in lastFrequentSequences)
                {
                    string item1 = lastFrequentSequence1.First()[0];
                    string item2 = lastFrequentSequence2.First()[0];

                    SequenceSupport candidate1 = new SequenceSupport();
                    candidate1.sequence = new List<List<string>>() { new List<string>() { item1 }, new List<string>() { item2 } };
                    candidates.Add(candidate1);

                    if (string.Compare(item1, item2) < 0)
                    {
                        SequenceSupport candidate2 = new SequenceSupport();
                        candidate2.sequence = new List<List<string>>() { new List<string>() { item1, item2 } };
                        candidates.Add(candidate2);
                    }
                }
            }
            return candidates;
        }

        private class SequenceTrimed
        {
            public List<List<string>> sequenceOriginal { get; set; }
            public List<List<string>> sequenceRemovedFirst { get; set; }
            public List<List<string>> sequenceRemovedLast { get; set; }
            public string lastItem { get; set; }
        }
    }
}
