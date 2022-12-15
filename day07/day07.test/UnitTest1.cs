namespace day07.test;

public class UnitTest1
{
    [Theory]
    [InlineData(584,"/a/e")]
    [InlineData(94853, "/a")]
    [InlineData(24933642, "/d")]
    [InlineData(48381165, "/")]
    public void TestFolderSize(int expected, string folder)
    {
        var f = new FileSystem("./data/test.txt");
        f.RunCommands();
        Assert.Equal(expected, f.FolderSize(folder));
    }

    [Fact]
    public void TestSumAtMost100000()
    {
        var f = new FileSystem("./data/test.txt");
        f.RunCommands();
        Assert.Equal(95437, f.SumAtMost100000());
    }

    [Fact]
    public void TestMinSizeMoreThan30000000()
    {
        var f = new FileSystem("./data/test.txt");
        f.RunCommands();
        Assert.Equal(24933642, f.MinSizeMoreThan30000000());

    }
}