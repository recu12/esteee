using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EquipoQ22.Domino;

//using System.Data;
//using System.Data.SqlClient;
//using EquipoQ22.Domino;

//3er paso:

namespace EquipoQ22.Datos
{
    class DBHelper : acceso
    {
        private static DBHelper instancia;
        public static DBHelper obtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new DBHelper();
            }
            return instancia;
        }
        public bool crearEquipo(Equipo equipo)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {

                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_INSERTAR_EQUIPO";
                comando.Parameters.AddWithValue("@pais", equipo.pais);
                comando.Parameters.AddWithValue("@director_tecnico", equipo.Director_tecnico);
                SqlParameter parametro = new SqlParameter("@id", SqlDbType.Int);
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);
                comando.ExecuteNonQuery();
                int idEquipo = (int)parametro.Value;
                foreach (Jugador detalle in equipo.detalleJugadores)
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_INSERTAR_DETALLES_EQUIPO";
                    comando.Parameters.AddWithValue("@id_equipo", idEquipo);
                    comando.Parameters.AddWithValue("@id_persona", detalle.Persona.IdPersona);
                    comando.Parameters.AddWithValue("@camiseta", detalle.Camiseta);
                    comando.Parameters.AddWithValue("@posicion", detalle.Posicion);
                    comando.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
                ok = false;

            }
            finally
            {
                desconectar();
            }
            return ok;
        }
        public DataTable listarPersonas()
        {
            comando.Parameters.Clear();
            conectar();
            comando.CommandText = "SP_CONSULTAR_PERSONAS";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
    }
}
