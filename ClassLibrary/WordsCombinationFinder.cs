namespace five_word.Library
{
    public class WordsCombinationFinder
    {
        private List<string> validWords;

        public WordsCombinationFinder(List<string> validWords)
        {
        }

        private static List<Tuple<string, string>> MatchWords(List<string> validWords)
        {
            var wordPairs = new List<Tuple<string, string>>();

            for (int i = 0; i < validWords.Count; i++)
            {
                for (int j = i + 1; j < validWords.Count; j++)
                {
                    if (validWords[i].Length == validWords[j].Length)
                    {
                        wordPairs.Add(new Tuple<string, string>(validWords[i], validWords[j]));
                    }
                }
            }
            return wordPairs;






            // var wordpairs = MatchWord(validWords); 
            // //declar wordpair
            //// Console.WriteLine($"\nFund {wordpairs} combinations");

            // return wordpairs;

        }
    }
}
