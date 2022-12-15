namespace day08.test;

public class UnitTest1
{
    [Fact]
    public void TestCount()
    {
        var forest = new Forest("data/test.txt");
        Assert.Equal(21, forest.CountVisibleTrees());

    }
}