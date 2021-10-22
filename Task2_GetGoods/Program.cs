using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Task1_Goods;

namespace Task2_GetGoods
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:/Goods/Products.json";
            string jsonText = "";

            using (StreamReader file = new StreamReader(filePath))
            {
                while (file.Peek() >= 0)
                {
                    jsonText += file.ReadLine();
                }
            }

            Goods[] productsArray = JsonSerializer.Deserialize<Goods[]>(jsonText);
            double priceBiggest = 0;
            string nameBiggest = "";

            for (int i = 0; i < 5; i++)
            {
                if (productsArray[i].PriceGood > priceBiggest)
                {
                    priceBiggest = productsArray[i].PriceGood;
                    nameBiggest = productsArray[i].NameGood;
                }

            }

            Console.WriteLine("Максимальная стоимость у товара \"{0}\" - {1:f2}.", nameBiggest, priceBiggest);
            Console.WriteLine("Нажмите любую кнопку для выхода из программы.");
            Console.ReadKey();
        }


    }
}
