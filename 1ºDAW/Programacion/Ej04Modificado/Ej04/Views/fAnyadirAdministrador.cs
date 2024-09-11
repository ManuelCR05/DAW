using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej04.Views
{
    public partial class fAnyadirAdministrador : Form
    {
        private SqlDBHelper conexionDB;
        private string dni, nombre, apellido1, apellido2 = "", telefono, email, contrasenya;
        private List<string> campos;
        private List<TextBox> listaCampos;

        public fAnyadirAdministrador(SqlDBHelper conexion)
        {
            InitializeComponent();
            conexionDB = conexion;
            listaCampos = new List<TextBox>()
            {
                txtDNI,
                txtNombre,
                txtApellido1,
                txtApellido2,
                txtTelefono,
                txtEmail,
                txtContrasenya
            };
        }

        private void VisualizarErroresNombreApellido(TextBox campo)
        {
            if (!Regex.IsMatch(campo.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$"))
            {
                campo.BackColor = string.IsNullOrEmpty(campo.Text) ? Color.White : Color.Red;
                campo.ForeColor = string.IsNullOrEmpty(campo.Text) ? Color.Black : Color.White;
            }
            else
            {
                campo.BackColor = Color.White;
                campo.ForeColor = Color.Black;

                if (campo.Name == "txtNombre")
                    nombre = campo.Text;
                else
                    apellido1 = campo.Text;
            }
        }

        private void VisualizarErrores(object sender, EventArgs e)
        {
            var txtBox = (TextBox)sender;

            switch (txtBox.Name)
            {
                case "txtDNI":
                    if (!Regex.IsMatch(txtBox.Text, @"^[0-9]{8}[A-Z]$") ||
                        conexionDB.ComprobarExistenciaDNI(txtBox.Text))
                    {
                        txtBox.BackColor = string.IsNullOrEmpty(txtBox.Text) ? Color.White : Color.Red;
                        txtBox.ForeColor = string.IsNullOrEmpty(txtBox.Text) ? Color.Black : Color.White;
                    }
                    else
                    {
                        txtBox.BackColor = Color.White;
                        txtBox.ForeColor = Color.Black;
                        dni = txtBox.Text;
                    }
                    break;

                case "txtNombre":
                    VisualizarErroresNombreApellido(txtBox);
                    break;

                case "txtApellido1":
                    VisualizarErroresNombreApellido(txtBox);
                    break;

                case "txtApellido2":
                    if (!Regex.IsMatch(txtBox.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$") && !string.IsNullOrEmpty(txtBox.Text))
                    {
                        txtBox.BackColor = string.IsNullOrEmpty(txtBox.Text) ? Color.White : Color.Red;
                        txtBox.ForeColor = string.IsNullOrEmpty(txtBox.Text) ? Color.Black : Color.White;
                    }
                    else
                    {
                        txtBox.BackColor = Color.White;
                        txtBox.ForeColor = Color.Black;
                        apellido2 = txtBox.Text;
                    }
                    break;

                case "txtTelefono":
                    if (!Regex.IsMatch(txtBox.Text, @"^[0-9]{9}$"))
                    {
                        txtBox.BackColor = string.IsNullOrEmpty(txtBox.Text) ? Color.White : Color.Red;
                        txtBox.ForeColor = string.IsNullOrEmpty(txtBox.Text) ? Color.Black : Color.White;
                    }
                    else
                    {
                        txtBox.BackColor = Color.White;
                        txtBox.ForeColor = Color.Black;
                        telefono = txtBox.Text;
                    }
                    break;

                case "txtEmail":
                    if (!Regex.IsMatch(txtBox.Text, @"^[a-zA-ZÑñáéíóúÁÉÍÓÚ0-9._%+-]+@{1}[a-zA-Z.]+\.{1}[a-z]{2,}$"))
                    {
                        txtBox.BackColor = string.IsNullOrEmpty(txtBox.Text) ? Color.White : Color.Red;
                        txtBox.ForeColor = string.IsNullOrEmpty(txtBox.Text) ? Color.Black : Color.White;
                    }
                    else
                    {
                        txtBox.BackColor = Color.White;
                        txtBox.ForeColor = Color.Black;
                        email = txtBox.Text;
                    }
                    break;

                case "txtContrasenya":
                    if (string.IsNullOrEmpty(txtBox.Text))
                    {
                        txtBox.BackColor = Color.Red;
                    }
                    else
                    {
                        txtBox.BackColor = Color.White;
                        contrasenya = txtBox.Text;
                    }
                    break;
            }
        }

        private bool ValidarEjecucion()
        {
            foreach (var campo in listaCampos)
            {
                if (campo.BackColor == Color.Red || (string.IsNullOrEmpty(campo.Text) && campo.Name != "txtApellido2"))
                    return false;
            }

            return true;
        }

        private void chkContrasenya_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenya.PasswordChar = chkContrasenya.Checked ? '\0' : '*';
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarEjecucion())
            {
                campos = new List<string>()
                {
                    dni,
                    nombre,
                    apellido1,
                    apellido2,
                    telefono,
                    email,
                    contrasenya
                };

                conexionDB.AnyadirAdministrador(campos);
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
