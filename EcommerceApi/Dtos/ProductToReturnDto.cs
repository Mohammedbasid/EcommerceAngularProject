using Core.Models;

namespace EcommerceApi.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
        public String ProductBrand { get; set; }
        
    }
}
