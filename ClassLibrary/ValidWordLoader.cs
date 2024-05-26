using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace five_word.Library
{
    public class ValidWordLoader
    {
        const int WordLength = 5;
       
        //READFILE
        public List<string> ReadFileFromFileStream(Stream fileStream) // parameter string
        {
            var words = new List<string>();    //create object
            using (var reader = new StreamReader(fileStream)) //not load at one time 
            {
                while (!reader.EndOfStream)
                {
                    string word = reader.ReadLine(); //return as string 

                    if (word.Length == WordLength && word.Length == word.Distinct().Count()) //if length 5 as length and remove duplicate&count as length
                    {
                        words.Add(word); // add to words
                    }
                }

            }
            return words;  // method return as 5 letter and non duplicate
        }
    }
}
