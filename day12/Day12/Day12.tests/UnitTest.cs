namespace Day12.tests
{
    public class UnitTest
    {
        [Fact]
        public void TestExampleData()
        {
            string path = "./data/test.txt";
            var mov = new Movement(path);
            mov.LookForThePath();

        }
    }
}