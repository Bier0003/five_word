namespace five_word
{
    public class Program
    {
        static void Main(string[] args)
        {

            string result = Word();
            Console.WriteLine(result);
            SaveReSult(result);
        }

        static void SaveReSult(string result)
        {
            string SavePath = @"C:\Users\b\OneDrive\Documents\h2\five_word\five_word\firstfive.txt";
            try
            {

                File.WriteAllText(SavePath, result);

                Console.WriteLine("Save successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :{ex.message}");
            }

        }



        static string Word()
        {

            string[] Alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string result = "";
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    result += (Alphabet[i + (5 * j)]);
                }
                // Console.Write('\n');
                result += '\n';
            }

            return result;




        }
    }
}
