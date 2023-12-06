using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            this.CreateMap<Product, ExportProductsInRangeDTO>()
                .ForMember(d => d.SellerFullName, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
        }
    }
}
