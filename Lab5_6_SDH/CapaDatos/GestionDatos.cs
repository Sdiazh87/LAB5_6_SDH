using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Entidades;
using System.Data;

namespace CapaDatos
{
    public class GestionDatos
    {

        SqlConnection conexion;
        SqlCommand comando;
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBase"].ConnectionString;

        #region "CRUD"

        public DataTable cargaAuto()
        {
            DataTable objTabla = new DataTable();
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM AUTOMOVIL";
            comando.Connection = conexion;
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando);
            sqlAdaptador.Fill(objTabla);
            return objTabla;
        }

        public int registrarAuto(Autos objAuto)
        {
            int cantidadRegistros = -1;
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO AUTOMOVIL (Marca, Modelo, Pais, Costo) " +
                                "VALUES (@Marca, @Modelo, @Pais, @Costo)";
                cmd.Parameters.Add(new SqlParameter("@Marca", objAuto.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objAuto.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objAuto.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objAuto.Costo));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public int eliminarAuto(Autos objAuto)
        {
            int cantidadRegistros = -1;
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM AUTOMOVIL WHERE Id_Carro = @Id_Carro";
                cmd.Parameters.Add(new SqlParameter("@Id_Carro", objAuto.Id_Carro));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); //Aqui estamos realizando el Insert en base de datos.
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public int actualizarAuto(Autos objAuto)
        {
            int cantidadRegistros = -1;

            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cnd = new SqlCommand();
                cnd.Connection = sqlCon;
                cnd.CommandType = CommandType.Text;
                cnd.CommandText = "UPDATE AUTOMOVIL " +
                                  "SET Marca  = @Marca, " +
                                  "    Modelo = @Modelo, " +
                                  "    Pais   = @Pais, " +
                                  "    Costo  = @Costo " +
                                  "WHERE Id_Carro = @Id_Carro ";
                cnd.Parameters.Add(new SqlParameter("@Marca", objAuto.Marca));
                cnd.Parameters.Add(new SqlParameter("@Modelo", objAuto.Modelo));
                cnd.Parameters.Add(new SqlParameter("@Pais", objAuto.Pais));
                cnd.Parameters.Add(new SqlParameter("@Costo", objAuto.Costo));
                cnd.Parameters.Add(new SqlParameter("@Id_Carro", objAuto.Id_Carro));
                sqlCon.Open();
                cantidadRegistros = cnd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        #endregion

    }
}
