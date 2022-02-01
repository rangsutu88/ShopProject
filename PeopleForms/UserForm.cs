using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using ShopProject.Classes.Products;
using ShopProject.DatabaseConnections;

namespace ShopProject.PeopleForms
{
    public partial class UserForm : Form
    {
        SqlConnection connection = OpenDatabaseConnection.GetConnection();

        SqlCommand TheCommand;
        SqlDataAdapter sqladapter;
        DataSet ds = new DataSet();
        DialogResult dialogresult;
        Classes.People.User user = new Classes.People.User();
        Cars p = new Cars();

        string TheCommandString;
        decimal z, u;
        int TotalProductsBought = 0, MaxOrderId;
        float TotalProductsPrice = 0;
        bool modify = false, removemoney = true, FirstBuy = true;
        
        public UserForm(int i)
        {
            InitializeComponent();
            if (i == 1) ID1ViewEverything.Visible = true;
            else ID1ViewEverything.Visible = false;
            user.ID = i;
        }

        private void BuyCarButton_Click(object sender, EventArgs e)
        {
            BuyPanel.Visible = true;
        }


        private void BuyTheCar_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                TheCommandString = "Select BalanceInDollars from [dbo].[User] where ID=@id";
                TheCommand = new SqlCommand(TheCommandString, connection);
                TheCommand.Parameters.AddWithValue("@id", user.ID);
                user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());

                int TotalCarsprices = Convert.ToInt32(TotalPrice.Text);

