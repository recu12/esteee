using EquipoQ22.Domino;
using EquipoQ22.servicios;
using EquipoQ22.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using EquipoQ22.Domino;
//using EquipoQ22.servicios;
//using EquipoQ22.servicios.interfaces;
//using System.Data.SqlClient;
//using System.Net.Http;



//COMPLETAR --> Curso: 1w4     Legajo: 114243        Apellido y Nombre: calvo maximiliano

//CadenaDeConexion: "Data Source=sqlgabineteinformatico.frc.utn.edu.ar;Initial Catalog=Qatar2022;User ID=alumnoprog22;Password=SQL+Alu22"

namespace EquipoQ22
{
    public partial class FrmAlta : Form
    {
        private IServicio servicio;
        private Equipo nuevoEquipo;
        public FrmAlta()
        {
            InitializeComponent();
            servicio = new ImplementacionFactoryServicio().crearServicio();
            nuevoEquipo = new Equipo();
        }
        private void FrmAlta_Load(object sender, EventArgs e)
        {
            cargarCombo();
            LimpiarCampos();
        }

        private void cargarCombo()
        {
            DataTable tabla = servicio.listarPersonas();
            cboPersona.DataSource = tabla;
            cboPersona.DisplayMember = "nombre_completo";
            cboPersona.ValueMember = "id_persona";
            cboPersona.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["camiseta"].Value.ToString().Equals(nudCamiseta.Value))
                {
                    MessageBox.Show("Ese numero ya fue ingresado");
                    return;
                }
            }
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["jugador"].Value.Equals(cboPersona.Text)) 
                {
                    MessageBox.Show("ese jugador ya fue ingresado");
                    return;
                }
            }       
            if (cboPersona.SelectedIndex == -1)
            {
                MessageBox.Show("debe seleccionar una persona");
                return;
            }
            if (cboPosicion.SelectedIndex == -1)
            {
                MessageBox.Show("debe seleccionar una posicion");
                return;
            }
            DataRowView item = (DataRowView)cboPersona.SelectedItem;
            int id = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            string pos = cboPosicion.Text;
            int camis = Convert.ToInt32(nudCamiseta.Value);
            int clase = Convert.ToInt32(item.Row.ItemArray[2]);
            Persona p = new Persona(id, nom, clase);
            Jugador jugador = new Jugador(p,camis,pos);
            nuevoEquipo.agregarJugador(jugador);
            dgvDetalles.Rows.Add(new object[] {id,nom, camis, pos });
            totalJugadores();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDT.Text == string.Empty)
            {
                MessageBox.Show("debe ingresar un tecnico");
                return;
            }
            if (txtPais.Text == string.Empty)
            {
                MessageBox.Show("debe ingresar un pais");
                return;
            }
            if (dgvDetalles.Rows.Count < 1)
            {
                MessageBox.Show("debe ingresar al menenos un jugador");
                return;
            }
            nuevoEquipo.Director_tecnico = txtDT.Text;
            nuevoEquipo.pais = txtPais.Text;
            if (servicio.crearEquipo(nuevoEquipo))
            {
                MessageBox.Show("equipo guardado");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("no se pudo guardar");
            }
        }

        private void LimpiarCampos()
        {
            txtDT.Text = string.Empty;
            txtPais.Text = string.Empty;
            cboPersona.SelectedIndex = -1;
            cboPosicion.SelectedIndex = -1;
            lblTotal.Text = "Total Jugadores:";
            dgvDetalles.Rows.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (MessageBox.Show("desea eliminar este jugador?", "ELIMINAR", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                nuevoEquipo.quitarJugador(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                totalJugadores();
            }
        }

        private void totalJugadores()
        {
            lblTotal.Text = "Total Jugadores:" + dgvDetalles.Rows.Count;
        }
    }
}
