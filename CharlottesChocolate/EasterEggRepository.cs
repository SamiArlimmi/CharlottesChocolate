using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocolateLibrary;

namespace ChocolateLibrary
{
    public class EasterEggRepository
    {
        private List<EasterEgg> easterEggList;

        public EasterEggRepository()
        {
            //listen af EasterEgg
            easterEggList = new List<EasterEgg>
            {
                new EasterEgg(1, "Lys Chocolate", 500, 15),
                new EasterEgg(2, "Mørk Chocolate", 700, 8),
                new EasterEgg(3, "Mørk Chocolate", 799, 20),
                new EasterEgg(4, "Mørk Chocolate", 999, 4),
                new EasterEgg(5, "Dark Chocolate", 1200, 12),
                new EasterEgg(6, "Mørk Chocolate", 1400, 1),
                new EasterEgg(7, "Mørk Chocolate", 2000, 27),
            };
        }

        // Metode til at hente alle EasterEgg
        public List<EasterEgg> Get()
        {
            return easterEggList;
        }

        // Metode til at hente et EasterEgg
        public EasterEgg GetByProductNo(int productNo)
        {
            EasterEgg easterEgg = easterEggList.Find(egg => egg.ProductNo == productNo);

            if (easterEgg == null)
            {
                throw new ArgumentException($"EasterEgg with ProductNo {productNo} not found.");
            }

            return easterEgg;
        }

        // Metode til at hente liste lavere eller lig med 10
        public List<EasterEgg> GetLowStock(int stockLevel)
        {
            List<EasterEgg> lowStockEggs = easterEggList.FindAll(egg => egg.InStock <= stockLevel);
            return lowStockEggs;
        }


        // Metode til at opdatere et easteregg fra listen
        public void Update(EasterEgg egg)
        {
            int index = easterEggList.FindIndex(e => e.ProductNo == egg.ProductNo);

            if (index == -1)
            {
                throw new ArgumentException($"EasterEgg with ProductNo {egg.ProductNo} not found.");
            }
            easterEggList[index] = egg;
        }
    }
}
