namespace five_word.Library
{
    public class CalulateToBitMask
    {
        public static int CalBitMask (string word)
        {
            int bitmask = 0;
            foreach (char c in word)
            {
                bitmask |= 1 << (c - 'a');
            }
            return bitmask;
        }

        //CountBitmask

        public int CountBits(int bitmask) 
        {
            int count = 0;
            while (bitmask != 0)
            {
                count += bitmask & 1; // how many bit are set
                bitmask >>= 1; 
            }
            return count;
        }

         





    }
}
