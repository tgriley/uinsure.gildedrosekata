using GildedRoseKata;

namespace GildedRose.Tests.Unit.UpdateQuality;

public class GivenALegendaryItem
{
    [Theory]
    [InlineData("Sulfuras, Hand of Ragnaros", 1, 80)]
    [InlineData("Sulfuras, Hand of Ragnaros", -1, 80)]
    public void WhenUpdateQualityIsCalled_ThenSellInRemainsUnchanged(string name, int sellIn, int quality)
    {
        //Given
        var expectedSellIn = sellIn;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        //When
        app.ProcessItems();

        //Then
        Assert.Equal(expectedSellIn, items[0].SellIn);
    }
    
    [Theory]
    [InlineData("Sulfuras, Hand of Ragnaros", 1, 80)]
    [InlineData("Sulfuras, Hand of Ragnaros", -1, 80)]
    public void WhenUpdateQualityIsCalled_ThenQualityRemainsUnchanged(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = 80;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        //When
        app.ProcessItems();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
}