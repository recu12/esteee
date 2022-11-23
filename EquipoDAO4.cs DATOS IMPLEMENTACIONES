using EquipoQ22.Domino;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using EquipoQ22.Domino;
//using System.Data;


//4to paso:

namespace EquipoQ22.Datos.implementaciones
{
    class EquipoDAO : IEquipoDao
    {
        public bool getCrearEquipo(Equipo equipo)
        {
            return DBHelper.obtenerInstancia().crearEquipo(equipo);
        }

        public DataTable getListarPersonas()
        {
            return DBHelper.obtenerInstancia().listarPersonas();
        }
    }
}
