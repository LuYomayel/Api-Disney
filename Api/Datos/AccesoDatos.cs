using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;



namespace Api.Datos

{
    public class AccesoDatos
    {

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {
            conexion = new SqlConnection("Data Source = DESKTOP-91DUSI5\\SQLEXPRESS; Initial Catalog = Disney; Uid = Luciano; Pwd = 02320434321l");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void setearProcedimiento(string procedimiento)
        {
            
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedimiento;
            
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        internal void ejectutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }
        public void EjecutarProcedimiento(string nombreProcedimiento, List<Parametro> parametros)
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = nombreProcedimiento;
            try
            {
                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        if (!parametro.Salida)
                        { comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor); }
                        else
                        { comando.Parameters.Add(parametro.Nombre, SqlDbType.VarChar, 100).Direction = ParameterDirection.Output; }
                    }
                }
                comando.ExecuteNonQuery();
            }
            catch(Exception )
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
