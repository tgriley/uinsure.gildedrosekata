using GildedRoseKata;

namespace GildedRose.Tests.Unit.UpdateQuality;

public class GivenABasicItem
{
    [Theory]
    [InlineData("+5 Dexterity Vest", 1, 10)]
    public void HasNotPassedItsSellInDate_WhenUpdateQualityIsCalled_ThenSellInDecreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedSellIn = sellIn - 1;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        //When
        app.ProcessItems();

        //Then
        Assert.Equal(expectedSellIn, items[0].SellIn);
    }

    [Theory]
    [InlineData("+5 Dexterity Vest", 1, 10)]
    public void HasNotPassedItsSellInDate_WhenUpdateQualityIsCalled_ThenQualityDecreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = quality - 1;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        //When
        app.ProcessItems();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }

    [Theory]
    [InlineData("+5 Dexterity Vest", 1, 10)]
    public void HasPassedItsSellInDate_WhenUpdateQualityIsCalled_ThenSellInDecreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedSellIn = sellIn - 1;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        //When
        app.ProcessItems();

        //Then
        Assert.Equal(expectedSellIn, items[0].SellIn);
    }

    [Theory]
    [InlineData("+5 Dexterity Vest", -1, 10)]
    public void HasPassedItsSellInDate_WhenUpdateQualityIsCalled_ThenQualityDecreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = quality - 2;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        //When
        app.ProcessItems();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }

    [Theory]
    [InlineData("+5 Dexterity Vest", 1, 0)]
    public void WithMinimumQuality_WhenUpdateQualityIsCalled_ThenQualityRemainsUnchanged(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = 0;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        //When
        app.ProcessItems();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
}