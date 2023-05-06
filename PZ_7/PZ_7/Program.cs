﻿using System;
using System.Collections.Generic;

namespace PZ_7
{
    class Program
    {
        abstract class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public virtual double GetDiscount(double Pokupki)
            {
                return 0;
            }
        }
        class Product1 : Product
        {
            public double Discount { get; set; }
            public override double GetDiscount(double Pokupki)
            {
                if (Pokupki >= 1000)
                {
                    Discount = 0.2;
                }
                else if (Pokupki >= 500)
                {
                    Discount = 0.1;
                }
                else
                {
                    Discount = 0;
                }
                return Discount * Price;
            }
        }
        class Product2 : Product
        {
            public double Ves { get; set; }
            public override double GetDiscount(double Pokupki)
            {
                if (Pokupki >= 2000)
                {
                    return Price * Ves * 0.05;
                }
                return 0;
            }
        }
        class Product3 : Product
        {
            public int Kolvo { get; set; }
            public override double GetDiscount(double Pokupki)
            {
                if (Kolvo >= 5)
                {
                    return Price * Kolvo * 0.1;
                }
                return 0;
            }
        }
        class Product4 : Product
        {
            public override double GetDiscount(double Pokupki)
            {
                if (Pokupki >= 5000)
                {
                    return Price * 0.1;
                }
                return 0;
            }
        }
        class Client
        {
            public string Name { get; set; }
            public double AllPurchases { get; set; }
            public Client(string name)
            {
                Name = name;
                AllPurchases = 0;
            }
        }
        class Store
        {
            public List<string> AllPurchases { get; set; }
            public Store()
            {
                AllPurchases = new List<string>();
            }
            public void SaveOrder(Product product, Client client)
            {
                if (product != null && client != null)
                {
                    double discount = product.GetDiscount(client.AllPurchases);
                    double totalPrice = product.Price - discount;
                    AllPurchases.Add($"{client.Name} купил {product.Name}, а стоит это {totalPrice}");
                    client.AllPurchases += totalPrice;
                }
            }
        }

            static void Main(string[] args)
            {
                Product1 product1 = new Product1() { Name = "Картошка", Price = 1000 };
                Product2 product2 = new Product2() { Name = "Лепешка", Price = 50, Ves = 2 };
                Product3 product3 = new Product3() { Name = "Хлэб", Price = 10, Kolvo = 5 };
                Product4 product4 = new Product4() { Name = "Черная икра самая вкусная", Price = 200 };
                Client client1 = new Client("Клиент Вадим");
                Client client2 = new Client("Клиент Вася");

                Store store = new Store();

                store.SaveOrder(product1, client1);
                store.SaveOrder(product2, client1);
                store.SaveOrder(product3, client2);
                store.SaveOrder(product4, client2);
                foreach (string purchase in store.AllPurchases)
                {

                    Console.WriteLine(purchase);
                }
                Console.WriteLine($"Общая стоимость для {client1.Name}: {client1.AllPurchases}");
                Console.WriteLine($"Общая стоимость для {client2.Name}: {client2.AllPurchases}");
                Console.ReadKey();
            }
        
    }
}
