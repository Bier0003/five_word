using five_word.Library;

namespace fiveletters.unittests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Openfile_FileWith77Combinations_77CombinationsFound() //methodname_input_expectation
        {
            //arrange
            var openFile  = new Openfile("words_beta_new.txt");
            var wordLoader = new ValidWordLoader();
            var wordSorter = new WordSorter();

            //act
            var loadedWords = wordLoader.ReadFileFromFileStream(openFile.GetFileStream());
            var sortedWords = wordSorter.FilterWords(loadedWords);
            var matchedWords = wordSorter.MatchWord(sortedWords);


            //assert
            Assert.IsTrue(matchedWords.Count == 77);
        }

        [Test]
        public void WordSorter_TwoWordsAreAnagrams_ReturnTrue()
        {
            //arrange
            var wordSorter = new WordSorter();

            //act
            var areAnagrams = wordSorter.AreAnagrams("listen", "silent");

            //assert
            Assert.IsTrue(areAnagrams);

        }

        [Test]
        public void WordSorter_TwoWordsAreNotAnagrams_ReturnFalse()
        {
            //arrange
            var wordSorter = new WordSorter();

            //act
            var areAnagrams = wordSorter.AreAnagrams("gram", "arm");

            //assert
            Assert.IsFalse(areAnagrams);

        }
    }
}