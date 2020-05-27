using System;
using System.IO;
using HRLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HRUnitTests
{
    [TestClass]
    public class MixtureUnitTest
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
                "Доктор МОМ Сироп от кашля",
                "Продажа с рецептом: Нет, " +
                "Производитель: ОАО ННОВ, Цена: 300 руб., Количество на скаладе: 100.",
                "Объем бутылки: 200мл"
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

        private Mixture CreateProduct()
        {
            var product = new Mixture("Доктор МОМ", "Сироп от кашля", "ОАО ННОВ", MedicineSaleWithRecipe.No, 200);
            product.Count = 100;
            product.Price = 300;
            return product;
        }
    }
}
