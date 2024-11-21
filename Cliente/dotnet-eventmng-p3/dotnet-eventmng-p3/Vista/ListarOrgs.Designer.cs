namespace dotnet_eventmng_p3.Vista
{
    partial class ListarOrgs
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
            panel1 = new Panel();
            txtFiltroInicial = new TextBox();
            btnFiltrar = new Button();
            label1 = new Label();
            btnListar = new Button();
            tblOrganizaciones = new DataGridView();
            lblTitulo = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblOrganizaciones).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(240, 244, 255);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtFiltroInicial);
            panel1.Controls.Add(btnFiltrar);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(115, 401);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 86);
            panel1.TabIndex = 19;
            // 
            // txtFiltroInicial
            // 
            txtFiltroInicial.Location = new Point(162, 52);
            txtFiltroInicial.Name = "txtFiltroInicial";
            txtFiltroInicial.Size = new Size(145, 23);
            txtFiltroInicial.TabIndex = 17;
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
            label1.Location = new Point(123, 12);
            label1.Name = "label1";
            label1.Size = new Size(127, 19);
            label1.TabIndex = 16;
            label1.Text = "Listar por inicial";
            // 
            // btnListar
            // 
            btnListar.BackColor = Color.FromArgb(13, 55, 113);
            btnListar.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnListar.ForeColor = Color.White;
            btnListar.Location = new Point(239, 346);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(125, 35);
            btnListar.TabIndex = 18;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = false;
            btnListar.Click += btnListar_Click;
            // 
            // tblOrganizaciones
            // 
            tblOrganizaciones.BackgroundColor = Color.White;
            tblOrganizaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblOrganizaciones.Location = new Point(35, 102);
            tblOrganizaciones.Name = "tblOrganizaciones";
            tblOrganizaciones.Size = new Size(525, 224);
            tblOrganizaciones.TabIndex = 17;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(2, 31, 85);
            lblTitulo.Location = new Point(115, 37);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(380, 44);
            lblTitulo.TabIndex = 16;
            lblTitulo.Text = "Listar Organizadores";
            // 
            // ListarOrgs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(594, 524);
            Controls.Add(panel1);
            Controls.Add(btnListar);
            Controls.Add(tblOrganizaciones);
            Controls.Add(lblTitulo);
            Name = "ListarOrgs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListarOrgs";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tblOrganizaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtFiltroInicial;
        private Button btnFiltrar;
        private Label label1;
        private Button btnListar;
        private DataGridView tblOrganizaciones;
        private Label lblTitulo;
    }
}