using EntityFrameworkDBFirst_BLL;
using EntityFrameworkDBFirst_BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameWorkDBFirstWinFormUI
{   //INSTALL ENTITYFRAMEWORK FOR UI AS WELL. COPY CONNECTIONSTRING FROM DAL's AppConfig and paste it into UI's AppConfig (inside configuration tags)
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Global
        ProductManager myProductManager = new ProductManager();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Let's bring product information into form load page.
            BringProductsToGrid();
        }

        private void BringProductsToGrid()
        {
            //Bring list through BLL.
            dataGridView1.DataSource = myProductManager.BringAllProducts();
            dataGridView1.Columns["SupplierID"].Visible = false;
            dataGridView1.Columns["CategoryID"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //testing purpose. That's actually it for dbfirst
            ProductViewModel newProduct = new ProductViewModel()
            {
                ProductName = "Testing Product",
                Discontinued = false,
                CategoryID = 1
            };
            myProductManager.AddNewProduct(newProduct);
            //Method added to Product manager in a primitive manner. Just to test adding new item in a shallow implementation conventions.
        }
    }
}
