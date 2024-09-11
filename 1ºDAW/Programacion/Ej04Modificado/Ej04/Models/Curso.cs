using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej04
{
    public class Curso
    {
        private string _id, _nombre;

        public string ID
        {
            get => _id;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public Curso(string id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
    }
}
