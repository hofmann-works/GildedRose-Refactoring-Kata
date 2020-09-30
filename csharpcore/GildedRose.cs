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

        public void UpdateQuality()
        {
            foreach (Item Item in Items)
            {
                    Item.updateQuality();
                    Item.DecreaseSellIn();                
            }
        }
    }
}
