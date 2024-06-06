namespace Ej04
{
    partial class fAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAdministrador));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.grpDatos1 = new System.Windows.Forms.GroupBox();
            this.chkContrasenya = new System.Windows.Forms.CheckBox();
            this.lblApellido2 = new System.Windows.Forms.Label();
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
            this.btnGestionAlumnos = new System.Windows.Forms.Button();
            this.btnGestionProfesores = new System.Windows.Forms.Button();
            this.btnGestionCursos = new System.Windows.Forms.Button();
            this.btnGestionAsignaturas = new System.Windows.Forms.Button();
            this.btnAnyadirAdministrador = new System.Windows.Forms.Button();
            this.msPerfil = new System.Windows.Forms.MenuStrip();
            this.perfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpDatos1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgProfesor)).BeginInit();
            this.msPerfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(11, 224);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 39);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(11, 176);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 39);
            this.btnGuardar.TabIndex = 34;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grpDatos1
            // 
            this.grpDatos1.Controls.Add(this.chkContrasenya);
            this.grpDatos1.Controls.Add(this.lblApellido2);
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
            this.grpDatos1.Location = new System.Drawing.Point(134, 33);
            this.grpDatos1.Name = "grpDatos1";
            this.grpDatos1.Size = new System.Drawing.Size(481, 230);
            this.grpDatos1.TabIndex = 33;
            this.grpDatos1.TabStop = false;
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
            this.lblID.Location = new System.Drawing.Point(26, 124);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 32;
            this.lblID.Text = "ID:";
            // 
            // picImgProfesor
            // 
            this.picImgProfesor.Location = new System.Drawing.Point(26, 39);
            this.picImgProfesor.Name = "picImgProfesor";
            this.picImgProfesor.Size = new System.Drawing.Size(78, 76);
            this.picImgProfesor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgProfesor.TabIndex = 31;
            this.picImgProfesor.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(53, 121);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(51, 20);
            this.txtID.TabIndex = 30;
            // 
            // btnGestionAlumnos
            // 
            this.btnGestionAlumnos.Location = new System.Drawing.Point(621, 39);
            this.btnGestionAlumnos.Name = "btnGestionAlumnos";
            this.btnGestionAlumnos.Size = new System.Drawing.Size(110, 109);
            this.btnGestionAlumnos.TabIndex = 36;
            this.btnGestionAlumnos.Text = "Gestión Alumnos";
            this.btnGestionAlumnos.UseVisualStyleBackColor = true;
            this.btnGestionAlumnos.Click += new System.EventHandler(this.btnGestionAlumnos_Click);
            // 
            // btnGestionProfesores
            // 
            this.btnGestionProfesores.Location = new System.Drawing.Point(737, 39);
            this.btnGestionProfesores.Name = "btnGestionProfesores";
            this.btnGestionProfesores.Size = new System.Drawing.Size(110, 109);
            this.btnGestionProfesores.TabIndex = 37;
            this.btnGestionProfesores.Text = "Gestión Profesores";
            this.btnGestionProfesores.UseVisualStyleBackColor = true;
            this.btnGestionProfesores.Click += new System.EventHandler(this.btnGestionProfesores_Click);
            // 
            // btnGestionCursos
            // 
            this.btnGestionCursos.Location = new System.Drawing.Point(621, 154);
            this.btnGestionCursos.Name = "btnGestionCursos";
            this.btnGestionCursos.Size = new System.Drawing.Size(110, 109);
            this.btnGestionCursos.TabIndex = 38;
            this.btnGestionCursos.Text = "Gestión Cursos";
            this.btnGestionCursos.UseVisualStyleBackColor = true;
            this.btnGestionCursos.Click += new System.EventHandler(this.btnGestionCursos_Click);
            // 
            // btnGestionAsignaturas
            // 
            this.btnGestionAsignaturas.Location = new System.Drawing.Point(737, 154);
            this.btnGestionAsignaturas.Name = "btnGestionAsignaturas";
            this.btnGestionAsignaturas.Size = new System.Drawing.Size(110, 109);
            this.btnGestionAsignaturas.TabIndex = 39;
            this.btnGestionAsignaturas.Text = "Gestión Asignaturas";
            this.btnGestionAsignaturas.UseVisualStyleBackColor = true;
            this.btnGestionAsignaturas.Click += new System.EventHandler(this.btnGestionAsignaturas_Click);
            // 
            // btnAnyadirAdministrador
            // 
            this.btnAnyadirAdministrador.Location = new System.Drawing.Point(11, 269);
            this.btnAnyadirAdministrador.Name = "btnAnyadirAdministrador";
            this.btnAnyadirAdministrador.Size = new System.Drawing.Size(836, 47);
            this.btnAnyadirAdministrador.TabIndex = 40;
            this.btnAnyadirAdministrador.Text = "Dar de alta a un nuevo Administrador";
            this.btnAnyadirAdministrador.UseVisualStyleBackColor = true;
            this.btnAnyadirAdministrador.Click += new System.EventHandler(this.btnAnyadirAdministrador_Click);
            // 
            // msPerfil
            // 
            this.msPerfil.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilToolStripMenuItem});
            this.msPerfil.Location = new System.Drawing.Point(0, 0);
            this.msPerfil.Name = "msPerfil";
            this.msPerfil.Size = new System.Drawing.Size(858, 24);
            this.msPerfil.TabIndex = 41;
            this.msPerfil.Text = "menuStrip1";
            // 
            // perfilToolStripMenuItem
            // 
            this.perfilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarCuentaToolStripMenuItem,
            this.toolStripSeparator1,
            this.cerrarSesiónToolStripMenuItem});
            this.perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            this.perfilToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.perfilToolStripMenuItem.Text = "Perfil";
            // 
            // eliminarCuentaToolStripMenuItem
            // 
            this.eliminarCuentaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarCuentaToolStripMenuItem.Image")));
            this.eliminarCuentaToolStripMenuItem.Name = "eliminarCuentaToolStripMenuItem";
            this.eliminarCuentaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarCuentaToolStripMenuItem.Text = "Eliminar Cuenta";
            this.eliminarCuentaToolStripMenuItem.Click += new System.EventHandler(this.eliminarCuentaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarSesiónToolStripMenuItem.Image")));
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // fAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(858, 326);
            this.Controls.Add(this.btnAnyadirAdministrador);
            this.Controls.Add(this.btnGestionAsignaturas);
            this.Controls.Add(this.btnGestionCursos);
            this.Controls.Add(this.btnGestionProfesores);
            this.Controls.Add(this.btnGestionAlumnos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grpDatos1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.picImgProfesor);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.msPerfil);
            this.MainMenuStrip = this.msPerfil;
            this.Name = "fAdministrador";
            this.Text = "fAdministrador";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fAdministrador_FormClosed);
            this.Load += new System.EventHandler(this.fAdministrador_Load);
            this.grpDatos1.ResumeLayout(false);
            this.grpDatos1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgProfesor)).EndInit();
            this.msPerfil.ResumeLayout(false);
            this.msPerfil.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox grpDatos1;
        private System.Windows.Forms.CheckBox chkContrasenya;
        private System.Windows.Forms.Label lblApellido2;
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
        private System.Windows.Forms.Button btnGestionAlumnos;
        private System.Windows.Forms.Button btnGestionProfesores;
        private System.Windows.Forms.Button btnGestionCursos;
        private System.Windows.Forms.Button btnGestionAsignaturas;
        private System.Windows.Forms.Button btnAnyadirAdministrador;
        private System.Windows.Forms.MenuStrip msPerfil;
        private System.Windows.Forms.ToolStripMenuItem eliminarCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}