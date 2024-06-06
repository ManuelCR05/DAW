using Ej04.Views;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Ej04
{
    public partial class fAlumno : Form
    {
        private SqlDBHelper conexionDB;
        private Alumno alumno;
        private string dniLogin;
        private string nombre, apellido1, apellido2, telefono, email, contrasenya;
        private List<TextBox> listaCampos;
        private fLog log;

        public fAlumno(string dni, SqlDBHelper conexion, fLog log)
        {
            InitializeComponent();
            conexionDB = conexion;
            this.dniLogin = dni;
            conexionDB.EstablecerBD($"SELECT p.*, a.idCursoPertenece FROM PERSONAS p, ALUMNOS a WHERE a.idAlumno = p.idPersona AND p.DNI = '{dni}'");
            listaCampos = new List<TextBox>()
            {
                txtNombre,
                txtApellido1,
                txtApellido2,
                txtTelefono,
                txtEmail,
                txtContrasenya
            };
            this.log = log;
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

        private void MostrarDatos()
        {
            string id = conexionDB.GetIDporDNIAlumno(dniLogin);

            alumno = conexionDB.GetAlumno(id);

            txtID.Text = alumno.ID.ToString();
            txtDNI.Text = alumno.DNI;
            txtNombre.Text = alumno.Nombre;
            txtApellido1.Text = alumno.Apellido1;
            txtApellido2.Text = alumno.Apellido2;
            txtTelefono.Text = alumno.Telefono;
            txtEmail.Text = alumno.Email;
            txtContrasenya.Text = alumno.Contrasenya;
            txtCodCurso.Text = alumno.IdCursoPertenece;

            if (!string.IsNullOrEmpty(alumno.RutaImgPerfil))
                picImgAlumno.ImageLocation = Path.GetFullPath($@"{alumno.RutaImgPerfil}");
        }

        private void fAlumno_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void chkContrasenya_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenya.PasswordChar = chkContrasenya.Checked ? '\0' : '*';
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar;

            if (ValidarEjecucion())
            {
                confirmar = MessageBox.Show("¿Esta seguro que desea modificar los datos?", "", MessageBoxButtons.YesNo);

                if (confirmar == DialogResult.Yes)
                {
                    List<string> datos = new List<string>()
                    {
                        txtID.Text,
                        nombre,
                        apellido1,
                        apellido2,
                        telefono,
                        email,
                        contrasenya,
                        txtCodCurso.Text
                    };

                    conexionDB.ActualizarAlumno(datos);
                }

                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Uno o varios campos son incorrectos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void fAlumno_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Close();
        }
    }
}
