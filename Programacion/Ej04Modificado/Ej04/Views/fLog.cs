using Ej04.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Ej04
{
    public partial class fLog : Form
    {
        private SqlDBHelper conexionBD = new SqlDBHelper();
        private string dni;

        public fLog()
        {
            InitializeComponent();
            picImgLogin.ImageLocation = Path.GetFullPath(@"..\..\Img\Default.png");
        }

        private void ValidarCampoContrasenya(TextBox contrasenya, string dni)
        {
            if (!conexionBD.ComporbarExistenciaContrasenya(contrasenya.Text, dni))
            {
                contrasenya.BackColor = string.IsNullOrEmpty(contrasenya.Text) ? Color.White : Color.Red;
                contrasenya.ForeColor = string.IsNullOrEmpty(contrasenya.Text) ? Color.Black : Color.White;
            }
            else
            {
                contrasenya.BackColor = Color.White;
                contrasenya.ForeColor = Color.Black;
            }
        }

        private bool ValidarCampos()
        {
            return (txtUsuario.BackColor != Color.Red && !string.IsNullOrEmpty(txtUsuario.Text)) &&
                   (txtContrasenya.BackColor != Color.Red && !string.IsNullOrEmpty(txtContrasenya.Text)); 
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                switch (conexionBD.ComporbarTipoUsuario(dni))
                {
                    case "ALUMNOS":
                        fAlumno formAlumno = new fAlumno(dni, conexionBD, this);
                        formAlumno.Show();
                        this.Visible = false;
                        break;
                    case "PROFESORES":
                        fProfesor formProfesor = new fProfesor(dni, conexionBD, this);
                        formProfesor.Show();
                        this.Visible = false;
                        break;
                    case "ADMINISTRADORES":
                        fAdministrador formAdministrador = new fAdministrador(dni, conexionBD, this);
                        formAdministrador.Show();
                        this.Visible = false;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Uno o varios campos no son validos");
            }
        }

        private void ControlErrores(object sender, EventArgs e)
        {
            var txtBox = (TextBox)sender;

            switch (txtBox.Name)
            {
                case "txtUsuario":
                    if (!conexionBD.ComprobarExistenciaDNI(txtBox.Text))
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

                    ValidarCampoContrasenya(txtContrasenya, txtBox.Text);
                    break;

                case "txtContrasenya":
                    ValidarCampoContrasenya(txtBox, dni);
                    break;
            }
        }
    }
}
