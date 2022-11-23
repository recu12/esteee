using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

//using System.Data;
//using System.Data.SqlClient;

//2do Paso

namespace EquipoQ22.Datos
{
    class acceso
    {
        protected SqlConnection conexion = new SqlConnection(Properties.Resources.conexionString);
        protected SqlCommand comando = new SqlCommand();
        protected void conectar()
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
        }
        protected void desconectar()
        {
            conexion.Close();
        }
    }
}
