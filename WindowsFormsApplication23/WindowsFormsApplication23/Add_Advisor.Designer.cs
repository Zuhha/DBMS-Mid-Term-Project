﻿namespace WindowsFormsApplication23
{
    partial class Add_Advisor
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Btnadd = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.labelDesignation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsalary = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(361, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // Btnadd
            // 
            this.Btnadd.Location = new System.Drawing.Point(365, 154);
            this.Btnadd.Name = "Btnadd";
            this.Btnadd.Size = new System.Drawing.Size(191, 44);
            this.Btnadd.TabIndex = 1;
            this.Btnadd.Text = "Add";
            this.Btnadd.UseVisualStyleBackColor = true;
            this.Btnadd.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(360, 20);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(216, 20);
            this.txtid.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(190, 19);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(18, 13);
            this.ID.TabIndex = 4;
            this.ID.Text = "ID";
            // 
            // labelDesignation
            // 
            this.labelDesignation.AutoSize = true;
            this.labelDesignation.Location = new System.Drawing.Point(190, 59);
            this.labelDesignation.Name = "labelDesignation";
            this.labelDesignation.Size = new System.Drawing.Size(63, 13);
            this.labelDesignation.TabIndex = 5;
            this.labelDesignation.Text = "Designation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Salary";
            // 
            // txtsalary
            // 
            this.txtsalary.Location = new System.Drawing.Point(365, 92);
            this.txtsalary.Name = "txtsalary";
            this.txtsalary.Size = new System.Drawing.Size(211, 20);
            this.txtsalary.TabIndex = 7;
            // 
            // Add_Advisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 353);
            this.Controls.Add(this.txtsalary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelDesignation);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.Btnadd);
            this.Controls.Add(this.comboBox1);
            this.Name = "Add_Advisor";
            this.Text = "Add_Advisor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Btnadd;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label labelDesignation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsalary;
    }
}