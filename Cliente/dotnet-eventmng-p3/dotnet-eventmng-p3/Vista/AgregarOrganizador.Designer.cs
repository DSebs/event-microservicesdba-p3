namespace dotnet_eventmng_p3.Vista
{
    partial class AgregarOrganizador
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
            panelPrincipal = new Panel();
            btnAgregar = new Button();
            dtpFundacion = new DateTimePicker();
            txtCeo = new TextBox();
            txtPresupuesto = new TextBox();
            txtNombre = new TextBox();
            txtId = new TextBox();
            lblCeo = new Label();
            lblFundacion = new Label();
            lblPresupuesto = new Label();
            lblNombre = new Label();
            lblId = new Label();
            panelPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(2, 31, 85);
            lblTitulo.Location = new Point(69, 35);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(399, 44);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Agregar Organizador";
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.FromArgb(240, 244, 255);
            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Controls.Add(btnAgregar);
            panelPrincipal.Controls.Add(dtpFundacion);
            panelPrincipal.Controls.Add(txtCeo);
            panelPrincipal.Controls.Add(txtPresupuesto);
            panelPrincipal.Controls.Add(txtNombre);
            panelPrincipal.Controls.Add(txtId);
            panelPrincipal.Controls.Add(lblCeo);
            panelPrincipal.Controls.Add(lblFundacion);
            panelPrincipal.Controls.Add(lblPresupuesto);
            panelPrincipal.Controls.Add(lblNombre);
            panelPrincipal.Controls.Add(lblId);
            panelPrincipal.Location = new Point(66, 130);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(402, 343);
            panelPrincipal.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(13, 55, 113);
            btnAgregar.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(143, 275);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 35);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dtpFundacion
            // 
            dtpFundacion.Location = new Point(197, 176);
            dtpFundacion.Name = "dtpFundacion";
            dtpFundacion.Size = new Size(200, 23);
            dtpFundacion.TabIndex = 12;
            // 
            // txtCeo
            // 
            txtCeo.Location = new Point(222, 230);
            txtCeo.Name = "txtCeo";
            txtCeo.Size = new Size(145, 23);
            txtCeo.TabIndex = 10;
            // 
            // txtPresupuesto
            // 
            txtPresupuesto.Location = new Point(222, 133);
            txtPresupuesto.Name = "txtPresupuesto";
            txtPresupuesto.Size = new Size(145, 23);
            txtPresupuesto.TabIndex = 8;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(222, 87);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(145, 23);
            txtNombre.TabIndex = 7;
            // 
            // txtId
            // 
            txtId.Location = new Point(222, 37);
            txtId.Name = "txtId";
            txtId.Size = new Size(145, 23);
            txtId.TabIndex = 6;
            // 
            // lblCeo
            // 
            lblCeo.AutoSize = true;
            lblCeo.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblCeo.ForeColor = Color.FromArgb(13, 55, 113);
            lblCeo.Location = new Point(19, 225);
            lblCeo.Name = "lblCeo";
            lblCeo.Size = new Size(63, 28);
            lblCeo.TabIndex = 4;
            lblCeo.Text = "CEO";
            // 
            // lblFundacion
            // 
            lblFundacion.AutoSize = true;
            lblFundacion.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblFundacion.ForeColor = Color.FromArgb(13, 55, 113);
            lblFundacion.Location = new Point(19, 176);
            lblFundacion.Name = "lblFundacion";
            lblFundacion.Size = new Size(134, 28);
            lblFundacion.TabIndex = 3;
            lblFundacion.Text = "Fundacion";
            // 
            // lblPresupuesto
            // 
            lblPresupuesto.AutoSize = true;
            lblPresupuesto.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblPresupuesto.ForeColor = Color.FromArgb(13, 55, 113);
            lblPresupuesto.Location = new Point(19, 125);
            lblPresupuesto.Name = "lblPresupuesto";
            lblPresupuesto.Size = new Size(151, 28);
            lblPresupuesto.TabIndex = 2;
            lblPresupuesto.Text = "Presupuesto";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(13, 55, 113);
            lblNombre.Location = new Point(19, 79);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(107, 28);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblId.ForeColor = Color.FromArgb(13, 55, 113);
            lblId.Location = new Point(19, 29);
            lblId.Name = "lblId";
            lblId.Size = new Size(36, 28);
            lblId.TabIndex = 0;
            lblId.Text = "ID";
            // 
            // AgregarOrganizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 524);
            Controls.Add(lblTitulo);
            Controls.Add(panelPrincipal);
            Name = "AgregarOrganizador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "59*";
            Load += AgregarOrganizador_Load;
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel panelPrincipal;
        private Button btnAgregar;
        private DateTimePicker dtpFundacion;
        private TextBox txtCeo;
        private TextBox txtPresupuesto;
        private TextBox txtNombre;
        private TextBox txtId;
        private Label lblCeo;
        private Label lblFundacion;
        private Label lblPresupuesto;
        private Label lblNombre;
        private Label lblId;
    }
}