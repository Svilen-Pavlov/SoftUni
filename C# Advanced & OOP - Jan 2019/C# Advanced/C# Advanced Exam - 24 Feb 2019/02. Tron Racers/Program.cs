using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            string firstPosition = string.Empty;
            string secondPosition = string.Empty;

            for (int row = 0; row < rows; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                matrix[row] = new char[line.Length];
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row][col] = line[col];
                    if (matrix[row][col] == 'f')
                    {
                        firstPosition = row + " " + col;
                    }
                    if (matrix[row][col] == 's')
                    {
                        secondPosition = row + " " + col;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstDir = commands[0];
                string secondDir = commands[1];
                //firstPlayer Sequence
                firstPosition = newPos(matrix, firstDir, firstPosition);
                bool firstDead = CheckDead(matrix, firstPosition, 'f');
                if (firstDead)
                {
                    break;
                }
                matrix = Mark(matrix, firstPosition, 'f');

                //SecondPlayer Sequence
                secondPosition = newPos(matrix, secondDir, secondPosition);
                bool secondDead = CheckDead(matrix, secondPosition, 's');
                if (secondDead)
                {
                    break;
                }
                matrix = Mark(matrix, secondPosition, 's');

            }
            Print(matrix);
        }

        private static void Print(char[][] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix[0].GetLength(0);
            for (int row = 0; row < rowCount; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static bool CheckDead(char[][] matrix, string pos, char player)
        {
            int posRow = int.Parse(pos.Split()[0]);
            int posCol = int.Parse(pos.Split()[1]);

            char currTile = matrix[posRow][posCol];
            if (currTile != player && currTile != '*')
            {
                matrix[posRow][posCol] = 'x';
                return true;
            }
            return false;

        }

        private static char[][] Mark(char[][] matrix, string pos, char player)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix[0].GetLength(0);

            int posRow = int.Parse(pos.Split()[0]);
            int posCol = int.Parse(pos.Split()[1]);

            char[][] resultingMatrix = new char[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                resultingMatrix[row] = new char[colCount];
                for (int col = 0; col < colCount; col++)
                {
                    char curr = matrix[row][col];
                    resultingMatrix[row][col] = curr;
                }
            }
            resultingMatrix[posRow][posCol] = player;

            return resultingMatrix;
        }

        private static string newPos(char[][] matrix, string dir, string pos)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix[0].GetLength(0);

            int posRow = int.Parse(pos.Split()[0]);
            int posCol = int.Parse(pos.Split()[1]);

            switch (dir)
            {
                case "up":
                    posRow--;
                    if (posRow < 0) posRow = rowCount - 1;
                    break;
                case "right":
                    posCol++;
                    if (posCol > colCount - 1) posCol = 0;
                    break;
                case "down":
                    posRow++;
                    if (posRow > rowCount - 1) posRow = 0;
                    break;
                case "left":
                    posCol--;
                    if (posCol < 0) posCol = colCount - 1;
                    break;
            }

            return posRow + " " + posCol;

        }
    }
}
