using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.IO;

namespace ControlPanel
{
    class Program
    {
        static void Main(string[] args)
        {
            if(File.Exists(@ConfigurationManager.AppSettings["ficheroInfo"]))
                File.Delete(@ConfigurationManager.AppSettings["ficheroInfo"]);

            StreamWriter sr = new StreamWriter(ConfigurationManager.AppSettings["ficheroInfo"],true);
            using (IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Avisos2012"].ToString()))
            {
                var listUsuarios = dbConnection.Query<string>("select * from dbo.OEC_UsuariosConectados(\'http://VM-OEC:8011/serverOEC/ServidorOEC\')").ToList();

                sr.WriteLine("{");    
                sr.WriteLine("\"oec\": {0}", listUsuarios.Count);
                sr.WriteLine("}");
                
                /*foreach (var usuario in listUsuarios)
                {
                    sr.WriteLine("{");
                    Console.WriteLine("user {0}",usuario);
                    sr.WriteLine("\"idUsuario\": {0}","\"" + usuario + "\"");
                    sr.WriteLine("}");

                }*/
                
            }

            sr.Flush();
            sr.Close();
        }
    }
}
