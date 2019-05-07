using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EjemploConexionBBDD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            button1.BackColor = Color.Transparent;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();

            MySqlCommand comando = new MySqlCommand("" + "SELECT * FROM usuarios WHERE" +
                " usuario = '" + textBox1.Text 
                + "' AND pass = '" + textBox2.Text + 
                "' ;", conexion);

            MySqlDataReader resultado = comando.ExecuteReader();

            if (resultado.Read())
            {
                PaginaPrincipal paginaPrincipal = new PaginaPrincipal();
                paginaPrincipal.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraeña incorrecto(s)", "ERROR");
            }
        }

        private void Enter (object sender, KeyEventArgs key)
        {
            if (key.KeyCode.Equals(Keys.Enter))
            {
                MySqlConnection conexion = new ConexionBBDD().conecta();

                MySqlCommand comando = new MySqlCommand("" + "SELECT * FROM usuarios WHERE" +
                    " usuario = '" + textBox1.Text
                    + "' AND pass = '" + textBox2.Text +
                    "' ;", conexion);

                MySqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    PaginaPrincipal paginaPrincipal = new PaginaPrincipal();
                    paginaPrincipal.Visible = true;

                }
                else
                {
                    MessageBox.Show("Usuario y/o contraeña incorrecto(s)", "ERROR");
                }
            }
        }
    }
}
