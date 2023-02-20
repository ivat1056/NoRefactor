using System;

namespace Indexs
{
    class program
    {
        static void Main(string[] args)
        {
            int[] ri = new int[] { 1, 1, 1, 2, 2, 3, 4 };
            int[] rj = new int[] { 2, 3, 5, 3, 4, 4, 5 };
            int[] dij = new int[ri.Length];

            Console.Write($"Введите номер способа заполнения продолжительностей работ\n1.Вручную\n2.Рандомно\nОтвет: ");
            int otv = int.Parse(Console.ReadLine());
            switch (otv)
            {
                case 1:
                    for (int i = 0; i < dij.Length; i++)
                    {
                        Console.Write($"Ввдеите продолжительность {i + 1} работы: ");
                        dij[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                case 2:
                    Random rnd = new Random();
                    for (int i = 0; i < dij.Length; i++)
                    {
                        dij[i] = rnd.Next(1, 100);
                    }
                    break;
            }

            Console.Clear();

            Console.WriteLine($"Работы и их продолжительность:");
            for (int i = 0; i < dij.Length; i++)
            {
                Console.WriteLine($"{ri[i]}-{rj[i]}({dij[i]})");
            }

            Console.WriteLine();

            int[,] table = new int[4, 5];

            int[][] pathes = new int[4][];
            pathes[0] = new int[5];
            pathes[1] = new int[6];
            pathes[2] = new int[5];
            pathes[3] = new int[3];

            for (int i = 0; i < ri.Length; i++)
            {
                table[ri[i] - 1, rj[i] - 1] = dij[i];
            }

            pathes[0][0] = 1;
            pathes[0][1] = 2;
            pathes[0][2] = 4;
            pathes[0][3] = 5;

            pathes[1][0] = 1;
            pathes[1][1] = 2;
            pathes[1][2] = 3;
            pathes[1][3] = 4;
            pathes[1][4] = 5;

            pathes[2][0] = 1;
            pathes[2][1] = 3;
            pathes[2][2] = 4;
            pathes[2][3] = 5;

            pathes[3][0] = 1;
            pathes[3][1] = 5;

            for (int j = 0; j < pathes.Length; j++)
            {
                for (int i = 1; i < pathes[j].Length - 1; i++)
                {
                    pathes[j][pathes[j].Length - 1] += table[pathes[j][i - 1] - 1, pathes[j][i] - 1];
                }
            }

            //public void fillIncidenceMatrix(int numberV, List<Edge> E, int[,] matrix)
            //{
            //    for (int i = 0; i < numberV; i++)
            //        for (int j = 0; j < E.Count; j++)
            //            matrix[i, j] = 0;
            //    for (int i = 0; i < E.Count; i++)
            //    {
            //        matrix[E[i].v1, i] = 1;
            //        matrix[E[i].v2, i] = 1;
            //    }
            //}

            for (int j = 0; j < pathes.Length; j++)
            {
                Console.Write($"Путь {j + 1}: ");
                for (int i = 0; i < pathes[j].Length - 1; i++)
                {
                    if (i == pathes[j].Length - 2)
                    {
                        Console.Write($"{pathes[j][i]}");
                    }
                    else
                    {
                        Console.Write($"{pathes[j][i]}-");
                    }

                }
                Console.WriteLine($"; F = {pathes[j][pathes[j].Length - 1]}");
            }

            int MaxF = int.MinValue;
            int ind = 0;

            for (int i = 0; i < pathes.Length; i++)
            {
                if (MaxF < pathes[i][pathes[i].Length - 1])
                {
                    MaxF = pathes[i][pathes[i].Length - 1];
                    ind = i;
                }
            }

            Console.Write($"Критический путь - Путь {ind + 1}: ");
            for (int i = 0; i < pathes[ind].Length - 1; i++)
            {
                if (i == pathes[ind].Length - 2)
                {
                    Console.Write($"{pathes[ind][i]}");
                }
                else
                {
                    Console.Write($"{pathes[ind][i]}-");
                }

            }
            Console.WriteLine($"; F = {pathes[ind][pathes[ind].Length - 1]}");
        }
        
    }
}