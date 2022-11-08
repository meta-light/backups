namespace Project_3
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGuests = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoPasta = new System.Windows.Forms.RadioButton();
            this.rdoChicken = new System.Windows.Forms.RadioButton();
            this.rdoSteak = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboSauce = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkWine = new System.Windows.Forms.CheckBox();
            this.chkOpenBar = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboSides = new System.Windows.Forms.ComboBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.askbhfjkbasf = new System.Windows.Forms.Label();
            this.lblTodaysDate = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carpinito Catering";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Today\'s Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of Guests";
            // 
            // txtGuests
            // 
            this.txtGuests.Location = new System.Drawing.Point(12, 76);
            this.txtGuests.Name = "txtGuests";
            this.txtGuests.Size = new System.Drawing.Size(100, 20);
            this.txtGuests.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoPasta);
            this.groupBox1.Controls.Add(this.rdoChicken);
            this.groupBox1.Controls.Add(this.rdoSteak);
            this.groupBox1.Location = new System.Drawing.Point(25, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Choices";
            // 
            // rdoPasta
            // 
            this.rdoPasta.AutoSize = true;
            this.rdoPasta.Location = new System.Drawing.Point(16, 86);
            this.rdoPasta.Name = "rdoPasta";
            this.rdoPasta.Size = new System.Drawing.Size(52, 17);
            this.rdoPasta.TabIndex = 2;
            this.rdoPasta.TabStop = true;
            this.rdoPasta.Text = "Pasta";
            this.rdoPasta.UseVisualStyleBackColor = true;
            // 
            // rdoChicken
            // 
            this.rdoChicken.AutoSize = true;
            this.rdoChicken.Location = new System.Drawing.Point(16, 62);
            this.rdoChicken.Name = "rdoChicken";
            this.rdoChicken.Size = new System.Drawing.Size(64, 17);
            this.rdoChicken.TabIndex = 1;
            this.rdoChicken.TabStop = true;
            this.rdoChicken.Text = "Chicken";
            this.rdoChicken.UseVisualStyleBackColor = true;
            // 
            // rdoSteak
            // 
            this.rdoSteak.AutoSize = true;
            this.rdoSteak.Location = new System.Drawing.Point(16, 39);
            this.rdoSteak.Name = "rdoSteak";
            this.rdoSteak.Size = new System.Drawing.Size(53, 17);
            this.rdoSteak.TabIndex = 0;
            this.rdoSteak.TabStop = true;
            this.rdoSteak.Text = "Steak";
            this.rdoSteak.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboSauce);
            this.groupBox2.Location = new System.Drawing.Point(156, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 56);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sauces";
            // 
            // cboSauce
            // 
            this.cboSauce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSauce.FormattingEnabled = true;
            this.cboSauce.Location = new System.Drawing.Point(6, 21);
            this.cboSauce.Name = "cboSauce";
            this.cboSauce.Size = new System.Drawing.Size(121, 21);
            this.cboSauce.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkWine);
            this.groupBox3.Controls.Add(this.chkOpenBar);
            this.groupBox3.Location = new System.Drawing.Point(313, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(113, 120);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bar Selection";
            // 
            // chkWine
            // 
            this.chkWine.AutoSize = true;
            this.chkWine.Location = new System.Drawing.Point(6, 44);
            this.chkWine.Name = "chkWine";
            this.chkWine.Size = new System.Drawing.Size(107, 17);
            this.chkWine.TabIndex = 1;
            this.chkWine.Text = "Wine with Dinner";
            this.chkWine.UseVisualStyleBackColor = true;
            // 
            // chkOpenBar
            // 
            this.chkOpenBar.AutoSize = true;
            this.chkOpenBar.Location = new System.Drawing.Point(6, 21);
            this.chkOpenBar.Name = "chkOpenBar";
            this.chkOpenBar.Size = new System.Drawing.Size(71, 17);
            this.chkOpenBar.TabIndex = 0;
            this.chkOpenBar.Text = "Open Bar";
            this.chkOpenBar.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboSides);
            this.groupBox4.Location = new System.Drawing.Point(156, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(141, 52);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sides";
            // 
            // cboSides
            // 
            this.cboSides.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSides.FormattingEnabled = true;
            this.cboSides.Location = new System.Drawing.Point(6, 19);
            this.cboSides.Name = "cboSides";
            this.cboSides.Size = new System.Drawing.Size(121, 21);
            this.cboSides.TabIndex = 0;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(459, 415);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 8;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(540, 415);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(621, 415);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(75, 23);
            this.btnSummary.TabIndex = 10;
            this.btnSummary.Text = "Summary";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(702, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // askbhfjkbasf
            // 
            this.askbhfjkbasf.AutoSize = true;
            this.askbhfjkbasf.Location = new System.Drawing.Point(12, 321);
            this.askbhfjkbasf.Name = "askbhfjkbasf";
            this.askbhfjkbasf.Size = new System.Drawing.Size(69, 13);
            this.askbhfjkbasf.TabIndex = 12;
            this.askbhfjkbasf.Text = "Amount Due:";
            // 
            // lblTodaysDate
            // 
            this.lblTodaysDate.AutoSize = true;
            this.lblTodaysDate.Location = new System.Drawing.Point(185, 18);
            this.lblTodaysDate.Name = "lblTodaysDate";
            this.lblTodaysDate.Size = new System.Drawing.Size(35, 13);
            this.lblTodaysDate.TabIndex = 13;
            this.lblTodaysDate.Text = "label5";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAmountDue.Location = new System.Drawing.Point(90, 321);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(100, 23);
            this.lblAmountDue.TabIndex = 14;
            this.lblAmountDue.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAmountDue);
            this.Controls.Add(this.lblTodaysDate);
            this.Controls.Add(this.askbhfjkbasf);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGuests);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Carpinito Catering";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGuests;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoPasta;
        private System.Windows.Forms.RadioButton rdoChicken;
        private System.Windows.Forms.RadioButton rdoSteak;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboSauce;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkWine;
        private System.Windows.Forms.CheckBox chkOpenBar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboSides;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label askbhfjkbasf;
        private System.Windows.Forms.Label lblTodaysDate;
        private System.Windows.Forms.Label lblAmountDue;
    }
}

