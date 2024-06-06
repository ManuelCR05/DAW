using Ej04.Views;
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

namespace Ej04
{
    public partial class fGestionCursos : Form
    {
        private SqlDBHelper conexionDB;
        private Curso curso;
        private string nombre;
        private int posicion = 0;
        private List<string> IDs;

        public fGestionCursos(SqlDBHelper conexion)
        {
            InitializeComponent();
            conexionDB = conexion;
            conexionDB.EstablecerBD("SELECT * FROM CURSOS");
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$"))
            {
                txtNombre.BackColor = string.IsNullOrEmpty(txtNombre.Text) ? Color.White : Color.Red;
                txtNombre.ForeColor = string.IsNullOrEmpty(txtNombre.Text) ? Color.Black : Color.White;
            }
            else
            {
                txtNombre.BackColor = Color.White;
                txtNombre.ForeColor = Color.Black;
                nombre = txtNombre.Text;
            }
        }

        private void MostrarDatos(string id)
        {
            curso = conexionDB.GetCurso(id);

            txtID.Text = curso.ID;
            txtNombre.Text = curso.Nombre;
        }

        private void RecargarFormulario()
        {
            conexionDB.EstablecerBD("SELECT * FROM ASIGNATURAS");
            IDs = conexionDB.GetIDsCursos();
            txtContador.Text = conexionDB.NumRegistros != 0 ? $"{posicion + 1}" : posicion.ToString();
            lblContador.Text = $"/ {conexionDB.NumRegistros}";
            MostrarDatos(IDs[posicion]);
        }

        private void fGestionCursos_Load(object sender, EventArgs e)
        {
            txtContador.Text = conexionDB.NumRegistros != 0 ? $"{posicion + 1}" : posicion.ToString();
            lblContador.Text = $"/ {conexionDB.NumRegistros}";

            IDs = conexionDB.GetIDsCursos();

            if (IDs.Count == 0)
            {
                txtID.Text = "";
                txtNombre.Text = "";
            }
            else
            {
                MostrarDatos(IDs[posicion]);
            }
        }


        //--FUNCIONALIDADES DEL FORMULARIO--//
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar;

            if (!(txtNombre.BackColor == Color.Red) && !string.IsNullOrEmpty(txtNombre.Text))
            {
                confirmar = MessageBox.Show("¿Esta seguro que desea modificar los datos?", "", MessageBoxButtons.YesNo);

                if (confirmar == DialogResult.Yes)
                {
                    List<string> datos = new List<string>()
                    {
                        txtID.Text,
                        txtNombre.Text
                    };

                    conexionDB.ActualizarCurso(datos);
                }

                MostrarDatos(txtID.Text);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarDatos(IDs[posicion]);
        }

        private void btnAnyadir_Click(object sender, EventArgs e)
        {
            fAnyadirCurso formAnyadirCurso = new fAnyadirCurso(conexionDB);
            formAnyadirCurso.ShowDialog();
            RecargarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("¿Seguro qué desea eliminar el Curso?", "", MessageBoxButtons.YesNo);

            if (confirmar == DialogResult.Yes)
            {
                conexionDB.EliminarCurso(txtID.Text);

                posicion--;

                if (posicion < 0)
                    posicion = 0;

                RecargarFormulario();
            }
        }


        //--NAVEGACIÓN DEL FORMULARIO--//
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
