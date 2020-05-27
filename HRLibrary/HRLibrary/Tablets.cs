using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLibrary
{
    public class Tablets : Medicine
    {
        public int CountInPackage { get; set; }
        public Tablets(string name, string articleNumber, string manufacturer, MedicineSaleWithRecipe saleWithRecipe, int countInPackage) : base(name, articleNumber, manufacturer, saleWithRecipe)
        {
            CountInPackage = countInPackage;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Количество таблеток в упаковке {CountInPackage}шт");
        }
    }
}
