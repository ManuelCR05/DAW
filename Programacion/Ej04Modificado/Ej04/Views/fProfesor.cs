using Ej04.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej04
{
    public partial class fProfesor : Form
    {
        private SqlDBHelper conexionDB;
        private Profesor profesor;
        private string dniLogin;
        private string nombre, apellido1, apellido2, telefono, email, contrasenya, codCurso;
        private List<TextBox> listaCampos;
        private fLog log;

        public fProfesor(string dni, SqlDBHelper conexion, fLog log)
        {
            InitializeComponent();
            conexionDB = conexion;
            dniLogin = dni;
            conexionDB.EstablecerBD($"SELECT p.*, pr.idCursoEsTutor FROM PERSONAS p, PROFESORES pr WHERE pr.idProfesor = p.idPersona AND p.DNI = '{dni}'");
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
            string id = conexionDB.GetIDporDNIProfesor(dniLogin);

            profesor = conexionDB.GetProfesor(id);

            txtID.Text = profesor.ID.ToString();
            txtDNI.Text = profesor.DNI;
            txtNombre.Text = profesor.Nombre;
            txtApellido1.Text = profesor.Apellido1;
            txtApellido2.Text = profesor.Apellido2;
            txtTelefono.Text = profesor.Telefono;
            txtEmail.Text = profesor.Email;
            txtContrasenya.Text = profesor.Contrasenya;
            MessageBox.Show(profesor.IdCursoEsTutor);
            cmbCodCurso.SelectedItem = string.IsNullOrEmpty(profesor.IdCursoEsTutor) ? "No es tutor" : profesor.IdCursoEsTutor;

            if (!string.IsNullOrEmpty(profesor.RutaImgPerfil))
                picImgProfesor.ImageLocation = Path.GetFullPath($@"{profesor.RutaImgPerfil}");
        }

        private void fProfesor_Load(object sender, EventArgs e)
        {
            cmbCodCurso.Items.Add("No es tutor");
            List<string> idCursos = conexionDB.GetIdCursos();
            for (int i = 0; i < idCursos.Count; i++)
            {
                cmbCodCurso.Items.Add(idCursos[i]);
            }

            MostrarDatos();
        }

        private void chkContrasenya_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenya.PasswordChar = chkContrasenya.Checked ? '\0' : '*';
        }

        private void chkTutor_CheckedChanged(object sender, EventArgs e)
        {
            cmbCodCurso.Enabled = chkTutor.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            codCurso = cmbCodCurso.Text == "No es tutor" ? null : cmbCodCurso.Text;

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
                        codCurso
                    };

                    conexionDB.ActualizarProfesor(datos);
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

        private void fProfesor_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Close();
        }
    }
}
