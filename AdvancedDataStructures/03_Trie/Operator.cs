namespace Trie
{
    using System.Linq;

    public class Operator
    {

        public WordsDB db { get; set; }

        public char ReadLetter(string word, int index)
        {
            return word[index];
        }

        public Pointer Pointer { get; set; }

        public char[] ReturnPossibilities(string prefix, int index)
        {
            var possibilities = db.Words.Where(x => x.Substring(0, index).Equals(prefix))
                                   .Where(s => s.Length < index + 1)
                                   .Select(ch => ch[index + 1]);

            return possibilities.ToArray();
            
        }

        
    }
}
