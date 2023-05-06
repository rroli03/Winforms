using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Orders;
using System.Collections.Generic;

namespace Hotcakes_orders
{
    public interface IApi
    {
        ApiResponse<List<OrderSnapshotDTO>> OrdersFindAll();

        ApiResponse<List<ProductDTO>> ProductsFindAll();

        ApiResponse<List<CategorySnapshotDTO>> CategoriesFindAll();

        ApiResponse<ProductDTO> ProductsCreate(ProductDTO item, byte[] imageData);

        ApiResponse<bool> ProductsDelete(string bvin);
    }
}