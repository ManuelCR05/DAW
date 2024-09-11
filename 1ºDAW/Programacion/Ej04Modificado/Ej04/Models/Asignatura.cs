using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej04
{
    public class Asignatura
    {
        private int _id;
        private string _nombre;

        public int ID 
        { 
            get => _id; 
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public Asignatura(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
    }
}
