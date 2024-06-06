using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej04
{
    public class Administrador : Persona
    {
        public Administrador(int id, string dni, string nombre,
                             string apellido1, string apellido2, string telefono,
                             string email, string contrasenya, string rutaImgPerfil) : base(id, dni, nombre, apellido1, apellido2,
                                                                                            telefono, email, contrasenya, rutaImgPerfil)
        {

        }
    }
}
