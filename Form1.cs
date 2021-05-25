using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4;

namespace NewGame
{
    public partial class Form1 : Form
    {
        Game game;
        Factory f;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            movewithkeyboard key = movewithkeyboard.getInstance();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(key.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(key.KeyUpEvent);
            game.update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = Game.getInstance();

            f = Factory.getInstance();

            GameObject G1 = f.createObjects(pictureBox1, movewithkeyboard.getInstance(), 2, gameType.player);
            GameObject G2 = f.createObjects(pictureBox2, new MoveLeft(), 2, gameType.ghost);
            GameObject G3 = f.createObjects(pictureBox3, new MoveRight(), 2, gameType.ghost);
            GameObject G4 = f.createObjects(pictureBox4, new Falling(), 3, gameType.ghost);


            int countplayer = f.getplayercount();
            label1.Text = "player : " + countplayer;
            int countenemy = f.getenemycount();
            label2.Text = "ghost : " + countenemy;


            game.AddObjects(G1);
            game.AddObjects(G2);
            game.AddObjects(G3);
            game.AddObjects(G4);

        }
    }
}
