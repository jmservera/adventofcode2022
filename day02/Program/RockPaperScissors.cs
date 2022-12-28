public class RockPaperScissors
{
    string[] play;

    // Rock -> A -> X
    // Paper -> B -> Y
    // Scissors -> C -> Z

    Dictionary<char, int> scores = new()
        {['A'] = 1,['B'] = 2,['C'] = 3};

    Dictionary<char, int> scores2 = new()
    { ['X'] = 1, ['Y'] = 2, ['Z'] = 3 };

    public RockPaperScissors(string path)
    {
        play = System.IO.File.ReadAllLines(path);
    }

    public int Score()
    {
        var score = 0;
        foreach(var turn in play)
        {
            if ((turn[0] == 'A' && turn[2] == 'Y') || 
                (turn[0] == 'B' && turn[2] == 'Z') ||
                (turn[0] == 'C' && turn[2] == 'X'))
            {
                // you win
                score += 6; 
            }
            else if ((scores[turn[0]] == scores2[turn[2]]))
            {
                //draw
                score += 3; 
            }
            else 
            { 
                // you lose
            
            }
            score += scores2[turn[2]];
        }
        return score;
    }

    public int ScoreStrategy()
    {
        var score = 0;

        int counter = 0;

        foreach (var turn in play)
        {
            char choose;

            if (turn[2] == 'X')
            {
                // you should lose

                if (turn[0] == 'A') // Rock
                {
                    // you choose Scissors for losing
                    choose = 'C';
                }
                else if (turn[0] == 'B') // paper
                {
                    // you choose Rock for losing
                    choose = 'A';
                }
                else // Scissors
                {
                    // you choose Paper for losing
                    choose = 'B';
                }

            }
            else if (turn[2] == 'Y')
            {
                // should be a draw
                score+= 3;

                choose = turn[0];

            }
            else if (turn[2]=='Z')
            {
                // you win
                score += 6;

                if (turn[0] == 'A') // Rock
                {
                    // you choose Paper for winning
                    choose = 'B';
                }
                else if(turn[0] == 'B') // paper
                {
                    // you choose Scissors for winning
                    choose = 'C';
                }
                else // Scissors
                {
                    // you choose Rock for winning
                    choose = 'A';
                }
            }
            else
            {
                Console.WriteLine("wtf");
                choose = ' ';
            }

            score += scores[choose];
            counter++;
        }

        Console.WriteLine($"{counter}");

        return score; 
    
    }
}