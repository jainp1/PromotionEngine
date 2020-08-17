namespace PromotionEngine.Models
{
    public class SKU
    {
        public string SkuId { get; set; }
        public int SkuUnitPrice { get; set; }
        public Promotion Promotion { get; set; }
    }
}
