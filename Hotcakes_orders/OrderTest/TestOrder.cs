//using Hotcakes.CommerceDTO.v1;
//using Hotcakes.CommerceDTO.v1.Catalog;
//using Newtonsoft.Json;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;

//namespace Hotcakes_orders.Tests
//{
//    public class Tests
//    {
//        private Api _proxy;
//        private const string _url = "http://20.234.113.211:8103/";
//        private const string _key = "1-8823ae01-abac-4ede-8316-c937104be727";

//        [SetUp]
//        public void Setup()
//        {
//            _proxy = new Api(_url, _key);
//        }

//        [Test]
//        public void OrdersFindAll_ShouldReturnOrders()
//        {
//            // Arrange

//            // Act
//            var response = _proxy.OrdersFindAll();
//            var deserializedResponse = JsonConvert.DeserializeObject<ApiResponse<List<OrderSnapshotDTO>>>(JsonConvert.SerializeObject(response));

//            // Assert
//            Assert.IsNotNull(response);
//            Assert.IsTrue(deserializedResponse.IsSuccessStatusCode);
//            Assert.IsNotNull(deserializedResponse.Content);
//            Assert.IsTrue(deserializedResponse.Content.Any());
//        }

//        [Test]
//        public void ProductsFindAll_ShouldReturnProducts()
//        {
//            // Arrange

//            // Act
//            var response = _proxy.ProductsFindAll();
//            var deserializedResponse = JsonConvert.DeserializeObject<ApiResponse<List<ProductDTO>>>(JsonConvert.SerializeObject(response));

//            // Assert
//            Assert.IsNotNull(response);
//            Assert.IsTrue(deserializedResponse.IsSuccessStatusCode);
//            Assert.IsNotNull(deserializedResponse.Content);
//            Assert.IsTrue(deserializedResponse.Content.Any());
//        }

//        [Test]
//        public void ProductsDelete_ShouldDeleteProduct()
//        {
//            // Arrange
//            var response = _proxy.ProductsFindAll();
//            var deserializedResponse = JsonConvert.DeserializeObject<ApiResponse<List<ProductDTO>>>(JsonConvert.SerializeObject(response));
//            var initialCount = deserializedResponse.Content.Count;
//            var productId = deserializedResponse.Content.First().Id;

//            // Act
//            var deleteResponse = _proxy.ProductsDelete(productId);

//            // Assert
//            Assert.IsNotNull(deleteResponse);
//            Assert.IsTrue(deleteResponse.IsSuccessStatusCode);

//            response = _proxy.ProductsFindAll();
//            deserializedResponse = JsonConvert.DeserializeObject<ApiResponse<List<ProductDTO>>>(JsonConvert.SerializeObject(response));
//            var finalCount = deserializedResponse.Content.Count;

//            Assert.AreEqual(initialCount - 1, finalCount);
//        }

//        [Test]
//        public void CategoriesFindAll_ShouldReturnCategories()
//        {
//            // Arrange

//            // Act
//            var response = _proxy.CategoriesFindAll();
//            var deserializedResponse = JsonConvert.DeserializeObject<ApiResponse<List<CategorySnapshotDTO>>>(JsonConvert.SerializeObject(response));

//            // Assert
//            Assert.IsNotNull(response);
//            Assert.IsTrue(deserializedResponse.IsSuccessStatusCode);
//            Assert.IsNotNull(deserializedResponse.Content);
//            Assert.IsTrue(deserializedResponse.Content.Any());
//        }

//        [Test]
//        public void ProductsDataGridView_ShouldHaveExpectedColumns()
//        {
//            // Arrange
//            var form1 = new Form1();

//            // Act
//            var actualColumns = form1.ProductsDataGridView.Columns.Cast<DataGridViewColumn>().Select(x => x.Name);

//            // Assert
//            Assert.AreEqual(new List<string> { "Bvin", "Sku", "ProductName", "SitePrice", "IsAvailableForSale", "CreationDateUtc" }, actualColumns);
//        }

//        [Test]
//        public void GetOrders_ShouldPopulateDataTable()
//        {
//            // Arrange
//            var form1 = new Form1();

//            // Act
//            form1.GetOrders();

//            // Assert
//            var dt = form1.ProductsDataGridView.DataSource as DataTable;
//            Assert.IsNotNull(dt);
//            Assert.IsTrue(dt.Rows.Count > 0);
//        }
//    }
//}
