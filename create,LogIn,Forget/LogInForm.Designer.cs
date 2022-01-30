namespace ShopProject.create_LogIn_Forget
{
    partial class LogInForm
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
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ShowLogInPasswordButton = new System.Windows.Forms.Button();
            this.LogInButton = new System.Windows.Forms.Button();
            this.LogInForgetThePasswordButton = new System.Windows.Forms.Button();
            this.ReturnBackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(29, 212);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(83, 20);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(29, 121);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(87, 20);
            this.FirstNameLabel.TabIndex = 2;
            this.FirstNameLabel.Text = "FirstName";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.Location = new System.Drawing.Point(29, 168);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(86, 20);
            this.LastNameLabel.TabIndex = 3;
            this.LastNameLabel.Text = "LastName";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(158, 121);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.FirstNameTextBox.TabIndex = 1;
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(158, 168);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.LastNameTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(158, 212);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 22);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ShowLogInPasswordButton
            // 
            this.ShowLogInPasswordButton.AutoSize = true;
            this.ShowLogInPasswordButton.Location = new System.Drawing.Point(279, 210);
            this.ShowLogInPasswordButton.Name = "ShowLogInPasswordButton";
            this.ShowLogInPasswordButton.Size = new System.Drawing.Size(75, 27);
            this.ShowLogInPasswordButton.TabIndex = 4;
            this.ShowLogInPasswordButton.Text = "Show";
            this.ShowLogInPasswordButton.UseVisualStyleBackColor = true;
            this.ShowLogInPasswordButton.Click += new System.EventHandler(this.ShowLogInPasswordButton_Click);
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(319, 283);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(75, 28);
            this.LogInButton.TabIndex = 5;
            this.LogInButton.Text = "LogIn";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // LogInForgetThePasswordButton
            // 
            this.LogInForgetThePasswordButton.Location = new System.Drawing.Point(133, 283);
            this.LogInForgetThePasswordButton.Name = "LogInForgetThePasswordButton";
            this.LogInForgetThePasswordButton.Size = new System.Drawing.Size(161, 28);
            this.LogInForgetThePasswordButton.TabIndex = 6;
            this.LogInForgetThePasswordButton.Text = "Forgot the password?";
            this.LogInForgetThePasswordButton.UseVisualStyleBackColor = true;
            this.LogInForgetThePasswordButton.Click += new System.EventHandler(this.LogInForgetThePasswordButton_Click);
            // 
            // ReturnBackButton
            // 
            this.ReturnBackButton.Location = new System.Drawing.Point(33, 283);
            this.ReturnBackButton.Name = "ReturnBackButton";
            this.ReturnBackButton.Size = new System.Drawing.Size(75, 28);
            this.ReturnBackButton.TabIndex = 7;
            this.ReturnBackButton.Text = "Return back";
            this.ReturnBackButton.UseVisualStyleBackColor = true;
            this.ReturnBackButton.Click += new System.EventHandler(this.ReturnBackButton_Click);
            // 
            // LogInForm
            // 
            this.AcceptButton = this.LogInButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ShopProject.Properties.Resources.logIn;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(439, 471);
            this.Controls.Add(this.ReturnBackButton);
            this.Controls.Add(this.LogInForgetThePasswordButton);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.ShowLogInPasswordButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.PasswordLabel);
            this.DoubleBuffered = true;
            this.Name = "LogInForm";
            this.Text = "LogInForm";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button ShowLogInPasswordButton;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Button LogInForgetThePasswordButton;
        private System.Windows.Forms.Button ReturnBackButton;
    }
}