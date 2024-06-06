using Ej04.Views;
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
using System.Windows.Forms;

namespace Ej04
{
    public partial class fGestionProfesores : Form
    {
        private SqlDBHelper conexionDB;
        private Profesor profesor;
        private string nombre, apellido1, apellido2, telefono, email, contrasenya, codCurso;
        private int posicion = 0;
        private List<TextBox> listaCampos;
        private List<string> IDs;

        public fGestionProfesores(SqlDBHelper conexion)
        {
            InitializeComponent();
            conexionDB = conexion;
            conexionDB.EstablecerBD("SELECT p.*, pr.idCursoEsTutor FROM PERSONAS p, PROFESORES pr WHERE p.idPersona = pr.idProfesor");
            listaCampos = new List<TextBox>()
            {
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

        private void MostrarDatos(string dni)
        {
            profesor = conexionDB.GetProfesor(dni);

            txtID.Text = profesor.ID.ToString();
            txtDNI.Text = profesor.DNI;
            txtNombre.Text = profesor.Nombre;
            txtApellido1.Text = profesor.Apellido1;
            txtApellido2.Text = profesor.Apellido2;
            txtTelefono.Text = profesor.Telefono;
            txtEmail.Text = profesor.Email;
            txtContrasenya.Text = profesor.Contrasenya;
            cmbCodCurso.SelectedItem = string.IsNullOrEmpty(profesor.IdCursoEsTutor) ? "No es tutor" : profesor.IdCursoEsTutor;

            if (!string.IsNullOrEmpty(profesor.RutaImgPerfil))
                picImgProfesor.ImageLocation = Path.GetFullPath($@"{profesor.RutaImgPerfil}");
            else
                picImgProfesor.Image = null;
        }

        private void RecargarFormulario()
        {
            conexionDB.EstablecerBD("SELECT p.*, pr.idCursoEsTutor FROM PERSONAS p, PROFESORES pr WHERE p.idPersona = pr.idProfesor");
            IDs = conexionDB.GetIDsProfesores();
            txtContador.Text = conexionDB.NumRegistros != 0 ? $"{posicion + 1}" : posicion.ToString();
            lblContador.Text = $"/ {conexionDB.NumRegistros}";
            MostrarDatos(IDs[posicion]);
        }

        private void fGestionProfesores_Load(object sender, EventArgs e)
        {
            cmbCodCurso.Items.Add("No es tutor");
            List<string> idCursos = conexionDB.GetIdCursos();
            for (int i = 0; i < idCursos.Count; i++)
            {
                cmbCodCurso.Items.Add(idCursos[i]);
            }

            txtContador.Text = conexionDB.NumRegistros != 0 ? $"{posicion + 1}" : posicion.ToString();
            lblContador.Text = $"/ {conexionDB.NumRegistros}";

            IDs = conexionDB.GetIDsProfesores();

            MostrarDatos(IDs[posicion]);
        }

        private void chkContrasenya_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenya.PasswordChar = chkContrasenya.Checked ? '\0' : '*';
        }

        private void chkCambiarTutoria_CheckedChanged(object sender, EventArgs e)
        {
            cmbCodCurso.Enabled = chkCambiarTutoria.Checked;
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

                MostrarDatos(txtID.Text);
            }
            else
            {
                MessageBox.Show("Uno o varios campos son incorrectos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarDatos(IDs[posicion]);
        }

        private void btnAnyadir_Click(object sender, EventArgs e)
        {
            fAnyadirProfesor formAnyadirProfesor = new fAnyadirProfesor(conexionDB);
            formAnyadirProfesor.ShowDialog();
            RecargarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("¿Seguro qué desea eliminar al Profesor?", "", MessageBoxButtons.YesNo);

            if (confirmar == DialogResult.Yes)
            {
                conexionDB.EliminarProfesor(txtID.Text);

                posicion--;

                if (posicion < 0)
                    posicion = 0;

                RecargarFormulario();
            }
        }



        private void btnPrimero_Click(object sender, EventArgs e)
        {
            posicion = 0;
            MostrarDatos(IDs[posicion]);
            txtContador.Text = $"{posicion + 1}";
            lblContador.Text = $"/ {conexionDB.NumRegistros}";
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicion - 1 >= 0)
            {
                posicion--;
                MostrarDatos(IDs[posicion]);
                txtContador.Text = $"{posicion + 1}";
                lblContador.Text = $"/ {conexionDB.NumRegistros}";
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (posicion + 1 <= conexionDB.NumRegistros - 1)
            {
                posicion++;
                MostrarDatos(IDs[posicion]);
                txtContador.Text = $"{posicion + 1}";
                lblContador.Text = $"/ {conexionDB.NumRegistros}";
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            posicion = conexionDB.NumRegistros - 1;
            MostrarDatos(IDs[posicion]);
            txtContador.Text = $"{posicion + 1}";
            lblContador.Text = $"/ {conexionDB.NumRegistros}";
        }
    }
}
