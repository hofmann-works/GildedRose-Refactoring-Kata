using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> items = new List<Item>{
                ItemFactory.Build("+5 Dexterity Vest", 10, 20),
                ItemFactory.Build("Aged Brie", 2, 0),
                ItemFactory.Build("Elixir of the Mongoose", 5, 7),
                ItemFactory.Build("Sulfuras, Hand of Ragnaros", 0, 80),
                ItemFactory.Build("Sulfuras, Hand of Ragnaros", -1, 80),
                ItemFactory.Build("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                ItemFactory.Build("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                ItemFactory.Build("Backstage passes to a TAFKAL80ETC concert", 5, 49),
                ItemFactory.Build("Conjured Mana Cake", 3, 6)
            };

            var app = new GildedRose(items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    System.Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
