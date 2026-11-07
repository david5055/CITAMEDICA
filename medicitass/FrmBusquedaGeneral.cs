using medicitass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MediCitas
{
    public partial class FrmBusquedaGeneral : Form
    {
        public FrmBusquedaGeneral()
        {
            InitializeComponent();
        }

        private void FrmBusquedaGeneral_Load(object sender, EventArgs e)
        {
            ActualizarEtiquetaFiltro();
            CargarTodosDatos();
        }

        private void rbTipo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEtiquetaFiltro();
            CargarTodosDatos();
        }

        private void ActualizarEtiquetaFiltro()
        {
            if (rbPacientes.Checked)
            {
                lblFiltro.Text = "Nombre, Apellido o DUI:";
            }
            else
            {
                lblFiltro.Text = "Nombre, Apellido o No. Junta:";
            }
            txtFiltro.Clear();
        }

        private void CargarTodosDatos()
        {
            try
            {
                using (SqlConnection conexion = new Conexion().Conectar())
                {
                    string query = "";
                    if (rbPacientes.Checked)
                    {
                        query = "SELECT id_paciente AS ID, nombres AS Nombres, apellidos AS Apellidos, dui AS DUI, telefono AS Teléfono, correo AS Correo, estado AS Estado FROM Pacientes";
                    }
                    else
                    {
                        query = @"SELECT d.id_doctor AS ID, d.nombres AS Nombres, d.apellidos AS Apellidos, e.nombre AS Especialidad, 
                                  d.numero_junta_vigilancia AS [No. Junta], d.telefono AS Teléfono, d.correo AS Correo, d.estado AS Estado 
                                  FROM Doctores d INNER JOIN Especialidades e ON d.id_especialidad = e.id_especialidad";
                    }

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvResultados.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();

            try
            {
                using (SqlConnection conexion = new Conexion().Conectar())
                {
                    string query = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conexion;

                    if (rbPacientes.Checked)
                    {
                        query = @"SELECT id_paciente AS ID, nombres AS Nombres, apellidos AS Apellidos, dui AS DUI, telefono AS Teléfono, correo AS Correo, estado AS Estado 
                                  FROM Pacientes 
                                  WHERE nombres LIKE @filtro OR apellidos LIKE @filtro OR dui LIKE @filtro";
                    }
                    else
                    {
                        query = @"SELECT d.id_doctor AS ID, d.nombres AS Nombres, d.apellidos AS Apellidos, e.nombre AS Especialidad, 
                                  d.numero_junta_vigilancia AS [No. Junta], d.telefono AS Teléfono, d.correo AS Correo, d.estado AS Estado 
                                  FROM Doctores d INNER JOIN Especialidades e ON d.id_especialidad = e.id_especialidad 
                                  WHERE d.nombres LIKE @filtro OR d.apellidos LIKE @filtro OR d.numero_junta_vigilancia LIKE @filtro";
                    }

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvResultados.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}