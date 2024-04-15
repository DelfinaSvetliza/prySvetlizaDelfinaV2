using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySvetlizaDelfina
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void firmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFirma firma = new frmFirma();
            firma.ShowDialog();
        }

        private void galagaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGalaga galaga = new frmGalaga();
            galaga.ShowDialog();
        }
    }
}
