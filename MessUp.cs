using System;

namespace FakeThat
{
    class MessUp
    {
        public static string DoMess(string s, string alphabet, double rate)
        {
            Random rnd = new Random();
            int amount = Convert.ToInt32(Math.Floor(rate)) + (rate % 1 > rnd.NextDouble() ? 1 : 0);
            string str = s;
            for(int i = 0; i< amount; i++)
                str = HowToMess(str, rnd, alphabet);
            return str;
        }
        public static string HowToMess(string s, Random rnd, string alphabet) 
        {
            int r = rnd.Next(3);
            int index = rnd.Next(s.Length);
            if      (r == 0) { return Shuffle(s, rnd); }
            else if (r == 1) { return Reduce (s, index); }
            else             { return Append (s, rnd, index, alphabet); }; 
        }
        public static string Shuffle(string s, Random rnd) 
        {
            int index = rnd.Next(s.Length-1);            
            string ch = s.Substring(index, 1), reduced = s.Remove(index,1);
            return reduced.Substring(0, index+1) + ch + reduced.Substring(index+1);
        }
        public static string Reduce(string s, int index) 
        {
            return s.Remove(index, 1); 
        }
        public static string Append(string s, Random rnd, int i, string alphabet) 
        {
            int alphabetIndex = rnd.Next(alphabet.Length);
            var ch = alphabet.Substring(alphabetIndex, 1);
            return s.Insert(i, ch);
        }
    }
}
