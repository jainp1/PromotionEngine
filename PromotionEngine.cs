using PromotionEngine.Models;

namespace PromotionEngine
{
    /// <summary>
    /// PromotionEngine class takes cart object as input and calculates total using existing inventory.
    /// This class can be extended by adding more promotions in future.
    /// </summary>
    public static class PromotionEngine
    {
        public static int CalculatePrice(Cart item, SKU sku)
        {
            int totalSkuPrice = 0;
            switch (sku.Promotion)
            {
                case Promotion.Buy1Get1:
                    {
                        if (item.Quantity > 1)
                        {
                            totalSkuPrice = totalSkuPrice + (item.Quantity / 2 * sku.SkuUnitPrice) + (item.Quantity % 2 * sku.SkuUnitPrice);
                        }
                        else
                        {
                            totalSkuPrice = item.Quantity * sku.SkuUnitPrice;
                        }
                        break;
                    }

                case Promotion.Buy3For130:
                    {
                        if (item.Quantity > 2)
                        {
                            totalSkuPrice = totalSkuPrice + (item.Quantity / 3 * 130) + (item.Quantity % 3 * sku.SkuUnitPrice);
                        }
                        else
                        {
                            totalSkuPrice = item.Quantity * sku.SkuUnitPrice;
                        }

                        break;
                    }
                case Promotion.Buy2For45:
                    {
                        if (item.Quantity > 1)
                        {
                            totalSkuPrice = totalSkuPrice + (item.Quantity / 2 * 45) + (item.Quantity % 2 * sku.SkuUnitPrice);
                        }
                        else
                        {
                            totalSkuPrice = item.Quantity * sku.SkuUnitPrice;
                        }
                        break;
                    }
            }

            return totalSkuPrice;
        }
    }
}
