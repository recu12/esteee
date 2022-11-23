using EquipoQ22.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

//using System.Data;
//using using EquipoQ22.Domino;


//1er paso

namespace EquipoQ22.Datos
{
    public interface IEquipoDao
    {
        DataTable getListarPersonas();
        bool getCrearEquipo(Equipo equipo);
    }
}
