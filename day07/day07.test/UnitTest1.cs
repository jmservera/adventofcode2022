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

        Assert.NotNull(expected);
    }

    
}