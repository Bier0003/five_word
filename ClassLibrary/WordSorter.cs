using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace five_word.Library
{
    public class WordSorter
    {
       
        private int WordCombination;
        private CalulateToBitMask _bitmaskCalculator;

        public WordSorter() //constructor
        {
            _bitmaskCalculator = new CalulateToBitMask();
        }

        public List<string> FilterWords(List<string> words)
        {
            var validWords = new List<string>();

            foreach (var word in words)
            {
                if (!validWords.Any(w => AreAnagrams(w, word))) //if non of any word is anagram then add as valid
                {                                               //an lampda expression
                    validWords.Add(word);
                }
            }
            return validWords; //method retrun validWords
        }

        //make Anagram method bool
        public bool AreAnagrams(string Word1, string Word2) // compair 2 word by make order alphabet then Concat 

        {
            return string.Concat(Word1.OrderBy(C => C)) == string.Concat(Word2.OrderBy(c => c));
        }
        // string concatation =  join string


        //Result write as count
        public int Result(List<string> words)
        {
            return words.Count;


        }

        //Match 25 word
        public List<List<string>> MatchWord(List<string> words)
        {
            WordCombination = 0; // start with no combi
            int targetLength = 25; //words
            int[] bitmasks = new int[words.Count];
            for (int i = 0; i < words.Count; i++)
                bitmasks[i] = CalulateToBitMask.CalBitMask(words[i]);

                                   // Initialize the list to hold all combinations
            List<List<string>> validFiveWordCombinations = new List<List<string>>(); // Call the function with an empty current combination
            FindWords(words, 0, 0, targetLength, new List<string>(), validFiveWordCombinations, bitmasks);

            return validFiveWordCombinations;
        }

        public void FindWords(List<string> words, int bitmask, int pointer, int targetLength, List<string> currentCombination, List<List<string>> validFiveWordCombinations, int[] bitmasks)
        {
            // Check if the current combination has reached the target length
            if (_bitmaskCalculator.CountBits(bitmask) == targetLength)
            {
                // Add the current combination to the list of valid five word combinations
                validFiveWordCombinations.Add(new List<string>(currentCombination));
                WordCombination++;
                return;
            }

            for (int i = pointer; i < words.Count; i++)
            {
                int wordBitmask = bitmasks[i];
                // Check if the current word can be added without repeating characters
                if ((bitmask & wordBitmask) == 0)
                {
                    // Add the current word to the combination
                    currentCombination.Add(words[i]);
                    // Recurse with the updated bitmask and current combination
                    FindWords(words, bitmask | wordBitmask, i + 1, targetLength, currentCombination, validFiveWordCombinations, bitmasks);
                    // Backtrack: remove the current word from the combination
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }





    }
}
