using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductEntryApp.BLL;
using ProductEntryApp.DLL.DAO;

namespace ProductEntryApp
{
    public partial class ProductEntryUI : Form
    {
        private Product aProduct;
        private ProductBLL aProductBll = new ProductBLL();

        public ProductEntryUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            aProduct = new Product();
            aProduct.ProductCode = productCodeTextBox.Text;
            aProduct.Name = productNameTextBox.Text;
            aProduct.Quantity = Convert.ToDouble(quantityTextBox.Text);


            string msg = aProductBll.Save(aProduct);
            MessageBox.Show(msg);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            List<Product> aProductList = aProductBll.GetAllProductList();

            foreach (Product product in aProductList)
            {                                                                                                         
                ListViewItem item = new ListViewItem(product.ProductCode);
                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.Quantity.ToString());
                viewAllProductListBox.Items.Add(item);
              
            }
            totalQuantityTextBox.Text = aProductBll.GetTotalQuantity();
        }
    }
}
