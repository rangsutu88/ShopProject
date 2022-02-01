namespace ShopProject.PeopleForms
{
    partial class EmployeeForm
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.AddJuniorEngineerButton = new System.Windows.Forms.Button();
            this.AddJuniorSalesButton = new System.Windows.Forms.Button();
            this.RemoveJuniorSalesButton = new System.Windows.Forms.Button();
            this.RemoveJuniorEngineerButton = new System.Windows.Forms.Button();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.DegreeLabel = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.AgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GenderCombobox = new System.Windows.Forms.ComboBox();
            this.DegreeComboBox = new System.Windows.Forms.ComboBox();
            this.AddTheEmployeeButton = new System.Windows.Forms.Button();
            this.RemoveEmployeeButton = new System.Windows.Forms.Button();
            this.IDToRemoveLabel = new System.Windows.Forms.Label();
            this.IDToRemoveNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AskForAPromotionButton = new System.Windows.Forms.Button();
            this.ViewEmployeeInformationsButton = new System.Windows.Forms.Button();
            this.ViewSamePositionsEmployeesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AgeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDToRemoveNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.Control;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(22, 527);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(131, 72);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AddJuniorEngineerButton
            // 
            this.AddJuniorEngineerButton.BackColor = System.Drawing.SystemColors.Control;
            this.AddJuniorEngineerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJuniorEngineerButton.Location = new System.Drawing.Point(12, 28);
            this.AddJuniorEngineerButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddJuniorEngineerButton.Name = "AddJuniorEngineerButton";
            this.AddJuniorEngineerButton.Size = new System.Drawing.Size(171, 84);
            this.AddJuniorEngineerButton.TabIndex = 2;
            this.AddJuniorEngineerButton.Text = "Add Junior engineer (if the employee is senior engineer)";
            this.AddJuniorEngineerButton.UseVisualStyleBackColor = false;
            this.AddJuniorEngineerButton.Click += new System.EventHandler(this.AddJuniorEngineerButton_Click);
            // 
            // AddJuniorSalesButton
            // 
            this.AddJuniorSalesButton.BackColor = System.Drawing.SystemColors.Control;
            this.AddJuniorSalesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddJuniorSalesButton.Location = new System.Drawing.Point(12, 135);
            this.AddJuniorSalesButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddJuniorSalesButton.Name = "AddJuniorSalesButton";
            this.AddJuniorSalesButton.Size = new System.Drawing.Size(171, 80);
            this.AddJuniorSalesButton.TabIndex = 3;
            this.AddJuniorSalesButton.Text = "Add Junior sales (if the employee is a senior sales)";
            this.AddJuniorSalesButton.UseVisualStyleBackColor = false;
            this.AddJuniorSalesButton.Click += new System.EventHandler(this.AddJuniorSalesButton_Click);
            // 
            // RemoveJuniorSalesButton
            // 
            this.RemoveJuniorSalesButton.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveJuniorSalesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveJuniorSalesButton.Location = new System.Drawing.Point(12, 348);
            this.RemoveJuniorSalesButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveJuniorSalesButton.Name = "RemoveJuniorSalesButton";
            this.RemoveJuniorSalesButton.Size = new System.Drawing.Size(179, 84);
            this.RemoveJuniorSalesButton.TabIndex = 4;
            this.RemoveJuniorSalesButton.Text = "Remove Junior sales (if the employee is a senior sales)";
            this.RemoveJuniorSalesButton.UseVisualStyleBackColor = false;
            this.RemoveJuniorSalesButton.Click += new System.EventHandler(this.RemoveJuniorSalesButton_Click);
            // 
            // RemoveJuniorEngineerButton
            // 
            this.RemoveJuniorEngineerButton.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveJuniorEngineerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveJuniorEngineerButton.Location = new System.Drawing.Point(12, 236);
            this.RemoveJuniorEngineerButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveJuniorEngineerButton.Name = "RemoveJuniorEngineerButton";
            this.RemoveJuniorEngineerButton.Size = new System.Drawing.Size(179, 95);
            this.RemoveJuniorEngineerButton.TabIndex = 5;
            this.RemoveJuniorEngineerButton.Text = "Remove Junior engineer (if the employee is senior engineer)";
            this.RemoveJuniorEngineerButton.UseVisualStyleBackColor = false;
            this.RemoveJuniorEngineerButton.Click += new System.EventHandler(this.RemoveJuniorEngineerButton_Click);
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FirstNameLabel.Location = new System.Drawing.Point(277, 38);
            this.FirstNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(87, 20);
            this.FirstNameLabel.TabIndex = 7;
            this.FirstNameLabel.Text = "FirstName";
            this.FirstNameLabel.Visible = false;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LastNameLabel.Location = new System.Drawing.Point(277, 82);
            this.LastNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(86, 20);
            this.LastNameLabel.TabIndex = 8;
            this.LastNameLabel.Text = "LastName";
            this.LastNameLabel.Visible = false;
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.AgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AgeLabel.Location = new System.Drawing.Point(277, 140);
            this.AgeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(38, 20);
            this.AgeLabel.TabIndex = 9;
            this.AgeLabel.Text = "Age";
            this.AgeLabel.Visible = false;
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.GenderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GenderLabel.Location = new System.Drawing.Point(277, 184);
            this.GenderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(64, 20);
            this.GenderLabel.TabIndex = 12;
            this.GenderLabel.Text = "Gender";
            this.GenderLabel.Visible = false;
            // 
            // DegreeLabel
            // 
            this.DegreeLabel.AutoSize = true;
            this.DegreeLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.DegreeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DegreeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DegreeLabel.Location = new System.Drawing.Point(277, 222);
            this.DegreeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DegreeLabel.Name = "DegreeLabel";
            this.DegreeLabel.Size = new System.Drawing.Size(64, 20);
            this.DegreeLabel.TabIndex = 13;
            this.DegreeLabel.Text = "Degree";
            this.DegreeLabel.Visible = false;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(376, 28);
            this.FirstNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.FirstNameTextBox.TabIndex = 18;
            this.FirstNameTextBox.Visible = false;
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(376, 78);
            this.LastNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.LastNameTextBox.TabIndex = 22;
            this.LastNameTextBox.Visible = false;
            // 
            // AgeNumericUpDown
            // 
            this.AgeNumericUpDown.Location = new System.Drawing.Point(368, 134);
            this.AgeNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.AgeNumericUpDown.Name = "AgeNumericUpDown";
            this.AgeNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.AgeNumericUpDown.TabIndex = 23;
            this.AgeNumericUpDown.Visible = false;
            // 
            // GenderCombobox
            // 
            this.GenderCombobox.FormattingEnabled = true;
            this.GenderCombobox.Items.AddRange(new object[] {
            "Man",
            "Woman"});
            this.GenderCombobox.Location = new System.Drawing.Point(368, 172);
            this.GenderCombobox.Margin = new System.Windows.Forms.Padding(4);
            this.GenderCombobox.Name = "GenderCombobox";
            this.GenderCombobox.Size = new System.Drawing.Size(120, 24);
            this.GenderCombobox.TabIndex = 24;
            this.GenderCombobox.Visible = false;
            // 
            // DegreeComboBox
            // 
            this.DegreeComboBox.FormattingEnabled = true;
            this.DegreeComboBox.Items.AddRange(new object[] {
            "Mechanical",
            "Electrical"});
            this.DegreeComboBox.Location = new System.Drawing.Point(368, 218);
            this.DegreeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.DegreeComboBox.Name = "DegreeComboBox";
            this.DegreeComboBox.Size = new System.Drawing.Size(120, 24);
            this.DegreeComboBox.TabIndex = 26;
            this.DegreeComboBox.Visible = false;
            // 
            // AddTheEmployeeButton
            // 
            this.AddTheEmployeeButton.AutoSize = true;
            this.AddTheEmployeeButton.BackColor = System.Drawing.SystemColors.Control;
            this.AddTheEmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTheEmployeeButton.Location = new System.Drawing.Point(648, 25);
            this.AddTheEmployeeButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddTheEmployeeButton.Name = "AddTheEmployeeButton";
            this.AddTheEmployeeButton.Size = new System.Drawing.Size(389, 87);
            this.AddTheEmployeeButton.TabIndex = 27;
            this.AddTheEmployeeButton.Text = "Add The employee (stringbuilder, filestream,\r\n textwriter, and streamwriter)";
            this.AddTheEmployeeButton.UseVisualStyleBackColor = false;
            this.AddTheEmployeeButton.Visible = false;
            this.AddTheEmployeeButton.Click += new System.EventHandler(this.AddTheEmployeeButton_Click);
            // 
            // RemoveEmployeeButton
            // 
            this.RemoveEmployeeButton.AutoSize = true;
            this.RemoveEmployeeButton.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveEmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveEmployeeButton.Location = new System.Drawing.Point(648, 140);
            this.RemoveEmployeeButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveEmployeeButton.Name = "RemoveEmployeeButton";
            this.RemoveEmployeeButton.Size = new System.Drawing.Size(389, 78);
            this.RemoveEmployeeButton.TabIndex = 28;
            this.RemoveEmployeeButton.Text = "Remove the employee\r\n(when an employee removed, this will be saved in a text file" +
    "\r\n(who removed who and the time)\r\nStream reader,streamwriter, list, streambuilde" +
    "r, textwriter)";
            this.RemoveEmployeeButton.UseVisualStyleBackColor = false;
            this.RemoveEmployeeButton.Visible = false;
            this.RemoveEmployeeButton.Click += new System.EventHandler(this.RemoveEmployeeButton_Click);
            // 
            // IDToRemoveLabel
            // 
            this.IDToRemoveLabel.AutoSize = true;
            this.IDToRemoveLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.IDToRemoveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDToRemoveLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IDToRemoveLabel.Location = new System.Drawing.Point(277, 272);
            this.IDToRemoveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDToRemoveLabel.Name = "IDToRemoveLabel";
            this.IDToRemoveLabel.Size = new System.Drawing.Size(162, 20);
            this.IDToRemoveLabel.TabIndex = 30;
            this.IDToRemoveLabel.Text = "Remove junior of ID:";
            this.IDToRemoveLabel.Visible = false;
            // 
            // IDToRemoveNumericUpDown
            // 
            this.IDToRemoveNumericUpDown.Location = new System.Drawing.Point(465, 273);
            this.IDToRemoveNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.IDToRemoveNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.IDToRemoveNumericUpDown.Name = "IDToRemoveNumericUpDown";
            this.IDToRemoveNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.IDToRemoveNumericUpDown.TabIndex = 31;
            this.IDToRemoveNumericUpDown.Visible = false;
            this.IDToRemoveNumericUpDown.ValueChanged += new System.EventHandler(this.IDToRemoveNumericUpDown_ValueChanged);
            // 
            // AskForAPromotionButton
            // 
            this.AskForAPromotionButton.BackColor = System.Drawing.SystemColors.Control;
            this.AskForAPromotionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AskForAPromotionButton.Location = new System.Drawing.Point(309, 445);
            this.AskForAPromotionButton.Margin = new System.Windows.Forms.Padding(4);
            this.AskForAPromotionButton.Name = "AskForAPromotionButton";
            this.AskForAPromotionButton.Size = new System.Drawing.Size(248, 62);
            this.AskForAPromotionButton.TabIndex = 32;
            this.AskForAPromotionButton.Text = "Ask for a promotion (list, Tostring, filestream)";
            this.AskForAPromotionButton.UseVisualStyleBackColor = false;
            this.AskForAPromotionButton.Click += new System.EventHandler(this.AskForAPromotionButton_Click);
            // 
            // ViewEmployeeInformationsButton
            // 
            this.ViewEmployeeInformationsButton.AutoSize = true;
            this.ViewEmployeeInformationsButton.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeeInformationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewEmployeeInformationsButton.Location = new System.Drawing.Point(309, 533);
            this.ViewEmployeeInformationsButton.Margin = new System.Windows.Forms.Padding(4);
            this.ViewEmployeeInformationsButton.Name = "ViewEmployeeInformationsButton";
            this.ViewEmployeeInformationsButton.Size = new System.Drawing.Size(248, 60);
            this.ViewEmployeeInformationsButton.TabIndex = 35;
            this.ViewEmployeeInformationsButton.Text = "View informations (To string)";
            this.ViewEmployeeInformationsButton.UseVisualStyleBackColor = false;
            this.ViewEmployeeInformationsButton.Click += new System.EventHandler(this.ViewEmployeeInformationsButton_Click);
            // 
            // ViewSamePositionsEmployeesButton
            // 
            this.ViewSamePositionsEmployeesButton.AutoSize = true;
            this.ViewSamePositionsEmployeesButton.BackColor = System.Drawing.SystemColors.Control;
            this.ViewSamePositionsEmployeesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewSamePositionsEmployeesButton.Location = new System.Drawing.Point(591, 445);
            this.ViewSamePositionsEmployeesButton.Margin = new System.Windows.Forms.Padding(4);
            this.ViewSamePositionsEmployeesButton.Name = "ViewSamePositionsEmployeesButton";
            this.ViewSamePositionsEmployeesButton.Size = new System.Drawing.Size(248, 62);
            this.ViewSamePositionsEmployeesButton.TabIndex = 37;
            this.ViewSamePositionsEmployeesButton.Text = "View same (and lower) positions\r\nemployees (View employee function)";
            this.ViewSamePositionsEmployeesButton.UseVisualStyleBackColor = false;
            this.ViewSamePositionsEmployeesButton.Click += new System.EventHandler(this.ViewSamePositionsEmployeesButton_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ShopProject.Properties.Resources.employee;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1063, 618);
            this.Controls.Add(this.ViewSamePositionsEmployeesButton);
            this.Controls.Add(this.ViewEmployeeInformationsButton);
            this.Controls.Add(this.AskForAPromotionButton);
            this.Controls.Add(this.IDToRemoveNumericUpDown);
            this.Controls.Add(this.IDToRemoveLabel);
            this.Controls.Add(this.RemoveEmployeeButton);
            this.Controls.Add(this.AddTheEmployeeButton);
            this.Controls.Add(this.DegreeComboBox);
            this.Controls.Add(this.GenderCombobox);
            this.Controls.Add(this.AgeNumericUpDown);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.DegreeLabel);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.RemoveJuniorEngineerButton);
            this.Controls.Add(this.RemoveJuniorSalesButton);
            this.Controls.Add(this.AddJuniorSalesButton);
            this.Controls.Add(this.AddJuniorEngineerButton);
            this.Controls.Add(this.ExitButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AgeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDToRemoveNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AddJuniorEngineerButton;
        private System.Windows.Forms.Button AddJuniorSalesButton;
        private System.Windows.Forms.Button RemoveJuniorSalesButton;
        private System.Windows.Forms.Button RemoveJuniorEngineerButton;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label DegreeLabel;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.NumericUpDown AgeNumericUpDown;
        private System.Windows.Forms.ComboBox GenderCombobox;
        private System.Windows.Forms.ComboBox DegreeComboBox;
        private System.Windows.Forms.Button AddTheEmployeeButton;
        private System.Windows.Forms.Button RemoveEmployeeButton;
        private System.Windows.Forms.Label IDToRemoveLabel;
        private System.Windows.Forms.NumericUpDown IDToRemoveNumericUpDown;
        private System.Windows.Forms.Button AskForAPromotionButton;
        private System.Windows.Forms.Button ViewEmployeeInformationsButton;
        private System.Windows.Forms.Button ViewSamePositionsEmployeesButton;
    }
}