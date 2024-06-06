using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NPOI.SS.Formula.Functions.Countif;

namespace Ej04.Views
{
    public partial class fAnyadirCurso : Form
    {
        private SqlDBHelper conexionDB;
        private string nombre, codCurso;
        private List<string> campos;
        private List<TextBox> listaCampos;

        public fAnyadirCurso(SqlDBHelper conexion)
        {
            InitializeComponent();
            conexionDB = conexion;
            listaCampos = new List<TextBox>()
            {
                txtNombre,
                txtCodCurso
            };
        }

        private void VisualizarErrores(object sender, EventArgs e)
        {
            var txtBox = (TextBox)sender;

            switch (txtBox.Name)
            {
                case "txtCodCurso":
                    if (string.IsNullOrEmpty(txtBox.Text) || !Regex.IsMatch(txtBox.Text, @"^[0-9]+º[A-Z]{2,4}-[A-Z]$") ||
                        conexionDB.ComporbarExistenciaCodCurso(txtBox.Text))
                    {
                        txtBox.BackColor = string.IsNullOrEmpty(txtBox.Text) ? Color.White : Color.Red;
                        txtBox.ForeColor = string.IsNullOrEmpty(txtBox.Text) ? Color.Black : Color.White;
                    }
                    else
                    {
                        txtBox.BackColor = Color.White;
                        txtBox.ForeColor = Color.Black;
                        codCurso = txtBox.Text;
                    }
                    break;

                case "txtNombre":
                    if (!Regex.IsMatch(txtBox.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$"))
                    {
                        txtBox.BackColor = string.IsNullOrEmpty(txtBox.Text) ? Color.White : Color.Red;
                        txtBox.ForeColor = string.IsNullOrEmpty(txtBox.Text) ? Color.Black : Color.White;
                    }
                    else
                    {
                        txtBox.BackColor = Color.White;
                        txtBox.ForeColor = Color.Black;
                        nombre = txtBox.Text;
                    }
                    break;
            }
        }

        private bool ValidarEjecucion()
        {
            foreach (var campo in listaCampos)
            {
                if (campo.BackColor == Color.Red || (string.IsNullOrEmpty(campo.Text)))
                    return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarEjecucion())
            {
                campos = new List<string>()
                {
                    nombre,
                    codCurso
                };

                conexionDB.AnyadirCurso(campos);
                this.Close();
            }
            else
            {
                MessageBox.Show("Uno o varios campos son incorrectos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
