using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Data
{
    public class Conexion
    {
        public static String rutaConexion = "Data Source=192.168.43.42; uid=SA; PWD=qwerty.123000; initial catalog=BDBANCO";
        public String getConexion()
        {
            return rutaConexion;
        }
    }
}