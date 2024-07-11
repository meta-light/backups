namespace Database_Project
{
    partial class Withdraw
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
            this.txtWithdraw = new System.Windows.Forms.TextBox();
            this.lblWthdraw = new System.Windows.Forms.Label();
            this.txtAccBalance = new System.Windows.Forms.TextBox();
            this.lblChecking2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UpdatedAccBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtWithdraw
            // 
            this.txtWithdraw.Location = new System.Drawing.Point(280, 254);
            this.txtWithdraw.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtWithdraw.Name = "txtWithdraw";
            this.txtWithdraw.Size = new System.Drawing.Size(200, 31);
            this.txtWithdraw.TabIndex = 19;
            // 
            // lblWthdraw
            // 
            this.lblWthdraw.AutoSize = true;
            this.lblWthdraw.Location = new System.Drawing.Point(90, 260);
            this.lblWthdraw.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWthdraw.Name = "lblWthdraw";
            this.lblWthdraw.Size = new System.Drawing.Size(180, 25);
            this.lblWthdraw.TabIndex = 16;
            this.lblWthdraw.Text = "Withdraw Amount";
            // 
            // txtAccBalance
            // 
            this.txtAccBalance.Location = new System.Drawing.Point(284, 173);
            this.txtAccBalance.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAccBalance.Name = "txtAccBalance";
            this.txtAccBalance.ReadOnly = true;
            this.txtAccBalance.Size = new System.Drawing.Size(196, 31);
            this.txtAccBalance.TabIndex = 27;
            this.txtAccBalance.TextChanged += new System.EventHandler(this.txtChecking2_TextChanged);
            // 
            // lblChecking2
            // 
            this.lblChecking2.AutoSize = true;
            this.lblChecking2.Location = new System.Drawing.Point(20, 179);
            this.lblChecking2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblChecking2.Name = "lblChecking2";
            this.lblChecking2.Size = new System.Drawing.Size(251, 25);
            this.lblChecking2.TabIndex = 25;
            this.lblChecking2.Text = "Current Account Balance";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 29;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(332, 337);
            this.btnWithdraw.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(150, 44);
            this.btnWithdraw.TabIndex = 30;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(284, 529);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(196, 31);
            this.textBox1.TabIndex = 32;
            // 
            // UpdatedAccBalance
            // 
            this.UpdatedAccBalance.AutoSize = true;
            this.UpdatedAccBalance.Location = new System.Drawing.Point(20, 535);
            this.UpdatedAccBalance.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.UpdatedAccBalance.Name = "UpdatedAccBalance";
            this.UpdatedAccBalance.Size = new System.Drawing.Size(261, 25);
            this.UpdatedAccBalance.TabIndex = 31;
            this.UpdatedAccBalance.Text = "Updated Account Balance";
            // 
            // Withdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.UpdatedAccBalance);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAccBalance);
            this.Controls.Add(this.lblChecking2);
            this.Controls.Add(this.txtWithdraw);
            this.Controls.Add(this.lblWthdraw);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Withdraw";
            this.Text = "Withdraw";
            this.Load += new System.EventHandler(this.Withdraw_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWithdraw;
        private System.Windows.Forms.Label lblWthdraw;
        private System.Windows.Forms.TextBox txtAccBalance;
        private System.Windows.Forms.Label lblChecking2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label UpdatedAccBalance;
    }
}