using System.IO;

namespace day10.tests
{
    public class UnitTest
    {
        [Fact]
        public void TestParse()
        {
            var file = System.IO.File.ReadAllLines("./data/test.txt");

            var f = new Operations(file);
            Assert.Equal(146, f.Commands.Count);
        }

        [Fact]
        public void TestSmallProgramExample()
        {
            string[] data = { "noop", "addx 3", "addx -5" };
            
            var f = new Operations(data);
            f.RunOperations();

            Assert.Equal(3, f.Commands.Count);
            Assert.Equal(1, f.valueInCycles[1]);
            Assert.Equal(1, f.valueInCycles[2]);
            Assert.Equal(4, f.valueInCycles[3]);
            Assert.Equal(4, f.valueInCycles[4]);
            Assert.Equal(-1, f.valueInCycles[5]);
        }

        [Fact]
        public void TestLargeProgramExample()
        {
            var f = new Operations("./data/test.txt");
            f.RunOperations();

            Assert.Equal(21, f.valueInCycles[20-1]);
            Assert.Equal(19, f.valueInCycles[60-1]);
            Assert.Equal(18, f.valueInCycles[100-1]);
            Assert.Equal(21, f.valueInCycles[140-1]);
            Assert.Equal(16, f.valueInCycles[180-1]);
            Assert.Equal(18, f.valueInCycles[220-1]);
        }

        [Fact]
        public void TestProgramExample()
        {
            var f = new Operations("./data/test.txt");
            f.RunOperations();
            Assert.Equal(13140, f.GetSignalStrength());

        }
        [Fact]
        public void TestImageCRT() 
        {
            var f = new Operations("./data/test.txt");
            f.RunOperations();
            f.GetImageCRT();

        }
    }
}