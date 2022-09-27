using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador;

namespace Capa_Vista
{
    
    public partial class IngresoAlumno : Form
    {
        string table = "alumnos";
        Controlador cn = new Controlador();
        public IngresoAlumno()
        {
            InitializeComponent();
        }
        public void limpiar()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(comboBox1.Text);
            TextBox[] textbox = { textBox1, textBox2, textBox3, textBox4, textBox5,textBox6 };
            cn.ingresar(textbox, table);
            string message = "Registro Guardado";
            limpiar();
            MessageBox.Show(message);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = cn.llenarTbl(table);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] textbox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
            int valor1 = int.Parse(textBox1.Text);
            string campo = "carnet_alumno= ";
            cn.modificar(textbox, table, campo, valor1);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Deseas Eliminar el Registro?";
            string title = "Eliminar Registro";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            try
            {


                if (result == DialogResult.Yes)
                {

                    int campo = int.Parse(textBox7.Text);
                    string condicion = "carnet_alumno = ";
                    cn.eliminar(table, condicion, campo);
                    string message1 = "Registro eliminado ";
                    limpiar();
                    MessageBox.Show(message1);
                }
                else
                {
                    limpiar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puede eliminar por permisos asignados");
                Console.WriteLine(ex.Message.ToString() + " \nNo se puede eliminar por permisos asignados");
            }
        }
    }
}
