using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej04
{
    public class Profesor : Persona
    {
        private string _idCursoEsTutor;

        public string IdCursoEsTutor
        {
            get => _idCursoEsTutor;
            set => _idCursoEsTutor = value;
        }

        public Profesor(int id, string dni, string nombre,
                      string apellido1, string apellido2, string telefono, string email, 
                      string contrasenya, string rutaImgPerfil, string idCursoEsTutor) : base(id, dni, nombre, apellido1, apellido2,
                                                                                              telefono, email, contrasenya, rutaImgPerfil)
        {
            _idCursoEsTutor = idCursoEsTutor;
        }
    }
}
