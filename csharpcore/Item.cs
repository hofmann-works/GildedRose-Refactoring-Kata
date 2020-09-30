using System;

namespace csharpcore
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        protected Item(string Name, int SellIn, int Quality)
        {
            this.Name = Name;
            this.SellIn = SellIn;
            this.Quality = Quality;
        }

        protected virtual int GetQualityModifier()
        {
            return -1;
        }
        public virtual void DecreaseSellIn()
        {
            SellIn -= 1;
        }
        public virtual void UpdateQuality()
        {
            Quality = Quality + GetQualityModifier();

            if (Quality > MaxQuality)
            {
                Quality = MaxQuality;
            }
            if (Quality < MinQuality)
            {
                Quality = MinQuality;
            }
        }
    }

    public class DegradingQualityItem : Item
    {
        public DegradingQualityItem(string Name, int SellIn, int Quality) : base(Name, SellIn, Quality) { }
        protected override int GetQualityModifier()
        {
            if (SellIn <= 0)
            {
                return base.GetQualityModifier()*2;
            }
            return base.GetQualityModifier();
        }
    }

    public class IncreasingQualityItem : Item
    {
        public IncreasingQualityItem(string Name, int SellIn, int Quality) : base(Name, SellIn, Quality) { }

        protected override int GetQualityModifier()
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
        public LegendaryItem(string Name, int SellIn, int Quality) : base(Name, SellIn, Quality) { }
        public override void DecreaseSellIn()
        {
            // do nothing
        }
        public override void UpdateQuality()
        {
            Quality = 80;
        }
    }

    public class ConcertTicket : Item
    {
        public ConcertTicket(string Name, int SellIn, int Quality) : base(Name, SellIn, Quality) { }
        protected override int GetQualityModifier()
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
        public ConjuredItem(string Name, int SellIn, int Quality) : base(Name, SellIn, Quality) { }
        protected override int GetQualityModifier()
        {
            return base.GetQualityModifier()*2;
        }
    }
}
