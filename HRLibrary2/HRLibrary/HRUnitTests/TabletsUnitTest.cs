using System;
using System.IO;
using HRLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HRUnitTests
{
    [TestClass]
    public class TabletsUnitTest
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var product = CreateProduct();
            Assert.AreEqual(10, product.CountInPackage);
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {
            var product = CreateProduct();

            var lines = new[]
            {
                "Аскорбиновая кислота Витамины",
                "Продажа с рецептом: Нет, " +
                "Производитель: ОАО НПРВ, Цена: 10 руб., Количество на скаладе: 10.",
                "Количество таблеток в упаковке 10шт"
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

        private Tablets CreateProduct()
        {
            var product = new Tablets("Аскорбиновая кислота", "Витамины", "ОАО НПРВ", MedicineSaleWithRecipe.No, 10);
            product.Count = 10;
            product.Price = 10;
            return product;

        }
    }
}
