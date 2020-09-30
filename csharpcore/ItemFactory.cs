namespace csharpcore
{
    public static class ItemFactory
    {
        public static Item Build(Item Item)
        {
            switch (Item.Name)
                {
                    case "Aged Brie":
                        return new IncreasingQualityItem {Name = Item.Name, SellIn = Item.SellIn, Quality = Item.Quality};
                    case "Sulfuras, Hand of Ragnaros":
                        return new LegendaryItem {Name = Item.Name, SellIn = Item.SellIn, Quality = Item.Quality};
                    case "Backstage passes to a TAFKAL80ETC concert":
                        return new ConcertTicket {Name = Item.Name, SellIn = Item.SellIn, Quality = Item.Quality};
                   case "Conjured Mana Cake":
                         return new ConjuredItem {Name = Item.Name, SellIn = Item.SellIn, Quality = Item.Quality};
                    default:
                        return new DegradingQualityItem {Name = Item.Name, SellIn = Item.SellIn, Quality = Item.Quality};
                }
        }
    }
}
