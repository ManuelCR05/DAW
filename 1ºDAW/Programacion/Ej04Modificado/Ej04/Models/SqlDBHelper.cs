using Microsoft.SqlServer.Server;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Ej04.Views
{
    public class SqlDBHelper
    {
        private DataSet dSet;
        private SqlDataAdapter dAdapter;
        private SqlConnection conexion;
        private int _numRegistros, _numDatos;
        private string _tabla = "PERSONAS";

        public int NumRegistros
        {
            get => _numRegistros;
        }

        public int NumDatos
        {
            get => _numDatos;
        }

        public string Tabla
        {
            get => _tabla;
            set => _tabla = value;
        }

        public SqlDBHelper()
        {
            string relative = @"..\..\AppData\INSTITUTO.mdf";
            string absolute = Path.GetFullPath(relative);
            string cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=" + absolute + " ;Integrated Security=True;" +
                "Connect Timeout=30";

            conexion = new SqlConnection(cadenaConexion);

            EstablecerBD($"SELECT * FROM {_tabla}");
        }

        private void AbrirConexion()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
        }

        private void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }

        public void EstablecerBD(string select)
        {
            AbrirConexion();

            dAdapter = new SqlDataAdapter(select, conexion);
            dSet = new DataSet();

            dAdapter.Fill(dSet, _tabla);

            _numRegistros = dSet.Tables[_tabla].Rows.Count;
            _numDatos = dSet.Tables[_tabla].Columns.Count;

            CerrarConexion();
        }

        public bool ComprobarExistenciaDNI(string DNI)
        {
            AbrirConexion();

            string select = $"SELECT DNI FROM PERSONAS WHERE DNI = '{DNI}'";

            SqlCommand cmd = new SqlCommand(select, conexion);

            object res = cmd.ExecuteScalar();

            CerrarConexion();

            return res != null;
        }

        public bool ComporbarExistenciaContrasenya(string contrasenya, string DNI)
        {
            AbrirConexion();

            string select = $"SELECT contrasenya FROM PERSONAS WHERE DNI = '{DNI}'";

            SqlCommand cmd = new SqlCommand(select, conexion);

            object res = cmd.ExecuteScalar();

            CerrarConexion();

            return res != null && contrasenya == res.ToString();
        }

        public bool ComporbarExistenciaCodCurso(string codCurso)
        {
            AbrirConexion();

            string select = $"SELECT idCurso FROM CURSOS";

            SqlCommand cmd = new SqlCommand(select, conexion);
            SqlDataReader registros = cmd.ExecuteReader();

            while(registros.Read())
            {
                if (registros["idCurso"].ToString() == codCurso)
                    return true;
            }

            CerrarConexion();

            return false;
        }

        public string ComporbarTipoUsuario(string DNI)
        {
            AbrirConexion();

            SqlCommand cmd;
            SqlDataReader registro;
            string selectDniAdmin = $"SELECT p.DNI FROM PERSONAS p, ADMINISTRADORES a WHERE p.idPersona = a.idAdministrador";
            string selectDniProf = $"SELECT p.DNI FROM PERSONAS p, PROFESORES pr WHERE p.idPersona = pr.idProfesor";
            string selectDniAlum = $"SELECT p.DNI FROM PERSONAS p, ALUMNOS a WHERE p.idPersona = a.idAlumno";

            List<Tuple<string, string>> selects = new List<Tuple<string, string>>
            {
                Tuple.Create(selectDniAdmin, "ADMINISTRADORES"),
                Tuple.Create(selectDniProf, "PROFESORES"),
                Tuple.Create(selectDniAlum, "ALUMNOS")
            };
            
            for (int i = 0; i < selects.Count; i++)
            {
                cmd = new SqlCommand(selects[i].Item1, conexion);
                registro = cmd.ExecuteReader();
                while(registro.Read())
                {
                    if (registro["DNI"].ToString() == DNI)
                    {
                        registro.Close();
                        return selects[i].Item2;
                    }
                }
                registro.Close();
            }

            CerrarConexion();

            return null;
        }


        //--OBTENER REGISTROS--//
        //Método genérico que obtiene un registro en concreto de la base de datos y
        //a traves de un delegado devulve "T" (cualquier cosas - en esete caso sera algun objeto).
        //El parametro "Func<SqlDataReader, T>" es el Delegado que recibe como parametro un SqlDataReader
        //y devulve cualquier cosa ("T").
        private T GetRegistro<T>(Func<SqlDataReader, T> instanciarPersona, string select)
        {
            AbrirConexion();

            SqlCommand cmd = new SqlCommand(select, conexion);
            SqlDataReader registroAux = cmd.ExecuteReader();
            T persona = default(T);

            if (registroAux.Read())
            {
                persona = instanciarPersona(registroAux);
            }

            CerrarConexion();

            return persona;
        }

        //Métodos a los que llama el método generico a traves del Delegado para realizar las
        //instancias de los objetos pertinentes.
        private Administrador InstanciarAdministrador(SqlDataReader registro)
        {
            return new Administrador((int)registro["idPersona"], registro["DNI"].ToString(),
                                     registro["nombre"].ToString(), registro["apellido1"].ToString(),
                                     registro["apellido2"].ToString(), registro["telefono"].ToString(),
                                     registro["email"].ToString(), registro["contrasenya"].ToString(),
                                     registro["rutaImagenPerfil"].ToString());
        }

        private Alumno InstanciarAlumno(SqlDataReader registro)
        {
            return new Alumno((int)registro["idPersona"], registro["DNI"].ToString(),
                              registro["nombre"].ToString(), registro["apellido1"].ToString(),
                              registro["apellido2"].ToString(), registro["telefono"].ToString(),
                              registro["email"].ToString(), registro["contrasenya"].ToString(),
                              registro["rutaImagenPerfil"].ToString(), registro["idCursoPertenece"].ToString());
        }

        private Profesor InstanciarProfesor(SqlDataReader registro)
        {
            return new Profesor((int)registro["idPersona"], registro["DNI"].ToString(),
                                registro["nombre"].ToString(), registro["apellido1"].ToString(),
                                registro["apellido2"].ToString(), registro["telefono"].ToString(),
                                registro["email"].ToString(), registro["contrasenya"].ToString(),
                                registro["rutaImagenPerfil"].ToString(), registro["idCursoEsTutor"].ToString());
        }

        private Asignatura InstanciarAsignatura(SqlDataReader registro)
        {
            return new Asignatura((int)registro[0], registro[1].ToString());
        }

        private Curso InstanciarCurso(SqlDataReader registro)
        {
            return new Curso (registro[1].ToString(), registro[0].ToString());
        }


        public Administrador GetAdministrador(string id)
        {
            string select = $"SELECT p.* FROM PERSONAS p, ADMINISTRADORES a WHERE p.idPersona = {id} AND a.idAdministrador = {id}";
            return GetRegistro(InstanciarAdministrador, select);
        }

        public Alumno GetAlumno(string id)
        {
            string select = $"SELECT p.*, a.idCursoPertenece FROM PERSONAS p, ALUMNOS a WHERE p.idPersona = {id} AND a.idAlumno = {id}";
            return GetRegistro(InstanciarAlumno, select);
        }

        public Profesor GetProfesor(string id)
        {
            string select = $"SELECT p.*, pr.idCursoEsTutor FROM PERSONAS p, PROFESORES pr WHERE p.idPersona = {id} AND pr.idProfesor = {id}";
            return GetRegistro(InstanciarProfesor, select);
        }

        public Asignatura GetAsignatura(string id)
        {
            string select = $"SELECT * FROM ASIGNATURAS WHERE idAsignatura = {id}";
            return GetRegistro(InstanciarAsignatura, select);
        }

        public Curso GetCurso(string id)
        {
            string select = $"SELECT * FROM CURSOS WHERE idCurso = '{id}'";
            return GetRegistro(InstanciarCurso, select);
        }


        //--AÑADIR REGISTROS--//
        private void AnyadirRegisro(Func<List<string>, string> anyadirObjeto, List<string> datos) 
        {
            AbrirConexion();

            SqlCommand cmd = new SqlCommand(anyadirObjeto(datos), conexion);
            cmd.ExecuteNonQuery();

            CerrarConexion();
        }

        private string InsertAlumno(List<string> datosAlumno)
        {
            string insert = $"INSERT INTO PERSONAS VALUES('{datosAlumno[0]}', '{datosAlumno[1]}', " +
                            $"'{datosAlumno[2]}', '{datosAlumno[3]}', '{datosAlumno[4]}', " +
                            $"'{datosAlumno[5]}', '{datosAlumno[6]}', NULL) " +
                            $"DECLARE @newID INT = SCOPE_IDENTITY() " +
                            $"INSERT INTO ALUMNOS VALUES(@newID, '{datosAlumno[7]}')";
            return insert;
        }

        private string InsertProfesor(List<string> datosProfesor)
        {
            string idCurso = datosProfesor[7] == null ? "NULL" : $"'{datosProfesor[7]}'";

            string insert = $"INSERT INTO PERSONAS VALUES('{datosProfesor[0]}', '{datosProfesor[1]}', " +
                            $"'{datosProfesor[2]}', '{datosProfesor[3]}', '{datosProfesor[4]}', " +
                            $"'{datosProfesor[5]}', '{datosProfesor[6]}', NULL) " +
                            $"DECLARE @newID INT = SCOPE_IDENTITY() " +
                            $"INSERT INTO PROFESORES VALUES(@newID, {idCurso})";
            return insert;
        }

        private string InsertAdministrador(List<string> datosAdministrador)
        {
            string insert = $"INSERT INTO PERSONAS VALUES('{datosAdministrador[0]}', '{datosAdministrador[1]}', " +
                            $"'{datosAdministrador[2]}', '{datosAdministrador[3]}', '{datosAdministrador[4]}', " +
                            $"'{datosAdministrador[5]}', '{datosAdministrador[6]}', NULL) " +
                            $"DECLARE @newID INT = SCOPE_IDENTITY() " +
                            $"INSERT INTO ADMINISTRADORES VALUES(@newID)";
            return insert;
        }

        private string InsertAsignatura(List<string> datos)
        {
            string insert = $"INSERT INTO ASIGNATURAS VALUES('{datos[0]}')";
            return insert;
        }

        private string InsertCurso(List<string> datos)
        {
            string insert = $"INSERT INTO CURSOS VALUES('{datos[0]}', '{datos[1]}')";
            return insert;
        }

        public void AnyadirAlumno(List<string> datos)
        {
            AnyadirRegisro(InsertAlumno, datos);
        }

        public void AnyadirProfesor(List<string> datos)
        {
            AnyadirRegisro(InsertProfesor, datos);
        }

        public void AnyadirAdministrador(List<string> datos)
        {
            AnyadirRegisro(InsertAdministrador, datos);
        }

        public void AnyadirAsignatura(List<string> datos)
        {
            AnyadirRegisro(InsertAsignatura, datos);
        }

        public void AnyadirCurso(List<string> datos)
        {
            AnyadirRegisro(InsertCurso, datos);
        }



        //--ACTUALIZAR REGISTROS--//
        private void ActualizarRegistro(Func<List<string>, string> updateObjeto, List<string> datos)
        {
            AbrirConexion();

            SqlCommand cmd = new SqlCommand(updateObjeto(datos), conexion);
            cmd.ExecuteNonQuery();

            CerrarConexion();
        }

        private string UpdateAdministrador(List<string> datosPersona)
        {
            string update = $"UPDATE PERSONAS SET nombre = '{datosPersona[1]}', " +
                            $"apellido1 = '{datosPersona[2]}', apellido2 = '{datosPersona[3]}', " +
                            $"telefono = '{datosPersona[4]}', email = '{datosPersona[5]}', " +
                            $"contrasenya = '{datosPersona[6]}' WHERE idPersona = '{datosPersona[0]}'";
            return update;
        }

        private string UpdateAlumno(List<string> datosAlumno)
        {
            string update = $"UPDATE PERSONAS SET nombre = '{datosAlumno[1]}', " +
                            $"apellido1 = '{datosAlumno[2]}', apellido2 = '{datosAlumno[3]}', " +
                            $"telefono = '{datosAlumno[4]}', email = '{datosAlumno[5]}', " +
                            $"contrasenya = '{datosAlumno[6]}' WHERE idPersona = '{datosAlumno[0]}'; " +
                            $"UPDATE ALUMNOS SET idCursoPertenece = '{datosAlumno[7]}' " +
                            $"WHERE idAlumno = {datosAlumno[0]}";
            return update;
        }

        private string UpdateProfesor(List<string> datosProfesor)
        {
            string idCurso = datosProfesor[7] == null ? "NULL" : $"'{datosProfesor[7]}'";

            string update = $"UPDATE PERSONAS SET nombre = '{datosProfesor[1]}', " +
                            $"apellido1 = '{datosProfesor[2]}', apellido2 = '{datosProfesor[3]}', " +
                            $"telefono = '{datosProfesor[4]}', email = '{datosProfesor[5]}', " +
                            $"contrasenya = '{datosProfesor[6]}' WHERE idPersona = '{datosProfesor[0]}'; " +
                            $"UPDATE PROFESORES SET idCursoEsTutor = {idCurso} " +
                            $"WHERE idProfesor = {datosProfesor[0]}";
            return update;
        }

        private string UpdateCurso(List<string> datosCurso)
        {
            string update = $"UPDATE CURSOS SET nombre = '{datosCurso[1]}' " +
                            $"WHERE idCurso = '{datosCurso[0]}'";

            return update;
        }

        private string UpdateAsignatura(List<string> datosAsignatura)
        {
            string update = $"UPDATE ASIGNATURAS SET nombre = '{datosAsignatura[1]}' " +
                            $"WHERE idAsignatura = '{datosAsignatura[0]}'";

            return update;
        }

        public void ActualizarAlumno(List<string> datos)
        {
            ActualizarRegistro(UpdateAlumno, datos);
        }

        public void ActualizarProfesor(List<string> datos)
        {
            ActualizarRegistro(UpdateProfesor, datos);
        }

        public void ActualizarAdministrador(List<string> datos)
        {
            ActualizarRegistro(UpdateAdministrador, datos);
        }

        public void ActualizarCurso(List<string> datos)
        {
            ActualizarRegistro(UpdateCurso, datos);
        }

        public void ActualizarAsignatura(List<string> datos)
        {
            ActualizarRegistro(UpdateAsignatura, datos);
        }


        //--ELIMINAR REGISTROS--//
        private void EliminarRegistro(Func<string, string> deleteObjeto, string id)
        {
            AbrirConexion();

            SqlCommand cmd = new SqlCommand(deleteObjeto(id), conexion);
            cmd.ExecuteNonQuery();

            CerrarConexion();
        }

        private string DeleteAlumno(string id)
        {
            string delete = $"DELETE FROM ALUMNOS WHERE idAlumno = {id} " +
                            $"DELETE FROM PERSONAS WHERE idPersona = {id}";
            return delete;
        }

        private string DeleteProfesor(string id)
        {
            string delete = $"DELETE FROM PROFESORES WHERE idProfesor = {id} " +
                            $"DELETE FROM PERSONAS WHERE idPersona = {id}";
            return delete;
        }

        private string DeleteAdministrador(string id)
        {
            string delete = $"DELETE FROM ADMINISTRADORES WHERE idAdministrador = {id} " +
                            $"DELETE FROM PERSONAS WHERE idPersona = {id}";
            return delete;
        }

        private string DeleteCurso(string id)
        {
            string delete = $"DELETE FROM CURSOS WHERE idCurso = '{id}'";
            return delete;
        }

        private string DeleteAsignatura(string id)
        {
            string delete = $"DELETE FROM ASIGNATURAS WHERE idAsignatura = {id}";
            return delete;
        }


        public void EliminarAlumno(string id)
        {
            EliminarRegistro(DeleteAlumno, id);
        }

        public void EliminarProfesor(string id)
        {
            EliminarRegistro(DeleteProfesor, id);
        }

        public void EliminarAdministrador(string id)
        {
            EliminarRegistro(DeleteAdministrador, id);
        }

        public void EliminarAsignatura(string id)
        {
            EliminarRegistro(DeleteAsignatura, id);
        }

        public void EliminarCurso(string id)
        {
            EliminarRegistro(DeleteCurso, id);
        }


        public int GetSiguienteIdPersonas()
        {
            AbrirConexion();

            int id = 0;
            string select = "SELECT TOP (1) idPersona + 1 AS idPersona FROM PERSONAS ORDER BY idPersona DESC";
            SqlCommand cmd = new SqlCommand(select, conexion);
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                id = (int)registro["idPersona"];
            }

            CerrarConexion();

            return id;
        }

        public List<string> GetIdCursos()
        {
            List<string> idCursos = new List<string>();

            AbrirConexion();

            string select = "SELECT idCurso FROM CURSOS";
            SqlCommand cmd = new SqlCommand(select, conexion);
            SqlDataReader registros = cmd.ExecuteReader();

            while (registros.Read())
            {
                idCursos.Add(registros["idCurso"].ToString());
            }

            CerrarConexion();
            return idCursos;
        }



        private List<string> GetIDs(string select, string columna)
        {
            List<string> dnis = new List<string>();

            AbrirConexion();

            SqlCommand cmd = new SqlCommand(select, conexion);
            SqlDataReader registros = cmd.ExecuteReader();

            while (registros.Read())
            {
                dnis.Add(registros[columna].ToString());
            }

            CerrarConexion();
            return dnis;
        }

        public List<string> GetIDsAlumnos()
        {
            string select = "SELECT idPersona FROM PERSONAS WHERE idPersona = ANY(SELECT idAlumno FROM ALUMNOS)";
            return GetIDs(select, "idPersona");
        }

        public List<string> GetIDsProfesores()
        {
            string select = "SELECT idPersona FROM PERSONAS WHERE idPersona = ANY(SELECT idProfesor FROM PROFESORES)";
            return GetIDs(select, "idPersona");
        }

        public List<string> GetIDsAsignaturas()
        {
            string select = "SELECT idAsignatura FROM ASIGNATURAS";
            return GetIDs(select, "idAsignatura");
        }

        public List<string> GetIDsCursos()
        {
            string select = "SELECT idCurso FROM CURSOS";
            return GetIDs(select, "idCurso");
        }

        /*
        public List<string> GetDNIsAdministradores()
        {
            return GetDNIs("idAdministrador", "ADMINISTRADORES");
        }*/



        private string GetIDporDNI(string select)
        {
            AbrirConexion();

            SqlCommand cmd = new SqlCommand(select, conexion);
            object id = cmd.ExecuteScalar();

            CerrarConexion();
            return id.ToString();
        }

        public string GetIDporDNIAlumno(string dni)
        {
            string select = $"SELECT a.idAlumno FROM ALUMNOS a, PERSONAS p WHERE p.DNI = '{dni}' AND a.idAlumno = p.idPersona";
            return GetIDporDNI(select);
        }

        public string GetIDporDNIProfesor(string dni)
        {
            string select = $"SELECT pr.idProfesor FROM PRFOESORES pr, PERSONAS p WHERE p.DNI = '{dni}' AND pr.idProfesor = p.idPersona";
            return GetIDporDNI(select);
        }

        public string GetIDporDNIAdministrador(string dni)
        {
            string select = $"SELECT a.idAdministrador FROM ADMINISTRADORES a, PERSONAS p WHERE p.DNI = '{dni}' AND a.idAdministrador = p.idPersona";
            return GetIDporDNI(select);
        }
    }
}