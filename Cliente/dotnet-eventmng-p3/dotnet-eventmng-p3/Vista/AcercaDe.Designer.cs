﻿namespace dotnet_eventmng_p3.Vista
{
    partial class AcercaDe
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
            lblTitulo = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(2, 31, 85);
            lblTitulo.Location = new Point(40, 52);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 56);
            lblTitulo.TabIndex = 20;
            lblTitulo.Text = "DESARROLLADO POR";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Harlow Solid Italic", 27.75F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.FromArgb(73, 159, 231);
            label1.Location = new Point(27, 131);
            label1.Name = "label1";
            label1.Size = new Size(234, 46);
            label1.TabIndex = 21;
            label1.Text = "Laura Gomez";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Harlow Solid Italic", 27.75F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.FromArgb(73, 159, 231);
            label2.Location = new Point(298, 131);
            label2.Name = "label2";
            label2.Size = new Size(261, 46);
            label2.TabIndex = 22;
            label2.Text = "Sebastian Diaz";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(2, 31, 85);
            label3.Location = new Point(157, 194);
            label3.Name = "label3";
            label3.Size = new Size(197, 41);
            label3.TabIndex = 23;
            label3.Text = "version 6.0";
            // 
            // AcercaDe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(589, 255);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitulo);
            Name = "AcercaDe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AcercaDe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}