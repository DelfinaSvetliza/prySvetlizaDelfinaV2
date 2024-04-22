using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql;


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

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
                   
            try
            {
                string cadenaconexion = "Server = localhost;" +
                    "Database = juegorol;" +
                    "Uid = root;" +
                    "Pwd = ;";
                MySqlConnection conn = new MySqlConnection(cadenaconexion);
                conn.Open();
                MessageBox.Show("Conectado BD");

            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}
