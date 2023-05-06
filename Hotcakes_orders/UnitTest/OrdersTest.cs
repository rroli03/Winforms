//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Hotcakes_orders;



//namespace UnitTest
//{
//    [TestClass]
//    public class OrdersTest
//    {
//        [TestMethod]
//        public void GetOrders_ReturnOrders()
//        {
//            // Arrange
//            var form = new Form1();

//            // Act
//            form.GetOrders();

//            // Assert
//            Assert.IsNotNull(form.ProductsDataGridView, "ProductsDataGridView is null");
//            Assert.IsNotNull(form.ProductsDataGridView.DataSource, "ProductsDataGridView.DataSource is null");

//        }


//        [TestMethod]
//        public void GetProducts_ReturnsProducts()
//        {
//            // Arrange
//            var form = new Form1();

//            // Act
//            form.GetProducts();

//            // Assert
//            Assert.IsNotNull(form.ProductsDataGridView);
//            if (form.ProductsDataGridView != null)
//            {
//                Assert.IsNotNull(form.ProductsDataGridView.DataSource);
//            }
//        }

//        [TestMethod]
//        public void ButtonDelete_DeletesSelectedProduct()
//        {
//            // Arrange
//            var form = new Form1();

//            // Act
//            var initialRowCount = form.ProductsDataGridView.Rows.Count;
//            form.buttonDelete.PerformClick();
//            var finalRowCount = form.ProductsDataGridView.Rows.Count;

//            // Assert
//            Assert.AreEqual(initialRowCount - 1, finalRowCount);
//        }

//        [TestMethod]
//        public void ButtonRefresh_ReloadsProducts()
//        {
//            // Arrange
//            var form = new Form1();

//            // Act
//            var initialRowCount = form.ProductsDataGridView.Rows.Count;
//            form.buttonRefresh.PerformClick();
//            var finalRowCount = form.ProductsDataGridView.Rows.Count;

//            // Assert
//            Assert.AreEqual(initialRowCount, finalRowCount);
//        }
//    }
//}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hotcakes_orders;

//namespace UnitTest
//{
//    //[TestClass]
//public class OrdersTest
//{
//    private Form1 form;

//    [TestInitialize]
//    public void TestInitialize()
//    {
//        form = new Form1();
//        // Initialize any other objects used in the test
//    }

//    [TestMethod]
//    public void GetOrders_ReturnOrders()
//    {
//        // Arrange

//        // Act
//        form.GetOrders();

//        // Assert
//        if (form.ProductsDataGridView != null)
//        {
//            Assert.IsNotNull(form.ProductsDataGridView.DataSource, "ProductsDataGridView.DataSource is null");
//        }
//        else
//        {
//            Assert.Fail("ProductsDataGridView is null");
//        }
//    }

//    [TestMethod]
//    public void GetProducts_ReturnsProducts()
//    {
//        // Arrange

//        // Act
//        form.GetProducts();

//        // Assert
//        if (form.ProductsDataGridView != null)
//        {
//            Assert.IsNotNull(form.ProductsDataGridView.DataSource);
//        }
//        else
//        {
//            Assert.Fail("ProductsDataGridView is null");
//        }
//    }

//    [TestMethod]
//    public void ButtonDelete_DeletesSelectedProduct()
//    {
//        // Arrange

//        // Act
//        var initialRowCount = form.ProductsDataGridView.Rows.Count;
//        form.buttonDelete.PerformClick();
//        var finalRowCount = form.ProductsDataGridView.Rows.Count;

//        // Assert
//        Assert.AreEqual(initialRowCount - 1, finalRowCount);
//    }

//    [TestMethod]
//    public void ButtonRefresh_ReloadsProducts()
//    {
//        // Arrange

//        // Act
//        var initialRowCount = form.ProductsDataGridView.Rows.Count;
//        form.buttonRefresh.PerformClick();
//        var finalRowCount = form.ProductsDataGridView.Rows.Count;

//        // Assert
//        Assert.AreEqual(initialRowCount, finalRowCount);
//    }
//}

//}


namespace UnitTest
{
    [TestClass]
    public class OrdersTest
    {
        private Form1 form;

        [TestInitialize]
        public void TestInitialize()
        {
            form = new Form1(new TestableApi());
            form.Show();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            form.Close();
            form.Dispose();
        }

        [TestMethod]
        public void GetOrders_ReturnOrders()
        {
            // Act
            form.GetOrders();

            // Assert
            Assert.IsNotNull(form.ProductsDataGridView, "ProductsDataGridView is null");
            Assert.IsNotNull(form.ProductsDataGridView.DataSource, "ProductsDataGridView.DataSource is null");
        }

        [TestMethod]
        public void GetProducts_ReturnsProducts()
        {
            // Act
            form.GetProducts();

            // Assert
            Assert.IsNotNull(form.ProductsDataGridView);
            Assert.IsNotNull(form.ProductsDataGridView.DataSource, "ProductsDataGridView.DataSource is null");
        }

        [TestMethod]
        public void ButtonDelete_DeletesSelectedProduct()
        {
            // Arrange
            form.GetProducts();

            // Act
            var initialRowCount = form.ProductsDataGridView.Rows.Count;
            form.buttonDelete.PerformClick();
            var finalRowCount = form.ProductsDataGridView.Rows.Count;

            // Assert
            Assert.AreEqual(initialRowCount - 1, finalRowCount);
        }

        [TestMethod]
        public void ButtonRefresh_ReloadsProducts()
        {
            // Arrange
            form.GetProducts();

            // Act
            var initialRowCount = form.ProductsDataGridView.Rows.Count;
            form.buttonRefresh.PerformClick();
            var finalRowCount = form.ProductsDataGridView.Rows.Count;

            // Assert
            Assert.AreEqual(initialRowCount, finalRowCount);
        }
    }
}
