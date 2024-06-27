using System;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace FINAL_PROJECT
{
    public partial class Form2 : Form
    {
        LogIn form = null;
        public Form2(LogIn form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Bounds = Screen.PrimaryScreen.Bounds;
            StatusCBX();
            CusCBX();
            ItemCBX();
            InvoiceCBX();
            PDetailsCBX();
            ReasonCDX();
            InvoiceReturnCBX();
            OverviewDisplay();
            lowStockTB();
            IRCBX();
            Status2CBX();

        }
        public void OP()
        {
            if (Inventory.Visible == true) 
            {
                FillIItems();
                FillProductionDetails();
            }
            else if (Contacts.Visible == true)
            {
                FillCusContacts();
                FillEmpContacts();
            }
            else if (Sales.Visible == true)
            {
                FillOSales();
                SelectedSales();
                FillPaymentReceived();
                FillComplete();
                FillReturnCustomerDetails();
            } 
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.form.setEmpty();
            this.form.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Inventory.Visible == false)
            {
                Inventory.Visible = true;
                Order.Visible = false;
                Sales.Visible = false;
                Overview.Visible = false;
                Contacts.Visible = false;
            }
            else if (Inventory.Visible == true)
            {
                Inventory.Visible = false;
            }
            OP();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (Sales.Visible == false)
            {
                Sales.Visible = true;
                Inventory.Visible = false;
                Order.Visible = false;
                Overview.Visible = false;
                Contacts.Visible = false;
            }
            else if (Sales.Visible == true)
            {
                Sales.Visible = false;
            }
            OP();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Overview.Visible == false)
            {
                Overview.Visible = true;
                Inventory.Visible = false;
                Order.Visible = false;
                Sales.Visible = false;
                Contacts.Visible = false;
            }
            else if (Overview.Visible == true)
            {
                Overview.Visible = false;
            }
            OP();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Contacts.Visible == false)
            {
                Contacts.Visible = true;
                Inventory.Visible = false;
                Order.Visible = false;
                Sales.Visible = false;
                Overview.Visible = false;
            }
            else if (Contacts.Visible == true)
            {
                Contacts.Visible = false;
            }
            OP();
        }
        // ID HERE 
        public int CusId()
        {
            int a = CusContacts.Rows.Count;
            int b = a + 2001;
            return b;
        }
        public int EmpId()
        {
            int a = EmpContacts.Rows.Count;
            int b = a + 1001;
            return b;
        }
        public int ItemId()
        {
            int a = IItem.Rows.Count;
            int b = a + 5001;
            return b;
        }
        public int OrderId()
        {
            int a = OSales.Rows.Count;
            int b = a + 3001;
            return b;
        }
        public int InvoiceId()
        {
            int a = OSales.Rows.Count;
            int b = a + 4001;
            return b;
        }

        public int ReturnCustomerID()
        {
            int a = ReturnCustomerT.Rows.Count;
            int b = a + 7001;
            return b;
        }

        public int ProductionId()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            SqlCommand query = new SqlCommand("Select COALESCE(MAX(ProductionID), '0') From Production", con);
            query.ExecuteNonQuery();
            int a = Convert.ToInt32(query.ExecuteScalar());
            int b = a + 1;
            return b;
        }

        public int ProductionDetailsId()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            SqlCommand query = new SqlCommand("Select COALESCE(MAX(PDetailsID), '0') From ProductionDetails", con);
            query.ExecuteNonQuery();
            int a = Convert.ToInt32(query.ExecuteScalar());
            int b = a + 1;
            return b;
        }

        // Retrieve and Insert into database
        private void FillEmpContacts()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            EmpContacts.Rows.Clear();
            SqlCommand query = new SqlCommand("Select * from eContacts", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                EmpContacts.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            panel1.Visible = true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        private void FillCusContacts()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            CusContacts.Rows.Clear();
            con.Open();
            SqlCommand query = new SqlCommand("Select * from CContacts ORDER BY CusId", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                CusContacts.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            int id = EmpId();

            string query = "INSERT INTO eContacts(empID, fName,lName, phone)";
            query += "VALUES (@Id,@fName,@lName,@phone)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@fName", textBox1.Text);
            cmd.Parameters.AddWithValue("@lName", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            int affectedRows = cmd.ExecuteNonQuery();
            MessageBox.Show(affectedRows + " rows inserted!");
            FillEmpContacts();

            panel1.Visible = false;
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            newOrder.Visible = true;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            int iid = InvoiceId();

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            string query = "Delete from salesDetails where invoiceNo = @iNID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@iNID", iid);
            cmd.ExecuteNonQuery();

            newOrder.Visible = false;
            this.ProductList.Items.Clear();
            this.comboBox2.Text = string.Empty;
            this.comboBox1.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.dateTimePicker1.Text = string.Empty;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            int id = CusId();

            string query = "INSERT INTO CContacts(CusId, FName,LName, phone)";
            query += "VALUES (@Id,@fName,@lName,@phone)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@fName", textBox8.Text);
            cmd.Parameters.AddWithValue("@lName", textBox7.Text);
            cmd.Parameters.AddWithValue("@phone", textBox6.Text);
            int affectedRows = cmd.ExecuteNonQuery();
            MessageBox.Show(affectedRows + " rows inserted!");
            FillCusContacts();

            panel3.Visible = false;
            this.textBox8.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            CusCBX();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }
        private void FillIItems()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            IItem.Rows.Clear();
            SqlCommand query = new SqlCommand("Select * from Item", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                IItem.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), string.Format("{0:C}", reader.GetValue(3)));
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            int id = ItemId();

            string query = "INSERT INTO Item(ItemID, IName,IDes, UnitPrice)";
            query += "VALUES (@Id,@iName,@iDes,@unitPrice)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@iName", textBox11.Text);
            cmd.Parameters.AddWithValue("@iDes", textBox10.Text);
            cmd.Parameters.AddWithValue("@unitPrice", textBox9.Text);
            int affectedRows = cmd.ExecuteNonQuery();
            MessageBox.Show(affectedRows + " rows inserted!");
            FillIItems();

            panel4.Visible = false;
            this.textBox8.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            ItemCBX();
            PDetailsCBX();
            OverviewDisplay();
        }
        private void button23_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }
        public void CusCBX()
        {
            Customer1 cus = new Customer1();
            ArrayList customerList = new ArrayList();
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            SqlCommand query = new SqlCommand("Select * from CContacts order by FName ", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                cus = new Customer1();
                cus.cId = Convert.ToInt32(reader.GetValue(0));
                cus.fullName = reader.GetValue(1) + " " + reader.GetValue(2);
                customerList.Add(cus);
            }
            comboBox2.DataSource = customerList;
            comboBox2.ValueMember = "cId";
            comboBox2.DisplayMember = "fullName";
            comboBox2.SelectedIndex = -1;
            OverviewDisplay();
        }
        public void ItemCBX()
        {
            Inventory item = new Inventory();
            ArrayList itemList = new ArrayList();
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            SqlCommand query = new SqlCommand("Select * from Item order by IName", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                item = new Inventory();
                item.iId = Convert.ToInt32(reader.GetValue(0));
                item.iName = reader.GetValue(1).ToString();
                itemList.Add(item);
            }
            comboBox1.DataSource = itemList;
            comboBox1.ValueMember = "iID";
            comboBox1.DisplayMember = "iName";
            comboBox1.SelectedIndex = -1;
            OverviewDisplay();
        }
        public int PID()
        {
            Inventory item = comboBox1.SelectedItem as Inventory;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            SqlCommand query = new SqlCommand("IF EXISTS (SELECT PDetailsID FROM ProductionDetails WHERE ItemId = @ItemId AND Quantity > @Qty) SELECT PDetailsID FROM ProductionDetails WHERE ItemID = @ItemID AND Quantity > @Qty ELSE SELECT 0", con);
            query.Parameters.AddWithValue("@ItemId", item.iId);
            query.Parameters.AddWithValue("@Qty", Convert.ToInt32(textBox4.Text));

            int pId = (int)query.ExecuteScalar();

            return pId;
        }

        public void button15_Click(object sender, EventArgs e)
        {
            int pId = PID();
            int iid = InvoiceId();
            int qty = Convert.ToInt32(textBox4.Text);
            Inventory item = comboBox1.SelectedItem as Inventory;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            string query = "INSERT INTO salesDetails(invoiceNo, itemID, Qty, PDetailsID)";
            query += "VALUES (@iNID,@itemID,@qty,@PDetailsID)";

            SqlCommand cmd = new SqlCommand(query, con);

            if (pId == 0)
            {
                MessageBox.Show("Item not in Stock");
            }
            else if (qty == 10)
            {
                MessageBox.Show("Quantity Limit is 10");
            }
            else
            {
                cmd.Parameters.AddWithValue("@iNID", iid);
                cmd.Parameters.AddWithValue("@itemID", item.iId);
                cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(textBox4.Text));
                cmd.Parameters.AddWithValue("@PDetailsID", pId);
                cmd.ExecuteNonQuery();

                ProductList.Items.Add(textBox4.Text + " " + item.iName);
            }
            this.comboBox1.Text = string.Empty;
            this.textBox4.Text = string.Empty;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            int oid = OrderId();
            int iid = InvoiceId();
            Customer1 cus = comboBox2.SelectedItem as Customer1;

            string query = "INSERT INTO sales(iDate,orderID, invoiceNo, cusID, iStatus, dDate)";
            query += "VALUES(@iDate, @oID, @iID, @cusID, @iStatus, @dDate)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@iDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@oID", oid);
            cmd.Parameters.AddWithValue("@iID", iid);
            cmd.Parameters.AddWithValue("@cusID", cus.cId);
            cmd.Parameters.AddWithValue("@iStatus", "Order Placed");
            cmd.Parameters.AddWithValue("@dDate", this.dateTimePicker1.Text);
            int affectedRows = cmd.ExecuteNonQuery();
            MessageBox.Show(affectedRows + " rows inserted!");
            FillOSales();
            OverviewDisplay();

            newOrder.Visible = false;
            this.comboBox1.Text = string.Empty;
            this.comboBox2.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.ProductList.Items.Clear();
            this.dateTimePicker1.Value = DateTime.Now;
        }

        private void FillOSales()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            OSales.Rows.Clear();
            SqlCommand query = new SqlCommand("Select * from sales order by iStatus desc", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                OSales.Rows.Add(String.Format("{0:MM/dd/yyyy}", reader.GetValue(0)), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), String.Format("{0:MM/dd/yyyy}", reader.GetValue(5)));
            }
            InvoiceCBX();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            statusUpdate.Visible = true;
            invoice.Text = string.Empty;
            Stats.Text = string.Empty;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            statusUpdate.Visible = false;
        }
        public void InvoiceCBX()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            invoice.Items.Clear();
            SqlCommand query = new SqlCommand("Select invoiceNo from sales where iStatus not in ('Complete', 'Cancelled') order by invoiceNo", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                invoice.Items.Add(reader.GetValue(0));
            }
        }
        public void StatusCBX()
        {
            Stats.Items.Add("In Transit");
            Stats.Items.Add("Complete");
            Stats.Items.Add("Cancelled");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            SqlCommand query = new SqlCommand("Update sales set iStatus = @stats where invoiceNo = @invoice1", con);

            query.Parameters.AddWithValue("@invoice1", invoice.Text);
            query.Parameters.AddWithValue("@stats", Stats.Text);
            query.ExecuteNonQuery();

            if (Stats.Text.Equals("In Transit"))
            {
                SqlCommand query1 = new SqlCommand("With Updater as (SELECT PDetailsID, SUM(Qty)AS Qty FROM (Select PDetailsID, -(Qty) AS Qty from salesDetails where invoiceNo = @i UNION SELECT PDetailsID, Quantity FROM ProductionDetails)updatedTbl GROUP BY PDetailsID)Update ProductionDetails set Quantity = (SELECT Qty FROM Updater WHERE Updater.PDetailsID = ProductionDetails.PDetailsID)", con);
                query1.Parameters.AddWithValue("@i", invoice.Text);
                query1.ExecuteNonQuery();
                FillProductionDetails();
            }
            else if (Stats.Text.Equals("Cancelled"))
            {
                SqlCommand query3 = new SqlCommand("Delete from salesDetails where invoiceNo = @iNID", con);
                query3.Parameters.AddWithValue("@iNID", invoice.Text);
                query3.ExecuteNonQuery();
                invoice.Items.Remove(invoice.SelectedItem);
            } else if (Stats.Text.Equals("Cancelled")){
                // No output here
            } else
            {
                MessageBox.Show("Invalid Input");
            }

            FillOSales();
            FillComplete();
            FillReturnCustomerDetails();
            OverviewDisplay();
            InvoiceReturnCBX();
            IRCBX();
            statusUpdate.Visible = false;
        }
        public void OverviewDisplay()
        {
            SqlConnection con;
            SqlCommand query;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            string cmd = "SELECT COUNT(*) FROM sales WHERE iStatus = ";
            query = new SqlCommand($"{cmd} 'Order Placed'", con);
            OrderPlacedCount.Text = query.ExecuteScalar().ToString();
            query = new SqlCommand($"{cmd} 'In Transit'", con);
            InTransitCount.Text = query.ExecuteScalar().ToString();
            query = new SqlCommand($"{cmd} 'Complete'", con);
            CompletedCount.Text = query.ExecuteScalar().ToString();
            string cmd1 = "SELECT COUNT(*) FROM sales";
            query = new SqlCommand($"{cmd1}", con);
            TotalSalesCount.Text = query.ExecuteScalar().ToString();
            string cmd2 = "SELECT COUNT(*) FROM CContacts";
            query = new SqlCommand($"{cmd2}", con);
            TotalCus.Text = query.ExecuteScalar().ToString();
            string cmd3 = "SELECT COUNT(*) FROM Item";
            query = new SqlCommand($"{cmd3}", con);
            TotalItems.Text = query.ExecuteScalar().ToString();
            string cmd4 = "select SUM(Quantity) from ProductionDetails";
            query = new SqlCommand($"{cmd4}", con);
            stock.Text = query.ExecuteScalar().ToString();
        }
        public void lowStockTB()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            lowStock.Rows.Clear();
            SqlCommand query = new SqlCommand("select top 10 Item.IName, tbl.totalQty from(select top 10 SUM(ProductionDetails.Quantity) AS totalqty, itemID from ProductionDetails group by ProductionDetails.ItemID) tbl inner join Item on Item.ItemID = tbl.ItemID order by tbl.totalqty", con);
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                lowStock.Rows.Add(reader.GetValue(0), reader.GetValue(1));
            }
        } 
        public void FillPaymentReceived()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            PaymentReceived.Rows.Clear();
            SqlCommand query = new SqlCommand("\r\nWITH result AS (SELECT salesDetails.invoiceNo, Item.UnitPrice * salesDetails.Qty AS totalPrice FROM Item INNER JOIN salesDetails ON Item.ItemID = salesDetails.ItemId) SELECT * FROM (SELECT result.invoiceNo,  SUM(totalPrice) AS totalPrice FROM result GROUP BY invoiceNo) totalPriceTbl INNER JOIN (SELECT CContacts.FName, CContacts.LName, sales.iDate, sales.invoiceNo FROM CContacts INNER JOIN sales ON CContacts.CusID = sales.cusID) namesTbl ON totalPriceTbl.invoiceNo = namesTbl.invoiceNo ORDER BY totalPriceTbl.invoiceNo", con);
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                PaymentReceived.Rows.Add(String.Format("{0:MM/dd/yyyy}", reader.GetValue(4)), reader.GetValue(0), reader.GetValue(2) + " " + reader.GetValue(3), string.Format("{0:C}", reader.GetValue(1)));
            }
        }
        public void SelectedSales()
        {
            OSales.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(OnRowHeaderMouseClick);
        }
        public void OnRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int InvoiceID = OSales.CurrentRow.Index + 4001;
            panel14.Visible = true;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            id.Text = "" + InvoiceID;
            SqlCommand query = new SqlCommand("select CContacts.CusID, CContacts.FName, CContacts.Lname from CContacts inner join sales on sales.cusID = CContacts.CusID where invoiceNo = @invoice", con);
            query.Parameters.AddWithValue("@invoice", InvoiceID);
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                label30.Text = reader.GetValue(1) + " " + reader.GetValue(2);
            }
            reader.Close();
            InvoiceTB.Rows.Clear();
            SqlCommand query2 = new SqlCommand("SELECT salesDetails.ItemID, Item.IName, salesDetails.Qty, salesDetails.PDetailsID FROM salesDetails INNER JOIN Item ON salesDetails.ItemID = Item.ItemID WHERE salesDetails.invoiceNo = @iid", con);
            query2.Parameters.AddWithValue("@iid", InvoiceID);
            SqlDataReader reader1 = query2.ExecuteReader();

            while (reader1.Read())
            {
                InvoiceTB.Rows.Add(reader1.GetValue(1), reader1.GetValue(2), reader1.GetValue(3));
            }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            panel14.Visible = false;
        }
        public void FillComplete()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            completeTB.Rows.Clear();
            SqlCommand query = new SqlCommand("Select * from sales where iStatus = 'Complete' ", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                completeTB.Rows.Add(String.Format("{0:MM/dd/yyyy}", reader.GetValue(0)), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), String.Format("{0:MM/dd/yyyy}", reader.GetValue(5)));
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {
            panel15.Visible = true;
        }
        private void FillProductionDetails()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            ProductionT.Rows.Clear();
            SqlCommand query = new SqlCommand("SELECT P.ArrivalDate,P.ProductionID,PD.PDetailsID,I.IName,PD.PStatus,PD.Quantity FROM Production P INNER JOIN ProductionDetails PD ON P.ProductionID = PD.ProductionID INNER JOIN Item I ON PD.ItemID = I.ItemID ORDER BY ProductionID;", con);


            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                ProductionT.Rows.Add(String.Format("{0:MM/dd/yyyy}", reader.GetValue(0)), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5));
            }
            reader.Close();
            con.Close();
        }
        public void PDetailsCBX()
        {
            ArrayList PdetailsList = new ArrayList();
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            SqlCommand query = new SqlCommand("Select * from Item order by IName", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Inventory item = new Inventory
                {
                    iId = Convert.ToInt32(reader.GetValue(0)),
                    iName = reader.GetValue(1).ToString()
                };
                PdetailsList.Add(item);
            }
            comboBox7.DataSource = PdetailsList;
            comboBox7.ValueMember = "iId";
            comboBox7.DisplayMember = "iName";
            comboBox7.SelectedIndex = -1;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Inventory item = comboBox7.SelectedItem as Inventory;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            int prodId = ProductionId();
            int pdid = ProductionDetailsId();
            string query = "INSERT INTO ProductionDetails (PDetailsID, ProductionID,  ItemID, PStatus, Quantity) VALUES (@PDetailsID, @ProductionID, @ItemID, @PStatus, @Quantity)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@PDetailsID", pdid);
            cmd.Parameters.AddWithValue("@ProductionID", prodId);
            cmd.Parameters.AddWithValue("@ItemID", item.iId);
            cmd.Parameters.AddWithValue("@PStatus", "On hand");
            cmd.Parameters.AddWithValue("@Quantity", textBox13.Text);
            int affectedRows = cmd.ExecuteNonQuery();
           

            Product_list2.Items.Add(textBox13.Text + " " + item.iName);
            comboBox7.SelectedIndex = -1;
            textBox13.Text = string.Empty;
        }
        private void button31_Click(object sender, EventArgs e)
        {
            Inventory item = comboBox7.SelectedItem as Inventory;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            int prodId = ProductionId();

            string query = "INSERT INTO Production VALUES (@ProductionID, @ArrivalDate);";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ProductionID", prodId);
            cmd.Parameters.AddWithValue("@ArrivalDate", DateTime.Now);
            cmd.ExecuteNonQuery();

            FillProductionDetails();
            comboBox7.SelectedIndex = -1;
            textBox13.Text = string.Empty;

            Product_list2.Items.Clear();
            panel15.Visible = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            int prodId = ProductionId();

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            string query = "DELETE from ProductionDetails where ProductionID = @ProductionID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ProductionID", prodId);
            cmd.ExecuteNonQuery();

            panel15.Visible = false;
            this.Product_list2.Items.Clear();
            this.comboBox7.SelectedIndex = -1;
            this.textBox13.Text = string.Empty;

        }
        private void FillReturnCustomerDetails()
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            ReturnCustomerT.Rows.Clear();
            SqlCommand query = new SqlCommand("SELECT RID, invoiceNo, ItemID, cusID, Reason, RStatus FROM ReturnCustomer ORDER BY RID", con);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                ReturnCustomerT.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5));
                //ReturnCustomerT.Rows.Add(reader.GetValue(0), reader.GetValue(1), String.Format("{0:MM/dd/yyyy}", reader.GetValue(2)), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7));
            }
            reader.Close();
            con.Close();
            IRCBX();
        }


        private void button38_Click(object sender, EventArgs e)
        {
            panel17.Visible = true;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
        }

        public void ReasonCDX()
        {
            comboBox4.Items.Add("Received Wrong Item");
            comboBox4.Items.Add("Delivery Delay");
            comboBox4.Items.Add("Change of Mind");
        }

        public void ReturnItemCBX()
        {
            ArrayList item1 = new ArrayList();
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            RItemComboBox.Items.Clear();

            // PPPPP Change Query, retrieve ItemID from sales where invoice = comboBox item.
            SqlCommand query = new SqlCommand("Select * from Item", con); 

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Inventory item = new Inventory();
                {
                    item.iId = Convert.ToInt32(reader.GetValue(0));
                    item.iName = reader.GetValue(1).ToString();
                }
                item1.Add(item);
            }
            RItemComboBox.DataSource = item1;
            RItemComboBox.ValueMember = "iId";
            RItemComboBox.DisplayMember = "iName";
            RItemComboBox.SelectedIndex = -1;
        }

        public void IRCBX()
        {
            ArrayList invoiceList = new ArrayList();
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            SqlCommand query = new SqlCommand("SELECT RID from ReturnCustomer where not RStatus = 'Returned' order by RID", con);
           
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                invoiceList.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            con.Close();

            returnIDComboBox.DataSource = invoiceList;
            returnIDComboBox.SelectedIndex = -1;
        }


        public void InvoiceReturnCBX()
        {
            ArrayList invoiceList = new ArrayList();
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            SqlCommand query = new SqlCommand("SELECT invoiceNo FROM sales WHERE iStatus = 'Complete'", con); 

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                invoiceList.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            con.Close();

            comboBox6.DataSource = invoiceList;
            comboBox6.SelectedIndex = -1;
        }


        private void button36_Click(object sender, EventArgs e)
        {
            int invoiceNo = Convert.ToInt32(comboBox6.SelectedItem);
            Inventory item = RItemComboBox.SelectedItem as Inventory;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();

            int rId = ReturnCustomerID();
            int cust = CusId();

            string query = "INSERT INTO ReturnCustomer (RID, invoiceNo, ItemID, cusID, Reason, RStatus)";
            query += "VALUES (@RID, @invoiceNo, @ItemID, @cusID, @Reason, @RStatus)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@RID", rId);
            cmd.Parameters.AddWithValue("@invoiceNo", invoiceNo);
            cmd.Parameters.AddWithValue("@ItemID", item.iId);
            cmd.Parameters.AddWithValue("@CusID", cust);
            cmd.Parameters.AddWithValue("@Reason", comboBox4.SelectedItem);
            cmd.Parameters.AddWithValue("@RStatus", "Requested");

            int affectedRows = cmd.ExecuteNonQuery();
            MessageBox.Show(affectedRows + " rows inserted!");

            // Clear the inputs
            comboBox6.SelectedIndex = -1;
            RItemComboBox.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            con.Close();
            FillReturnCustomerDetails();
        }

        //Search In Table Item
        private void button22_Click(object sender, EventArgs e)
        {
            panel18.Visible = true;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            IItem.Rows.Clear();
            SqlCommand query = new SqlCommand("Select * from Item where IName like @search or ItemID like @search", con);
            query.Parameters.AddWithValue("@search", textBox5.Text);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                IItem.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), string.Format("{0:C}", reader.GetValue(3)));
            }

            this.textBox5.Text = string.Empty;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            FillIItems();
            panel18.Visible = false;
            this.textBox5.Text = string.Empty;
        }

        //Search In Table Inventory Production
        private void button29_Click(object sender, EventArgs e)
        {
            panel16.Visible = true;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            ProductionT.Rows.Clear();

            string sql = @"
            SELECT P.ArrivalDate, P.ProductionID, PD.PDetailsID, I.IName, PD.PStatus, PD.Quantity 
            FROM Production P 
            INNER JOIN ProductionDetails PD ON P.ProductionID = PD.ProductionID 
            INNER JOIN Item I ON PD.ItemID = I.ItemID 
            WHERE PD.PDetailsID LIKE @search 
            OR PD.ProductionID LIKE @search 
            OR I.IName LIKE @search
            ORDER BY P.ProductionID";

            SqlCommand query = new SqlCommand(sql, con);
            query.Parameters.AddWithValue("@search", textBox12.Text);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                ProductionT.Rows.Add(String.Format("{0:MM/dd/yyyy}", reader.GetValue(0)), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5));
            }

            this.textBox12.Text = string.Empty;
        }


        private void button33_Click(object sender, EventArgs e)
        {
            FillProductionDetails();
            panel16.Visible = false;
            this.textBox12.Text = string.Empty;

        }

        // Search In Employee Table
        private void button9_Click(object sender, EventArgs e)
        {
            panel19.Visible = true;


            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            EmpContacts.Rows.Clear();

            SqlCommand query = new SqlCommand("Select * from eContacts where empID like @search or lName like @search or fName like @search", con);
            query.Parameters.AddWithValue("@search", textBox14.Text);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                EmpContacts.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
            }


            this.textBox14.Text = string.Empty;

        }

        private void button34_Click(object sender, EventArgs e)
        {
            FillEmpContacts();
            panel19.Visible = false;
            this.textBox14.Text = string.Empty;
        }

        //Search In Customer Table
        private void button18_Click(object sender, EventArgs e)
        {
            panel20.Visible = true;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            CusContacts.Rows.Clear();

            SqlCommand query = new SqlCommand("Select * from CContacts where CusID like @search or  Lname like @search or FName like @search", con);
            query.Parameters.AddWithValue("@search", textBox15.Text);


            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                CusContacts.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
            }

            this.textBox15.Text = string.Empty;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            FillCusContacts();
            panel20.Visible = false;
            this.textBox15.Text = string.Empty;
        }


        //Search In SalesOrder
        private void button12_Click_1(object sender, EventArgs e)
        {
            panel21.Visible = true;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            OSales.Rows.Clear();

            SqlCommand query = new SqlCommand("Select * from Sales where orderID like @search or  invoiceNo like @search or cusID like @search", con);
            query.Parameters.AddWithValue("@search", textBox16.Text);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                OSales.Rows.Add(String.Format("{0:MM/dd/yyyy}", reader.GetValue(0)), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), String.Format("{0:MM/dd/yyyy}", reader.GetValue(5)));
            }

            this.textBox16.Text = string.Empty;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            FillOSales();
            panel21.Visible = false;
            this.textBox16.Text = string.Empty;
        }

        //Search In ReturnCustomer
        private void button35_Click(object sender, EventArgs e)
        {
            panel22.Visible = true;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            ReturnCustomerT.Rows.Clear();

            SqlCommand query = new SqlCommand("Select * from ReturnCustomer where RID like @search or  invoiceNo like @search or cusID like @search or ItemID like @search", con);
            query.Parameters.AddWithValue("@search", textBox17.Text);

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                ReturnCustomerT.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5));
            }

            this.textBox17.Text = string.Empty;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            FillReturnCustomerDetails();
            panel22.Visible = false;
            this.textBox17.Text = string.Empty;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            panel24.Visible = true;

            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            PaymentReceived.Rows.Clear();

            string sql = @"
            WITH result AS (
                SELECT salesDetails.invoiceNo, Item.UnitPrice * salesDetails.Qty AS totalPrice 
                FROM Item 
                INNER JOIN salesDetails ON Item.ItemID = salesDetails.ItemID
            ), 
            totalPriceTbl AS (
                SELECT invoiceNo, SUM(totalPrice) AS totalPrice 
                FROM result 
                GROUP BY invoiceNo
            ),
            namesTbl AS (
                SELECT CContacts.FName, CContacts.LName, sales.invoiceNo, sales.iStatus, sales.orderID, sales.cusID 
                FROM CContacts 
                INNER JOIN sales ON CContacts.CusID = sales.cusID
            )
            SELECT totalPriceTbl.invoiceNo, totalPriceTbl.totalPrice, namesTbl.FName, namesTbl.LName 
            FROM totalPriceTbl 
            INNER JOIN namesTbl ON totalPriceTbl.invoiceNo = namesTbl.invoiceNo
            WHERE namesTbl.iStatus = 'Complete' 
            OR namesTbl.orderID LIKE @search 
            OR namesTbl.invoiceNo LIKE @search 
            OR namesTbl.cusID LIKE @search
            ORDER BY totalPriceTbl.invoiceNo";

            SqlCommand query = new SqlCommand(sql, con);
            query.Parameters.AddWithValue("@search", textBox19.Text);

            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                PaymentReceived.Rows.Add(
                    reader.GetValue(0),
                    reader.GetValue(2) + " " + reader.GetValue(3),
                    string.Format("{0:C}", reader.GetValue(1))
                );
            }

            this.textBox19.Text = string.Empty;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            FillPaymentReceived();
            panel24.Visible = false;
            this.textBox19.Text = string.Empty;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void a()
        {
            Inventory itemm;
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID=admin;Password=1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            ArrayList completedList = new ArrayList();
            SqlCommand query = new SqlCommand("SELECT Item.IName, Item.ItemID FROM Item INNER JOIN (SELECT ItemID FROM salesDetails INNER JOIN sales ON sales.invoiceNo = salesDetails.invoiceNo WHERE sales.invoiceNo = @invoiceNo) AS aaa ON Item.ItemID = aaa.ItemID", con);
            query.Parameters.AddWithValue("@invoiceNo", comboBox6.Text);
            query.ExecuteNonQuery();
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                itemm = new Inventory();
                itemm.iId = Convert.ToInt32(reader.GetValue(1));
                itemm.iName = reader.GetValue(0).ToString();
                completedList.Add(itemm);
            }
            RItemComboBox.DataSource = completedList;
            RItemComboBox.ValueMember = "iID";
            RItemComboBox.DisplayMember = "iName";
            RItemComboBox.SelectedIndex = -1;
            OverviewDisplay();
        }
        public void Status2CBX()
        {
            returnStatsComboBox.Items.Add("Return in Progress");
            returnStatsComboBox.Items.Add("Returned");
        }

        private void button47_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string config = @"Data Source=.\SQLEXPRESS;Initial Catalog=FPROJECT;User ID = admin; Password =1234;Integrated Security=True;";
            con = new SqlConnection(config);
            con.Open();
            SqlCommand query = new SqlCommand("Update ReturnCustomer set RStatus = @stats where RID = @RID", con);

            query.Parameters.AddWithValue("@RID", returnIDComboBox.Text);
            query.Parameters.AddWithValue("@stats", returnStatsComboBox.Text);
            query.ExecuteNonQuery();
            
            if (returnStatsComboBox.Text.Equals("Return in Progress"))
            {
                
            }
            else if (returnStatsComboBox.Text.Equals("Returned"))
            {
                SqlCommand query1 = new SqlCommand("UPDATE ProductionDetails SET Quantity = ((SELECT Quantity FROM ProductionDetails WHERE PDetailsID = (SELECT PDetailsID FROM salesDetails WHERE invoiceNo = (SELECT invoiceNo FROM ReturnCustomer WHERE RID = @RID) AND ItemID = (SELECT ItemID FROM ReturnCustomer WHERE RID = @RID))) + 1) WHERE PDetailsID = (SELECT PDetailsID FROM salesDetails WHERE invoiceNo = (SELECT invoiceNo FROM ReturnCustomer WHERE RID = @RID) AND ItemID = (SELECT ItemID FROM ReturnCustomer WHERE RID = @RID))", con);
                query1.Parameters.AddWithValue("@RID", returnIDComboBox.Text);
                query1.ExecuteNonQuery();
                lowStockTB();
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
            FillReturnCustomerDetails();
            this.returnIDComboBox.Text = string.Empty;
            this.returnStatsComboBox.Text = string.Empty;

            

        }
        private void button43_Click(object sender, EventArgs e)
        {
            //panel17.Visible = false;
            RSelectButton.Visible = false;
            button37.Visible = false;

            selectRItemPanel.Visible = true;
            a();
        }

        private void button43_Click_1(object sender, EventArgs e)
        {
            this.comboBox6.Text = string.Empty;
            this.RItemComboBox.Text = string.Empty;
            this.comboBox4.Text = string.Empty;
            selectRItemPanel.Visible = false;
            RSelectButton.Visible = true;
            button37.Visible = true;
        }

        private void RSubmitButton_Click(object sender, EventArgs e)
        {
            selectRItemPanel.Visible = false;
            panel17.Visible = false;
            RSelectButton.Visible = true;
            button37.Visible = true;
            this.comboBox6.Text = string.Empty;
            this.RItemComboBox.Text = string.Empty;
            this.comboBox4.Text = string.Empty;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            panel8.Visible = true;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
