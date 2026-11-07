using medicitass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MediCitas
{
    public partial class FrmConsultaDisponibilidad : Form
    {
        public FrmConsultaDisponibilidad()
        {
            InitializeComponent();
        }

        private void FrmConsultaDisponibilidad_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
            dtpFecha.Value = DateTime.Today;
        }

        private void CargarEspecialidades()
        {
            try
            {
                using (SqlConnection conexion = new Conexion().Conectar())
                {
                    string query = "SELECT id_especialidad, nombre FROM Especialidades WHERE estado = 'Activo'";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbEspecialidad.DataSource = dt;
                    cmbEspecialidad.DisplayMember = "nombre";
                    cmbEspecialidad.ValueMember = "id_especialidad";

                    if (cmbEspecialidad.Items.Count > 0)
                    {
                        cmbEspecialidad.SelectedIndex = 0;
                        CargarDoctores((int)cmbEspecialidad.SelectedValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDoctores(int idEspecialidad)
        {
            try
            {
                using (SqlConnection conexion = new Conexion().Conectar())
                {
                    string query = "SELECT id_doctor, (nombres + ' ' + apellidos) AS nombre_completo FROM Doctores WHERE id_especialidad = @id_especialidad AND estado = 'Activo'";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id_especialidad", idEspecialidad);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDoctor.DataSource = dt;
                    cmbDoctor.DisplayMember = "nombre_completo";
                    cmbDoctor.ValueMember = "id_doctor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar doctores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecialidad.SelectedValue is int idEspecialidad)
            {
                CargarDoctores(idEspecialidad);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un doctor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDoctor = Convert.ToInt32(cmbDoctor.SelectedValue);
            DateTime fechaSeleccionada = dtpFecha.Value.Date;

            ConsultarBloquesDisponibles(idDoctor, fechaSeleccionada);
        }

        private void ConsultarBloquesDisponibles(int idDoctor, DateTime fecha)
        {
            DataTable dtResultado = new DataTable();
            dtResultado.Columns.Add("Hora Inicio", typeof(string));
            dtResultado.Columns.Add("Hora Fin", typeof(string));
            dtResultado.Columns.Add("Estado", typeof(string));

            try
            {
                using (SqlConnection conexion = new Conexion().Conectar())
                {
                    // 1. Obtener la franja horaria del doctor para ese día de la semana según la base de datos
                    // El día de la semana en la BD se evalúa como texto ('Lunes', 'Martes', etc.)
                    string diaSemana = ObtenerNombreDiaEsp(fecha.DayOfWeek);

                    string queryHorario = "SELECT hora_inicio, hora_fin FROM Horarios_Doctor WHERE id_doctor = @id_doctor AND dia_semana = @dia_semana AND estado = 'Activo'";
                    SqlCommand cmdHorario = new SqlCommand(queryHorario, conexion);
                    cmdHorario.Parameters.AddWithValue("@id_doctor", idDoctor);
                    cmdHorario.Parameters.AddWithValue("@dia_semana", diaSemana);

                    SqlDataAdapter da = new SqlDataAdapter(cmdHorario);
                    DataTable dtHorarios = new DataTable();
                    da.Fill(dtHorarios);

                    if (dtHorarios.Rows.Count == 0)
                    {
                        MessageBox.Show("El doctor no tiene un horario activo configurado para el día " + diaSemana + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvHorarios.DataSource = null;
                        return;
                    }

                    // Tomamos la primera franja configurada para el día
                    TimeSpan horaInicio = (TimeSpan)dtHorarios.Rows[0]["hora_inicio"];
                    TimeSpan horaFin = (TimeSpan)dtHorarios.Rows[0]["hora_fin"];

                    // 2. Generar bloques de 30 minutos y consultar la función dbo.fn_HorarioDisponible
                    TimeSpan intervalo = TimeSpan.FromMinutes(30);
                    TimeSpan horaActualBloque = horaInicio;

                    while (horaActualBloque.Add(intervalo) <= horaFin)
                    {
                        TimeSpan horaSiguiente = horaActualBloque.Add(intervalo);

                        // Consultar la función escalable fn_HorarioDisponible
                        string queryFunc = "SELECT dbo.fn_HorarioDisponible(@id_doctor, @fecha, @hora_inicio)";
                        SqlCommand cmdFunc = new SqlCommand(queryFunc, conexion);
                        cmdFunc.Parameters.AddWithValue("@id_doctor", idDoctor);
                        cmdFunc.Parameters.AddWithValue("@fecha", fecha);
                        cmdFunc.Parameters.Add("@hora_inicio", SqlDbType.Time).Value = horaActualBloque;

                        object result = cmdFunc.ExecuteScalar();
                        bool disponible = (result != null && result != DBNull.Value && Convert.ToBoolean(result));

                        dtResultado.Rows.Add(
                            horaActualBloque.ToString(@"hh\:mm"),
                            horaSiguiente.ToString(@"hh\:mm"),
                            disponible ? "Disponible" : "Ocupado / Fuera de horario"
                        );

                        horaActualBloque = horaSiguiente;
                    }

                    dgvHorarios.DataSource = dtResultado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar disponibilidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerNombreDiaEsp(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return "Lunes";
                case DayOfWeek.Tuesday: return "Martes";
                case DayOfWeek.Wednesday: return "Miercoles";
                case DayOfWeek.Thursday: return "Jueves";
                case DayOfWeek.Friday: return "Viernes";
                case DayOfWeek.Saturday: return "Sabado";
                case DayOfWeek.Sunday: return "Domingo";
                default: return "";
            }
        }
    }
}