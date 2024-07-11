namespace Database_Project
{
    partial class Deposit
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
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.DepositAmount = new System.Windows.Forms.TextBox();
            this.txtAccBalance = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.UpdatedAccbalance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Location = new System.Drawing.Point(112, 169);
            this.lblCurrentBalance.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(251, 25);
            this.lblCurrentBalance.TabIndex = 8;
            this.lblCurrentBalance.Text = "Current Account Balance";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Location = new System.Drawing.Point(200, 246);
            this.lblDeposit.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(164, 25);
            this.lblDeposit.TabIndex = 9;
            this.lblDeposit.Text = "Deposit Amount";
            // 
            // DepositAmount
            // 
            this.DepositAmount.Location = new System.Drawing.Point(376, 240);
            this.DepositAmount.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DepositAmount.Name = "DepositAmount";
            this.DepositAmount.Size = new System.Drawing.Size(196, 31);
            this.DepositAmount.TabIndex = 14;
            // 
            // txtAccBalance
            // 
            this.txtAccBalance.Location = new System.Drawing.Point(376, 163);
            this.txtAccBalance.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAccBalance.Name = "txtAccBalance";
            this.txtAccBalance.ReadOnly = true;
            this.txtAccBalance.Size = new System.Drawing.Size(196, 31);
            this.txtAccBalance.TabIndex = 22;
            this.txtAccBalance.TextChanged += new System.EventHandler(this.txtCurrentBalance1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 25;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 308);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 44);
            this.button2.TabIndex = 26;
            this.button2.Text = "Deposit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdatedAccbalance
            // 
            this.UpdatedAccbalance.Location = new System.Drawing.Point(376, 552);
            this.UpdatedAccbalance.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.UpdatedAccbalance.Name = "UpdatedAccbalance";
            this.UpdatedAccbalance.ReadOnly = true;
            this.UpdatedAccbalance.Size = new System.Drawing.Size(196, 31);
            this.UpdatedAccbalance.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 558);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Updated Account Balance";
            // 
            // Deposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.UpdatedAccbalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAccBalance);
            this.Controls.Add(this.DepositAmount);
            this.Controls.Add(this.lblDeposit);
            this.Controls.Add(this.lblCurrentBalance);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Deposit";
            this.Text = "Deposit";
            this.Load += new System.EventHandler(this.Deposit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.TextBox DepositAmount;
        private System.Windows.Forms.TextBox txtAccBalance;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox UpdatedAccbalance;
        private System.Windows.Forms.Label label1;
    }
}