namespace dotnet_eventmng_p3.Vista
{
    partial class ListarFerias
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
            tblFerias = new DataGridView();
            btnListar = new Button();
            panel1 = new Panel();
            txtFiltroPrecioMax = new TextBox();
            btnFiltrar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)tblFerias).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(2, 31, 85);
            lblTitulo.Location = new Point(181, 42);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 44);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Listar Ferias";
            // 
            // tblFerias
            // 
            tblFerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblFerias.Location = new Point(34, 107);
            tblFerias.Name = "tblFerias";
            tblFerias.Size = new Size(525, 224);
            tblFerias.TabIndex = 3;
            // 
            // btnListar
            // 
            btnListar.BackColor = Color.FromArgb(13, 55, 113);
            btnListar.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnListar.ForeColor = Color.White;
            btnListar.Location = new Point(238, 351);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(125, 35);
            btnListar.TabIndex = 14;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = false;
            btnListar.Click += btnListar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(240, 244, 255);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtFiltroPrecioMax);
            panel1.Controls.Add(btnFiltrar);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(114, 406);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 86);
            panel1.TabIndex = 15;
            // 
            // txtFiltroPrecioMax
            // 
            txtFiltroPrecioMax.Location = new Point(162, 52);
            txtFiltroPrecioMax.Name = "txtFiltroPrecioMax";
            txtFiltroPrecioMax.Size = new Size(145, 23);
            txtFiltroPrecioMax.TabIndex = 17;
            txtFiltroPrecioMax.TextChanged += txtOrganizadores_TextChanged;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(13, 55, 113);
            btnFiltrar.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(87, 43);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(69, 32);
            btnFiltrar.TabIndex = 16;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(2, 31, 85);
            label1.Location = new Point(87, 13);
            label1.Name = "label1";
            label1.Size = new Size(200, 19);
            label1.TabIndex = 16;
            label1.Text = "Listar por precio maximo";
            // 
            // ListarFerias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 524);
            Controls.Add(panel1);
            Controls.Add(btnListar);
            Controls.Add(tblFerias);
            Controls.Add(lblTitulo);
            Name = "ListarFerias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListarFerias";
            ((System.ComponentModel.ISupportInitialize)tblFerias).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView tblFerias;
        private Button btnListar;
        private Panel panel1;
        private Button btnFiltrar;
        private Label label1;
        private TextBox txtFiltroPrecioMax;
    }
}