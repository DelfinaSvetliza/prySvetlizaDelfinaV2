using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySvetlizaDelfina
{
    internal class clsNave
    {
        public int vida;
        public string nombre;
        public int puntosDanos;
        public PictureBox imgNave;

        public void crearJugador()
        {
            vida = 100;
            nombre = "jugador1";
            puntosDanos = 1;
            imgNave = new PictureBox();
            imgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            imgNave.ImageLocation = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVYM4r6c8hGJnGnJ1lDYY6R8gJmhxk6LJBz5SlmFRcsA&s";

        }

        public void crearEnemigo()
        {
            vida = 25;
            nombre = "enemigo";
            puntosDanos = 2;
        }

    }
}
