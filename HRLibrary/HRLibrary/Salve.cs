using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLibrary
{
    public class Salve : Medicine
    {
        public int Volume { get; set; }
        public Salve(string name, string articleNumber, string manufacturer, MedicineSaleWithRecipe saleWithRecipe, int volume) : base(name, articleNumber, manufacturer, saleWithRecipe)
        {
            Volume = volume;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Объем тубы: {Volume}мг");
        }
    }
}
