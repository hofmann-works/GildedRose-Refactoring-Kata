using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private void DegradeItem(Item item, int degradation)
        {
            item.SellIn -= 1;
            // prevent negative quality
            item.Quality = Math.Max(0, item.Quality - degradation);
        }

        private void IncreaseItemQuality(Item item, int increaseQuality)
        {
            item.SellIn -= 1;
            // prevent quality higher than 50
            item.Quality = Math.Min(50, item.Quality + increaseQuality);
        }

        public void UpdateQuality()
        {
            foreach (Item Item in Items)
            {
                // default degradation
                int degradation = 1;
                // default quality increase
                int increaseQuality = 1;

                switch (Item.Name)
                {
                    case "Aged Brie":
                        if (Item.SellIn <= 0)
                        {
                            increaseQuality = increaseQuality*2;
                        }
                        IncreaseItemQuality(Item,increaseQuality);
                        break;
                    
                    case "Sulfuras, Hand of Ragnaros":
                        Item.Quality = 80;
                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":
                        //  Quality drops to 0 after the concert.
                        if (Item.SellIn <= 0)
                        {
                            DegradeItem(Item,Item.Quality);
                            continue;
                        }
                        
                        if (Item.SellIn <= 10)
                        {
                            increaseQuality = 2;
                        }

                        if (Item.SellIn <= 5)
                        {
                            increaseQuality = 3;
                        }

                        IncreaseItemQuality(Item,increaseQuality);
                        break;

                   case "Conjured Mana Cake":
                        degradation = 2;

                        if (Item.SellIn <= 0)
                        {
                            degradation = degradation*2;
                        }
                        DegradeItem(Item,degradation);
                        break;
                    
                    default:
                        if (Item.SellIn <= 0)
                        {
                            degradation = degradation*2;
                        }
                        DegradeItem(Item,degradation);
                        break;
                }
                
            }
        }
    }
}
