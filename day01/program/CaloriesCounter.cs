public class CaloriesCounter{
    private string[] lines;
    private List<int> elvesCalories = new List<int>();
    
    public CaloriesCounter(string path)
    {
       
        string[] lines = System.IO.File.ReadAllLines(path);

        // Display the file contents by using a foreach loop.
        System.Console.WriteLine("Contents of WriteLines2.txt = ");

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
            else{
                elvesCalories.Add(elfSum);
                elfSum = 0;
                        
            }
        }
    }

    public int FindMax(){
        return elvesCalories.Max();
    }
}