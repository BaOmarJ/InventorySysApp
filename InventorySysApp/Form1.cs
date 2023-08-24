using System.Data;
using System;
namespace InventorySysApp
{
    public partial class InventorySysApp : Form
    {
        int indexRow;
        DataTable inventory=new DataTable();
        BindingSource invTblBs = new BindingSource();
        public InventorySysApp()
        {
            InitializeComponent();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            txtSku.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
            txtQuantity.Text = "";
            cmbCategory.SelectedIndex = -1;
        }
        private void inputItemToTbl(object sender, EventArgs e)
        {
            float parsedValuePrice; int parsedValueQty;
            if (float.TryParse(txtPrice.Text, out parsedValuePrice) && int.TryParse(txtQuantity.Text, out parsedValueQty))
            { 
                // save_to_variables
                string sku = txtSku.Text;
                string name = txtName.Text;
                string price = txtPrice.Text;
                string description = txtDescription.Text;
                string quantity = txtQuantity.Text;
                string category = (string)cmbCategory.SelectedItem;
                //add_to_datatable
                inventory.Rows.Add(sku, name, price, description, quantity, category);
                //clear_text_fields
                btnAddNewItem_Click(sender, e);
            }
            else if(!float.TryParse(txtPrice.Text, out parsedValuePrice))
            {
                MessageBox.Show("Please enter correct format for the price, e.g. 12.50");
                txtPrice.Focus();
            }
            else
            {
                MessageBox.Show("Please enter correct format for the quantity, e.g. 12");
                txtQuantity.Focus();
            }
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            //Array for all or some of the TextBox on the Form
            TextBox[] textBox = { txtSku, txtName, txtPrice, txtDescription, txtQuantity };
            int txtBxToCheckAmount = 0;

            //foreach loop for check TextBox is empty
            foreach (TextBox txt in textBox)
            {
                string str = ((string)txt.Name).Substring(3);
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("The " + str + " is empty!" );
                    txt.Focus();
                    break;
                }
                else
                {
                    txtBxToCheckAmount++;
                };
            }
            if(txtBxToCheckAmount == 5)
            {
                inputItemToTbl(sender,e);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].Delete();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void inventoryGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtSku.Text = inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
                txtName.Text = inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
                txtPrice.Text = inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].ItemArray[2].ToString();
                txtDescription.Text = inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].ItemArray[3].ToString();
                txtQuantity.Text = inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].ItemArray[4].ToString();

                string itemToLookFor = inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].ItemArray[5].ToString();
                cmbCategory.SelectedIndex = cmbCategory.Items.IndexOf(itemToLookFor);
                //txtSku.Text = inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                Console.WriteLine("There has been error: " + err);
            } 
        }

        private void InventorySysApp_Load(object sender, EventArgs e)
        {
            inventory.Columns.Add("SKU");
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Price");
            inventory.Columns.Add("Description");
            inventory.Columns.Add("Quantity");
            inventory.Columns.Add("Category");

            ///*// using bindingsource to display on datagridview
            invTblBs.DataSource = inventory;
            inventoryGridView1.DataSource = invTblBs;
            //*/

            /*// or using the inven
            inventoryGridView1.DataSource = inventory;
            */
        }

        private void txtPrice_MouseLeave(object sender, EventArgs e)
        {
            float parsedValue;
            if (!float.TryParse(txtPrice.Text, out parsedValue))
            {
                MessageBox.Show("This is a Price only field, Please enter the price per item in numbers e.g. 12.50");
                txtPrice.Focus();
            }
        }

        private void inventoryGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = inventoryGridView1.Rows[indexRow];
            try
            {
                txtSku.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPrice.Text = row.Cells[2].Value.ToString();
                txtDescription.Text = row.Cells[3].Value.ToString();
                txtQuantity.Text = row.Cells[4].Value.ToString();

                string itemToLookFor = row.Cells[5].Value.ToString();
                cmbCategory.SelectedIndex = cmbCategory.Items.IndexOf(itemToLookFor);
                //txtSku.Text = inventory.Rows[inventoryGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                Console.WriteLine("There has been error: " + err);
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow newDataRow = inventoryGridView1.Rows[indexRow];
                newDataRow.Cells[0].Value = txtSku.Text;
                newDataRow.Cells[1].Value = txtName.Text;
                newDataRow.Cells[2].Value = txtPrice.Text;
                newDataRow.Cells[3].Value = txtDescription.Text;
                newDataRow.Cells[4].Value = txtQuantity.Text;
                newDataRow.Cells[5].Value = cmbCategory.Text;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }
    }
}