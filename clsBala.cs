using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace prySvetlizaDelfina
{
    internal class clsBala
    {       
        public PictureBox imgBala;

        public void Bala()
        {
            imgBala = new PictureBox();
            imgBala.Image = Properties.Resources.Bala_removebg_preview;
            imgBala.Size = new Size(5, 15);
            
        }
         public void DispararBala()
         {
            imgBala.Location = new Point(imgBala.Location.X, imgBala.Location.Y - 5);
         }

    }

   
}
