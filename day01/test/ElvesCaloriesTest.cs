namespace test;

public class ElvesCaloriesTest
{
    [Theory]
    [InlineData("./data/elvestest.txt", 24000)]
    public void TestCalories(string path, int result)
    {
        //Arrange
        var calories = 0;

        //act 
        calories= new CaloriesCounter(path).FindMax();

        //assert
        Assert.Equal(result, calories);

    }

    [Theory]
    [InlineData("./data/elvestest2.txt", 45000)]
    public void TestTopThreeCalories(string path, int result)
    {
        //Arrange
        var calories = 0;

        //act 
        calories = new CaloriesCounter(path).SumTopThreeMax();

        //assert
        Assert.Equal(result, calories);

    }
}