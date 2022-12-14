using day04;

namespace day04.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2,4,6,8, false)]
        [InlineData(2, 3, 4, 5, false)]
        [InlineData(5, 7, 7, 9, false)]
        [InlineData(2, 8, 3, 7, true)]
        [InlineData(6, 6, 4, 6, true)]
        [InlineData(2, 6, 4, 8, false)]
        [InlineData(2, 6, 2, 8, true)]
        [InlineData(3, 8, 2, 8, true)]
        [InlineData(3, 8, 2, 18, true)]
        public void TestFullyContained(int a1, int b1, int a2, int b2, bool expectedResult)
        {
            Assert.Equal(expectedResult, RangeCheck.ContainRange(a1, b1, a2, b2));
        }

        [Theory]
        [InlineData("2-4, 6-8", 2, 4, 6, 8)]
        public void TestParseRanges(string line, int a1, int b1, int a2, int b2)
        {
            Assert.Equal((a1, b1, a2, b2), RangeCheck.ParseRange(line));
        }

        [Fact]
        public void TestFullyContainedTest () 
        {
            var r = new RangeCheck("./data/test.txt").CountFullyContainedRanges();
            Assert.Equal(2, r);    
        }

        [Fact]
        public void TestOverlapRangesTest()
        {
            var r = new RangeCheck("./data/test.txt").CountOverlappedRanges();
            Assert.Equal(4, r);
        }

        [Theory]
        [InlineData(5, 7, 7, 9, true)]
        [InlineData(2, 3, 4, 5, false)]
        [InlineData(2, 8, 3, 5, true)]
        [InlineData(6, 6, 4, 6, true)]
        [InlineData(2, 6, 4, 8, true)]
        [InlineData(2, 6, 2, 8, true)]
        [InlineData(3, 8, 2, 8, true)]
        [InlineData(3, 8, 2, 18, true)]
        [InlineData(3, 8, 10, 18, false)]
        [InlineData(10, 18, 3, 4, false)]

        public void TestPartiallyContained(int a1, int b1, int a2, int b2, bool expectedResult)
        {
            Assert.Equal(expectedResult, RangeCheck.OverlapRange(a1, b1, a2, b2));
        }



    }
}