namespace GildedRose.Domain.Tests.Unit;

public class ItemQualityProcessorTests
{
    private ItemQualityProcessor ItemQualityProcessor { get; set; } = new();

    [Theory]
    [InlineData(-1,1, 0)]
    [InlineData(0,1, 1)]
    [InlineData(1,1, 2)]
    [InlineData(0,0, 1)]
    [InlineData(49,0, 50)]
    [InlineData(50,0, 50)]
    [InlineData(49,-1, 50)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateAppreciatingItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var result = ItemQualityProcessor.UpdateAppreciatingItemQuality(quality, sellIn);
        
        //Then
        Assert.Equal(expectedQuality, result);
    }
    
    [Theory]
    [InlineData(-1,1, 0)]
    [InlineData(1,-1, 0)]
    [InlineData(1,10, 2)]
    [InlineData(1,9, 3)]
    [InlineData(1,5, 3)]
    [InlineData(1,4, 4)]
    [InlineData(1,0, 4)]
    [InlineData(50,10, 50)]
    [InlineData(49,9, 50)]
    [InlineData(48,4, 50)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateBackstagePassItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var result = ItemQualityProcessor.UpdateBackstagePassItemQuality(quality, sellIn);
        
        //Then
        Assert.Equal(expectedQuality, result);
    }
    
    [Theory]
    [InlineData(-1,1, 0)]
    [InlineData(10,1, 9)]
    [InlineData(10,0, 9)]
    [InlineData(10,-1, 8)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateBasicItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var result = ItemQualityProcessor.UpdateBasicItemQuality(quality, sellIn);
        
        //Then
        Assert.Equal(expectedQuality, result);
    }
    
    [Theory]
    [InlineData(-1,1, 0)]
    [InlineData(10,1, 8)]
    [InlineData(10,0, 8)]
    [InlineData(10,-1, 6)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateConjuredItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var result = ItemQualityProcessor.UpdateConjuredItemQuality(quality, sellIn);
        
        //Then
        Assert.Equal(expectedQuality, result);
    }
    
    [Theory]
    [InlineData(80,1, 80)]
    [InlineData(1,1, 1)]
    [InlineData(1,0, 1)]
    [InlineData(1,-1, 1)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateLegendaryItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var result = ItemQualityProcessor.UpdateLegendaryItemQuality(quality, sellIn);
        
        //Then
        Assert.Equal(expectedQuality, result);
    }
}