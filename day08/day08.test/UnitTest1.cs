namespace day08.test;

public class UnitTest1
{
    [Fact]
    public void TestCount()
    {
        var forest = new Forest("data/test.txt");
        Assert.Equal(21, forest.CountVisibleTrees());

    }

    [Theory]
    [InlineData(4, 1, 2)]
    [InlineData(8, 3, 2)]
    public void TestScenicScore(int expectedResult, int x, int y)
    {
        var forest = new Forest("data/test.txt");
        var actualResult = forest.GetScenicScore(x, y);
        Assert.Equal(expectedResult, actualResult);

    }
}