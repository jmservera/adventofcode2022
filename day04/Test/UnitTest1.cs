using day04.data;

namespace Test
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

        public void Test1(int a1, int b1, int a2, int b2, bool expectedResult)
        {
            Assert.Equal(expectedResult, RangeCheck.ContainRange(a1, b1, a2, b2));
        }


    }
}