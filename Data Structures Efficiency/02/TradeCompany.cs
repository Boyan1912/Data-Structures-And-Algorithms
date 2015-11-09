namespace _02
{
    using Wintellect.PowerCollections;
    public class TradeCompany
    {


        public string Name { get; set; }

        public OrderedMultiDictionary<decimal, Article> Articles { get; set; }

        public OrderedMultiDictionary<decimal, Article>.View ShowArticlesInPriceRange(decimal min, decimal max)
        {
            return this.Articles.Range(min, true, max, true);
        }

    }
}
