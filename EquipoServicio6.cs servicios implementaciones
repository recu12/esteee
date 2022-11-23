using EquipoQ22.Datos;
using EquipoQ22.Datos.implementaciones;
using EquipoQ22.Domino;
using EquipoQ22.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using EquipoQ22.Datos;
//using EquipoQ22.Datos.implementaciones;
//using EquipoQ22.Domino;
//using EquipoQ22.servicios.interfaces;
//using System.Data;


//6to paso:


namespace EquipoQ22.servicios.implementaciones
{
    class EquipoServicio : IServicio
    {
        private IEquipoDao DAO;
        public EquipoServicio()
        {
            DAO = new EquipoDAO();
        }
        public bool crearEquipo(Equipo equipo)
        {
            return DAO.getCrearEquipo(equipo);
        }

        public DataTable listarPersonas()
        {
            return DAO.getListarPersonas();
        }
    }
}
