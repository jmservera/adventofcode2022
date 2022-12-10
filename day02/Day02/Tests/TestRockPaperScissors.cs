namespace Tests
{
    public class TestRockPaperScissors
    {
        [Fact]
        public void TestScore()
        {
            //Arrange

            //Act
            var r = new RockPaperScissors("./data/test.txt");

            //Assert
            Assert.Equal(15, r.Score());
        }

        [Fact]
        public void TestScoreStrategy()
        {
            //Arrange

            //Act
            var r = new RockPaperScissors("./data/test.txt");

            //Assert
            Assert.Equal(12, r.ScoreStrategy());
        }
    }
}