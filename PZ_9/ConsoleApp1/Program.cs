using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Origin origin = new Origin();
            Client client = new Client();
            origin.OriginDouble(4.2);
            origin.OriginInt(31231);
            origin.OrigiChar('i');

            client.ClientDouble(213.54);
            client.ClientInt(11111);
            client.ClientChar('q');
            Console.ReadKey();
        }

        public class Origin
        {
            public void OriginDouble(double dbl_ori)
            {
                Console.WriteLine("Значение Double:" + dbl_ori);
            }
            public void OriginInt(int int_ori)
            {
                Console.WriteLine("Значение Int:" + int_ori);
            }
            public void OrigiChar(char char_ori)
            {
                Console.WriteLine("Значение Char:" + char_ori);
            }
            
        }
    

        public class Client
        {
            
            public void ClientDouble(double dbl_cl)
            {
                Console.WriteLine("Значение Double:" + dbl_cl);

            }

            public void ClientInt(int int_cl)
            {
                Console.WriteLine("Значение Int:" + int_cl * 2);
            }
            public void ClientChar(char char_cl)
            {

                for (int i = 0; i < 5; i++)
                {
                    Console.Write(char_cl);
                }
                Console.WriteLine();


            }


        }
    }
}

