using System;


namespace PZ_3
{
    class Program
    {
        public class Node
        {
            public int Info { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node() { }
            public Node(int info) { Info = info; }
            public Node(int info, Node left, Node right)
            {
                Info = info;
                Left = left;
                Right = right;
            }
        }

        public class BinaryTree
        {
            public Node Root { get; set; }

            public BinaryTree(int n)
            {
                Root = CreateBalancedTree(n);
            }

            public Node CreateBalancedTree(int n)
            {
                int text;
                Node root;

                if (n == 0)
                    root = null;
                else
                {
                    Console.WriteLine("Введите узел древа () >>");
                    text = Convert.ToInt32(Console.ReadLine());

                    root = new Node(text); 
                    root.Left = CreateBalancedTree(n / 2); 
                    root.Right = CreateBalancedTree(n - n / 2 - 1); 
                }

                return root;
            }
            
            public int CountNodes(Node root)
            {
                if (root == null)
                {
                    return 0;
                }
                return CountNodes(root.Left) + 1 + CountNodes(root.Right);
            }

            public int SumNodes(Node root)
            {
                if (root == null)
                {
                    return 0;
                }
                return SumNodes(root.Left) + root.Info + SumNodes(root.Right);

            }

            public double AverageArif()
            {
                int count = CountNodes(Root);
                int sum = SumNodes(Root);
                if (count == 0)
                {
                    return 0;
                }
                return (double)sum / count;
            }

            public int Positiv(Node root)
            {
                if (root == null)
                {
                    return 0;
                }

                if (root.Info > 0)
                {
                    return Positiv(root.Left) + 1 + Positiv(root.Right);
                }
                else
                {
                    return Positiv(root.Left) + Positiv(root.Right);
                }
            }

            public int Negative(Node root) 
            {
                if (root == null)
                {
                    return 0;
                }
                if (root.Info < 0)
                {
                    return Negative(root.Left) + 1 + Negative(root.Right);
                }
                else
                {
                    return Negative(root.Left) + Negative(root.Right);
                }
            }
        }
        static void Main(string[] args)
        {

            BinaryTree tree = new BinaryTree(5);

            double average = tree.AverageArif();
            Console.WriteLine($"Задание 1:  Среднее арифметическое значение : {average}");

            int positiveCount = tree.Positiv(tree.Root);
            int negativeCount = tree.Negative(tree.Root);
            Console.WriteLine($"Здаание 2:  Количество позитивных узлов: {positiveCount}");
            Console.WriteLine($"Количество негативных узлов: {negativeCount}");

        }
    }
    
}

