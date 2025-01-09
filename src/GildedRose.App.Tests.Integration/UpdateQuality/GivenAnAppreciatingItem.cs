using GildedRoseKata;

namespace GildedRose.Tests.Unit.UpdateQuality;

public class GivenAnAppreciatingItem
{
    [Theory]
    [InlineData("Aged Brie", 1, 10)]
    public void HasNotPassedItsSellInDate_WhenUpdateQualityIsCalled_ThenQualityIncreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = quality + 1;
        
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
            
        //When
        app.ProcessItems();
            
        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
    
    [Theory]
    [InlineData("Aged Brie", -1, 10)]
    public void HasPassedItsSellIn_WhenUpdateQualityIsCalled_ThenQualityIncreasesAsExpected(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = quality + 2;
        
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
            
        //When
        app.ProcessItems();
            
        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }

    [Theory]
    [InlineData("Aged Brie", 10, 50)]
    public void WithMaxQuality_WhenUpdateQualityIsCalled_ThenQualityRemainsUnchanged(string name, int sellIn, int quality)
    {
        //Given
        var expectedQuality = 50;

        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
            
        //When
        app.ProcessItems();
            
        //Then
        Assert.Equal(expectedQuality, items[0].Quality);
    }
}