using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.CommerceDTO.v1.Orders;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotcakes_orders
{
    public partial class Form1 : Form
    {
        //Egy olyan API implementáció kerül létrehozásra, ami nem végez valódi hálózati hívásokat,
        //hanem előre beégetett válaszokkal tér vissza.
        //TestableApi.cs: az előre beégetett API válaszok.
        //Az ApiImplementation.cs file amiatt kellett, hogy az eredeti API osztály tesztelhető legyen.
        //A közös Interface az IApi.cs amit mind a kettő API osztály megkapott. A TestableApi és az ApiImplementation, ami az eredeti API ből leszármazott osztály, csak amiatt, hogy az interface-t megkapja.

        //A Program.cs ben könnyen kipróbálható, ha úgy indítod a programot, hogy paraméterben a TestableApi kerül példányosításra, akkor a tesztadatokkal fog futni a program
        //ugyanúgy, mint amikor a Unit tesztek is indulnak az OrderedTest.cs -ben.

        private readonly IApi api;

        public Form1(IApi testableApi = null)
        {
            InitializeComponent();

            if (testableApi != null)
            {
                api = testableApi;
            }
            else 
            {
                string url = "http://20.234.113.211:8103/";
                string key = "1-8823ae01-abac-4ede-8316-c937104be727";

                api = new ApiImplementation(url, key);
            }

            GetOrders();
        }

        public void GetOrders()
        {
            // call the API to find all orders in the store
            ApiResponse<List<OrderSnapshotDTO>> response = api.OrdersFindAll();
            string json = JsonConvert.SerializeObject(response);

            ApiResponse<List<OrderSnapshotDTO>> deserializedResponse = JsonConvert.DeserializeObject<ApiResponse<List<OrderSnapshotDTO>>>(json);

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("bvin", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("StoreId", typeof(long));

            foreach (OrderSnapshotDTO item in deserializedResponse.Content)
            {
                dt.Rows.Add(item.Id, item.bvin, item.BillingAddress.FirstName, item.StoreId);
            }

            ProductsDataGridView.DataSource = dt;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            GetProducts();
        }

        public void GetProducts()
        {
            ApiResponse<List<ProductDTO>> response = api.ProductsFindAll();
           //ApiResponse<List<CategoryDTO>> response1 = proxy.CategoriesFindAll();
            ApiResponse<List<CategorySnapshotDTO>> response1 = api.CategoriesFindAll();
            //ApiResponse<List<CategorySnapshotDTO>> response3 = proxy.CategoriesFindForProduct(productID);


            string json = JsonConvert.SerializeObject(response);
            string json1 = JsonConvert.SerializeObject(response1);


            ApiResponse<List<ProductDTO>> deserializedResponse = JsonConvert.DeserializeObject<ApiResponse<List<ProductDTO>>>(json);
            ApiResponse<List<CategorySnapshotDTO>> deserializedResponse1 = JsonConvert.DeserializeObject<ApiResponse<List<CategorySnapshotDTO>>>(json);


            DataTable dt = new DataTable();

            dt.Columns.Add("Bvin", typeof(string));
            dt.Columns.Add("Sku", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("SitePrice", typeof(string));
            dt.Columns.Add("IsAvailableForSale", typeof(string));
            dt.Columns.Add("CreationDateUtc", typeof(DateTime));


            foreach (ProductDTO item in deserializedResponse.Content)
            {
                dt.Rows.Add(item.Bvin, item.Sku, item.ProductName, $"{item.SitePrice} Ft", item.IsAvailableForSale, item.CreationDateUtc);
            }

            //foreach (CategorySnapshotDTO item in deserializedResponse1.Content)
            //{
            //    dt.Rows.Add(item.Name);
            //}

            // save the selected row index and row count
            int selectedRowIndex = ProductsDataGridView.CurrentRow != null ? ProductsDataGridView.CurrentRow.Index : 0;
            int rowCount = ProductsDataGridView.Rows.Count;


            // set the DataSource
            ProductsDataGridView.DataSource = dt;


            // restore the selected row index if the DataGridView has rows
            if (rowCount > 0)
            {
                int indexToSelect = Math.Min(selectedRowIndex, ProductsDataGridView.Rows.Count - 1);
                ProductsDataGridView.CurrentCell = ProductsDataGridView.Rows[indexToSelect].Cells[0];
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos törölni szeretnéd?", "Törlés megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // your existing code to delete the selected row
                int rowIndex = ProductsDataGridView.CurrentCell.RowIndex;
                int selectedRowIndex = ProductsDataGridView.CurrentRow.Index;
                // get the productId from the first column of the selected row
                var productId = ProductsDataGridView.Rows[rowIndex].Cells[0].Value.ToString();

                ApiResponse<bool> response = api.ProductsDelete(productId);

                // refresh the DataGridView
                GetProducts();

                textBoxSearch.Clear();

            }
        }

        public void buttonRefresh_Click(object sender, EventArgs e)
        {
            GetProducts();
           // textBoxSearch.Clear();

        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Biztosan be szeretnéd zárni?", "Ablak bezárásának megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            var product = new ProductDTO();

            var productId1 = textBoxName.Text;

            if (!decimal.TryParse(textBoxPrice.Text, out decimal value) || value == 0)
            {
                MessageBox.Show("Érvénytelen érték. Kérlek adj meg egy valós árat a terméknek.");
                return;
            }

            Random rnd = new Random();

            product.Sku = rnd.Next(40000, 1000000).ToString();
            product.ProductName = textBoxName.Text;
            product.SitePrice = int.Parse(textBoxPrice.Text);
            product.IsAvailableForSale = checkBoxAvailable.Checked;
            product.CreationDateUtc= DateTime.Now;

            ApiResponse<ProductDTO> response = api.ProductsCreate(product, null);

            textBoxName.Clear();
            textBoxPrice.Clear();
            checkBoxAvailable.Checked = false;
            textBoxSearch.Clear();

            GetProducts();

            foreach (DataGridViewRow row in ProductsDataGridView.Rows)
            {
                if (row.Cells["ProductName"].Value.ToString() == productId1)
                {
                    // highlight the row
                    row.Selected = true;
                    break;
                }
            } 
                      
        }

        public void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            (ProductsDataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("ProductName LIKE '{0}%'", textBoxSearch.Text);
        }

        private void ProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
