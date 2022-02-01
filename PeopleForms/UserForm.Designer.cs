namespace ShopProject.PeopleForms
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.MostExpensiveCarView = new System.Windows.Forms.Button();
            this.BuyTheCar = new System.Windows.Forms.Button();
            this.BuyCarButton = new System.Windows.Forms.Button();
            this.SeeCarsButton = new System.Windows.Forms.Button();
            this.BuyPanel = new System.Windows.Forms.Panel();
            this.TotalPrice = new System.Windows.Forms.TextBox();
            this.BoughtNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProductIDToBuy = new System.Windows.Forms.ComboBox();
            this.ViewCarOfIDComboBox = new System.Windows.Forms.ComboBox();
            this.ViewCarID = new System.Windows.Forms.TextBox();
            this.TotalPriceTextbox = new System.Windows.Forms.TextBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.BuyThisCarButton = new System.Windows.Forms.TextBox();
            this.AccountPropertiesLabel = new System.Windows.Forms.Button();
            this.ChooseWhatToDoComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CurrentBalanceLabel = new System.Windows.Forms.Label();
            this.NewBalanceLabel = new System.Windows.Forms.Label();
            this.AddMoneyLabel = new System.Windows.Forms.Label();
            this.NewBalanceTextBox = new System.Windows.Forms.TextBox();
            this.CurrentBalanceTextBox = new System.Windows.Forms.TextBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.ModifyBalanceButton = new System.Windows.Forms.Button();
            this.ID1ViewEverything = new System.Windows.Forms.Panel();
            this.DeleteCar153RadioButton = new System.Windows.Forms.RadioButton();
            this.UpdateProductRadioButton = new System.Windows.Forms.RadioButton();
            this.GetProductsRadioButton = new System.Windows.Forms.RadioButton();
            this.InsertProductRadioButton = new System.Windows.Forms.RadioButton();
            this.ViewAllOrdersRadioButton = new System.Windows.Forms.RadioButton();
            this.DisplayEverythingButton = new System.Windows.Forms.Button();
            this.DeleteCarButton = new System.Windows.Forms.Button();
            this.DeleteCarID = new System.Windows.Forms.NumericUpDown();
            this.DeleteCar = new System.Windows.Forms.TextBox();
            this.ReturnHighestBalancestudent = new System.Windows.Forms.RadioButton();
            this.SeeAllOrdersRadioButton = new System.Windows.Forms.RadioButton();
            this.TopExpensiveCarsButton = new System.Windows.Forms.RadioButton();
            this.SeeAllUsersRadioButton = new System.Windows.Forms.RadioButton();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.BuyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoughtNumericUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.ID1ViewEverything.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteCarID)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(597, 69);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 51;
            this.DataGridView.RowTemplate.Height = 24;
            this.DataGridView.Size = new System.Drawing.Size(752, 375);
            this.DataGridView.TabIndex = 2;
            this.DataGridView.Visible = false;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            // 
            // MostExpensiveCarView
            // 
            this.MostExpensiveCarView.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MostExpensiveCarView.ForeColor = System.Drawing.Color.CadetBlue;
            this.MostExpensiveCarView.Location = new System.Drawing.Point(469, 14);
            this.MostExpensiveCarView.Name = "MostExpensiveCarView";
            this.MostExpensiveCarView.Size = new System.Drawing.Size(264, 23);
            this.MostExpensiveCarView.TabIndex = 7;
            this.MostExpensiveCarView.Text = "View the most expensive car";
            this.MostExpensiveCarView.UseVisualStyleBackColor = false;
            this.MostExpensiveCarView.Click += new System.EventHandler(this.MostExpensiveCarView_Click);
            // 
            // BuyTheCar
            // 
            this.BuyTheCar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BuyTheCar.ForeColor = System.Drawing.Color.CadetBlue;
            this.BuyTheCar.Location = new System.Drawing.Point(272, 91);
            this.BuyTheCar.Name = "BuyTheCar";
            this.BuyTheCar.Size = new System.Drawing.Size(122, 38);
            this.BuyTheCar.TabIndex = 6;
            this.BuyTheCar.Text = "Buy the car";
            this.BuyTheCar.UseVisualStyleBackColor = false;
            this.BuyTheCar.Click += new System.EventHandler(this.BuyTheCar_Click);
            // 
            // BuyCarButton
            // 
            this.BuyCarButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BuyCarButton.ForeColor = System.Drawing.Color.CadetBlue;
            this.BuyCarButton.Location = new System.Drawing.Point(869, 16);
            this.BuyCarButton.Name = "BuyCarButton";
            this.BuyCarButton.Size = new System.Drawing.Size(125, 47);
            this.BuyCarButton.TabIndex = 1;
            this.BuyCarButton.Text = "Buy a car";
            this.BuyCarButton.UseVisualStyleBackColor = false;
            this.BuyCarButton.Click += new System.EventHandler(this.BuyCarButton_Click);
            // 
            // SeeCarsButton
            // 
            this.SeeCarsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SeeCarsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SeeCarsButton.ForeColor = System.Drawing.Color.CadetBlue;
            this.SeeCarsButton.Location = new System.Drawing.Point(272, 16);
            this.SeeCarsButton.Name = "SeeCarsButton";
            this.SeeCarsButton.Size = new System.Drawing.Size(122, 23);
            this.SeeCarsButton.TabIndex = 3;
            this.SeeCarsButton.Text = "See all cars";
            this.SeeCarsButton.UseVisualStyleBackColor = false;
            this.SeeCarsButton.Click += new System.EventHandler(this.SeeCarsButton_Click);
            // 
            // BuyPanel
            // 
            this.BuyPanel.Controls.Add(this.TotalPrice);
            this.BuyPanel.Controls.Add(this.BoughtNumericUpDown);
            this.BuyPanel.Controls.Add(this.ProductIDToBuy);
            this.BuyPanel.Controls.Add(this.ViewCarOfIDComboBox);
            this.BuyPanel.Controls.Add(this.ViewCarID);
            this.BuyPanel.Controls.Add(this.TotalPriceTextbox);
            this.BuyPanel.Controls.Add(this.QuantityTextBox);
            this.BuyPanel.Controls.Add(this.BuyThisCarButton);
            this.BuyPanel.Controls.Add(this.SeeCarsButton);
            this.BuyPanel.Controls.Add(this.BuyTheCar);
            this.BuyPanel.Controls.Add(this.MostExpensiveCarView);
            this.BuyPanel.Location = new System.Drawing.Point(597, 474);
            this.BuyPanel.Name = "BuyPanel";
            this.BuyPanel.Size = new System.Drawing.Size(752, 142);
            this.BuyPanel.TabIndex = 7;
            this.BuyPanel.Visible = false;
            // 
            // TotalPrice
            // 
            this.TotalPrice.Location = new System.Drawing.Point(130, 107);
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Size = new System.Drawing.Size(100, 22);
            this.TotalPrice.TabIndex = 5;
            // 
            // BoughtNumericUpDown
            // 
            this.BoughtNumericUpDown.Location = new System.Drawing.Point(130, 65);
            this.BoughtNumericUpDown.Name = "BoughtNumericUpDown";
            this.BoughtNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.BoughtNumericUpDown.TabIndex = 4;
            this.BoughtNumericUpDown.ValueChanged += new System.EventHandler(this.BoughtNumericUpDown_ValueChanged);
            // 
            // ProductIDToBuy
            // 
            this.ProductIDToBuy.FormattingEnabled = true;
            this.ProductIDToBuy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.ProductIDToBuy.Location = new System.Drawing.Point(129, 15);
            this.ProductIDToBuy.Name = "ProductIDToBuy";
            this.ProductIDToBuy.Size = new System.Drawing.Size(121, 24);
            this.ProductIDToBuy.TabIndex = 2;
            this.ProductIDToBuy.SelectedIndexChanged += new System.EventHandler(this.ProductIDToBuy_SelectedIndexChanged);
            // 
            // ViewCarOfIDComboBox
            // 
            this.ViewCarOfIDComboBox.FormattingEnabled = true;
            this.ViewCarOfIDComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.ViewCarOfIDComboBox.Location = new System.Drawing.Point(602, 99);
            this.ViewCarOfIDComboBox.Name = "ViewCarOfIDComboBox";
            this.ViewCarOfIDComboBox.Size = new System.Drawing.Size(121, 24);
            this.ViewCarOfIDComboBox.TabIndex = 8;
            this.ViewCarOfIDComboBox.SelectedIndexChanged += new System.EventHandler(this.ViewCarOfIDComboBox_SelectedIndexChanged);
            // 
            // ViewCarID
            // 
            this.ViewCarID.Location = new System.Drawing.Point(469, 101);
            this.ViewCarID.Name = "ViewCarID";
            this.ViewCarID.Size = new System.Drawing.Size(100, 22);
            this.ViewCarID.TabIndex = 11;
            this.ViewCarID.Text = "View Car of ID:";
            this.ViewCarID.TextChanged += new System.EventHandler(this.ViewCarID_TextChanged);
            // 
            // TotalPriceTextbox
            // 
            this.TotalPriceTextbox.Location = new System.Drawing.Point(16, 109);
            this.TotalPriceTextbox.Name = "TotalPriceTextbox";
            this.TotalPriceTextbox.Size = new System.Drawing.Size(100, 22);
            this.TotalPriceTextbox.TabIndex = 8;
            this.TotalPriceTextbox.Text = "TotalPrice";
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(16, 64);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(100, 22);
            this.QuantityTextBox.TabIndex = 9;
            this.QuantityTextBox.Text = "Quantity";
            // 
            // BuyThisCarButton
            // 
            this.BuyThisCarButton.Location = new System.Drawing.Point(16, 15);
            this.BuyThisCarButton.Name = "BuyThisCarButton";
            this.BuyThisCarButton.Size = new System.Drawing.Size(100, 22);
            this.BuyThisCarButton.TabIndex = 10;
            this.BuyThisCarButton.Text = "Buy Product ID";
            this.BuyThisCarButton.TextChanged += new System.EventHandler(this.BuyThisCarButton_TextChanged);
            // 
            // AccountPropertiesLabel
            // 
            this.AccountPropertiesLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AccountPropertiesLabel.ForeColor = System.Drawing.Color.CadetBlue;
            this.AccountPropertiesLabel.Location = new System.Drawing.Point(142, 22);
            this.AccountPropertiesLabel.Name = "AccountPropertiesLabel";
            this.AccountPropertiesLabel.Size = new System.Drawing.Size(188, 35);
            this.AccountPropertiesLabel.TabIndex = 9;
            this.AccountPropertiesLabel.Text = "Account properties";
            this.AccountPropertiesLabel.UseVisualStyleBackColor = false;
            this.AccountPropertiesLabel.Click += new System.EventHandler(this.AccountPropertiesLabel_Click);
            // 
            // ChooseWhatToDoComboBox
            // 
            this.ChooseWhatToDoComboBox.FormattingEnabled = true;
            this.ChooseWhatToDoComboBox.Items.AddRange(new object[] {
            "Add money",
            "Remove money",
            "Balance"});
            this.ChooseWhatToDoComboBox.Location = new System.Drawing.Point(174, 69);
            this.ChooseWhatToDoComboBox.Name = "ChooseWhatToDoComboBox";
            this.ChooseWhatToDoComboBox.Size = new System.Drawing.Size(121, 24);
            this.ChooseWhatToDoComboBox.TabIndex = 10;
            this.ChooseWhatToDoComboBox.Visible = false;
            this.ChooseWhatToDoComboBox.SelectedIndexChanged += new System.EventHandler(this.ChooseWhatToDoComboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.CurrentBalanceLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NewBalanceLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddMoneyLabel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 116);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 35);
            this.tableLayoutPanel1.TabIndex = 17;
            this.tableLayoutPanel1.Visible = false;
            // 
            // CurrentBalanceLabel
            // 
            this.CurrentBalanceLabel.AutoSize = true;
            this.CurrentBalanceLabel.ForeColor = System.Drawing.Color.Blue;
            this.CurrentBalanceLabel.Location = new System.Drawing.Point(3, 0);
            this.CurrentBalanceLabel.Name = "CurrentBalanceLabel";
            this.CurrentBalanceLabel.Size = new System.Drawing.Size(102, 16);
            this.CurrentBalanceLabel.TabIndex = 0;
            this.CurrentBalanceLabel.Text = "Current Balance";
            // 
            // NewBalanceLabel
            // 
            this.NewBalanceLabel.AutoSize = true;
            this.NewBalanceLabel.ForeColor = System.Drawing.Color.Blue;
            this.NewBalanceLabel.Location = new System.Drawing.Point(319, 0);
            this.NewBalanceLabel.Name = "NewBalanceLabel";
            this.NewBalanceLabel.Size = new System.Drawing.Size(87, 16);
            this.NewBalanceLabel.TabIndex = 2;
            this.NewBalanceLabel.Text = "New Balance";
            // 
            // AddMoneyLabel
            // 
            this.AddMoneyLabel.AutoSize = true;
            this.AddMoneyLabel.ForeColor = System.Drawing.Color.Blue;
            this.AddMoneyLabel.Location = new System.Drawing.Point(161, 0);
            this.AddMoneyLabel.Name = "AddMoneyLabel";
            this.AddMoneyLabel.Size = new System.Drawing.Size(93, 16);
            this.AddMoneyLabel.TabIndex = 1;
            this.AddMoneyLabel.Text = "Amount to add";
            // 
            // NewBalanceTextBox
            // 
            this.NewBalanceTextBox.Location = new System.Drawing.Point(329, 183);
            this.NewBalanceTextBox.Name = "NewBalanceTextBox";
            this.NewBalanceTextBox.Size = new System.Drawing.Size(100, 22);
            this.NewBalanceTextBox.TabIndex = 14;
            this.NewBalanceTextBox.Visible = false;
            // 
            // CurrentBalanceTextBox
            // 
            this.CurrentBalanceTextBox.Location = new System.Drawing.Point(22, 183);
            this.CurrentBalanceTextBox.Name = "CurrentBalanceTextBox";
            this.CurrentBalanceTextBox.Size = new System.Drawing.Size(100, 22);
            this.CurrentBalanceTextBox.TabIndex = 13;
            this.CurrentBalanceTextBox.Visible = false;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(172, 184);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown2.TabIndex = 11;
            this.numericUpDown2.Visible = false;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // ModifyBalanceButton
            // 
            this.ModifyBalanceButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ModifyBalanceButton.ForeColor = System.Drawing.Color.CadetBlue;
            this.ModifyBalanceButton.Location = new System.Drawing.Point(182, 223);
            this.ModifyBalanceButton.Name = "ModifyBalanceButton";
            this.ModifyBalanceButton.Size = new System.Drawing.Size(95, 39);
            this.ModifyBalanceButton.TabIndex = 12;
            this.ModifyBalanceButton.Text = "Modify";
            this.ModifyBalanceButton.UseVisualStyleBackColor = false;
            this.ModifyBalanceButton.Visible = false;
            this.ModifyBalanceButton.Click += new System.EventHandler(this.ModifyBalanceButton_Click);
            // 
            // ID1ViewEverything
            // 
            this.ID1ViewEverything.Controls.Add(this.DeleteCar153RadioButton);
            this.ID1ViewEverything.Controls.Add(this.UpdateProductRadioButton);
            this.ID1ViewEverything.Controls.Add(this.GetProductsRadioButton);
            this.ID1ViewEverything.Controls.Add(this.InsertProductRadioButton);
            this.ID1ViewEverything.Controls.Add(this.ViewAllOrdersRadioButton);
            this.ID1ViewEverything.Controls.Add(this.DisplayEverythingButton);
            this.ID1ViewEverything.Controls.Add(this.DeleteCarButton);
            this.ID1ViewEverything.Controls.Add(this.DeleteCarID);
            this.ID1ViewEverything.Controls.Add(this.DeleteCar);
            this.ID1ViewEverything.Controls.Add(this.ReturnHighestBalancestudent);
            this.ID1ViewEverything.Controls.Add(this.SeeAllOrdersRadioButton);
            this.ID1ViewEverything.Controls.Add(this.TopExpensiveCarsButton);
            this.ID1ViewEverything.Controls.Add(this.SeeAllUsersRadioButton);
            this.ID1ViewEverything.Location = new System.Drawing.Point(-1, 268);
            this.ID1ViewEverything.Name = "ID1ViewEverything";
            this.ID1ViewEverything.Size = new System.Drawing.Size(577, 348);
            this.ID1ViewEverything.TabIndex = 22;
            // 
            // DeleteCar153RadioButton
            // 
            this.DeleteCar153RadioButton.AutoSize = true;
            this.DeleteCar153RadioButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.DeleteCar153RadioButton.Location = new System.Drawing.Point(277, 154);
            this.DeleteCar153RadioButton.Name = "DeleteCar153RadioButton";
            this.DeleteCar153RadioButton.Size = new System.Drawing.Size(129, 68);
            this.DeleteCar153RadioButton.TabIndex = 32;
            this.DeleteCar153RadioButton.TabStop = true;
            this.DeleteCar153RadioButton.Text = "Delete Car153\r\n(Lambda, \r\nDeleteOnSubmit,\r\nSubmitChanges)";
            this.DeleteCar153RadioButton.UseVisualStyleBackColor = true;
            this.DeleteCar153RadioButton.CheckedChanged += new System.EventHandler(this.DeleteCar153RadioButton_CheckedChanged);
            // 
            // UpdateProductRadioButton
            // 
            this.UpdateProductRadioButton.AutoSize = true;
            this.UpdateProductRadioButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.UpdateProductRadioButton.Location = new System.Drawing.Point(23, 220);
            this.UpdateProductRadioButton.Name = "UpdateProductRadioButton";
            this.UpdateProductRadioButton.Size = new System.Drawing.Size(228, 36);
            this.UpdateProductRadioButton.TabIndex = 29;
            this.UpdateProductRadioButton.TabStop = true;
            this.UpdateProductRadioButton.Text = "Update product Car153 to Car 200\r\n(Lambda)";
            this.UpdateProductRadioButton.UseVisualStyleBackColor = true;
            this.UpdateProductRadioButton.CheckedChanged += new System.EventHandler(this.UpdateProductRadioButton_CheckedChanged);
            // 
            // GetProductsRadioButton
            // 
            this.GetProductsRadioButton.AutoSize = true;
            this.GetProductsRadioButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.GetProductsRadioButton.Location = new System.Drawing.Point(23, 112);
            this.GetProductsRadioButton.Name = "GetProductsRadioButton";
            this.GetProductsRadioButton.Size = new System.Drawing.Size(208, 36);
            this.GetProductsRadioButton.TabIndex = 28;
            this.GetProductsRadioButton.TabStop = true;
            this.GetProductsRadioButton.Text = "Get products of name 18i\r\n(Lambda,Equal,FirstOrDefault)";
            this.GetProductsRadioButton.UseVisualStyleBackColor = true;
            this.GetProductsRadioButton.CheckedChanged += new System.EventHandler(this.GetProductsRadioButton_CheckedChanged);
            // 
            // InsertProductRadioButton
            // 
            this.InsertProductRadioButton.AutoSize = true;
            this.InsertProductRadioButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.InsertProductRadioButton.Location = new System.Drawing.Point(23, 170);
            this.InsertProductRadioButton.Name = "InsertProductRadioButton";
            this.InsertProductRadioButton.Size = new System.Drawing.Size(227, 36);
            this.InsertProductRadioButton.TabIndex = 25;
            this.InsertProductRadioButton.TabStop = true;
            this.InsertProductRadioButton.Text = "Insert Product Car153\r\n(InsertOnSubmit, SubmitChanges)";
            this.InsertProductRadioButton.UseVisualStyleBackColor = true;
            this.InsertProductRadioButton.CheckedChanged += new System.EventHandler(this.InsertProductRadioButton_CheckedChanged);
            // 
            // ViewAllOrdersRadioButton
            // 
            this.ViewAllOrdersRadioButton.AutoSize = true;
            this.ViewAllOrdersRadioButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.ViewAllOrdersRadioButton.Location = new System.Drawing.Point(277, 112);
            this.ViewAllOrdersRadioButton.Name = "ViewAllOrdersRadioButton";
            this.ViewAllOrdersRadioButton.Size = new System.Drawing.Size(186, 36);
            this.ViewAllOrdersRadioButton.TabIndex = 24;
            this.ViewAllOrdersRadioButton.TabStop = true;
            this.ViewAllOrdersRadioButton.Text = "See all orders bought date\r\n(ToString)";
            this.ViewAllOrdersRadioButton.UseVisualStyleBackColor = true;
            this.ViewAllOrdersRadioButton.CheckedChanged += new System.EventHandler(this.ViewAllOrdersRadioButton_CheckedChanged);
            // 
            // DisplayEverythingButton
            // 
            this.DisplayEverythingButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DisplayEverythingButton.ForeColor = System.Drawing.Color.CadetBlue;
            this.DisplayEverythingButton.Location = new System.Drawing.Point(16, 271);
            this.DisplayEverythingButton.Name = "DisplayEverythingButton";
            this.DisplayEverythingButton.Size = new System.Drawing.Size(120, 42);
            this.DisplayEverythingButton.TabIndex = 23;
            this.DisplayEverythingButton.Text = "Display everything";
            this.DisplayEverythingButton.UseVisualStyleBackColor = false;
            this.DisplayEverythingButton.Click += new System.EventHandler(this.DisplayEverythingButton_Click);
            // 
            // DeleteCarButton
            // 
            this.DeleteCarButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DeleteCarButton.ForeColor = System.Drawing.Color.CadetBlue;
            this.DeleteCarButton.Location = new System.Drawing.Point(426, 280);
            this.DeleteCarButton.Name = "DeleteCarButton";
            this.DeleteCarButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteCarButton.TabIndex = 22;
            this.DeleteCarButton.Text = "Delete";
            this.DeleteCarButton.UseVisualStyleBackColor = false;
            this.DeleteCarButton.Click += new System.EventHandler(this.DeleteCarButton_Click);
            // 
            // DeleteCarID
            // 
            this.DeleteCarID.Location = new System.Drawing.Point(300, 281);
            this.DeleteCarID.Name = "DeleteCarID";
            this.DeleteCarID.Size = new System.Drawing.Size(120, 22);
            this.DeleteCarID.TabIndex = 21;
            // 
            // DeleteCar
            // 
            this.DeleteCar.Location = new System.Drawing.Point(188, 281);
            this.DeleteCar.Name = "DeleteCar";
            this.DeleteCar.ReadOnly = true;
            this.DeleteCar.Size = new System.Drawing.Size(105, 22);
            this.DeleteCar.TabIndex = 23;
            this.DeleteCar.Text = "Delete car ID";
            // 
            // ReturnHighestBalancestudent
            // 
            this.ReturnHighestBalancestudent.AutoSize = true;
            this.ReturnHighestBalancestudent.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.ReturnHighestBalancestudent.Location = new System.Drawing.Point(277, 53);
            this.ReturnHighestBalancestudent.Name = "ReturnHighestBalancestudent";
            this.ReturnHighestBalancestudent.Size = new System.Drawing.Size(165, 20);
            this.ReturnHighestBalancestudent.TabIndex = 20;
            this.ReturnHighestBalancestudent.TabStop = true;
            this.ReturnHighestBalancestudent.Text = "Return highest balance";
            this.ReturnHighestBalancestudent.UseVisualStyleBackColor = true;
            this.ReturnHighestBalancestudent.CheckedChanged += new System.EventHandler(this.ReturnHighestBalancestudent_CheckedChanged);
            // 
            // SeeAllOrdersRadioButton
            // 
            this.SeeAllOrdersRadioButton.AutoSize = true;
            this.SeeAllOrdersRadioButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.SeeAllOrdersRadioButton.Location = new System.Drawing.Point(277, 17);
            this.SeeAllOrdersRadioButton.Name = "SeeAllOrdersRadioButton";
            this.SeeAllOrdersRadioButton.Size = new System.Drawing.Size(158, 20);
            this.SeeAllOrdersRadioButton.TabIndex = 17;
            this.SeeAllOrdersRadioButton.TabStop = true;
            this.SeeAllOrdersRadioButton.Text = "See All Orders details";
            this.SeeAllOrdersRadioButton.UseVisualStyleBackColor = true;
            this.SeeAllOrdersRadioButton.CheckedChanged += new System.EventHandler(this.SeeAllOrdersRadioButton_CheckedChanged);
            // 
            // TopExpensiveCarsButton
            // 
            this.TopExpensiveCarsButton.AutoSize = true;
            this.TopExpensiveCarsButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.TopExpensiveCarsButton.Location = new System.Drawing.Point(23, 53);
            this.TopExpensiveCarsButton.Name = "TopExpensiveCarsButton";
            this.TopExpensiveCarsButton.Size = new System.Drawing.Size(147, 20);
            this.TopExpensiveCarsButton.TabIndex = 16;
            this.TopExpensiveCarsButton.TabStop = true;
            this.TopExpensiveCarsButton.Text = "Top expensive cars";
            this.TopExpensiveCarsButton.UseVisualStyleBackColor = true;
            this.TopExpensiveCarsButton.CheckedChanged += new System.EventHandler(this.TopExpensiveCarsButton_CheckedChanged);
            // 
            // SeeAllUsersRadioButton
            // 
            this.SeeAllUsersRadioButton.AutoSize = true;
            this.SeeAllUsersRadioButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.SeeAllUsersRadioButton.Location = new System.Drawing.Point(23, 17);
            this.SeeAllUsersRadioButton.Name = "SeeAllUsersRadioButton";
            this.SeeAllUsersRadioButton.Size = new System.Drawing.Size(106, 20);
            this.SeeAllUsersRadioButton.TabIndex = 15;
            this.SeeAllUsersRadioButton.TabStop = true;
            this.SeeAllUsersRadioButton.Text = "See all users";
            this.SeeAllUsersRadioButton.UseVisualStyleBackColor = true;
            this.SeeAllUsersRadioButton.CheckedChanged += new System.EventHandler(this.SeeAllUsersRadioButton_CheckedChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(447, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(136, 71);
            this.CloseButton.TabIndex = 23;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1392, 628);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ID1ViewEverything);
            this.Controls.Add(this.ModifyBalanceButton);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.CurrentBalanceTextBox);
            this.Controls.Add(this.NewBalanceTextBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ChooseWhatToDoComboBox);
            this.Controls.Add(this.AccountPropertiesLabel);
            this.Controls.Add(this.BuyPanel);
            this.Controls.Add(this.BuyCarButton);
            this.Controls.Add(this.DataGridView);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.BuyPanel.ResumeLayout(false);
            this.BuyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoughtNumericUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ID1ViewEverything.ResumeLayout(false);
            this.ID1ViewEverything.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteCarID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button MostExpensiveCarView;
        private System.Windows.Forms.Button BuyTheCar;
        private System.Windows.Forms.Button BuyCarButton;
        private System.Windows.Forms.Button SeeCarsButton;
        private System.Windows.Forms.Panel BuyPanel;
        private System.Windows.Forms.ComboBox ViewCarOfIDComboBox;
        private System.Windows.Forms.TextBox ViewCarID;
        private System.Windows.Forms.TextBox TotalPriceTextbox;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.TextBox BuyThisCarButton;
        private System.Windows.Forms.ComboBox ProductIDToBuy;
        private System.Windows.Forms.NumericUpDown BoughtNumericUpDown;
        private System.Windows.Forms.Button AccountPropertiesLabel;
        private System.Windows.Forms.ComboBox ChooseWhatToDoComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label CurrentBalanceLabel;
        private System.Windows.Forms.Label NewBalanceLabel;
        private System.Windows.Forms.Label AddMoneyLabel;
        private System.Windows.Forms.TextBox NewBalanceTextBox;
        private System.Windows.Forms.TextBox CurrentBalanceTextBox;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button ModifyBalanceButton;
        private System.Windows.Forms.Panel ID1ViewEverything;
        private System.Windows.Forms.TextBox TotalPrice;
        private System.Windows.Forms.RadioButton ReturnHighestBalancestudent;
        private System.Windows.Forms.RadioButton SeeAllOrdersRadioButton;
        private System.Windows.Forms.RadioButton TopExpensiveCarsButton;
        private System.Windows.Forms.RadioButton SeeAllUsersRadioButton;
        private System.Windows.Forms.Button DeleteCarButton;
        private System.Windows.Forms.NumericUpDown DeleteCarID;
        private System.Windows.Forms.TextBox DeleteCar;
        private System.Windows.Forms.Button DisplayEverythingButton;
        private System.Windows.Forms.RadioButton ViewAllOrdersRadioButton;
        private System.Windows.Forms.RadioButton InsertProductRadioButton;
        private System.Windows.Forms.RadioButton GetProductsRadioButton;
        private System.Windows.Forms.RadioButton UpdateProductRadioButton;
        private System.Windows.Forms.RadioButton DeleteCar153RadioButton;
        private System.Windows.Forms.Button CloseButton;
    }
}