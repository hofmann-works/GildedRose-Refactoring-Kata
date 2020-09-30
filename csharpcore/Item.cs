using System;

namespace csharpcore
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        protected virtual int getQualityModifier()
        {
            return -1;
        }
        public virtual void DecreaseSellIn()
        {
            SellIn -= 1;
        }
        public virtual void updateQuality()
        {
            Quality = Quality + getQualityModifier();

            if (Quality > 50)
            {
                Quality = 50;
            }
            if (Quality < 0)
            {
                Quality = 0;
            }
        }
    }

    public class DegradingQualityItem : Item
    {
        protected override int getQualityModifier()
        {
            if (SellIn <= 0)
            {
                return base.getQualityModifier()*2;
            }
            return base.getQualityModifier();
        }
    }

    public class IncreasingQualityItem : Item
    {
        protected override int getQualityModifier()
        {
            if (SellIn <= 0)
            {
                return 2;
            }
            return 1;
        }
    }

    public class LegendaryItem : Item
    {
        public override void DecreaseSellIn()
        {
            // do nothing
        }
        public override void updateQuality()
        {
            Quality = 80;
        }
    }

    public class ConcertTicket : Item
    {
        protected override int getQualityModifier()
        {
            //  Quality drops to 0 after the concert.
            if (SellIn <= 0)
            {
                return Quality * -1;
            }

            if (SellIn <= 5)
            {
                return 3;
            }

            if (SellIn <= 10)
            {
                return 2;
            }

            return 1;
        }

    }

    public class ConjuredItem : DegradingQualityItem
    {
        protected override int getQualityModifier()
        {
            return base.getQualityModifier()*2;
        }
    }
}
