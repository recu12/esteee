using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EquipoQ22.Domino;

//using System.Data;
//using EquipoQ22.Domino;

//5to paso:

namespace EquipoQ22.servicios.interfaces
{
    interface IServicio
    {
        bool crearEquipo(Equipo equipo);
        DataTable listarPersonas();
    }
}