                if (TotalCarsprices <= user.Balance)
                {
                    TheCommandString = "Select Numberofcars from [dbo].[Products] where CarID=@id";
                    TheCommand = new SqlCommand(TheCommandString, connection);
                    TheCommand.Parameters.AddWithValue("@id", Convert.ToInt32(ProductIDToBuy.SelectedItem));
                    int NumberOfCarsAvailable = Convert.ToInt32(TheCommand.ExecuteScalar());

                    int NumberOfCarToBuy = Convert.ToInt32(BoughtNumericUpDown.Value);

                    if (NumberOfCarsAvailable >= NumberOfCarToBuy)
                    {
                        TheCommandString = "Update [dbo].[User] set BalanceInDollars = @removed where ID=@id";
                        TheCommand = new SqlCommand(TheCommandString, connection);
                        int a = user.Balance - TotalCarsprices;
                        TheCommand.Parameters.AddWithValue("@removed", a);
                        TheCommand.Parameters.AddWithValue("@id", user.ID);
                        TheCommand.ExecuteNonQuery();

                        TotalProductsBought = TotalProductsBought + NumberOfCarToBuy;
                        TotalProductsPrice = TotalProductsPrice + TotalCarsprices;

                        if (FirstBuy == true)
                        {
                            TheCommandString = "Insert Into [dbo].[Orders] " + "(CustomerID, BoughtDate, [Total number of products bought], " +
                                "[Total Price])" + "Values(@a, @b, @c, @d)";

                            TheCommand = new SqlCommand(TheCommandString, connection);
                            TheCommand.Parameters.AddWithValue("@a", user.ID);
                            TheCommand.Parameters.AddWithValue("@b", DateTime.Now);
                            TheCommand.Parameters.AddWithValue("@c", TotalProductsBought);
                            TheCommand.Parameters.AddWithValue("@d", TotalProductsPrice);
                            TheCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            TheCommandString = "Select Max(OrderID) from [dbo].[Orders]";
                            TheCommand = new SqlCommand(TheCommandString, connection);
                            MaxOrderId = Convert.ToInt32(TheCommand.ExecuteScalar());

                            TheCommandString = "Update [dbo].[Orders] SET [Total number of products bought]=@a, [Total Price]=@b" +
                            " where OrderID=@id";
                            TheCommand = new SqlCommand(TheCommandString, connection);
                            TheCommand.Parameters.AddWithValue("@a", TotalProductsBought);
                            TheCommand.Parameters.AddWithValue("@b", TotalProductsPrice);
                            TheCommand.Parameters.AddWithValue("@id", MaxOrderId);
                            TheCommand.ExecuteNonQuery();
                        }

                        TheCommandString = "Select Max(OrderID) from [dbo].[Orders]";
                        TheCommand = new SqlCommand(TheCommandString, connection);
                        MaxOrderId = Convert.ToInt32(TheCommand.ExecuteScalar());

                        TheCommandString = "Insert into [dbo].[Order Details] " + " (OrderID, ProductID, Quantity, Price)" + "Values(@OrderID, @a, @Quantity, @Price)";
                        TheCommand = new SqlCommand(TheCommandString, connection);
                        TheCommand.Parameters.AddWithValue("@OrderID", MaxOrderId);
                        TheCommand.Parameters.AddWithValue("@a", Convert.ToInt32(ProductIDToBuy.SelectedItem));
                        TheCommand.Parameters.AddWithValue("@Quantity", Convert.ToInt32(BoughtNumericUpDown.Value));
                        TheCommand.Parameters.AddWithValue("@Price", Convert.ToInt32(TotalPrice.Text));
                        TheCommand.ExecuteNonQuery();

                        TheCommandString = "Update [dbo].[Products] set Numberofcars=@remaining where CarID=@id";
                        TheCommand = new SqlCommand(TheCommandString, connection);
                        int remaining = NumberOfCarsAvailable - Convert.ToInt32(BoughtNumericUpDown.Value);
                        TheCommand.Parameters.AddWithValue("@remaining", remaining);
                        TheCommand.Parameters.AddWithValue("@id", Convert.ToInt32(ProductIDToBuy.SelectedItem));
                        TheCommand.ExecuteNonQuery();

                        MessageBox.Show("Your purschase has been completed");

                        dialogresult = MessageBox.Show("Do you want to buy something else?", "Buy another product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogresult == DialogResult.Yes)
                        {
                            MessageBox.Show("Choose what you want to buy");
                        }
                    }
                    else { MessageBox.Show("Sorry the number of available cars is less than that you want"); }
                }
                else { MessageBox.Show("you don't have enough money in your account"); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
            finally
            {
                FirstBuy = false;
                connection.Close();
            }
        }

        private void MostExpensiveCarView_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                TheCommandString = "Select Max(UnitPrice) from [dbo].[Products];";
                this.TheCommand = new SqlCommand(TheCommandString, connection);
                p.unitPrice = Convert.ToInt32(this.TheCommand.ExecuteScalar());

                DataGridView.Visible = true;
                TheCommandString = "SELECT CarID, Name, Engine, [Top speed], [Acceleration 0-60mph], [Capacity of the motor]," +
                        " Numberofcars, UnitPrice" + " FROM [dbo].[Products] " + "WHERE UnitPrice=@price";

                TheCommand = new SqlCommand(TheCommandString, connection);
                TheCommand.Parameters.AddWithValue("@price", p.unitPrice);
                sqladapter = new SqlDataAdapter(TheCommand);
                user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());
                ds = new DataSet();
                sqladapter.Fill(ds);
                DataGridView.DataSource = ds.Tables[0];
            }

            catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
            finally { connection.Close(); }
        }

        private void ViewCarOfIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idd = Convert.ToInt32(ViewCarOfIDComboBox.SelectedItem);
                p = Cars.Getproduct(idd);
                MessageBox.Show("Name: " + p.productName + "engine: " + p.engine + "  topSpeed: " + p.topSpeed + "  Acceleration: " + p.acceleration + "capacityOfTheMotor:  " + 
                    p.capacityOfTheMotor + "  numberOfCarsAvailable: " + p.numberOfCarsAvailable + "  unitPrice: " + p.unitPrice);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ProductIDToBuy_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void BoughtNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                Cars p = new Cars();
                TheCommandString = "Select UnitPrice from [dbo].[Products] where CarID=@id";
                TheCommand = new SqlCommand(TheCommandString, connection);
                TheCommand.Parameters.AddWithValue("@id", Convert.ToInt32(ProductIDToBuy.SelectedItem));
                p.unitPrice = Convert.ToInt32(TheCommand.ExecuteScalar());
                int y = Convert.ToInt32(BoughtNumericUpDown.Value);
                int z = y * (p.unitPrice);
                TotalPrice.Text = Convert.ToString(z);
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
            finally { connection.Close(); }
        }

        private void AccountPropertiesLabel_Click(object sender, EventArgs e)
        {
            try
            {
                ChooseWhatToDoComboBox.Visible = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ChooseWhatToDoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    if (ChooseWhatToDoComboBox.Text == "Add money")
                    {
                        modify = true;
                        tableLayoutPanel1.Visible = true;
                        numericUpDown2.Visible = true;
                        CurrentBalanceTextBox.Visible = true;
                        NewBalanceTextBox.Visible = true;
                        ModifyBalanceButton.Visible = true;
                        numericUpDown2.Visible = true;

                        TheCommandString = "Select BalanceInDollars from [dbo].[User] where ID=@id";
                        TheCommand = new SqlCommand(TheCommandString, connection);
                        TheCommand.Parameters.AddWithValue("@id", user.ID);
                        user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());
                        z = Convert.ToInt32(numericUpDown2.Value);
                        u = user.Balance + z;
                        CurrentBalanceTextBox.Text = Convert.ToString(user.Balance);
                        NewBalanceTextBox.Text = Convert.ToString(u);
                    }

                    if (ChooseWhatToDoComboBox.Text == "Remove money")
                    {
                        modify = false;
                        tableLayoutPanel1.Visible = true;
                        numericUpDown2.Visible = true;
                        CurrentBalanceTextBox.Visible = true;
                        NewBalanceTextBox.Visible = true;
                        ModifyBalanceButton.Visible = true;
                        numericUpDown2.Visible = true;

                        TheCommandString = "Select BalanceInDollars from [dbo].[User] where ID=@id";
                        TheCommand = new SqlCommand(TheCommandString, connection);
                        TheCommand.Parameters.AddWithValue("@id", user.ID);
                        user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());
                        z = Convert.ToDecimal(numericUpDown2.Value);
                        u = user.Balance - z;
                        CurrentBalanceTextBox.Text = Convert.ToString(user.Balance);
                        NewBalanceTextBox.Text = Convert.ToString(u);
                    }

                    if (ChooseWhatToDoComboBox.Text == "Balance")
                    {
                        tableLayoutPanel1.Visible = false;
                        numericUpDown2.Visible = false;
                        CurrentBalanceTextBox.Visible = false;
                        NewBalanceTextBox.Visible = false;
                        ModifyBalanceButton.Visible = false;
                        numericUpDown2.Visible = false;

                        TheCommandString = "Select BalanceInDollars from [dbo].[User] where ID=@id";
                        TheCommand = new SqlCommand(TheCommandString, connection);
                        TheCommand.Parameters.AddWithValue("@id", user.ID);
                        user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());
                        MessageBox.Show("You have " + user.Balance + " $ in your account");
                    }
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally { connection.Close(); }
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (modify)
                {
                    user.Balance = Convert.ToInt32(CurrentBalanceTextBox.Text);
                    z = Convert.ToDecimal(numericUpDown2.Value);
                    u = user.Balance + z;
                    NewBalanceTextBox.Text = Convert.ToString(u);
                }
                else
                {
                    user.Balance = Convert.ToInt32(CurrentBalanceTextBox.Text);
                    z = Convert.ToDecimal(numericUpDown2.Value);
                    u = user.Balance - z;
                    NewBalanceTextBox.Text = Convert.ToString(u);
                }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
        }
        private void ModifyBalanceButton_Click(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    if (modify)
                    {
                        int t = Convert.ToInt32(numericUpDown2.Value);
                        TheCommandString = "Update [dbo].[User] set BalanceInDollars=@added where ID=@id";
                        TheCommand = new SqlCommand(TheCommandString, connection);
                        TheCommand.Parameters.AddWithValue("@added", t + user.Balance);
                        TheCommand.Parameters.AddWithValue("@id", user.ID);
                        TheCommand.ExecuteNonQuery();
                        user.Balance = t + user.Balance;
                    }
                    else
                    {
                        int t = Convert.ToInt32(numericUpDown2.Value);
                        if ((user.Balance - t) >= 0)
                        {
                            TheCommandString = "Update [dbo].[User] set BalanceInDollars=@added where ID=@id";
                            TheCommand = new SqlCommand(TheCommandString, connection);
                            TheCommand.Parameters.AddWithValue("@added", user.Balance - t);
                            TheCommand.Parameters.AddWithValue("@id", user.ID);
                            TheCommand.ExecuteNonQuery();
                            user.Balance = user.Balance - t;
                            removemoney = true;
                        }
                        else
                        {
                            MessageBox.Show("You don't have that amount of money to remove it");
                            removemoney = false;
                        }
                    }
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally
                {
                    if (modify)
                    {
                        CurrentBalanceTextBox.Text = Convert.ToString(user.Balance);
                        decimal z = Convert.ToDecimal(numericUpDown2.Value) + user.Balance;
                        NewBalanceTextBox.Text = Convert.ToString(z);
                    }
                    else
                    {
                        CurrentBalanceTextBox.Text = Convert.ToString(user.Balance);
                        decimal z = user.Balance - Convert.ToDecimal(numericUpDown2.Value);
                        NewBalanceTextBox.Text = Convert.ToString(z);
                    }
                    if (numericUpDown2.Value == 0) { MessageBox.Show("No Money added"); }
                    else
                    {
                        if (modify) { MessageBox.Show("Money added successfully"); }
                        else if (removemoney == true) { MessageBox.Show("Money removed successfully"); }
                    }
                    connection.Close();
                }
            }
        }
        private void SeeAllUsersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    DataGridView.Visible = true;
                    TheCommandString = "select ID, Firstname, LastName, Passcode, Age, BalanceInDollars, Country, City" +
                        " from [dbo].[User] INNER JOIN [dbo].[Address] ON [dbo].[User].AddressID = [dbo].[Address].AddressID ";

                    TheCommand = new SqlCommand(TheCommandString, connection);
                    sqladapter = new SqlDataAdapter(TheCommand);

                    user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());

                    ds = new DataSet();

                    sqladapter.Fill(ds);
                    DataGridView.DataSource = ds.Tables[0];
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally { connection.Close(); }
            }
        }
        private void TopExpensiveCarsButton_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    DataGridView.Visible = true;
                    TheCommandString = "Select Name, [Top speed], [Acceleration 0-60mph], UnitPrice from[dbo].[Products] ORDER BY UnitPrice DESC";
                    TheCommand = new SqlCommand(TheCommandString, connection);
                    sqladapter = new SqlDataAdapter(TheCommand);
                    TheCommand.ExecuteNonQuery();
                    ds = new DataSet();
                    sqladapter.Fill(ds);
                    DataGridView.DataSource = ds.Tables[0];
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally { connection.Close(); }
            }
        }

        private void SeeAllOrdersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    DataGridView.Visible = true;
                    TheCommandString = "Select O.OrderID, O.CustomerID, O.BoughtDate, O.[Total number of products bought], " +
                        " O.[Total Price] from [dbo].[Orders] O INNER JOIN [Order Details] D ON O.OrderID = D.OrderID " +
                        "INNER JOIN [Products] P ON D.ProductID = P.CarID ";

                    TheCommand = new SqlCommand(TheCommandString, connection);
                    sqladapter = new SqlDataAdapter(TheCommand);

                    user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());

                    ds = new DataSet();

                    sqladapter.Fill(ds);
                    DataGridView.DataSource = ds.Tables[0];
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally { connection.Close(); }
            }
        }

        private void ReturnHighestBalancestudent_CheckedChanged(object sender, EventArgs e)
        {
            Classes.People.User u = Classes.People.User.GetHigherbalance(connection);
            MessageBox.Show("FirstName: " + u.Firstname + "LastName: " + u.Lastname + "  Age: " + u.Age);
        }

        private void DeleteCarButton_Click(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    int i = Convert.ToInt32(DeleteCarID.Value);
                    TheCommandString = "Delete from [dbo].[Products]  where CarID=@id";
                    TheCommand = new SqlCommand(TheCommandString, connection);
                    TheCommand.Parameters.AddWithValue("@id", i);
                    TheCommand.ExecuteNonQuery();
                    MessageBox.Show("Car deleted");
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally { connection.Close(); }
            }
        }

        private void DisplayEverythingButton_Click(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    DataGridView.Visible = true;
                    TheCommandString = "Select * from [dbo].[Orders] INNER JOIN [dbo].[Order Details] ON " +
                        "[dbo].[Orders].OrderID = [dbo].[Order Details].OrderID INNER JOIN [dbo].[Products] ON " +
                        "[dbo].[Order Details].ProductID = [dbo].[Products].CarID";

                    TheCommand = new SqlCommand(TheCommandString, connection);
                    sqladapter = new SqlDataAdapter(TheCommand);
                    user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());
                    ds = new DataSet();
                    sqladapter.Fill(ds);
                    DataGridView.DataSource = ds.Tables[0];
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally { connection.Close(); }
            }
        }

        private void SeeCarsButton_Click(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    DataGridView.Visible = true;
                    TheCommandString = "Select * from [dbo].[Products]";

                    TheCommand = new SqlCommand(TheCommandString, connection);
                    sqladapter = new SqlDataAdapter(TheCommand);

                    user.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());

                    ds = new DataSet();
                    sqladapter.Fill(ds);
                    DataGridView.DataSource = ds.Tables[0];
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally { connection.Close(); }
            }
        }
        private void ViewAllOrdersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                using (LINQToSQLClassDataContext db = new LINQToSQLClassDataContext())
                {
                    foreach (Order o in db.Orders) { s = s + o.BoughtDate.ToString() + "\n"; }
                }
                MessageBox.Show(s);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void InsertProductRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Product a = new Product();
                a.Name = "Car153"; a.Engine = "Petrol"; a.Color = "red"; a.Number_of_cylinders = 4; a.Distance_covered = 100; a.Charging_time = 5;
                a.Top_speed = 220; a.Acceleration_0_60mph = 4; a.Seating_Capacity = 4; a.Capacity_of_the_motor = "4"; a.Numberofcars = 45; a.UnitPrice = 1300;
                using (LINQToSQLClassDataContext db = new LINQToSQLClassDataContext())
                {
                    db.Products.InsertOnSubmit(a);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GetProductsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string s;
                using (LINQToSQLClassDataContext db = new LINQToSQLClassDataContext())
                {
                    //DatabaseConnections.Product p = db.Products.FirstOrDefault();
                    Product p = db.Products.FirstOrDefault(x => x.Name.Equals("18i"));
                    s = "Name: " + p.Name + "\nEngine: " + p.Engine + "\nTop speed: " + p.Top_speed + "\nAcceleration: " + p.Acceleration_0_60mph;
                }
                MessageBox.Show(s);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UpdateProductRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                using (LINQToSQLClassDataContext db = new LINQToSQLClassDataContext())
                {
                    Product p = db.Products.FirstOrDefault(x => x.Name.Equals("Car153"));
                    p.Name = "Car200";
                    db.SubmitChanges();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteCar153RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                using (LINQToSQLClassDataContext db = new LINQToSQLClassDataContext())
                {
                    Product p = db.Products.FirstOrDefault(x => x.Name.Equals("Car153"));
                    db.Products.DeleteOnSubmit(p);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BuyThisCarButton_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewCarID_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
        }
        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                connection.Open();
                TheCommandString = "update [dbo].[Orders] set [Total number of products bought]=@a Where OrderID=@CurrentOrderID";
                TheCommand = new SqlCommand(TheCommandString, connection);
                TheCommand.Parameters.AddWithValue("@a", TotalProductsBought);
                TheCommand.Parameters.AddWithValue("@CurrentOrderID", MaxOrderId);
                TheCommand.ExecuteNonQuery();

                TheCommandString = "Update [dbo].[Orders] set [Total Price]=@b where OrderID=@CurrentOrderID";
                TheCommand = new SqlCommand(TheCommandString, connection);
                TheCommand.Parameters.AddWithValue("@b", TotalProductsPrice);
                TheCommand.Parameters.AddWithValue("@CurrentOrderID", MaxOrderId);
                TheCommand.ExecuteNonQuery();
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
            finally
            {
                FirstBuy = true;
                connection.Close();
            }
        }
    }
}