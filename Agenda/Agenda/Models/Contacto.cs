using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Agenda.Models
{
    public class Contacto
    {
        public static string cadenaConexion { get; set;}

        public string nombre { get; set; }
        public string email { get; set; }
        public string telCasa { get; set; }
        public string telCel { get; set; }
        public string nota { get; set; }

        public bool Guardar(){

            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "insert into Contactos values(?,?,?,?,?)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@nombre", this.nombre);
            comando.Parameters.AddWithValue("@email", this.email);
            comando.Parameters.AddWithValue("@telCasa", this.telCasa);
            comando.Parameters.AddWithValue("@telCel", this.telCel);
            comando.Parameters.AddWithValue("@nota", this.nota);

            int filas = comando.ExecuteNonQuery();
            conexion.Close();

            return (filas>0);
        }

        public List<Contacto> Consultar(){
            List<Contacto> contactos = new List<Contacto>();

            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "select * from Contactos";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Contacto c = new Contacto();
                c.nombre = lector["nombre"].ToString();
                c.email = lector["email"].ToString();
                c.telCasa = lector["telCasa"].ToString();
                c.telCel = lector["telCel"].ToString();
                c.nota = lector["nota"].ToString();
                contactos.Add(c);
            }

            lector.Close();

            conexion.Close();

            return contactos;
        }

        public bool Eliminar(){
            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "delete from Contactos where email = ?";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@email", this.email);
            int filas = comando.ExecuteNonQuery();
            conexion.Close();
            return (filas > 0);
        }

        public bool Buscar(){
            bool encontrado = false;
            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "select * from Contactos";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            MySqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                this.nombre = lector["nombre"].ToString();
                this.email = lector["email"].ToString();
                this.telCasa = lector["telCasa"].ToString();
                this.telCel = lector["telCel"].ToString();
                this.nota = lector["nota"].ToString();

            }

            lector.Close();

            conexion.Close();

            return encontrado;
        }


        public Contacto()
        {
        }

        public Contacto(string email){
            this.email = email;
        }
    }
}
