using System;

namespace PZ_2
{
    class Program
    {
        public class Graph
        {
            public int Size { get; set; }
            public bool[,] Adjacency { get; set; }
            public bool[] Vector { get; set; }

            public Graph(int size, bool[,] G) 
            {
                Adjacency = new bool[size, size]; 
                Adjacency = G;
                Vector = new bool[size];
                for (int i = 0; i < size; i++)
                    Vector[i] = false;
                Size = size;
            }
            public void Depth(int i) 
            {
                Vector[i] = true;

                Console.Write(" {0}" + ' ', i);
                for (int k = 0; k < Size; k++) 
                    if (Adjacency[i, k] && !(Vector[k]))
                        Depth(k);
            }

            static void Main(string[] args)
            {
                bool[,] M = new bool[5, 5]
                {
                    {false, true, true, false,false}, 
                    {false, false, false, true,false},
                    {false, true, false, false,true},
                    {false, false, true, false,false},
                    {false,false,false,true,false}
                };
                Console.Write("Вершины по которым прошли:");


                Graph graph = new Graph(5, M);
                graph.Depth(0);

                bool allvershin = true; 
                for (int i = 0; i < graph.Size; i++)
                {
                    if (!graph.Vector[i])
                    {
                        allvershin = false;
                        break;
                    }
                }

                if (allvershin)
                    Console.WriteLine("- Граф связный.");
                else
                    Console.WriteLine("- Граф не связный.");

            }
        }
    }
 }
