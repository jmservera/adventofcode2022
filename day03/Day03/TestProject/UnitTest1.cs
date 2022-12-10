namespace Day03.Test
{
    public class Test
    {
        [Fact]
        public void SumPrioritiesTest()
        {           

            var r = new Rucksack("./data/test.txt").GetSumPriorities();
            Assert.Equal(157, r);
        }

        [Theory]
        [InlineData("vJrwpWtwJgWr", "hcsFMMfFFhFp", 'p')]
        [InlineData("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL", 'L')]
        [InlineData("vJrwRWtwJgWr", "hcsFMMfFFhFR", 'R')]
        [InlineData("PmmdzqPrV", "vPwwTWBwg", 'P')]

        public void TestGetRepetedItem(string compartiment1, string compartiment2, char expectedResult)
        {
            Assert.Equal(expectedResult, Rucksack.FindRepeatedItem(compartiment1, compartiment2));

        }

        [Theory]
        [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
        [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
        [InlineData("vJrwRWtwJgWrhcsFMMfFFhFR", 'R')]
        [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
        [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
        [InlineData("ttgJtRGJQctTZtZT", 't')]
        [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]

        public void TestGetRepetedItemFromRucksack(string rucksack, char expectedResult)
        {
            Assert.Equal(expectedResult, Rucksack.FindRepeatedItem(rucksack));

        }

        [Theory]
        [InlineData('a', 1)]
        [InlineData('z', 26)]
        [InlineData('A', 27)]
        [InlineData('Z', 52)]
        public void GetPriorityTest(char caracter, int expectedValue)
        {   
            Assert.Equal(expectedValue, Rucksack.GetPriority(caracter));
        
        }
    }
}