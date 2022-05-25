using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace APP_USUARIOS
{
    public partial class Consulta_Locales : Form
    {
        static string conexionstring = "server=190.210.227.194,33410 ; user=sa; password=Cinet1212 ; database=Mostaza_ERP ;integrated security=false";
        SqlConnection conexion = new SqlConnection(conexionstring);
        public Consulta_Locales()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((textBox4.Text.Replace("'", "")).Replace(";", "")).Replace("*", "") != "")
            {
                try
                {
                    conexion.Open();
                }
                catch (Exception ex3)
                {
                    MessageBox.Show("No se pudo conectar con la base de datos");
                }
                try
                {
                    string query = "  select * from all_locales1 where local_codigo like '%" + ((textBox4.Text.Replace("'", "")).Replace(";", "")).Replace("*", "") + "%' or local_nombre like '%" + ((textBox4.Text.Replace("'", "")).Replace(";", "")).Replace("*", "") + "%' or local_tipo like '%" + ((textBox4.Text.Replace("'", "")).Replace(";", "")).Replace("*", "") + "%' order by local_nombre asc";
           
                    SqlCommand comand = new SqlCommand(query, conexion);
                    SqlDataAdapter resultadoQuery = new SqlDataAdapter(comand);
                    DataTable tabla = new DataTable();
                    resultadoQuery.Fill(tabla);
                    dataGridView1.DataSource = tabla;
                    conexion.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Verificar local consultado");
                    conexion.Close();
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("Escribi algun local para consultar");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Consulta_Locales_Load(object sender, EventArgs e)
        {
            
        }

        private void Consulta_Locales_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }
        private void VentanaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

