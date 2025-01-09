using GildedRoseKata;

namespace GildedRose.Tests.Unit.UpdateQuality;

public class GivenABackstagePassItem
{
    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 10)]
    public void WithSellInGreaterThan10_WhenUpdateQualityIsCalled_ThenSellInIncreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = quality + 1;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRoseKata.GildedRose(items);

        //When
        app.UpdateQuality();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
    
    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 10)]
    public void WithSellInLessThanOrEqualToo10AndGreaterThan5_WhenUpdateQualityIsCalled_ThenSellInIncreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = quality + 2;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRoseKata.GildedRose(items);

        //When
        app.UpdateQuality();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
    
    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 10)]
    public void WithSellInLessThanOrEqualToo5AndGreaterThan0_WhenUpdateQualityIsCalled_ThenSellInIncreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = quality + 3;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRoseKata.GildedRose(items);

        //When
        app.UpdateQuality();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
    
    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 10)]
    public void WithSellInLessThanOrEqualToo0_WhenUpdateQualityIsCalled_ThenQualityDecreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = 0;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRoseKata.GildedRose(items);

        //When
        app.UpdateQuality();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
    
    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 48)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 49)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 50)]
    public void WithMaxQuality_WhenUpdateQualityIsCalled_ThenQualityRemainsUnchanged(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = 50;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRoseKata.GildedRose(items);

        //When
        app.UpdateQuality();

        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
}