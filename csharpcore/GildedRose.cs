using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> items;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                    item.UpdateQuality();
                    item.DecreaseSellIn();                
            }
        }
    }
}
