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
    }

    public int FindMax(){
        return elvesCalories.Max();
    }
    public int SumTopThreeMax(){
        // quick and dirty

        int top1 = elvesCalories.Max();
        elvesCalories.Remove(top1);
        int top2 = elvesCalories.Max();
        elvesCalories.Remove(top2);
        int top3 = elvesCalories.Max();
        return top1 + top2 + top3;
    }
}