using System;
using System.IO;
using HRLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HRUnitTests
{
    [TestClass]
    public class SalveUnitTest
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var product = CreateProduct();
            Assert.AreEqual(200, product.Volume);
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {
            var product = CreateProduct();

            var lines = new[]
            {
                "Спортриа Мазь от ушибов",
                "Продажа с рецептом: Нет, " +
                "Производитель: ОАО РРНО, Цена: 990 руб., Количество на скаладе: 100.",
                "Объем тубы: 200мг"
            };

            TextWriter oldOut = Console.Out;
            using (FileStream file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);
                    product.PrintInfo();
                }
            }

            Console.SetOut(oldOut);
            using (FileStream file = new FileStream("test.txt", FileMode.Open))
            {
                using (TextReader reader = new StreamReader(file))
                {
                    var i = 0;
                    while (!(reader as StreamReader).EndOfStream)
                        Assert.AreEqual(lines[i++], reader.ReadLine());
                    Assert.AreEqual(lines.Length, i);
                }
            }
            File.Delete("test.txt");
        }

        private Salve CreateProduct()
        {
            var product = new Salve("Спортриа", "Мазь от ушибов", "ОАО РРНО", MedicineSaleWithRecipe.No, 200);
            product.Price = 990;
            product.Count = 100;
            return product;
        }
    }
}
