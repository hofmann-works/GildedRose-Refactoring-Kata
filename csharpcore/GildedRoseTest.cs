using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        //At the end of each day the system lowers both values (SellIn, Quality) for every item.
        [Fact]
        public void itemDegradeNormal()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("+5 Dexterity Vest", 5, 5 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(4, Items[0].Quality);
        }

        //Once the sell by date has passed, Quality degrades twice as fast.
        [Fact]
        public void itemDegradeZeroSellIn()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("+5 Dexterity Vest",0, 5 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(3, Items[0].Quality);
        }

        // The Quality of an item is never negative
        [Fact]
        public void itemQualityNeverNegative()
        {
            IList<Item> Items = new List<Item> {
                ItemFactory.Build("+5 Dexterity Vest",10, 20),
                ItemFactory.Build("Aged Brie", 2, 0),
                ItemFactory.Build("Elixir of the Mongoose", 5, 0),
                ItemFactory.Build("Sulfuras, Hand of Ragnaros", 0, 80),
                ItemFactory.Build("Sulfuras, Hand of Ragnaros", -1, 0),
                ItemFactory.Build("Backstage passes to a TAFKAL80ETC concert", 15, 0 ),
                ItemFactory.Build("Backstage passes to a TAFKAL80ETC concert", 10, 0 ),
                ItemFactory.Build("Backstage passes to a TAFKAL80ETC concert", 5, 0 ),
                };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var Item in Items)
            {   
                Assert.True(Item.Quality > -1);
            }
        }

        //"Aged Brie" actually increases in Quality the older it gets
        [Fact]
        public void itemIncreaseQualityNormal()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("Aged Brie", 5, 5 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(6, Items[0].Quality);
        }

        //Not listed in Requirements. Original behavior of GildedRose.cs
        //Once the sell by date of "Aged Brie" has passed, Quality increases twice as fast.
        [Fact]
        public void itemIncreaseQualityZeroSellIn()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("Aged Brie", 0, 5 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(7, Items[0].Quality);
        }


        //The Quality of an item is never more than 50
        [Fact]
        public void itemIncreaseQualityMax()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("Aged Brie", 0, 50 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);
        }

        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        // Official GitHub Requirement: Sulfuras" is alegendary item and as such its Quality is 80 and it never alters.
        [Fact]
        public void legendaryItemDoNothing()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("Sulfuras, Hand of Ragnaros", 27, 75 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(27, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        // Increase Quality the older it gets
        [Fact]
        public void concertTicketIncreaseQualityNormal()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("Backstage passes to a TAFKAL80ETC concert",23, 32 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(22, Items[0].SellIn);
            Assert.Equal(33, Items[0].Quality);
        }

        // Increase 2 when SellIn is low
        [Fact]
        public void concertTicketIncreaseQualityLowSellIn()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build( "Backstage passes to a TAFKAL80ETC concert", 10, 32 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(34, Items[0].Quality);
        }
        
        // Increase 3 when SellIn is very low
        [Fact]
        public void concertTicketIncreaseQualityVeryLowSellIn()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("Backstage passes to a TAFKAL80ETC concert", 5, 32 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(35, Items[0].Quality);
        }

        //  Official GitHub Requirement: "Conjured" items degrade in Quality twice as fast as normal items
        [Fact]
        public void conjuredItemDegradeNormal()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("Conjured Mana Cake", 5, 32 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(30, Items[0].Quality);
        }

        //  Official GitHub Requirement: "Conjured" items degrade in Quality twice as fast as normal items
        [Fact]
        public void conjuredItemDegradeZeroSellIn()
        {
            IList<Item> Items = new List<Item> { ItemFactory.Build("Conjured Mana Cake", 0, 32 ) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(28, Items[0].Quality);
        }

    }
}