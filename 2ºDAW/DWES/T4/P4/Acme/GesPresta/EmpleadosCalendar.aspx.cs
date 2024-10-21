using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class EmpleadosCalendar : System.Web.UI.Page
    {
        List<Label> labelsError;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodEmp.Focus();
            labelsError = new List<Label>
            {
                lblError1,
                lblError2,
                lblError3
            };
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            lblValores.Visible = true;

            lblValores.Text = "VALORES DEL FORMULARIO" +
                              $"<br/> Código Empleado: {txtCodEmp.Text}" +
                              $"<br/> NIF: {txtNifEmp.Text}" +
                              $"<br/> Apellidos y Nombre: {txtNomEmp.Text}" +
                              $"<br/> Dirección: {txtDirEmp.Text}" +
                              $"<br/> Ciudad: {txtCiuEmp.Text}" +
                              $"<br/> Teléfonos: {txtTelEmp.Text}" +
                              $"<br/> Fecha de Nacimiento: {txtFnaEmp.Text}" +
                              $"<br/> Fecha de Incorporación: {txtFinEmp.Text}" +
                              $"<br/> Sexo:  {rblSexEmp.SelectedItem.Value}" +
                              $"<br/> Departamento: {ddlDepEmp.Text}";
        }

        private void VisualizarAntiguedad()
        {
            if (cFechaIngreso.SelectedDate != new DateTime(1, 1, 1))
            {
                DateTime dtHoy = DateTime.Now;
                TimeSpan diferencia = dtHoy - cFechaIngreso.SelectedDate;
                DateTime fechamin = new DateTime(1, 1, 1);

                txtAnyo.Text = ((fechamin + diferencia).Year - 1).ToString();
                txtMes.Text = ((fechamin + diferencia).Month - 1).ToString();
                txtDia.Text = ((fechamin + diferencia).Day).ToString();
            }
        }

        private void ValidarFechasCalendario()
        {
            DateTime dtHoy = DateTime.Now;

            if (cFechaIngreso.SelectedDate != new DateTime(1, 1, 1))
                lblError1.Visible = cFechaIngreso.SelectedDate < cFechaNacimiento.SelectedDate ? true : false;

            lblError2.Visible = cFechaIngreso.SelectedDate > dtHoy ? true : false;

            lblError3.Visible = cFechaNacimiento.SelectedDate > dtHoy ? true : false;
        }

        private void ValidarFechasTextBox()
        {
            DateTime dtHoy = DateTime.Now;

            if (txtFechIngreso.Text != "")
            {
                lblError1.Visible = Convert.ToDateTime(txtFechIngreso.Text) < cFechaNacimiento.SelectedDate ? true : false;

                lblError2.Visible = Convert.ToDateTime(txtFechIngreso.Text) > dtHoy ? true : false;

                lblError3.Visible = Convert.ToDateTime(txtFechIngreso.Text) > dtHoy ? true : false;
            }
        }

        private bool ComprobarErrores()
        {
            foreach (Label label in labelsError)
            {
                if (label.Visible == true)
                    return false;
            }

            return true;
        }

        protected void cFechaNacimiento_SelectionChanged(object sender, EventArgs e)
        {
            ValidarFechasCalendario();

            if (ComprobarErrores() == true || lblError1.Visible == true)
            {
                txtFechaNacimiento.Text = cFechaNacimiento.SelectedDate.ToShortDateString();
            }
            else if (lblError3.Visible == true || lblError1.Visible == true)
            {
                txtFechaNacimiento.Text = "";
            }

            if (ComprobarErrores() == true)
            {
                VisualizarAntiguedad();
            }
        }

        protected void cFechaIngreso_SelectionChanged(object sender, EventArgs e)
        {
            ValidarFechasCalendario();

            if (ComprobarErrores() == true)
            {
                txtFechIngreso.Text = cFechaIngreso.SelectedDate.ToShortDateString();
                VisualizarAntiguedad();
            }
            else if (lblError1.Visible == true || lblError2.Visible == true)
            {
                txtFechIngreso.Text = "";
                txtAnyo.Text = "";
                txtMes.Text = "";
                txtDia.Text = "";
            }
        }

        protected void txtFechaNacimiento_TextChanged(object sender, EventArgs e)
        {
            ValidarFechasTextBox();

            if (ComprobarErrores() == true || lblError1.Visible == true)
            {
                cFechaNacimiento.SelectedDate = Convert.ToDateTime(txtFechaNacimiento.Text);
                cFechaNacimiento.VisibleDate = Convert.ToDateTime(txtFechaNacimiento.Text);
            }
            else if (lblError3.Visible == true || lblError1.Visible == true)
            {
                txtFechaNacimiento.Text = "";
            }

            if (ComprobarErrores() == true)
            {
                VisualizarAntiguedad();
            }
        }

        protected void txtFechIngreso_TextChanged(object sender, EventArgs e)
        {
            ValidarFechasTextBox();

            if (ComprobarErrores() == true)
            {
                cFechaIngreso.SelectedDate = Convert.ToDateTime(txtFechIngreso.Text);
                cFechaIngreso.VisibleDate = Convert.ToDateTime(txtFechIngreso.Text);
                VisualizarAntiguedad();
            }
            else if (lblError1.Visible == true || lblError2.Visible == true)
            {
                txtFechIngreso.Text = "";
                txtAnyo.Text = "";
                txtMes.Text = "";
                txtDia.Text = "";
            }
        }
    }
}