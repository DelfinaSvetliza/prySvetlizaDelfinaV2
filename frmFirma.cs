using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySvetlizaDelfina
{
    public partial class frmFirma : Form
    {
        private Point previousPoint;
        private bool isMouseDrawing = false;
        private Bitmap signatureBitmap;
        private string fondo;
        public frmFirma()
        {
            InitializeComponent();
            InitializeSignaturePictureBox();
            pctFirma.MouseDown += new MouseEventHandler(pctFirma_MouseDown);
            pctFirma.MouseMove += new MouseEventHandler(pctFirma_MouseMove);
            pctFirma.MouseUp += new MouseEventHandler(pctFirma_MouseUp);
        }
        private void InitializeSignaturePictureBox()
        {
            signatureBitmap = new Bitmap(pctFirma.Width, pctFirma.Height);
            pctFirma.Image = signatureBitmap;
            Graphics g = Graphics.FromImage(pctFirma.Image);
            g.Clear(Color.White);
            g.Dispose();
        }
        private void frmFirma_Load(object sender, EventArgs e)
        {

        }
        private void pctFirma_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDrawing = true;
                previousPoint = e.Location;
            }
        }

        private void pctFirma_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pctFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDrawing)
            {
                using (Graphics g = Graphics.FromImage(pctFirma.Image))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(Color.Black, 2))
                    {
                        g.DrawLine(pen, previousPoint, e.Location);
                    }
                }
                previousPoint = e.Location;
                pctFirma.Invalidate();
            }

        }

        private void pctFirma_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDrawing = false;
        }

        private void pctFirma_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener la fecha actual
            string fecha = DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + ".png";


            // Construir la ruta del archivo
            string carpeta = "FIRMA";
            string nombreArchivo = $"dibujo_{fecha}.png";
            string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

            // Crear la carpeta si no existe
            Directory.CreateDirectory(carpeta);

            // Crear un bitmap del mismo tamaño que el PictureBox
            Bitmap bmp = new Bitmap(pctFirma.Width, pctFirma.Height);

            // Dibujar el contenido del PictureBox en el bitmap
            pctFirma.DrawToBitmap(bmp, pctFirma.ClientRectangle);

            // Guardar el bitmap en un archivo
            bmp.Save(rutaCompleta);

            // Liberar recursos
            bmp.Dispose();

            MessageBox.Show("Firma guardada correctamente.");
        }
    }
    
}
