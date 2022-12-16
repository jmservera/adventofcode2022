using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public class Forest
    {
        private int[,] forest;
        private int width, height;

        public Forest(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);
            if (lines.Length > 0)
            {
                height = lines.Length;
                width = lines[0].Length;
            }
            forest = new int[height, width];
            for (int w = 0; w < width; w++)
                for (int h = 0; h < height; h++)
                {
                    forest[h, w] = int.Parse(lines[h][w].ToString());
                }
        }

        public int CountVisibleTrees()
        {
            bool[][] l = new bool[height][];
            for(int h = 0; h < height; h++)
            {
                l[h] = new bool[width];
            }

            countH(l);
            countW(l);
            return l.Sum(r => r.Count(i => i));
        }

        private void countH(bool[][] l)
        {
            for (int h = 0; h < height; h++)
            {
                int maxH = -1;

                for (int w = 0; w < width; w++)
                {
                    if (forest[h, w] > maxH)
                    {
                        l[h][w] = true;
                        maxH = forest[h, w];
                    }
                }

                maxH = -1;
                for (int w = width-1; w >= 0; w--)
                {
                    if (forest[h, w] > maxH)
                    {
                        l[h][w] = true;
                        maxH = forest[h, w];
                    }
                }

            }
        }

        private void countW(bool[][] l)
        {
            for (int w = 0; w < width; w++)
            {
                int maxH = -1;

                for (int h = 0; h < height; h++)
                {
                    if (forest[h, w] > maxH)
                    {
                        l[h][w] = true;
                        maxH = forest[h, w];
                    }
                }

                maxH = -1;
                for (int h = height-1; h >= 0; h--)
                {
                    if (forest[h, w] > maxH)
                    {
                        l[h][w] = true;
                        maxH = forest[h, w];
                    }
                }

            }
        }

        public int GetMaxScenicScore()
        {
            int max = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var scenicScore = GetScenicScore(i, j);
                    if (scenicScore > max)
                    {
                        max = scenicScore;
                    }
                }
            }

            return max;
        }

        public int GetScenicScore(int x, int y)
        {
            int scenicScore = 0;

            int rightScenicScore = countR(x, y);
            int leftScenicScore = countL(x, y);
            int downScenicScore = countD(x, y);
            int topScenicScore = countT(x, y);

            scenicScore = rightScenicScore * leftScenicScore * downScenicScore * topScenicScore;

            return scenicScore;

        }

        private int countR(int x, int y)
        {
            int currentHight = forest[x,y];
            int scenicScore = 0;
            bool shorterTree = true;
            int i = y + 1;
            do
            {
                if (forest[x, i] >= currentHight)
                {
                    shorterTree = false;
                }

                scenicScore++;
                i++;
            } while (shorterTree && i < width);


            return scenicScore;
        }

        private int countL(int x, int y)
        {
            int currentHight = forest[x, y];
            int scenicScore = 0;
            bool shorterTree = true;
            int i = y -1;
            do
            {
                if (forest[x, i] > currentHight)
                {
                    shorterTree = false;
                }

                scenicScore++;
                i--;
            } while (shorterTree && i > 0);


            return scenicScore;
        }

        private int countD(int x, int y)
        {
            int currentHight = forest[x, y];
            int scenicScore = 0;
            bool shorterTree = true;
            int i = x + 1;
            do
            {
                if (forest[i, y] >= currentHight)
                {
                    shorterTree = false;
                }

                scenicScore++;
                i++;
            } while (shorterTree && i < height);


            return scenicScore;
        }

        private int countT(int x, int y)
        {
            int currentHight = forest[x, y];
            int scenicScore = 0;
            bool shorterTree = true;
            int i = x - 1;
            do
            {
                if (forest[i, y] >= currentHight)
                {
                    shorterTree = false;
                }

                scenicScore++;
                i--;
            } while (shorterTree && i > 0);


            return scenicScore;
        }

    }
}