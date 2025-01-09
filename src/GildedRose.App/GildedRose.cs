using System;
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
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
            if (IsBasicItem(item.Name))
            {
                UpdateBasicItemQuality(item);
                return;
            }

            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 10 && item.Quality < 50)
                    {
                        item.Quality += 1;
                    }

                    if (item.SellIn < 5 && item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality -= 1;
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }

        private static void UpdateBasicItemQuality(Item item)
        {
            if (item.Quality < 0) return;
            var modifier = item.SellIn < 0 ? -2 : -1;
            item.Quality = Math.Max(item.Quality + modifier, 0);
        }

        private static bool IsBasicItem(string name)
        {
            string[] nonBasicItems = ["Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros"];
            return !nonBasicItems.Contains(name);
        }
    }
}