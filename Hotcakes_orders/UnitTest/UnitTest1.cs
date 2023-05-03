using Hotcakes_orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace UnitTest
{
    [TestClass]
    public class Form1Tests
    {
        [TestMethod]
        public void GetOrders_ReturnsOrders()
        {
            // Arrange
            var form = new Form1();

            // Act
            form.GetOrders();

            // Assert
            Assert.IsNotNull(form.ProductsDataGridView.DataSource);

            var dataSource = (System.Data.DataTable)form.ProductsDataGridView.DataSource;
            Assert.AreEqual(4, dataSource.Rows.Count);

            var row = dataSource.Rows[0];
            Assert.AreEqual(1, row["Id"]);
            Assert.AreEqual("bvin1", row["bvin"]);
            Assert.AreEqual("John", row["FirstName"]);
            Assert.AreEqual(1, row["StoreId"]);
        }
    }
}

