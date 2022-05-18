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
    public partial class VentanaPrincipal : Form
    {
        static string conexionstring = "server=cinettickets.ddns.net ; user=sa; password=mandragora15 ; database=cinettickets ;integrated security=false";
        SqlConnection conexion = new SqlConnection(conexionstring);
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (((textBox1.Text.Replace("'", "")).Replace(";", "")).Replace("*","")!= "")
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
                    string query = "select rtrim(ltrim(usuCodigo)) as Usuario, rtrim(ltrim(usuMail)) as Mail from cinettickets.dbo.web_usuarios where usucodigo like '%"+ ((textBox1.Text.Replace("'", "")).Replace(";", "")).Replace("*", "") + "%' and usupermisos<1 order by usucodigo asc";
                    SqlCommand comand = new SqlCommand(query,conexion);
                    SqlDataAdapter resultadoQuery = new SqlDataAdapter(comand);
                    DataTable tabla = new DataTable();
                    resultadoQuery.Fill(tabla);
                    dataGridView1.DataSource = tabla;
                    conexion.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Por favor verifica el usuario a consultar");
                    conexion.Close();
                }



            }
            else
            {
                MessageBox.Show("Escribi el usuario a modificar");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string valorUsuario = dataGridView1.CurrentCell.Value.ToString(); 

                if (valorUsuario != "")
                {
                    usuarioseleccionado.Text = valorUsuario;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar un usuario");
            }


        }


        public void button3_Click(object sender, EventArgs e)
        {
            if(usuarioseleccionado.Text!="")
            {
                try
                {
                    conexion.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo conectar con la base de datos.");
                }
                try
                {
                    int flag = 0;
                    string query = "Update web_usuarios set usuclave='"+usuarioseleccionado.Text + "' where usucodigo='" + usuarioseleccionado.Text + "'";
                    SqlCommand comando = new SqlCommand(query,conexion);
                    flag = comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El usuario se ha blanqueado correctamente");
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Hubo un error, por favor volve a intentarlo");
                    conexion.Close();
                }                
            }
            else
            {
                MessageBox.Show("No hay ningun usuario seleccionado.");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VentanaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
