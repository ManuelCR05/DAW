namespace GestorContrasenyas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aLMACEN_CREDENCIALESDataSet = new GestorContrasenyas.ALMACEN_CREDENCIALESDataSet();
            this.cREDENCIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cREDENCIALESTableAdapter = new GestorContrasenyas.ALMACEN_CREDENCIALESDataSetTableAdapters.CREDENCIALESTableAdapter();
            this.idCredencialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contraseenyaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uRLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLMACEN_CREDENCIALESDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cREDENCIALESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(452, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inicioToolStripMenuItem.Image")));
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCredencialDataGridViewTextBoxColumn,
            this.nombreUsuarioDataGridViewTextBoxColumn,
            this.contraseenyaDataGridViewTextBoxColumn,
            this.uRLDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cREDENCIALESBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 234);
            this.dataGridView1.TabIndex = 1;
            // 
            // aLMACEN_CREDENCIALESDataSet
            // 
            this.aLMACEN_CREDENCIALESDataSet.DataSetName = "ALMACEN_CREDENCIALESDataSet";
            this.aLMACEN_CREDENCIALESDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cREDENCIALESBindingSource
            // 
            this.cREDENCIALESBindingSource.DataMember = "CREDENCIALES";
            this.cREDENCIALESBindingSource.DataSource = this.aLMACEN_CREDENCIALESDataSet;
            // 
            // cREDENCIALESTableAdapter
            // 
            this.cREDENCIALESTableAdapter.ClearBeforeFill = true;
            // 
            // idCredencialDataGridViewTextBoxColumn
            // 
            this.idCredencialDataGridViewTextBoxColumn.DataPropertyName = "IdCredencial";
            this.idCredencialDataGridViewTextBoxColumn.HeaderText = "IdCredencial";
            this.idCredencialDataGridViewTextBoxColumn.Name = "idCredencialDataGridViewTextBoxColumn";
            // 
            // nombreUsuarioDataGridViewTextBoxColumn
            // 
            this.nombreUsuarioDataGridViewTextBoxColumn.DataPropertyName = "nombreUsuario";
            this.nombreUsuarioDataGridViewTextBoxColumn.HeaderText = "nombreUsuario";
            this.nombreUsuarioDataGridViewTextBoxColumn.Name = "nombreUsuarioDataGridViewTextBoxColumn";
            // 
            // contraseenyaDataGridViewTextBoxColumn
            // 
            this.contraseenyaDataGridViewTextBoxColumn.DataPropertyName = "contraseenya";
            this.contraseenyaDataGridViewTextBoxColumn.HeaderText = "contraseenya";
            this.contraseenyaDataGridViewTextBoxColumn.Name = "contraseenyaDataGridViewTextBoxColumn";
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            this.uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            this.uRLDataGridViewTextBoxColumn.HeaderText = "URL";
            this.uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 270);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLMACEN_CREDENCIALESDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cREDENCIALESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ALMACEN_CREDENCIALESDataSet aLMACEN_CREDENCIALESDataSet;
        private System.Windows.Forms.BindingSource cREDENCIALESBindingSource;
        private ALMACEN_CREDENCIALESDataSetTableAdapters.CREDENCIALESTableAdapter cREDENCIALESTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCredencialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contraseenyaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn;
    }
}

