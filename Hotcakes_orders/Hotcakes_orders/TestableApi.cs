using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Orders;
using System;
using System.Collections.Generic;

namespace Hotcakes_orders
{
    public class TestableApi : IApi
    {
        public ApiResponse<List<OrderSnapshotDTO>> OrdersFindAll()
        {
            return new ApiResponse<List<OrderSnapshotDTO>>()
            {
                Content = new List<OrderSnapshotDTO>() {
                    new OrderSnapshotDTO() {
                        Id = 1,
                        bvin = "testbvin",
                        BillingAddress = new Hotcakes.CommerceDTO.v1.Contacts.AddressDTO() { FirstName = "Teszt Elek" },
                        StoreId = 123,
                        UserEmail = "TestEmail@gmail.com" },
                    new OrderSnapshotDTO() { Id = 2, UserEmail = "Vasarlo@gmail.com" }
                }
            };
        }

        public ApiResponse<List<ProductDTO>> ProductsFindAll()
        {
            return new ApiResponse<List<ProductDTO>>()
            {
                Content = new List<ProductDTO>() {
                    new ProductDTO() {
                        Bvin = "TestBvin",
                        Sku = "ABC_SKU",
                        ProductName = "TeszTermékNeve",
                        SitePrice = 550m,
                        IsAvailableForSale = true,
                        CreationDateUtc = DateTime.UtcNow },
                    new ProductDTO() {
                        Bvin = "MásodikTestBvin",
                        Sku = "QQQQ_SKU",
                        ProductName = "TeszTermékNeve",
                        SitePrice = 8880m,
                        IsAvailableForSale = true,
                        CreationDateUtc = DateTime.UtcNow }
                }
            };
        }

        public ApiResponse<List<CategorySnapshotDTO>> CategoriesFindAll()
        {
            return new ApiResponse<List<CategorySnapshotDTO>>()
            {
                Content = new List<CategorySnapshotDTO>() {
                    new CategorySnapshotDTO() { Name = "TesztKategoria01" },
                    new CategorySnapshotDTO() { Name = "TesztKategoria02" },
                }
            };
        }

        public ApiResponse<ProductDTO> ProductsCreate(ProductDTO item, byte[] imageData)
        {
            return null;
        }

        public ApiResponse<bool> ProductsDelete(string bvin)
        {
            return null;
        }
    }
}
