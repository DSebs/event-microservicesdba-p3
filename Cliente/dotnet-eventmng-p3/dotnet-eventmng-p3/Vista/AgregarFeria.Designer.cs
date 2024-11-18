namespace dotnet_eventmng_p3.Vista
{
    partial class AgregarFeria
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
            panelPrincipal = new Panel();
            btnAgregar = new Button();
            dtpFecha = new DateTimePicker();
            txtOrganizadores = new TextBox();
            txtTipo = new TextBox();
            txtPrecio = new TextBox();
            txtNombre = new TextBox();
            txtId = new TextBox();
            lblOrganizadores = new Label();
            lblTipo = new Label();
            lblFecha = new Label();
            lblPrecio = new Label();
            lblNombre = new Label();
            lblId = new Label();
            lblTitulo = new Label();
            panelPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.FromArgb(240, 244, 255);
            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Controls.Add(btnAgregar);
            panelPrincipal.Controls.Add(dtpFecha);
            panelPrincipal.Controls.Add(txtOrganizadores);
            panelPrincipal.Controls.Add(txtTipo);
            panelPrincipal.Controls.Add(txtPrecio);
            panelPrincipal.Controls.Add(txtNombre);
            panelPrincipal.Controls.Add(txtId);
            panelPrincipal.Controls.Add(lblOrganizadores);
            panelPrincipal.Controls.Add(lblTipo);
            panelPrincipal.Controls.Add(lblFecha);
            panelPrincipal.Controls.Add(lblPrecio);
            panelPrincipal.Controls.Add(lblNombre);
            panelPrincipal.Controls.Add(lblId);
            panelPrincipal.Location = new Point(67, 104);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(402, 393);
            panelPrincipal.TabIndex = 0;
            panelPrincipal.Paint += panelPrincipal_Paint;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(13, 55, 113);
            btnAgregar.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(140, 338);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 35);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(197, 176);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 12;
            // 
            // txtOrganizadores
            // 
            txtOrganizadores.Location = new Point(222, 282);
            txtOrganizadores.Name = "txtOrganizadores";
            txtOrganizadores.Size = new Size(145, 23);
            txtOrganizadores.TabIndex = 11;
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(222, 230);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(145, 23);
            txtTipo.TabIndex = 10;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(222, 133);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(145, 23);
            txtPrecio.TabIndex = 8;
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
            // lblOrganizadores
            // 
            lblOrganizadores.AutoSize = true;
            lblOrganizadores.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblOrganizadores.ForeColor = Color.FromArgb(13, 55, 113);
            lblOrganizadores.Location = new Point(19, 277);
            lblOrganizadores.Name = "lblOrganizadores";
            lblOrganizadores.Size = new Size(184, 28);
            lblOrganizadores.TabIndex = 5;
            lblOrganizadores.Text = "Organizadores";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblTipo.ForeColor = Color.FromArgb(13, 55, 113);
            lblTipo.Location = new Point(19, 225);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(59, 28);
            lblTipo.TabIndex = 4;
            lblTipo.Text = "Tipo";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(13, 55, 113);
            lblFecha.Location = new Point(19, 176);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(84, 28);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblPrecio.ForeColor = Color.FromArgb(13, 55, 113);
            lblPrecio.Location = new Point(19, 125);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(84, 28);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio";
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
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(2, 31, 85);
            lblTitulo.Location = new Point(127, 33);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(263, 44);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar Feria";
            lblTitulo.Click += label1_Click;
            // 
            // AgregarFeria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(535, 524);
            Controls.Add(lblTitulo);
            Controls.Add(panelPrincipal);
            Name = "AgregarFeria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AgregarFeria";
            Load += AgregarFeria_Load;
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelPrincipal;
        private Label lblTitulo;
        private Label lblPrecio;
        private Label lblNombre;
        private Label lblId;
        private Label lblTipo;
        private Label lblFecha;
        private Label lblOrganizadores;
        private DateTimePicker dtpFecha;
        private TextBox txtOrganizadores;
        private TextBox txtTipo;
        private TextBox txtPrecio;
        private TextBox txtNombre;
        private TextBox txtId;
        private Button btnAgregar;
    }
}