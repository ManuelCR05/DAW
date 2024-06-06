namespace Ej04
{
    partial class fProfesor
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.grpDatos1 = new System.Windows.Forms.GroupBox();
            this.cmbCodCurso = new System.Windows.Forms.ComboBox();
            this.chkTutor = new System.Windows.Forms.CheckBox();
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
            this.picImgProfesor = new System.Windows.Forms.PictureBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpDatos1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgProfesor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 203);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 39);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 158);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 39);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grpDatos1
            // 
            this.grpDatos1.Controls.Add(this.cmbCodCurso);
            this.grpDatos1.Controls.Add(this.chkTutor);
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
            this.grpDatos1.Location = new System.Drawing.Point(135, 12);
            this.grpDatos1.Name = "grpDatos1";
            this.grpDatos1.Size = new System.Drawing.Size(481, 230);
            this.grpDatos1.TabIndex = 26;
            this.grpDatos1.TabStop = false;
            // 
            // cmbCodCurso
            // 
            this.cmbCodCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodCurso.Enabled = false;
            this.cmbCodCurso.FormattingEnabled = true;
            this.cmbCodCurso.Location = new System.Drawing.Point(223, 182);
            this.cmbCodCurso.Name = "cmbCodCurso";
            this.cmbCodCurso.Size = new System.Drawing.Size(128, 21);
            this.cmbCodCurso.TabIndex = 21;
            // 
            // chkTutor
            // 
            this.chkTutor.AutoSize = true;
            this.chkTutor.Location = new System.Drawing.Point(357, 184);
            this.chkTutor.Name = "chkTutor";
            this.chkTutor.Size = new System.Drawing.Size(66, 17);
            this.chkTutor.TabIndex = 20;
            this.chkTutor.Text = "Es Tutor";
            this.chkTutor.UseVisualStyleBackColor = true;
            this.chkTutor.CheckedChanged += new System.EventHandler(this.chkTutor_CheckedChanged);
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
            this.lblID.Location = new System.Drawing.Point(27, 103);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "ID:";
            // 
            // picImgProfesor
            // 
            this.picImgProfesor.Location = new System.Drawing.Point(30, 18);
            this.picImgProfesor.Name = "picImgProfesor";
            this.picImgProfesor.Size = new System.Drawing.Size(78, 76);
            this.picImgProfesor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgProfesor.TabIndex = 24;
            this.picImgProfesor.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(57, 100);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(51, 20);
            this.txtID.TabIndex = 23;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(622, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(228, 224);
            this.dataGridView1.TabIndex = 29;
            // 
            // fProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(861, 254);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grpDatos1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.picImgProfesor);
            this.Controls.Add(this.txtID);
            this.Name = "fProfesor";
            this.Text = "fProfesor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fProfesor_FormClosed);
            this.Load += new System.EventHandler(this.fProfesor_Load);
            this.grpDatos1.ResumeLayout(false);
            this.grpDatos1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgProfesor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.PictureBox picImgProfesor;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.CheckBox chkTutor;
        private System.Windows.Forms.ComboBox cmbCodCurso;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}