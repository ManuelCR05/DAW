namespace Ej04
{
    partial class fGestionAlumnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGestionAlumnos));
            this.txtContador = new System.Windows.Forms.TextBox();
            this.lblContador = new System.Windows.Forms.Label();
            this.btnAnyadir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.grpDatos1 = new System.Windows.Forms.GroupBox();
            this.chkCambiarCurso = new System.Windows.Forms.CheckBox();
            this.cmbCodCurso = new System.Windows.Forms.ComboBox();
            this.chkContrasenya = new System.Windows.Forms.CheckBox();
            this.lblApellido2 = new System.Windows.Forms.Label();
            this.lblCodCurso = new System.Windows.Forms.Label();
            this.lblApellido1 = new System.Windows.Forms.Label();
            this.lblContrasenya = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtContrasenya = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.picImgAlumno = new System.Windows.Forms.PictureBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpDatos1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtContador
            // 
            this.txtContador.BackColor = System.Drawing.SystemColors.Menu;
            this.txtContador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtContador.Location = new System.Drawing.Point(15, 248);
            this.txtContador.Name = "txtContador";
            this.txtContador.Size = new System.Drawing.Size(75, 28);
            this.txtContador.TabIndex = 36;
            this.txtContador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblContador.Location = new System.Drawing.Point(93, 248);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(0, 29);
            this.lblContador.TabIndex = 35;
            // 
            // btnAnyadir
            // 
            this.btnAnyadir.Location = new System.Drawing.Point(196, 248);
            this.btnAnyadir.Name = "btnAnyadir";
            this.btnAnyadir.Size = new System.Drawing.Size(239, 35);
            this.btnAnyadir.TabIndex = 33;
            this.btnAnyadir.Text = "Añadir";
            this.btnAnyadir.UseVisualStyleBackColor = true;
            this.btnAnyadir.Click += new System.EventHandler(this.btnAnyadir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(441, 248);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(239, 35);
            this.btnEliminar.TabIndex = 32;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 203);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(178, 39);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 158);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(178, 39);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grpDatos1
            // 
            this.grpDatos1.Controls.Add(this.chkCambiarCurso);
            this.grpDatos1.Controls.Add(this.cmbCodCurso);
            this.grpDatos1.Controls.Add(this.chkContrasenya);
            this.grpDatos1.Controls.Add(this.lblApellido2);
            this.grpDatos1.Controls.Add(this.lblCodCurso);
            this.grpDatos1.Controls.Add(this.lblApellido1);
            this.grpDatos1.Controls.Add(this.lblContrasenya);
            this.grpDatos1.Controls.Add(this.lblNombre);
            this.grpDatos1.Controls.Add(this.lblEmail);
            this.grpDatos1.Controls.Add(this.lblDNI);
            this.grpDatos1.Controls.Add(this.lblTelefono);
            this.grpDatos1.Controls.Add(this.txtApellido2);
            this.grpDatos1.Controls.Add(this.txtNombre);
            this.grpDatos1.Controls.Add(this.txtApellido1);
            this.grpDatos1.Controls.Add(this.txtEmail);
            this.grpDatos1.Controls.Add(this.txtDNI);
            this.grpDatos1.Controls.Add(this.txtContrasenya);
            this.grpDatos1.Controls.Add(this.txtTelefono);
            this.grpDatos1.Location = new System.Drawing.Point(196, 12);
            this.grpDatos1.Name = "grpDatos1";
            this.grpDatos1.Size = new System.Drawing.Size(481, 230);
            this.grpDatos1.TabIndex = 37;
            this.grpDatos1.TabStop = false;
            // 
            // chkCambiarCurso
            // 
            this.chkCambiarCurso.AutoSize = true;
            this.chkCambiarCurso.Location = new System.Drawing.Point(357, 184);
            this.chkCambiarCurso.Name = "chkCambiarCurso";
            this.chkCambiarCurso.Size = new System.Drawing.Size(109, 17);
            this.chkCambiarCurso.TabIndex = 23;
            this.chkCambiarCurso.Text = "Cambiar de Curso";
            this.chkCambiarCurso.UseVisualStyleBackColor = true;
            this.chkCambiarCurso.CheckedChanged += new System.EventHandler(this.chkCambiarCurso_CheckedChanged);
            // 
            // cmbCodCurso
            // 
            this.cmbCodCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodCurso.Enabled = false;
            this.cmbCodCurso.FormattingEnabled = true;
            this.cmbCodCurso.Location = new System.Drawing.Point(223, 182);
            this.cmbCodCurso.Name = "cmbCodCurso";
            this.cmbCodCurso.Size = new System.Drawing.Size(128, 21);
            this.cmbCodCurso.TabIndex = 22;
            // 
            // chkContrasenya
            // 
            this.chkContrasenya.AutoSize = true;
            this.chkContrasenya.Location = new System.Drawing.Point(357, 136);
            this.chkContrasenya.Name = "chkContrasenya";
            this.chkContrasenya.Size = new System.Drawing.Size(99, 17);
            this.chkContrasenya.TabIndex = 19;
            this.chkContrasenya.Text = "Ver Contraseña";
            this.chkContrasenya.UseVisualStyleBackColor = true;
            this.chkContrasenya.CheckedChanged += new System.EventHandler(this.chkContrasenya_CheckedChanged);
            // 
            // lblApellido2
            // 
            this.lblApellido2.AutoSize = true;
            this.lblApellido2.Location = new System.Drawing.Point(30, 166);
            this.lblApellido2.Name = "lblApellido2";
            this.lblApellido2.Size = new System.Drawing.Size(93, 13);
            this.lblApellido2.TabIndex = 14;
            this.lblApellido2.Text = "Segundo Apellido:";
            // 
            // lblCodCurso
            // 
            this.lblCodCurso.AutoSize = true;
            this.lblCodCurso.Location = new System.Drawing.Point(220, 166);
            this.lblCodCurso.Name = "lblCodCurso";
            this.lblCodCurso.Size = new System.Drawing.Size(90, 13);
            this.lblCodCurso.TabIndex = 18;
            this.lblCodCurso.Text = "Codígo de Curso:";
            // 
            // lblApellido1
            // 
            this.lblApellido1.AutoSize = true;
            this.lblApellido1.Location = new System.Drawing.Point(30, 118);
            this.lblApellido1.Name = "lblApellido1";
            this.lblApellido1.Size = new System.Drawing.Size(79, 13);
            this.lblApellido1.TabIndex = 13;
            this.lblApellido1.Text = "Primer Apellido:";
            // 
            // lblContrasenya
            // 
            this.lblContrasenya.AutoSize = true;
            this.lblContrasenya.Location = new System.Drawing.Point(220, 118);
            this.lblContrasenya.Name = "lblContrasenya";
            this.lblContrasenya.Size = new System.Drawing.Size(64, 13);
            this.lblContrasenya.TabIndex = 17;
            this.lblContrasenya.Text = "Contraseña:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(30, 72);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(220, 72);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(30, 28);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(29, 13);
            this.lblDNI.TabIndex = 11;
            this.lblDNI.Text = "DNI:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(220, 28);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 15;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtApellido2
            // 
            this.txtApellido2.Location = new System.Drawing.Point(33, 182);
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(128, 20);
            this.txtApellido2.TabIndex = 4;
            this.txtApellido2.TextChanged += new System.EventHandler(this.VisualizarErrores);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(33, 88);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(128, 20);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextChanged += new System.EventHandler(this.VisualizarErrores);
            // 
            // txtApellido1
            // 
            this.txtApellido1.Location = new System.Drawing.Point(33, 134);
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(128, 20);
            this.txtApellido1.TabIndex = 1;
            this.txtApellido1.TextChanged += new System.EventHandler(this.VisualizarErrores);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(223, 88);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(128, 20);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.TextChanged += new System.EventHandler(this.VisualizarErrores);
            // 
            // txtDNI
            // 
            this.txtDNI.Enabled = false;
            this.txtDNI.Location = new System.Drawing.Point(33, 44);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(128, 20);
            this.txtDNI.TabIndex = 0;
            this.txtDNI.TextChanged += new System.EventHandler(this.VisualizarErrores);
            // 
            // txtContrasenya
            // 
            this.txtContrasenya.Location = new System.Drawing.Point(223, 134);
            this.txtContrasenya.Name = "txtContrasenya";
            this.txtContrasenya.PasswordChar = '*';
            this.txtContrasenya.Size = new System.Drawing.Size(128, 20);
            this.txtContrasenya.TabIndex = 7;
            this.txtContrasenya.TextChanged += new System.EventHandler(this.VisualizarErrores);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(223, 44);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(128, 20);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.TextChanged += new System.EventHandler(this.VisualizarErrores);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(58, 103);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 40;
            this.lblID.Text = "ID:";
            // 
            // picImgAlumno
            // 
            this.picImgAlumno.Location = new System.Drawing.Point(61, 18);
            this.picImgAlumno.Name = "picImgAlumno";
            this.picImgAlumno.Size = new System.Drawing.Size(78, 76);
            this.picImgAlumno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgAlumno.TabIndex = 39;
            this.picImgAlumno.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(88, 100);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(51, 20);
            this.txtID.TabIndex = 38;
            // 
            // btnPrimero
            // 
            this.btnPrimero.BackColor = System.Drawing.SystemColors.Menu;
            this.btnPrimero.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.btnPrimero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimero.Image = ((System.Drawing.Image)(resources.GetObject("btnPrimero.Image")));
            this.btnPrimero.Location = new System.Drawing.Point(12, 289);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(70, 71);
            this.btnPrimero.TabIndex = 41;
            this.btnPrimero.UseVisualStyleBackColor = false;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.SystemColors.Menu;
            this.btnAnterior.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.Location = new System.Drawing.Point(88, 289);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(70, 71);
            this.btnAnterior.TabIndex = 42;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.Location = new System.Drawing.Point(806, 289);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(70, 71);
            this.btnSiguiente.TabIndex = 43;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.BackColor = System.Drawing.SystemColors.Menu;
            this.btnUltimo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Menu;
            this.btnUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btnUltimo.Image")));
            this.btnUltimo.Location = new System.Drawing.Point(882, 289);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(70, 71);
            this.btnUltimo.TabIndex = 44;
            this.btnUltimo.UseVisualStyleBackColor = false;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(683, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(269, 265);
            this.dataGridView1.TabIndex = 45;
            // 
            // fGestionAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 369);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnPrimero);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.picImgAlumno);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.grpDatos1);
            this.Controls.Add(this.txtContador);
            this.Controls.Add(this.btnAnyadir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "fGestionAlumnos";
            this.Text = "fGestionAlumnos";
            this.Load += new System.EventHandler(this.fGestionAlumnos_Load);
            this.grpDatos1.ResumeLayout(false);
            this.grpDatos1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContador;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button btnAnyadir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox grpDatos1;
        private System.Windows.Forms.CheckBox chkContrasenya;
        private System.Windows.Forms.Label lblApellido2;
        private System.Windows.Forms.Label lblCodCurso;
        private System.Windows.Forms.Label lblApellido1;
        private System.Windows.Forms.Label lblContrasenya;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtContrasenya;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.PictureBox picImgAlumno;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbCodCurso;
        private System.Windows.Forms.CheckBox chkCambiarCurso;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}