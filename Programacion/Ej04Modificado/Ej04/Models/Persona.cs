using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej04
{
    public class Persona
    {
        private int _id;
        private string _dni, _nombre, _apellido1, _apellido2, _telefono, _email, _contrasenya, _rutaImgPerfil;

        public int ID
        {
            get => _id;
        }

        public string DNI
        {
            get => _dni;
            set => _dni = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public string Apellido1
        {
            get => _apellido1; 
            set => _apellido1 = value;
        }

        public string Apellido2
        {
            get => _apellido2; 
            set => _apellido2 = value;
        }

        public string Telefono
        {
            get => _telefono; 
            set => _telefono = value;

        }

        public string Email
        {
            get => _email; 
            set => _email = value;
        }

        public string Contrasenya
        {
            get => _contrasenya; 
            set => _contrasenya = value;
        }

        public string RutaImgPerfil
        {
            get => _rutaImgPerfil;
            set => _rutaImgPerfil = value;
        }

        public Persona(int id, string dni, string nombre, string apellido1, string apellido2, 
                       string telefono, string email, string contrasenya, string rutaImgPerfil)
        {
            _id = id;
            _dni = dni;
            _nombre = nombre;
            _apellido1 = apellido1;
            _apellido2 = apellido2;
            _telefono = telefono;
            _email = email;
            _contrasenya = contrasenya;
            _rutaImgPerfil = rutaImgPerfil;
        }
    }
}
