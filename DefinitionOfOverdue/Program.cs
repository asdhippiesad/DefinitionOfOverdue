using System;
using System.Collections.Generic;
using System.Linq;

namespace DefinitionOfOverdue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.Work();

            Console.ReadKey();
        }
    }

    class Menu
    {
        private IEnumerable<CannedFood> _cannedFoods = new List<CannedFood>();

        public Menu()
        {
            _cannedFoods = new List<CannedFood>
            {
                new CannedFood("Говядина тушёная", 2021, 2),
                new CannedFood("Свинина тушеная", 2019, 2),
                new CannedFood("Индейка филе с овощами", 2020, 2),
                new CannedFood("Конина тушеная", 2021, 3),
                new CannedFood("Мясо марала", 2020, 2),
                new CannedFood("Куриное филе грудки", 2021, 3)
            };
        }

        public void Work()
        {
            Console.WriteLine("Все консервы: ");
            ShowCannedFoods(_cannedFoods);
            Console.WriteLine("_______________");

            Console.WriteLine("Просроченные консервы: ");
            ShowCannedFoods(GetExpiredCanned(_cannedFoods));
            Console.WriteLine("_______________");
        }

        private void ShowCannedFoods(IEnumerable<CannedFood> cannedFoods)
        {
            if (cannedFoods.Any())
            {
                foreach (var cannedFood in cannedFoods)
                {
                    cannedFood.ShowInfo();
                }
            }
        }

        private IEnumerable<CannedFood> GetExpiredCanned(IEnumerable<CannedFood> cannedFoods) =>
            cannedFoods.Where(cannedFood => cannedFood.YearOfProduction + cannedFood.ExpirationDate > DateTime.Now.Year);
    }

    class CannedFood
    {
        public CannedFood(string name, int yearMade, int expirationData)
        {
            Name = name;
            YearOfProduction = yearMade;
            ExpirationDate = expirationData;
        }

        public string Name { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, {YearOfProduction} - {ExpirationDate}");
        }
    }
}
