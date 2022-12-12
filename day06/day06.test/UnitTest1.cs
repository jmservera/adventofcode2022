namespace day06.test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1234", true)]
        [InlineData("aqwer", true)]
        [InlineData("aqaer", false)]
        [InlineData("aqwuyq", false)]
        public void allDifferentTest(string sequency, bool result)
        {
            Assert.Equal(result, Sequency.checkIfDifferents(sequency));
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]

        public void findMarkerTest(string sequency, int result)
        {
            Assert.Equal(result, Sequency.FindMarker(sequency));
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]

        public void findMarker14Test(string sequency, int result)
        {
            Assert.Equal(result, Sequency.FindMarker14(sequency));
        }


    }
}