namespace csharpcore
{
    public static class ItemFactory
    {
        public static Item Build(string name, int sellIn, int quality)
        {
            switch (name)
                {
                    case "Aged Brie":
                        return new IncreasingQualityItem(name, sellIn, quality);
                    case "Sulfuras, Hand of Ragnaros":
                        return new LegendaryItem (name, sellIn, quality);
                    case "Backstage passes to a TAFKAL80ETC concert":
                        return new ConcertTicket (name, sellIn, quality);
                   case "Conjured Mana Cake":
                         return new ConjuredItem (name, sellIn, quality);
                    default:
                        return new DegradingQualityItem (name, sellIn, quality);
                }
        }
    }
}
