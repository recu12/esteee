using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Domino
{
    public class Equipo
    {
        public string pais { get; set; }
        public string Director_tecnico { get; set; }
        public List<Jugador> detalleJugadores { get; set; }
        public Equipo()
        {
            detalleJugadores = new List<Jugador>();
        }

        public void agregarJugador(Jugador jugador)
        {
            detalleJugadores.Add(jugador);
        }
        public void quitarJugador(int index)
        {
            detalleJugadores.RemoveAt(index);
        }
    }
}
