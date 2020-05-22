using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MojButton
{
    public class MyButton :Button
    {


        private bool isHidden = true;
        private bool hasMine;
        private bool hasFlag;
        private int brojOkolnihMina;
        private int koordinataI;
        private int koordinataJ;
        private bool visited = false;
        Image mina = (Image)MojButton.Properties.Resources.Mina;
       
        
        Image flag =(Image)MojButton.Properties.Resources.Flag;
        
        public int BrojOkolnihMina
        {
            get =>  brojOkolnihMina;
            set => brojOkolnihMina = value;
        }
        public bool IsHidden { get => isHidden; set => isHidden = value; }
        public bool HasMine { get => hasMine; set => hasMine = value; }
        public bool HasFlag { get => hasFlag; set => hasFlag = value; }
        public int KoordinataI { get => koordinataI; set => koordinataI = value; }
        public int KoordinataJ { get => koordinataJ; set => koordinataJ = value; }
        public bool Visited { get => visited; set => visited = value; }
        public void svimaDodeliVrednsti(int i, int j, bool visited,
           int brojOkolnihMina, bool hasFlag, bool hasMine, bool isHidden)
        {
            koordinataI = i;
            koordinataJ = j;
            this.visited = visited;
            this.brojOkolnihMina = brojOkolnihMina;
            this.hasFlag = hasFlag;
            this.hasMine = hasMine;
            this.isHidden = isHidden;
        }
        public void ShowImageFlag()
        {
            try
            {
                this.BackgroundImage = (Image)(new Bitmap(flag, new Size(this.Width, this.Height)));
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch(Exception e)
            {
                this.BackgroundImage = null;
            }
           
        }
        public void ShowImageMina()
        {
            try
            {

                this.BackgroundImage = (Image)(new Bitmap(mina, new Size(this.Width, this.Height)));
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception e)
            {
                this.BackgroundImage = null;
            }

        }
        public void RemoveImageMina()
        {
            this.BackgroundImage = null;
        }
         public void PostaviNoviBackGround()
        {
            if (!HasMine)
            {
                this.BackColor = Color.GhostWhite;
                    
            }
            else ShowImageMina();
        }
        public void ObojiBrojMina()
        {
            if (brojOkolnihMina == 0)
                return;
            this.Text = brojOkolnihMina.ToString();
            switch (brojOkolnihMina)
            {
               
                  
                case 1:
                    {
                        this.ForeColor = Color.Green;
                    }
                    break;
                case 2:
                    {
                        this.ForeColor = Color.Red;
                    }
                    break;
                case 3:
                    {
                        this.ForeColor = Color.Blue;
                    }
                    break;
                case 4:
                    {
                        this.ForeColor = Color.Brown;
                    }
                    break;
                case 5:
                    {
                        this.ForeColor = Color.Gray;
                    }
                    break;
                case 6:
                    {
                        this.ForeColor = Color.RoyalBlue;
                    }
                    break;
                case 7:
                    {
                        this.ForeColor = Color.Azure;
                    }
                    break;



            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyButton
            // 
            this.Text = "\r\n";
            this.ResumeLayout(false);

        }
    }
}
