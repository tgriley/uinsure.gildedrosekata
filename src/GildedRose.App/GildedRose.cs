using System;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        public void ProcessItems()
        {
            foreach (var item in Items)
            {
                UpdateItemSellIn(item);
                UpdateItemQuality(item);
            }
        }

        private static void UpdateItemSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }
        }

        private static void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePassItemQuality(item);
                    return;
                case "Aged Brie":
                    UpdateAppreciatingItemQuality(item);
                    return;
                case "Sulfuras, Hand of Ragnaros":
                    return;
                default:
                    UpdateBasicItemQuality(item);
                    break;
            }
        }

        private static void UpdateAppreciatingItemQuality(Item item)
        {
            if (item.Quality is < 0)
                return;
            
            var modifier = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Min(item.Quality + modifier, 50);
        }

        private static void UpdateBackstagePassItemQuality(Item item)
        {
            if (item.Quality is < 0)
                return;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            var modifier = 1;
            if (item.SellIn < 10) modifier++;
            if (item.SellIn < 5) modifier++;

            item.Quality = Math.Min(item.Quality + modifier, 50);
        }

        private static void UpdateBasicItemQuality(Item item)
        {
            if (item.Quality < 0)
                return;

            var modifier = item.SellIn < 0 ? -2 : -1;
            item.Quality = Math.Max(item.Quality + modifier, 0);
        }
    }
}