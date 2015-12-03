namespace RepeatPattern_Rabin_Karp
{
    using System;
    using System.Text;

    class Hash : IComparable<Hash>
    {
        private ulong Base = 101;

        public Hash()
        {
        }

        public Hash(string pattern)
        {
            this.GetHash(pattern);
        }

        public ulong Value { get; set; }

        public int CompareTo(Hash other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public void GetHash(string symbols)
        {
            int power = symbols.Length - 1;

            for (int i = 0; i < symbols.Length; i++)
            {
                this.AddSymbol(symbols[i]);
                    //(ulong)Math.Pow(this.Base, (power - i));
            }
        }

        public void AddSymbol(char symbol)
        {
            this.Value += (symbol * this.Base);
        }

    }

    class Program
    {

        static void Main()
        {
            string text = Console.ReadLine();
            var result = new StringBuilder();
            var resultHash = new Hash(result.ToString());
            var textHash = new Hash(text);

            var patternHash = new Hash();

            for (int i = 0; i < text.Length; i++)
            {
                result.Append(text[i]);
                resultHash.AddSymbol(text[i]);

                int currentPatternLength = result.Length;
                string patternAtEnd = text.Substring(text.Length - currentPatternLength, currentPatternLength);

                patternHash.AddSymbol(patternAtEnd[0]);
                
                int possibleMatchLength = text.Length / patternAtEnd.Length;

                if (resultHash.Value == patternHash.Value)
                {
                    bool isMatch = true;
                    for (int j = 0; j < possibleMatchLength; j += currentPatternLength)
                    {
                        if (new Hash(text.Substring(j, currentPatternLength)).Value != patternHash.Value)
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch && currentPatternLength * possibleMatchLength == text.Length)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}

