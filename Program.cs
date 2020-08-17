using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Program
    {
        /// <summary>
        /// A simple shopping console application. User needs to setup Sku and promotions before running the application. 
        /// This app takes product name and quantity as input from customer and calculates final price based on promotion applied from backend to the product.
        /// App is extendable from backend by manually adding more promotions and sku's.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Cart> cart = new List<Cart>();

            // Set Inventory
            List<SKU> sKUs = SetupInventory();

            // Get user inputs
            GetCustomerInputs(cart, sKUs);

            // Calculate Total Value
            var total = 0;
            foreach (var item in cart)
            {
                var totalSkuPrice = 0;
                var sku = sKUs.Where(x => x.SkuId == item.SkuId).FirstOrDefault();
                totalSkuPrice = PromotionEngine.CalculatePrice(item, sku);
                total += totalSkuPrice;
            }

            Console.WriteLine($"Your total payable amount is : ${total}");
            Console.ReadKey();
        }

        private static void GetCustomerInputs(List<Cart> cart, List<SKU> sKUs)
        {
            Console.WriteLine("Welcome to T-Mart");
            Console.WriteLine($"Available products are: {string.Join(", ", sKUs.Select(x => x.SkuId).ToList())}");
            Console.WriteLine("Please add products and quantity.");
            string add = "y";
            while (add == "y")
            {
                Console.WriteLine("Please add product name");
                string skuId = Console.ReadLine();
                if (sKUs.Any(x => x.SkuId == skuId))
                {
                    Console.WriteLine("Please add product quantity");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    cart.Add(new Cart
                    {
                        SkuId = skuId,
                        Quantity = quantity
                    });

                    Console.WriteLine("Do you want to add more items in cart: y/n");
                    add = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please enter correct product name.");
                }
            }
        }

        private static List<SKU> SetupInventory()
        {
            // Setup inventory 
            return new List<SKU>
            {
                new SKU
                {
                    SkuId = "A",
                    SkuUnitPrice = 50,
                    Promotion = Promotion.Buy3For130
                },
                new SKU
                {
                    SkuId = "B",
                    SkuUnitPrice = 30,
                    Promotion = Promotion.Buy2For45
                }
            };
        }
    }
}
