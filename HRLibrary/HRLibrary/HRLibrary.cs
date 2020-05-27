using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLibrary
{
    public enum MedicineSaleWithRecipe
    {
        Yes,
        No
    }

    public class Medicine
    {
        
        public string Name { get;  set; }
        public string ArticleNumber { get; private set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public MedicineSaleWithRecipe SaleWithRecipe { get; set; }

        
        public Medicine(string name, string articleNumber, string manufacturer, MedicineSaleWithRecipe saleWithRecipe)
        {
            Name = name;
            ArticleNumber = articleNumber;
            Manufacturer = manufacturer;
            SaleWithRecipe = saleWithRecipe;
        }

        
        public override string ToString()
        {
            return  $"{Name} {ArticleNumber}";
        }

        
        public virtual void PrintInfo()
        {
            
            Console.WriteLine(this);

            var saleWithRecipe = " ";

             
            switch (SaleWithRecipe)
            {
                case MedicineSaleWithRecipe.Yes:
                    saleWithRecipe = "Да";
                    break;
                case MedicineSaleWithRecipe.No:
                    saleWithRecipe = "Нет";
                    break;
            }

            
            Console.WriteLine($"Продажа с рецептом: {saleWithRecipe}, " +
                $"Производитель: {Manufacturer}, Цена: {Price} руб., Количество на скаладе: {Count}.");
        }
    }
}
