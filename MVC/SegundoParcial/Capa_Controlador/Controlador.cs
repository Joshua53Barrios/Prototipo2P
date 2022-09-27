using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo;
using System.Windows.Forms;

namespace Capa_Controlador
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();


        public DataTable llenarTbl(string tabla)
        {
            OdbcDataAdapter dt = sn.llenarTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        public void ingresar(TextBox[] textbox, string tabla)
        {
            string dato = " ";
            string tipo = " ";

            for (int x = 0; x < textbox.Length; x++)
            {

                if (x == textbox.Length - 1)
                {
                    dato += "'" + textbox[x].Text + "'";
                    tipo += textbox[x].Tag.ToString();
                }
                else
                {
                    dato += "'" + textbox[x].Text + "',";
                    tipo += textbox[x].Tag.ToString() + ",";
                }

            }
            sn.insertar(dato, tipo, tabla);
        }
        public void moverseIF(DataGridView tabla, string mover)//Metodo para moverse al inicio, final, siguiente, anterior
        {
            try
            {
                int fin = (tabla.Rows.Count - 2); ;
                int posicion;

                if (mover.Equals("i"))
                {
                    posicion = 0;
                    tabla.CurrentCell = tabla.Rows[posicion].Cells[tabla.CurrentCell.ColumnIndex];

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }



        }
        public void modificar(TextBox[] textbox, string tabla, string campo, int num)
        {
            string dato = " ";
            string condicion = campo;

            for (int x = 1; x < textbox.Length; x++)
            {

                if (x == textbox.Length - 1)
                {
                    dato += " " + textbox[x].Tag.ToString() + " = '" + textbox[x].Text + "' ";

                }
                else if (x == 1)
                {
                    dato += "SET " + textbox[x].Tag.ToString() + " = '" + textbox[x].Text + "', ";

                }
                else
                {
                    dato += " " + textbox[x].Tag.ToString() + " = '" + textbox[x].Text + "', ";

                }

            }
            sn.actualizar(tabla, condicion, dato, num);
            MessageBox.Show("Dato actualizado");

        }
        public void eliminar(string tabla, string condicion, int campo)
        {
            try
            {
                sn.eliminar(tabla, condicion, campo);
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede eliminar por permisos asignados");
                Console.WriteLine(ex.Message.ToString() + " \nNo se puede eliminar por permisos asignados");
            }


        }
    }
}