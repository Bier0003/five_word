using System.Diagnostics.Tracing;
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using five_word.Library;
using System.Threading;
using System.Data;
using System.Reflection.Metadata;


namespace five_word
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("________________________________________________________________________________________\n");
            Console.WriteLine(" Five letters Five words Look up !\n");
            Console.WriteLine("_________________________________________________________________________________________\n");

            Console.WriteLine("write your path file\n");
            Console.WriteLine("Patch :   ");

            string File = Console.ReadLine();

            Console.WriteLine("\n");
            Console.WriteLine("****************************************************************************************\n");

            Console.WriteLine("We operation looking for 5 letters  5 words from your file ....\n");

            Thread.Sleep(1000);

            var openfile = new Openfile(File);
            var wordLoader = new ValidWordLoader();
            var wordSorter = new WordSorter();

            var stopwatch = Stopwatch.StartNew();
            var loadedWords = wordLoader.ReadFileFromFileStream(openfile.GetFileStream());
            var sortedWords = wordSorter.FilterWords(loadedWords);
            var matchedWords = wordSorter.MatchWord(sortedWords);
            stopwatch.Stop();

            Console.WriteLine($"words from input: {loadedWords.Count}");
            Console.WriteLine($"\nFund {matchedWords.Count} combinations");
            Console.WriteLine("The combinations are:");
            foreach (var validWordCombination in matchedWords)
                Console.WriteLine(String.Join(" ", validWordCombination));
            

            Console.WriteLine("________________________________________________________________________________________\n");

            Console.WriteLine($"Time  in milliseconds: {stopwatch.ElapsedMilliseconds}");

            Console.WriteLine("________________________________________________________________________________________\n");





            //    var Openfile = new Openfile("words_beta_new.txt");


            //    var stopwatch = Stopwatch.StartNew();
            ////    for (int i = 0; i < 5; i++)
            //  //  {
            //        var Content = Openfile.Run();
            //    // }

            //    stopwatch.Stop();

            //    Console.WriteLine($"Time in milliseconds: {stopwatch.ElapsedMilliseconds}");

            //[first task]

            //var result = SaveFile.Word();
            //Console.WriteLine(result);

            //SaveFile.SaveReSult(result);
        }
    }
}
