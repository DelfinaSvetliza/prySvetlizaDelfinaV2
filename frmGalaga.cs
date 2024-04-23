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
    public partial class frmGalaga : Form
    {
        private clsNave objNaveJugador;
        private List<clsBala> balas = new List<clsBala>();
        private Timer timer = new Timer();
        private List<clsNave> enemigos = new List<clsNave>();
        public frmGalaga()
        {
            InitializeComponent();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        private void frmGalaga_Load(object sender, EventArgs e)
        {
            objNaveJugador = new clsNave();
            objNaveJugador.crearJugador();
            objNaveJugador.imgNave.Location = new Point(175, 360);
            Controls.Add(objNaveJugador.imgNave);
            MessageBox.Show(objNaveJugador.nombre);

        }

        private void frmGalaga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                objNaveJugador.imgNave.Location = new Point(objNaveJugador.imgNave.Location.X + 5, objNaveJugador.imgNave.Location.Y);

            }

            if (e.KeyCode == Keys.Left)
            {
                objNaveJugador.imgNave.Location = new Point(objNaveJugador.imgNave.Location.X - 5, objNaveJugador.imgNave.Location.Y);

            }

            if (e.KeyCode == Keys.Space)
            {
                clsBala bala = new clsBala();
                bala.imgBala = new PictureBox();
                bala.imgBala.Image = Properties.Resources.Bala_removebg_preview;
                bala.imgBala.SizeMode = PictureBoxSizeMode.StretchImage;
                bala.imgBala.Size = new Size(5, 15);
                bala.imgBala.Visible = true;
                //calcula la posicion x de la bala
                int balaX = objNaveJugador.imgNave.Location.X + objNaveJugador.imgNave.Width / 2 - bala.imgBala.Width / 2;
                // la posicion y de la bala es la misma que la de la nave
                int balaY = objNaveJugador.imgNave.Location.Y;
                // establece la ubicacion de la bala
                bala.imgBala.Location = new Point(balaX, balaY);
                //agrega la bala al formulario
                Controls.Add(bala.imgBala);
                balas.Add(bala);

            }

        }
        Random rnd = new Random();
        private void Timer_Tick(object sender, EventArgs e)
        {
           

            foreach (var bala in balas)
            {
                bala.imgBala.Location = new Point(bala.imgBala.Location.X, bala.imgBala.Location.Y - 5);
            }

            int coordX;

            if (new Random().Next(0, 100) < 2) // Probabilidad de generar un enemigo
            {
                clsNave nuevoEnemigo = new clsNave();
                nuevoEnemigo.imgEnemigo = new PictureBox();
                nuevoEnemigo.imgEnemigo.Image = Properties.Resources.enemigos;
                nuevoEnemigo.imgEnemigo.SizeMode = PictureBoxSizeMode.StretchImage;
                nuevoEnemigo.imgEnemigo.Size = new Size(30, 30);
                // Generar un número aleatorio entre 0 y el ancho del formulario menos el ancho del enemigo
                coordX = rnd.Next(0, this.Width - nuevoEnemigo.imgEnemigo.Width);
                // Usar la coordenada x generada aleatoriamente
                nuevoEnemigo.imgEnemigo.Location = new Point(coordX, 0); // Coordenada y fija en la parte superior
                enemigos.Add(nuevoEnemigo); // Agregar el enemigo a la lista de enemigos
                Controls.Add(nuevoEnemigo.imgEnemigo); // Agregar el enemigo al formulario
            }

            // Mover los enemigos hacia abajo
            foreach (var enemigo in enemigos)
            {
                enemigo.imgEnemigo.Location = new Point(enemigo.imgEnemigo.Location.X, enemigo.imgEnemigo.Location.Y + 5); // Mover hacia abajo (ajusta según tus necesidades)
            }


            foreach (var bala in balas.ToList()) // Utilizamos ToList() para evitar errores de modificación durante la iteración
            {
                bala.imgBala.Location = new Point(bala.imgBala.Location.X, bala.imgBala.Location.Y - 5); // Mover la bala hacia arriba

                foreach (var enemigo in enemigos.ToList()) // Utilizamos ToList() para evitar errores de modificación durante la iteración
                {
                    if (bala.imgBala.Bounds.IntersectsWith(enemigo.imgEnemigo.Bounds))
                    {
                        // Eliminar la bala y el enemigo
                        Controls.Remove(bala.imgBala);
                        bala.imgBala.Dispose();
                        Controls.Remove(enemigo.imgEnemigo);
                        balas.Remove(bala);
                        enemigos.Remove(enemigo);
                        enemigo.imgEnemigo.Dispose();
                        break; // Salir del bucle de enemigos después de eliminar uno
                    }
                }
            }

            // Verificar colisión entre la nave del jugador y los enemigos
            foreach (var enemigo in enemigos.ToList())
            {
                if (objNaveJugador.imgNave.Bounds.IntersectsWith(enemigo.imgEnemigo.Bounds))
                {
                    // Eliminar todos los enemigos restantes
                    foreach (var enemy in enemigos)
                    {
                        Controls.Remove(enemy.imgEnemigo);
                        enemy.imgEnemigo.Dispose();
                    }
                    enemigos.Clear();

                    MessageBox.Show("Game Over");
                    timer.Stop();
                    break; // Salir del bucle después de detectar una colisión
                }
            }

        }   
    }        
}
