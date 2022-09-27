using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
namespace CapaModelo
{
    class Sentencias
    {
        Conexion con = new Conexion();
        public OdbcDataAdapter llenartabla(string tabla)
        {
            string sql = "select * from " + tabla + ";";
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());
            return datatable;
        }
    }
}
