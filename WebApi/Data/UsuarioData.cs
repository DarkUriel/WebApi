using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class UsuarioData
    {
        public static bool Registrar(Usuario oUsuario)
        {
            Conexion con = new Conexion();
            SqlConnection oConexion = new SqlConnection(con.getConexion());
            string sentencia = "INSERT INTO Usuario(FechaCreacion,Login,Clave,Estado) values ('" + oUsuario.FechaCreacion + "', '" + oUsuario.Login + "', '" + oUsuario.Clave + "', '" + oUsuario.Estado + "')";
            SqlCommand cmd = new SqlCommand();

            try
            {
                oConexion.Open();
                cmd = new SqlCommand(sentencia, oConexion);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Modificar(Usuario oUsuario)
        {
            Conexion con = new Conexion();
            SqlConnection oConexion = new SqlConnection(con.getConexion());
            string sentencia = "UPDATE Usuario SET FechaCreacion = '" + oUsuario.FechaCreacion + "', Login = '" + oUsuario.Login + "', Clave = '" + oUsuario.Clave + "', Estado = '" + oUsuario.Estado + "' WHERE IdUsuario = " + oUsuario.IdUsuario;
            SqlCommand cmd = new SqlCommand();

            try
            {
                oConexion.Open();
                cmd = new SqlCommand(sentencia, oConexion);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static List<Usuario> Listar()
        {
            List<Usuario> oListarUsuario = new List<Usuario>();
            Conexion con = new Conexion();
            SqlConnection oConexion = new SqlConnection(con.getConexion());
            string sentencia = "SELECT * FROM Usuario";
            SqlCommand cmd = new SqlCommand();
            try
            {
                oConexion.Open();
                cmd = new SqlCommand(sentencia, oConexion);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListarUsuario.Add(new Usuario() { 
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            FechaCreacion = dr["FechaCreacion"].ToString(),
                            Login = dr["Login"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            Estado = dr["Estado"].ToString()
                        });
                    }
                }
                return oListarUsuario;
            }
            catch(Exception ex)
            {
                return oListarUsuario;
            }
        }
        public static Usuario Obtener(int idusuario)
        {
            Usuario oUsuario = new Usuario();
            Conexion con = new Conexion();
            SqlConnection oConexion = new SqlConnection(con.getConexion());
            string sentencia = "SELECT * FROM Usuario WHERE IdUsuario = " + idusuario;
            SqlCommand cmd = new SqlCommand();
            try
            {
                oConexion.Open();
                cmd = new SqlCommand(sentencia, oConexion);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUsuario = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            FechaCreacion = dr["FechaCreacion"].ToString(),
                            Login = dr["Login"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            Estado = dr["Estado"].ToString()
                        };
                    }
                }
                return oUsuario;
            }
            catch(Exception ex)
            {
                return oUsuario;
            }
        }
        public static bool Eliminar(int id)
        {
            Usuario oUsuario = new Usuario();
            Conexion con = new Conexion();
            SqlConnection oConexion = new SqlConnection(con.getConexion());
            string sentencia = "DELETE FROM Usuario WHERE IdUsuario = " + id;
            SqlCommand cmd = new SqlCommand();
            try
            {
                oConexion.Open();
                cmd = new SqlCommand(sentencia, oConexion);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}