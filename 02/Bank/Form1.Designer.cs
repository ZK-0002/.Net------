namespace Bank
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private Button btnWithdraw;
        private TextBox txtAccountNumber;
        private TextBox txtAccountHolder;
        private TextBox txtBalance;
        private TextBox txtWithdrawalAmount;
        private Label lblAccountNumber;
        private Label lblAccountHolder;
        private Label lblBalance;
        private Label lblWithdrawalAmount;

        private void InitializeComponent()
        {
            btnWithdraw = new Button();
            txtAccountNumber = new TextBox();
            txtAccountHolder = new TextBox();
            txtBalance = new TextBox();
            txtWithdrawalAmount = new TextBox();
            lblAccountNumber = new Label();
            lblAccountHolder = new Label();
            lblBalance = new Label();
            lblWithdrawalAmount = new Label();
            SuspendLayout();
            // 
            // btnWithdraw
            // 
            btnWithdraw.Location = new Point(20, 150);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(120, 30);
            btnWithdraw.TabIndex = 0;
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Location = new Point(168, 20);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.Size = new Size(150, 27);
            txtAccountNumber.TabIndex = 1;
            // 
            // txtAccountHolder
            // 
            txtAccountHolder.Location = new Point(168, 50);
            txtAccountHolder.Name = "txtAccountHolder";
            txtAccountHolder.Size = new Size(150, 27);
            txtAccountHolder.TabIndex = 2;
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(168, 80);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(150, 27);
            txtBalance.TabIndex = 3;
            // 
            // txtWithdrawalAmount
            // 
            txtWithdrawalAmount.Location = new Point(168, 110);
            txtWithdrawalAmount.Name = "txtWithdrawalAmount";
            txtWithdrawalAmount.Size = new Size(150, 27);
            txtWithdrawalAmount.TabIndex = 4;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.Location = new Point(20, 20);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(142, 20);
            lblAccountNumber.TabIndex = 5;
            lblAccountNumber.Text = "Account Number:";
            // 
            // lblAccountHolder
            // 
            lblAccountHolder.Location = new Point(20, 50);
            lblAccountHolder.Name = "lblAccountHolder";
            lblAccountHolder.Size = new Size(142, 20);
            lblAccountHolder.TabIndex = 6;
            lblAccountHolder.Text = "Account Holder:";
            // 
            // lblBalance
            // 
            lblBalance.Location = new Point(20, 80);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(120, 20);
            lblBalance.TabIndex = 7;
            lblBalance.Text = "Balance:";
            // 
            // lblWithdrawalAmount
            // 
            lblWithdrawalAmount.Location = new Point(20, 110);
            lblWithdrawalAmount.Name = "lblWithdrawalAmount";
            lblWithdrawalAmount.Size = new Size(120, 20);
            lblWithdrawalAmount.TabIndex = 8;
            lblWithdrawalAmount.Text = "Withdrawal Amount:";
            // 
            // Form1
            // 
            ClientSize = new Size(465, 252);
            Controls.Add(btnWithdraw);
            Controls.Add(txtAccountNumber);
            Controls.Add(txtAccountHolder);
            Controls.Add(txtBalance);
            Controls.Add(txtWithdrawalAmount);
            Controls.Add(lblAccountNumber);
            Controls.Add(lblAccountHolder);
            Controls.Add(lblBalance);
            Controls.Add(lblWithdrawalAmount);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}