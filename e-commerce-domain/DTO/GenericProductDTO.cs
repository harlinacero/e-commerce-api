using e_commerce_domain.enums;

namespace e_commerce_domain.DTO
{
    public class GenericProductDTO
    {
        public ProductType ProductType { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal GrossValue { get; set; }
        public decimal DiscPercentaje { get; set; }
        public decimal TaxPercentaje { get; set; }
        public int Stock { get; set; }
        public string FileFormat { get; set; }
        public float Size { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal BaseShippingCost { get; set; }
    }
}
