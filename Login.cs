﻿using System;
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
    public partial class Login : Form
    {
        static string conexionstring = "server= cinettickets.ddns.net ; user=sa; password=mandragora15 ; database=cinettickets ;integrated security=false";
        SqlConnection conexion = new SqlConnection(conexionstring);
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" & textBox2.Text!="")
            {
                try
                {
                    conexion.Open();
                }
                catch (Exception ex4)
                {
                    MessageBox.Show("No se pudo conectar con la base de datos");
                }
                try
                {                    
                    string Query = "select usucodigo, usuclave from cinettickets.dbo.web_usuarios where usucodigo='" + textBox1.Text + "' and usuclave='" + textBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(Query, conexion);
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    if (dr.Read())
                    {
                        this.Hide();
                        VentanaPrincipal v1 = new VentanaPrincipal();
                        v1.Show();
                        
                    }
                    else 
                    {
                        MessageBox.Show("Verificar Usuario y contraseña");
                    }

                    conexion.Close();
                }
                catch (Exception)
                {
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}