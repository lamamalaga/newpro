using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRLibrary;
using System.IO;

namespace HRUnitTests
{
    [TestClass]
    public class MedicineUnitTest
    {

        [TestMethod]
        public void ConstructorTestMethod()
        {
            var product = CreatrMedicine();

            Assert.AreEqual("Гексорал", product.Name);
            Assert.AreEqual("Парке-Дейвис для Пфайзер Х.К.П.", product.Manufacturer);
            Assert.AreEqual(MedicineSaleWithRecipe.No, product.SaleWithRecipe);
            Assert.AreEqual("Аэрозоль", product.ArticleNumber);
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            var product = CreatrMedicine();
            Assert.AreEqual("Гексорал Аэрозоль", product.ToString());
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {

            var firstProduct = CreatrMedicine();
            var secondProduct = new Medicine("Аскорбиновая кислота", "Таблетки",
                "Новосибирский завод медицинских препаратов", MedicineSaleWithRecipe.No)
            { Count = 50, Price = 53 };

            var consoleOut = new[]
            {
                "Гексорал Аэрозоль",
                $"Продажа с рецептом: Нет, Производитель: Парке-Дейвис для Пфайзер Х.К.П., " +
                $"Цена: 187 руб., Количество на скаладе: 10.",
                "Аскорбиновая кислота Таблетки",
                $"Продажа с рецептом: Нет, Производитель: Новосибирский завод медицинских препаратов, " +
                $"Цена: 53 руб., Количество на скаладе: 50.",

            };


            TextWriter oldOut = Console.Out;

            using (FileStream file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);
                    firstProduct.PrintInfo();
                    secondProduct.PrintInfo();
                }
            }

            Console.SetOut(oldOut);

            var i = 0;

            foreach (var line in File.ReadLines("test.txt"))
                Assert.AreEqual(consoleOut[i++], line);

            File.Delete("test.txt");
        }

        
        public Medicine CreatrMedicine()
        {
            return new Medicine("Гексорал", "Аэрозоль", "Парке-Дейвис для Пфайзер Х.К.П.",
                MedicineSaleWithRecipe.No)
            { Count = 10, Price = 187};
        }
    }
}
