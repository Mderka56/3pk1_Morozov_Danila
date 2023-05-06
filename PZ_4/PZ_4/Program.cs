using System;
using System.Collections.Generic;
using System.Text;

namespace PZ_4
{
    class Program
    {
        internal class Node
        {
            public char Info { get; set; }
            public int Key { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node() { }

            public Node(char info, int key)
            {
                Info = info; Key = key;
            }


            public Node(char info, int key, Node left, Node right)
            {
                Info = info; Key = key; Left = left; Right = right;
            }

        }
        class SearchTree
        {
            //1
            public static Node Insert(Node node, char info, int key)
            {
                if (node == null)
                    return new Node(info, key);
                else if (key < node.Key)
                    node.Left = Insert(node.Left, info, key);
                else
                    node.Right = Insert(node.Right, info, key);
                return node;
            }

            public static int Summa(Node node)
            {
                if (node == null)
                    return 0;
                return node.Key + Summa(node.Left) + Summa(node.Right);
            }
            //2
            public static int CountInternalNodes(Node node)
            {
                if (node == null)
                    return 0;
                else if (node.Left == null && node.Right == null)
                    return 0;
                else
                    return 1 + CountInternalNodes(node.Left) + CountInternalNodes(node.Right);
            }
            //3
            public static List<int> GetNegativeValues(Node node)
            {

                List<int> result = new List<int>();
                if (node == null)
                    return result;

                if (node.Key < 0)
                {
                    result.Add(node.Key);
                    Console.WriteLine($"Узел: {node.Info}, Кол-во отрицательный: {result.Count}: {node.Key} ");

                }
                else
                {
                    Console.WriteLine($"Узел: {node.Info}, Кол-во отрицательный: {result.Count}: {node.Key} ");

                }

                result.AddRange(GetNegativeValues(node.Left));
                result.AddRange(GetNegativeValues(node.Right));

                return result;
            }

        }
        static void Main(string[] args)
        {
            Random random = new Random();
            Node root = null;
            for (int i = 0; i < 10; i++)
            {
                int key = random.Next(-1000, 1001);
                root = SearchTree.Insert(root, (char)('A' + i), key);
            }

            Console.WriteLine("Сумма значений дерева: " + SearchTree.Summa(root));

            Console.WriteLine("Кол-во внутренних узлов дерева: " + SearchTree.CountInternalNodes(root) + "");

            List<int> negativeValues = SearchTree.GetNegativeValues(root);
            Console.WriteLine("\nОтрицательные значения информационных полей дерева:" + negativeValues.Count);
            foreach (var value in negativeValues)
            {
                Console.Write($"{value}, ");
            }
            Console.ReadLine();
        }
    }
}
