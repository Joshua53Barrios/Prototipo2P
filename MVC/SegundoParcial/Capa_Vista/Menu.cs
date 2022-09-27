using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void cRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoAlumno alum = new IngresoAlumno();
            alum.MdiParent = this;
            alum.Show();
        }
    }
}
