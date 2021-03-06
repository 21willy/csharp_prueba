﻿using System;
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
    public partial class PaginaPrincipal : Form
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
            rellenaComboAutores();
        }

        //codigo para cerrar la ventana del login cuando se abre la segunda ventana
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

        private void rellenaComboAutores()
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();

            MySqlCommand comando =
                new MySqlCommand("SELECT * from actors order by first_name", conexion);

            MySqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                String id = resultado.GetString(0); //0 numero de columna de la bbdd
                String first_name = resultado.GetString("first_name");//recoge lo que hay entre comillas
                String last_name = resultado.GetString("last_name");
                String gender = resultado.GetString("gender");
                String film_count = resultado.GetString("film_count");

                desplegable.Items.Add(id + "--" + first_name + "--" + last_name);
            }

            conexion.Close();
        }
    }
}
