using System;

namespace ChocolateLibrary
{
    public class EasterEgg
    {
        //(Properties)
        public int ProductNo { get; set; }
        public string ChocolateType { get; set; }
        public int Price { get; set; }
        public int InStock { get; set; }

        //(Constructor)
        public EasterEgg(int productNo, string chocolateType, int price, int inStock)
        {
            ProductNo = productNo;
            ChocolateType = chocolateType;
            Price = price;
            InStock = inStock;
        }

        //ToString metode
        public override string ToString()
        {
            return $"ProductNo: {ProductNo}, ChocolateType: {ChocolateType}, Price: {Price}, InStock: {InStock}";
        }
    }
}
