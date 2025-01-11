using GildedRose.Domain;
using GildedRoseKata;
using Moq;

namespace GildedRose.App.Tests.Unit;

public class GildedRoseTests
{
    [Fact]
    public void GivenAListOfItems_WhenProcessItemsIsCalled_ThenTheItemsAreUpdatedAsExpected()
    {
        //Given
        var item1Name = "Item 1";
        var item1SellIn = 1;
        var item1Quality = 2;
        var item1ExpectedQuality = 3;
        var item1ExpectedSellIn = 4;
        
        var item2Name = "Item 2";
        var item2SellIn = 5;
        var item2Quality = 6;
        var item2ExpectedQuality = 7;
        var item2ExpectedSellIn = 8;
        
        
        var items = new List<Item>()
        {
            new() { Name = item1Name, SellIn = item1SellIn, Quality = item1Quality },
            new() { Name = item2Name, SellIn = item2SellIn, Quality = item2Quality },
        };

        var itemProcessor = new Mock<IItemProcessor>();
        itemProcessor
            .Setup(m => m.Process(item1Name, item1SellIn, item1Quality))
            .Returns(() => (expectedQuality: item1ExpectedQuality, expectedSellIn: item1ExpectedSellIn));
        itemProcessor
            .Setup(m => m.Process(item2Name, item2SellIn, item2Quality))
            .Returns(() => (expectedQuality: item2ExpectedQuality, expectedSellIn: item2ExpectedSellIn));
        
        var gildedRose = new GildedRose(items, itemProcessor.Object);

        //When
        gildedRose.ProcessItems();

        //Then
        itemProcessor.Verify(m => m.Process(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
        Assert.Equal(item1ExpectedQuality, items[0].Quality);
        Assert.Equal(item1ExpectedSellIn, items[0].SellIn);
        Assert.Equal(item2ExpectedQuality, items[1].Quality);
        Assert.Equal(item2ExpectedSellIn, items[1].SellIn);
    }
}