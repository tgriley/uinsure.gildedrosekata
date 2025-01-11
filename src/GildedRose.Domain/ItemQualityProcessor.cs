namespace GildedRose.Domain;

public class ItemQualityProcessor
{
    public int UpdateAppreciatingItemQuality(int quality, int sellIn)
    {
        if (quality < 0)
            return 0;
            
        var modifier = sellIn < 0 ? 2 : 1;
        return Math.Min(quality + modifier, 50);
    }

    public int UpdateBackstagePassItemQuality(int quality, int sellIn)
    {
        if (quality < 0 || sellIn < 0)
            return 0;

        var modifier = 1;
        if (sellIn < 10) modifier++;
        if (sellIn < 5) modifier++;

        return Math.Min(quality + modifier, 50);
    }

    public int UpdateBasicItemQuality(int quality, int sellIn)
    {
        if (quality < 0)
            return 0;

        var modifier = sellIn < 0 ? -2 : -1;
        return Math.Max(quality + modifier, 0);
    }
    
    public int UpdateLegendaryItemQuality(int quality, int sellIn)
    {
        return quality;
    }
}