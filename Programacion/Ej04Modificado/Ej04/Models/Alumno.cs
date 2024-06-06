using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej04
{
    public class Alumno : Persona
    {
        private string _idCursoPertenece;

        public string IdCursoPertenece
        {
            get => _idCursoPertenece;
            set => _idCursoPertenece = value;
        }

        public Alumno(int id, string dni, string nombre, 
                      string apellido1, string apellido2, string telefono, string email, 
                      string contrasenya, string rutaImgPerfil, string idCursoPertenece) : base(id, dni, nombre, apellido1, apellido2, 
                                                                                                telefono, email, contrasenya, rutaImgPerfil)
        {
            _idCursoPertenece = idCursoPertenece;
        }
    }
}
