
public class CaloriesCounter{
    private string[] lines;
    private List<int> elvesCalories = new List<int>();
    
    public CaloriesCounter(string path)
    {
       
        string[] lines = System.IO.File.ReadAllLines(path);

        int elfSum =0;
        foreach (string line in lines)
        {
            if(!string.IsNullOrEmpty(line))
            {
                if (int.TryParse(line,  out int number))
                {
                        elfSum += number;
                }
            }
            else
            {
                elvesCalories.Add(elfSum);
                elfSum = 0;                       
            }               
        }

        if(elfSum> 0)
        {
            elvesCalories.Add(elfSum);
        }
    }

    public int FindMax(){
        return elvesCalories.Max();
    }
    
    public int SumTopThreeMax(){

        elvesCalories.Sort();
        elvesCalories.Reverse();

        // sum top 3
        return elvesCalories.Take(3).Sum();
    }
}