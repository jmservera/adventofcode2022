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
    [InlineData(1, 1, 1)]
    [InlineData(4, 1, 2)]
    [InlineData(1, 1, 3)]
    [InlineData(6, 2, 1)]
    [InlineData(2, 2, 3)]
    [InlineData(8, 3, 2)]
    [InlineData(3, 3, 3)]

    public void TestScenicScore(int expectedResult, int x, int y)
    {
        var forest = new Forest("data/test.txt");
        var actualResult = forest.GetScenicScore(x, y);
        Assert.Equal(expectedResult, actualResult);

    }

    [Fact]
    public void TestMaxScenicScore()
    {

            int expectedResult = 8;
            var forest = new Forest("data/test.txt");
            var actualResult = forest.GetMaxScenicScore();
            Assert.Equal(expectedResult, actualResult);

       
    }
}